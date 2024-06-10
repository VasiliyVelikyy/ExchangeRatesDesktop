using ExchangeRates.Model;
using System;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ExchangeRates.Helper;
using System.Windows;
using System.Data;
using ExchangeRates.View;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Drawing;
using System.Linq;

namespace ExchangeRates.ViewModel
{
    public class ExchangeViewModel : INotifyPropertyChanged
    {
        readonly string path = @"C:\Users\Vasiliy\source\repos\ExchangeRates\ExchangeRates\DataModels\SaveData.json";
        string _jsonPersons = String.Empty;
        public string Error { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// выбранная в списке должность
        /// </summary>
        private Exchange selectedExchange;
        public Exchange SelectedExchange
        {
            get
            {
                return selectedExchange;
            }
            set
            {
                selectedExchange = value;
                OnPropertyChanged("SelectedExchange");
                //  EditRole.CanExecute(true);
            }
        }

        /// <summary>
        /// коллекция должностей сотрудников
        /// </summary>
        public ObservableCollection<Exchange> ListExchange { get; set; } = new
       ObservableCollection<Exchange>();
        public ExchangeViewModel()
        {
            this.ListExchange.Add(new Exchange
            {
                Id = 1,
                DateTime = new DateTime(1980, 02, 28),
                RateName = "USD",
                RateValue = 12.2f
            });
            this.ListExchange.Add(new Exchange
            {
                Id = 2,
                DateTime = new DateTime(1983, 05, 10),
                RateName = "EUR",
                RateValue = 14.2f
            });
            this.ListExchange.Add(new Exchange
            {
                Id = 3,
                DateTime = new DateTime(1982, 04, 15),
                RateName = "CNY",
                RateValue = 6f

            });
            this.ListExchange.Add(new Exchange
            {
                Id = 4,
                DateTime = new DateTime(2024, 04, 15),
                RateName = "USD",
                RateValue = 100.1f

            });

            this.ListExchange.Add(new Exchange
            {
                Id = 5,
                DateTime = new DateTime(2022, 11, 15),
                RateName = "USD",
                RateValue = 50.1f

            });

            this.ListExchange.Add(new Exchange
            {
                Id = 6,
                DateTime = new DateTime(2022, 04, 15),
                RateName = "CNY",
                RateValue = 12f

            });

            this.ListExchange.Add(new Exchange
            {
                Id = 7,
                DateTime = new DateTime(2023, 04, 15),
                RateName = "CNY",
                RateValue = 15f

            });

            this.ListExchange.Add(new Exchange
            {
                Id = 8,
                DateTime = new DateTime(2000, 05, 10),
                RateName = "EUR",
                RateValue = 24.2f
            });

            this.ListExchange.Add(new Exchange
            {
                Id = 9,
                DateTime = new DateTime(2021, 03, 10),
                RateName = "EUR",
                RateValue = 80.2f
            });

        }

        private void SaveChanges(ObservableCollection<Exchange> listExchanges)
        {
            var jsonExchange = JsonConvert.SerializeObject(listExchanges);
            try
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.Write(jsonExchange);
                }
            }
            catch (IOException e)
            {
                Error = "Ошибка записи json файла /n" + e.Message;
            }
        }


        #region AddExchange
        /// <summary>
        /// добавление сотрудника
        /// </summary>
        private RelayCommand addExchange;
        /// <summary>
        /// добавление сотрудника
        /// </summary>
        public RelayCommand AddExchange
        {
            get
            {
                return addExchange ??
                (addExchange = new RelayCommand(obj =>
                {
                    WindowNewExchange wnExchange = new WindowNewExchange
                    {
                        Title = "Новые данные по курсу"
                    };
                    // формирование кода нового курса
                    int maxIdExchgange = MaxId() + 1;
                    Exchange exchange = new Exchange
                    {
                        Id = maxIdExchgange,
                        DateTime = DateTime.Now
                    };
                    wnExchange.DataContext = exchange;

                    wnExchange.CbRates.ItemsSource = new RatesViewModel().ListRates;
                    if (wnExchange.ShowDialog() == true)
                    {
                        // добавление нового курса в коллекцию  ListExchange<Exchange> 
                        Rate r = (Rate)wnExchange.CbRates.SelectedValue;
                        exchange.RateName = r.Code;
                        ListExchange.Add(exchange);

                    }
                    SelectedExchange = exchange;
                },
 (obj) => true));
            }
        }
        #endregion

