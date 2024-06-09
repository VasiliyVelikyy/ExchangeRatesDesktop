using ExchangeRates.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.ViewModel
{
    public class ExchangeViewModel : INotifyPropertyChanged
    {
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


        public event PropertyChangedEventHandler PropertyChanged;
        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName]
        string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
