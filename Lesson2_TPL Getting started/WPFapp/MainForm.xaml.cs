﻿using System;
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
using System.Windows.Shapes;

namespace WPFapp
{
    /// <summary>
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() => {

                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(300);
                    Dispatcher.Invoke(() => txtResult.Text += "*");
                }
            });
        }
    }
}