        #region EditExchange
        /// команда редактирования данных по сотруднику
        private RelayCommand editExchange;
        public RelayCommand EditExchange
        {
            get
            {
                return editExchange ??
                (editExchange = new RelayCommand(obj =>
                {
                    WindowNewExchange wnExchange = new WindowNewExchange()
                    {
                        Title = "Редактирование данных по курсу",
                    };
                    Exchange exchange = SelectedExchange;
                    Exchange tempexchange = new Exchange();
                    tempexchange = exchange.ShallowCopy();
                    wnExchange.DataContext = tempexchange;

                    wnExchange.CbRates.ItemsSource = new RatesViewModel().ListRates;

                    if (wnExchange.ShowDialog() == true)
                    {
                        ListExchange.Remove(SelectedExchange);
                        // сохранение данных в оперативной памяти
                        // перенос данных из временного класса в класс отображения 
                        // данных 
                        Rate r = (Rate)wnExchange.CbRates.SelectedValue;
                        exchange.RateName= r.Code;
                        exchange.RateValue = tempexchange.RateValue;
                        exchange.DateTime = tempexchange.DateTime;
                        ListExchange.Add(exchange);

                    }
                }, (obj) => SelectedExchange != null && ListExchange.Count > 0));
            }
        }

        #endregion

        #region DeleteExchange
        /// команда удаления данных по сотруднику
        private RelayCommand deleteExchange;
        public RelayCommand DeleteExchange
        {
            get
            {
                return deleteExchange ??
                (deleteExchange = new RelayCommand(obj =>
                {
                    Exchange selecEx = SelectedExchange;
                    MessageBoxResult result = MessageBox.Show("Удалить данные по выбранному курсу?: \n",
 "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.OK)
                    {
                        // удаление данных в списке отображения данных
                        ListExchange.Remove(selecEx);                    
                    }
                }, (obj) => SelectedExchange != null && ListExchange.Count > 0));
            }
        }
        #endregion

        #region UploadData
        /// команда удаления данных по сотруднику
        private RelayCommand uploadData;
        public RelayCommand UploadData
        {
            get
            {
                return uploadData ??
                (uploadData = new RelayCommand(obj =>
                {

                    MessageBoxResult result = MessageBox.Show("Выгрузить данные в файл? Возможно перезатирание файла \n",
 "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.OK)
                    {
                        try
                        {
                            // сохраненее данных в файле json
                            SaveChanges(ListExchange);
                        }
                        catch (Exception e)
                        {
                            Error = "Ошибка выгрузки данных\n" + e.Message;
                        }
                    }
                }));
            }
        }
        #endregion

        #region DrawnGraphic
        /// <summary>
        /// добавление сотрудника
        /// </summary>
        private RelayCommand drawnGraphic;
        /// <summary>
        /// добавление сотрудника
        /// </summary>
        public RelayCommand DrawnGraphic
        {
            get
            {
                return drawnGraphic ??
                (drawnGraphic = new RelayCommand(obj =>
                {
                    WindowDrawnGraphic wnGraph = new WindowDrawnGraphic
                    {
                        Title = "График изменения курсов"
                    };

                    if (wnGraph.ShowDialog() == true)
                    {
                        
                    }

                },
                    (obj) => true));
            }
        }
        #endregion




        /// <summary>
        /// Нахождение максимального Id в коллекции данных
        /// </summary>
        /// <returns></returns>
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListExchange)
            {
                if (max < r.Id)
                {
                    max = r.Id;
                };
            }
            return max;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName]
        string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
