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
    public partial class ConvertViewModel : ObservableObject
    {
        private readonly ICryptocurrencieService _cryptocurrencieService;

        [ObservableProperty]
        private Cryptocurrencie _selectedFromCurrency;

        [ObservableProperty]
        private Cryptocurrencie _selectedToCurrency;

        [ObservableProperty]
        private string _amountToConvert;

        [ObservableProperty]
        private string _convertResult;

        public ObservableCollection<Cryptocurrencie> Cryptocurrencies { get; } = new();

        public ConvertViewModel(ICryptocurrencieService cryptocurrencieService)
        {
            _cryptocurrencieService = cryptocurrencieService;
            LoadCryptocurrencies();
        }

        [RelayCommand]
        private void Convert()
        {
            if (SelectedFromCurrency is not null && SelectedToCurrency is not null && decimal.TryParse(AmountToConvert, out var amount))
            {
                var conversionRate = SelectedToCurrency.PriceUsd / SelectedFromCurrency.PriceUsd;
                var convertedAmount = amount * conversionRate;
                ConvertResult = $"{amount} {SelectedFromCurrency.Symbol} = {convertedAmount} {SelectedToCurrency.Symbol}";
            }
            else
            {
                ConvertResult = "Invalid input.";
            }
        }

        [RelayCommand]
        private async Task GetCryptocurrenciesAsync()
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

        private async void LoadCryptocurrencies()
        {
            await GetCryptocurrenciesAsync();
        }
    }

}

