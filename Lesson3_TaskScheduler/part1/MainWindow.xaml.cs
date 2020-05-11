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

namespace part1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task<double>.Factory.StartNew(() => FindLastFibonacciNumber(5), TaskCreationOptions.LongRunning)
                .ContinueWith(x => txtResult.Text = x.Result.ToString(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private static double FindLastFibonacciNumber(int number)
        {
            Func<int, double> fib = null;

            fib = (x) => x > 1 ? fib(x - 1) + fib(x - 2) : x;

            return 5;//fib.Invoke(number);
        }
    }
}
