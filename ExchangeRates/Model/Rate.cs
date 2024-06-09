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
    public class Rate : INotifyPropertyChanged
    {
        /// <summary>
        /// код валюты
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// наименование валюты
        /// </summary>
        private string nameRate;
        public string NameRate
        {
            get { return nameRate; }
            set
            {
                nameRate = value;
                OnPropertyChanged("NameRates");
            }
        }

        private string code;
        public string Code
        {
            get { return code; }
            set
            {
                code = value;
                OnPropertyChanged("Code");

            }
        }

        public Rate() { }
        public Rate(int id, string nameRates, string code)
        {
            this.Id = id;
            this.NameRate = nameRates;
            this.Code = code;
        }

        /// <summary>
        /// Метод поверхностного копирования 
        /// </summary>
        /// <returns></returns>
        public Rate ShallowCopy()
        {
            return (Rate)this.MemberwiseClone();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        // [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName]
        string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
