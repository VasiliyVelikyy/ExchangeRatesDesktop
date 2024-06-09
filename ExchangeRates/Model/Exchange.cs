using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Model
{
    public class Exchange
    {

        /// <summary>
        /// код курса
        /// </summary>
        public int Id { get; set; }

        private DateTime dateTime;

        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                OnPropertyChanged("DateTime");

            }
        }

        private string rateName;
        public string RateName
        {
            get { return rateName; }
            set
            {
                rateName = value;
                OnPropertyChanged("RateName");

            }
        }

        private float rateValue;
        public float RateValue
        {
            get { return rateValue; }
            set
            {
                rateValue = value;
                OnPropertyChanged("RateValue");

            }
        }

        public Exchange() { }
        public Exchange(int id, DateTime dateTime, string rateName, float rateValue)
        {
            this.Id = id;
            this.DateTime = dateTime;
            this.RateName = rateName;
            this.RateValue = rateValue;
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
