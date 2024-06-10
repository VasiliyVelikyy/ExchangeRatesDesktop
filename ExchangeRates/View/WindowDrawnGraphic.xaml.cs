using ExchangeRates.Model;
using LiveCharts;
using System;
using System.Windows;

using LiveCharts.Configurations;
using ExchangeRates.ViewModel;
using System.Linq;
using System.Reflection;
using ExchangeRates.Helper;

namespace ExchangeRates.View
{
    /// <summary>
    /// Логика взаимодействия для WindowDrawnGraphic.xaml
    /// </summary>
    public partial class WindowDrawnGraphic : Window
    {
        public WindowDrawnGraphic()
        {
            InitializeComponent();

            this.ObservableDateModelMapper = new CartesianMapper<GraphPoint>();
            this.ObservableDateModelMapper
              .X(item => item.Date.Ticks)
              .Y(item => item.Value);

            var listExchange = new ExchangeViewModel().ListExchange.ToList();

           
            FindRate finderUSD = new FindRate("USD");
            FindRate finderEUR = new FindRate("EUR");
            FindRate finderCNY = new FindRate("CNY");
            var findUSD = listExchange.FindAll(new Predicate<Exchange>(finderUSD.RatePredicate));
            var findEUR = listExchange.FindAll(new Predicate<Exchange>(finderEUR.RatePredicate));
            var findCNY = listExchange.FindAll(new Predicate<Exchange>(finderCNY.RatePredicate));

            PlotUSD(findUSD);
            PlotEUR(findEUR);
            PlotCNY(findCNY);

            DataContext = this;
        }


        public void PlotUSD(System.Collections.Generic.List<Exchange> findUSD)
        {
            this.SeriesValuesUSD = new ChartValues<GraphPoint>();

            foreach (var exchange in findUSD) {
                var point = new GraphPoint(exchange.DateTime, exchange.RateValue);
                this.SeriesValuesUSD.Add(point);
            }
        }

        public void PlotEUR(System.Collections.Generic.List<Exchange> findEUR)
        {
            this.SeriesValuesEUR = new ChartValues<GraphPoint>();

            foreach (var exchange in findEUR)
            {
                var point = new GraphPoint(exchange.DateTime, exchange.RateValue);
                this.SeriesValuesEUR.Add(point);
            }
        }

        public void PlotCNY(System.Collections.Generic.List<Exchange> findCNY)
        {
            this.SeriesValuesCNY = new ChartValues<GraphPoint>();

            foreach (var exchange in findCNY)
            {
                var point = new GraphPoint(exchange.DateTime, exchange.RateValue);
                this.SeriesValuesCNY.Add(point);
            }
        }



        public CartesianMapper<GraphPoint> ObservableDateModelMapper { get; }
        public ChartValues<GraphPoint> SeriesValuesUSD { get; private set; }
        public ChartValues<GraphPoint> SeriesValuesEUR { get; private set; }
        public ChartValues<GraphPoint> SeriesValuesCNY { get; private set; }
        public Func<double, string> LabelFormatter => value => new DateTime((long)value).ToString("MM/dd/yy");

    }
}
