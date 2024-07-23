using CryptocurrencieApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
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

namespace CryptocurrencieApp
{
    /// <summary>
    /// Логика взаимодействия для ConvertWindow.xaml
    /// </summary>
    public partial class ConvertWindow : Window
    {
        public ConvertWindow()
        {
            DataContext = (App.Current as App)!.Host.Services.GetService<ConvertViewModel>();
            this.Closed += ConvertWindow_Closed;
            InitializeComponent();
        }

        private void ConvertWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CryptocurrenciesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = this.Left,
                Top = this.Top,
                Width = this.Width,
                Height = this.Height
            };

            mainWindow.Show();
            this.Hide();
        }
    }
}
