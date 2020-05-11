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

namespace patr1
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
            int result = await Task.Run(() => Addition(10, 15))
                                        .ConfigureAwait(false);
            txtOutput.Text = result.ToString(); // будет ошибка, поскольку мы отказались от захвата UI потока
        }

        int Addition(int x, int y) => x + y;
    }
}
