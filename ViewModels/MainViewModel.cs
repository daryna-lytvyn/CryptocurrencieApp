using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptocurrencieApp.Models;
using CryptocurrencieApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CryptocurrencieApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly ICryptocurrencieService _cryptocurrencieService;

        [ObservableProperty]
        private string _searchQuery;

        public ObservableCollection<Cryptocurrencie> Cryptocurrencies { get; } = new();
        public ObservableCollection<Cryptocurrencie> FilteredCryptocurrencies { get; } = new();


        public MainViewModel(ICryptocurrencieService cryptocurrencieService)
        {
            _cryptocurrencieService = cryptocurrencieService;
            LoadCryptocurrencies();
        }

        [RelayCommand]
        public async Task GetCryptocurrenciesAsync()
        {
            var cryptocurrencies = await Task.Run(() => _cryptocurrencieService.GetCryptocurrenciesAsync());

            await Dispatcher.CurrentDispatcher.InvokeAsync(() =>
            {
                foreach (var cryptocurrencie in cryptocurrencies)
                {
                    Cryptocurrencies.Add(cryptocurrencie);
                }
            }, DispatcherPriority.Background);
        }

        [RelayCommand]
        private async void FilterCryptocurrencies()
        {
            FilteredCryptocurrencies.Clear();

            var filtered = Cryptocurrencies.Where(c =>
                string.IsNullOrEmpty(SearchQuery) ||
                c.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                c.Symbol.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase));

            await Dispatcher.CurrentDispatcher.InvokeAsync(() =>
            {
                foreach (var cryptocurrencie in filtered)
                {
                    FilteredCryptocurrencies.Add(cryptocurrencie);
                }
            }, DispatcherPriority.Background);
        }

        private async void LoadCryptocurrencies()
        {
            await GetCryptocurrenciesAsync();
            FilterCryptocurrencies();
        }
    }
}

