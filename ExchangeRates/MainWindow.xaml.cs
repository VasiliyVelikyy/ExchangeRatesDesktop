using ExchangeRates.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExchangeRates
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        public static int IdRate { get; set; }

        public static int IdExchange { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rate_OnClick(object sender, RoutedEventArgs e)
        {
            WindowRates wRate = new WindowRates();
            wRate.Show();
        }

        private void Exchange_OnClick(object sender, RoutedEventArgs e)
        {
            WindowExchanges wExchanges = new WindowExchanges();
            wExchanges.Show();
        }


    }
}
