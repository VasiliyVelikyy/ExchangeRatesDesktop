using ExchangeRates.Helper;
using ExchangeRates.Model;
using ExchangeRates.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ExchangeRates.ViewModel
{
    public class RatesViewModel : INotifyPropertyChanged
    {
        readonly string path = @"C:\Users\Vasiliy\source\repos\ExchangeRates\ExchangeRates\DataModels\Rate.json";
        string _jsonRate = String.Empty;
        public string Error { get; set; }
        public string Message { get; set; }
        /// <summary>
        /// выбранная в списке валюта
        /// </summary>
        private Rate selectedRate;
       
        public Rate SelectedRate
        {
            get
            {
                return selectedRate;
            }
            set
            {
                selectedRate = value;
                OnPropertyChanged("SelectedRate");
              //  EditRole.CanExecute(true);
            }
        }

        /// <summary>
        /// коллекция Доступных Валют
        /// </summary>
        public ObservableCollection<Rate> ListRates { get; set; } = new
       ObservableCollection<Rate>();

        public RatesViewModel()
        {

            if (!ListRates.Any()) {
                ListRates = LoadRate();
            }
            else
            {
                this.ListRates.Add(new Rate
                {
                    Id = 1,
                    NameRate = "Доллар",
                    Code = "USD"
                });
                this.ListRates.Add(new Rate
                {
                    Id = 2,
                    NameRate = "Евро",
                    Code = "EUR"
                });
                this.ListRates.Add(new Rate
                {
                    Id = 3,
                    NameRate = "Юань",
                    Code = "CNY"
                });
            }
        }

        /// <summary>
        /// Нахождение максимального Id в коллекции
        /// </summary>
        /// <returns></returns>
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListRates)
            {
                if (max < r.Id)
                {
                    max = r.Id;
                };
            }
            return max;
        }

        public ObservableCollection<Rate> LoadRate()
        {
            _jsonRate = File.ReadAllText(path);
            if (_jsonRate != null)
            {
                ListRates = JsonConvert.DeserializeObject<ObservableCollection<Rate>>(_jsonRate);
                return ListRates;
            }
            else
            {
                return null;
            }
        }

        private void SaveChanges(ObservableCollection<Rate> listRate)
        {
            var jsonRate = JsonConvert.SerializeObject(listRate);
            try
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.Write(jsonRate);
                }
            }
            catch (IOException e)
            {
                Error = "Ошибка записи json файла /n" + e.Message;
            }
        }

        #region AddRate
        /// <summary>
        /// добавление сотрудника
        /// </summary>
        private RelayCommand addRate;
        /// <summary>
        /// добавление сотрудника
        /// </summary>
        public RelayCommand AddRate
        {
            get
            {
                return addRate ??
                (addRate = new RelayCommand(obj =>
                {
                    WindowNewRate wnRate = new WindowNewRate
                    {
                        Title = "Новые данные по валюте"
                   
                    };
                    // формирование кода нового курса
                    int maxIdRate = MaxId() + 1;
                    Rate rate = new Rate
                    {
                        Id = maxIdRate,
                      
                    };
                    wnRate.DataContext = rate;

                  //  wnRate.CbRates.ItemsSource = new RatesViewModel().ListRates;
                    if (wnRate.ShowDialog() == true)
                    {
                        ListRates.Add(rate);
                        SaveChanges(ListRates);
                    }

                    SelectedRate = rate;
                },
        (obj) => true));
            }
        }
#endregion


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]
        string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

