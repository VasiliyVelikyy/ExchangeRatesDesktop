using ExchangeRates.Model;
using ExchangeRates.ViewModel;
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
            // DataContext = new DrawnViewModel();

            var Points = new System.Windows.Point[3]
              {
                         new System.Windows.Point { X = 0, Y = 10 },
                        new System.Windows.Point { X = 10, Y = 30 },
                        new System.Windows.Point { X = 20, Y = 20 },
              };
            IList<Segment> Segments = new List<Segment>(Points.Zip(Points.Skip(1), (a, b) => new Segment { From = a, To = b }));

            DataContext = Segments;
        }
    }
}
