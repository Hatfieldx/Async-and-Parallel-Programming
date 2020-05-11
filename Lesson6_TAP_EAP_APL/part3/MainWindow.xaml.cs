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

namespace part3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SynchronizationContext context;
        
        public MainWindow()
        {
            InitializeComponent();

            context = SynchronizationContext.Current;

            CounterMemory();
        }

        private async void btnExecute250_Click(object sender, RoutedEventArgs e)
        {
            var a = await CreateObjectsAsync(250);

            txtOutput.Text += a.Length;
        }

        private async Task<object[]> CreateObjectsAsync(int objectCount)
        {
            object[] a = new object[objectCount];

            await Task.Run(() =>
            {
                for (int i = 0; i < objectCount - 1; i++)
                {
                   Thread.Sleep(1000);
                    a[i] = new object();
                }
            });

            return a;
        }

        private async void btnExecute400_Click(object sender, RoutedEventArgs e)
        {
            var a = await CreateObjectsAsync(400);

            txtOutput.Text += a.Length;
        }

        private async void btnExecute1000_Click(object sender, RoutedEventArgs e)
        {
            var a = await CreateObjectsAsync(1000);

            txtOutput.Text += a.Length;
        }

        private async Task CounterMemory()
        {
            await Task.Run(() =>
            {
               // SynchronizationContext.SetSynchronizationContext(context);

                while (true)
                {
                    Thread.Sleep(500);
                    Dispatcher.Invoke(() => txtInput.Text += GC.GetTotalMemory(true) + "\n");                    
                };
            });
        }
    }
}
