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
    internal partial class MainViewModel : ObservableObject
    {
        private readonly ICryptocurrencieService _cryptocurrencieService;
        public ObservableCollection<Cryptocurrencie> Cryptocurrencies { get; } = new();

        public MainViewModel(ICryptocurrencieService cryptocurrencieService)
        {
            _cryptocurrencieService = cryptocurrencieService;
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
    }
}

