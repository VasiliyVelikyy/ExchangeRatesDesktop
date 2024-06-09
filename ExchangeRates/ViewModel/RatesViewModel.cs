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


       
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]
string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

