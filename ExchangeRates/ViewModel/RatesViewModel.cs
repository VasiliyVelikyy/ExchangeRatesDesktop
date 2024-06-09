using ExchangeRates.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.ViewModel
{
    public class RatesViewModel : INotifyPropertyChanged
    {

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
                selectedRole = value;
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
            this.ListRates.Add(new Rate
            {
                Id = 1,
                NameRate = "Доллар",
                Code= "USD"
            });
            this.ListRates.Add(new Rate
            {
                Id = 2,
                NameRate = "Евро",
                Code = "Eur"
            });
            this.ListRates.Add(new Rate
            {
                Id = 3,
                NameRate = "Юань",
                Code = "CNY"
            });
        }
    }
}
