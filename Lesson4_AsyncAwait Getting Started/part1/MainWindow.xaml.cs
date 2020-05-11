using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        private async void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Text = $"##Старт обработчика в потоке { Thread.CurrentThread.ManagedThreadId} \n";

            string info = "";

            btnExecute.IsEnabled = false;

            string result = await Task.Run(() =>
            {
                info = $"##Выполнение обработчика в потоке { Thread.CurrentThread.ManagedThreadId} \n";

                return GenerateAnswer();                               
            });

            btnExecute.IsEnabled = true;

            txtOutput.Text += info;

            txtOutput.Text += result + $"##Выполнено в потоке { Thread.CurrentThread.ManagedThreadId}";
        }

        string GenerateAnswer()
        {
            Thread.Sleep(10000);

            return "Hello world";
        }
    }
}
