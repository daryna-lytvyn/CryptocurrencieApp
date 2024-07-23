using CryptocurrencieApp.Models;
using CryptocurrencieApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
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

namespace CryptocurrencieApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = (App.Current as App)!.Host.Services.GetService<MainViewModel>();

            InitializeComponent();
        }

        private void OpenDetailWindow(Cryptocurrencie selectedCryptocurrencie)
        {
            if (selectedCryptocurrencie is null)
            {
                return;
            }

            var detailViewModel = (App.Current as App)!.Host.Services.GetService<DetailViewModel>();
            detailViewModel.CurrentCryptocurrencie = selectedCryptocurrencie;

            var detailWindow = new DetailWindow { DataContext = detailViewModel };
            detailWindow.Show();
        }

        private void FilteredCryptocurrencies_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedCryptocurrencie = (sender as ListBox)?.SelectedItem as Cryptocurrencie;
            if (selectedCryptocurrencie is not null)
            {
                OpenDetailWindow(selectedCryptocurrencie);
            }
        }

        private void ConvertMenuItem_Click(object sender, RoutedEventArgs e)
        {

            var convertWindow = new ConvertWindow
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = this.Left,
                Top = this.Top,
                Width = this.Width,
                Height = this.Height
            };

            convertWindow.Show();

            this.Hide();


        }
    }
}