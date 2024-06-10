using ExchangeRates.Model;
using ExchangeRates.ViewModel;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiveCharts.Wpf;
using System.Collections.ObjectModel;
using LiveCharts.Defaults;
using LiveCharts.Definitions.Charts;
using ExchangeRates.Helper;
using System.Runtime.Serialization;
using static System.Resources.ResXFileRef;
using LiveCharts.Configurations;

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

            var mapper = Mappers.Xy<GraphPoint>()
             .X(model => model.Date.Ticks)
            .Y(model => model.Value);

            var list = new ExchangeViewModel().ListExchange;

            list = new ObservableCollection<Exchange>(list.OrderBy(i => i.DateTime));


            var series1 = new LineSeries
            {
                Values = new ChartValues<GraphPoint>
                    {
                        new GraphPoint(DateTime.Now.AddDays(1),10),       //First Point of First Line
                        
                    },
                PointGeometrySize = 25,
                Title="USD"
            };

            var series2 = new LineSeries
            {
                    Values = new ChartValues<GraphPoint>
                    {
                        new GraphPoint(DateTime.Now.AddDays(2),4),      //First Point of 2nd Line
                        
                    },
                    PointGeometrySize = 15,
                    Title = "EUR"
            };

            var series3 = new LineSeries
            {
                Values = new ChartValues<GraphPoint>
                    {
                         new GraphPoint(DateTime.Now.AddDays(3),4),     //First Point of 3rd Line
                        
                    },
                PointGeometrySize = 15,
                Title= "CNY"
            };


            SeriesCollection = new SeriesCollection { series1, series2, series3 };
     
        
           
            ///Labels = new[] { "Giga", "Perish","SADF","WQFS" };

            Formatter = value => new DateTime((long)value).ToString("MM/dd/yy");

            DataContext = this;

        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }

        public Func<double, string> Values { get; set; }
        public Func<double, string> Formatter { get;  set; }


      
    }
}
