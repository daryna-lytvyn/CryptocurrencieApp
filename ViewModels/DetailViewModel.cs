using CommunityToolkit.Mvvm.ComponentModel;
using CryptocurrencieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencieApp.ViewModels
{
    public partial class DetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private Cryptocurrencie _currentCryptocurrencie;

        public DetailViewModel(Cryptocurrencie cryptocurrencie) 
        {
            _currentCryptocurrencie = cryptocurrencie;
        
        }
    }
}
