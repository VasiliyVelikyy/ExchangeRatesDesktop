using ExchangeRates.Model;
using System;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

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


        public event PropertyChangedEventHandler PropertyChanged;
        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName]
        string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
