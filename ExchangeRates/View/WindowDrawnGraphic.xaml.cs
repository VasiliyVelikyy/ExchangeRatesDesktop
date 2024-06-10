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

            this.ObservableDateModelMapper = new CartesianMapper<GraphPoint>();
            this.ObservableDateModelMapper
              .X(item => item.Date.Ticks)
              .Y(item => item.Value);

            Plot();

            DataContext = this;
        }


        public void Plot()
        {
            this.SeriesValues = new ChartValues<GraphPoint>
    {
      new GraphPoint(DateTime.Now, 2),
      new GraphPoint(DateTime.Now.AddDays(1), 5),
      new GraphPoint(DateTime.Now.AddDays(2), 6),
      new GraphPoint(DateTime.Now.AddDays(3), 8),
      new GraphPoint(DateTime.Now.AddDays(4), 5),
      new GraphPoint(DateTime.Now.AddDays(5), 5),
      new GraphPoint(DateTime.Now.AddDays(6), 5)
    };
        }
    
       

        public CartesianMapper<GraphPoint> ObservableDateModelMapper { get; }
        public ChartValues<GraphPoint> SeriesValues { get; private set; }
        public Func<double, string> LabelFormatter => value => new DateTime((long)value).ToString();

    }
}
