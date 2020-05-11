using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Threading;

namespace part1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource _cts;
        private static IProgress<int> _progress;

        public MainWindow()
        {
            InitializeComponent();

            _cts = new CancellationTokenSource();

            _progress = new Progress<int>(UpdateProgress);
        }

        private async void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            int res;

            pbBar.Value = 0;

            if (Int32.TryParse(txtInput.Text.Trim(), out int num))
            {
                try
                {
                    res = await CalcFactorialAsync(num);
                    txtOutput.Text += res.ToString() + "\n";
                }
                catch (OperationCanceledException ex)
                {

                    txtOutput.Text += "Operation canceled\n";
                }
            }            
        }

        private async Task<int> CalcFactorialAsync(int num)
        {
            var token = _cts.Token;
            
            return await Task.Run(() => CalcFactorial(num, token), token);

        }
        private int CalcFactorial(int num, CancellationToken token)
        {
            int res = 1;

            if (num == 0)
            {
                _progress.Report(100);
                return res;
            }

            token.ThrowIfCancellationRequested();

            for (int i = 1; i <= num; i++)
            {
                Thread.Sleep(200);

                token.ThrowIfCancellationRequested();

                res *= i;

                _progress.Report((int)Math.Round((double)(100 / num * i), 0));
            }

            _progress.Report(100);

            return res;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _cts.Cancel();

            _cts = new CancellationTokenSource();

        }

        private void UpdateProgress(int count)
        {
            pbBar.Value = count;
        }
    }
}
