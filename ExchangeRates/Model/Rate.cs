using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ExchangeRates.Model
{
    /// <summary>
    /// класс Валюты
    /// </summary>
    public class Rates : INotifyPropertyChanged
    {
        /// <summary>
        /// код валюты
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// наименование валюты
        /// </summary>
        private string nameRates;
        public string NameRates
        {
            get { return nameRates; }
            set
            {
                nameRates = value;
                OnPropertyChanged("NameRates");

            }
        }

        public Rates() { }
        public Rates(int id, string nameRates)
        {
            this.Id = id;
            this.NameRates = nameRates;
        }

        /// <summary>
        /// Метод поверхностного копирования 
        /// </summary>
        /// <returns></returns>
        public Rates ShallowCopy()
        {
            return (Rates)this.MemberwiseClone();
        }
        public event PropertyChangedEventHandler PropertyChanged;
         [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName]
        string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }

    
}
