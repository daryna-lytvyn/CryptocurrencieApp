﻿using CryptocurrencieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencieApp.Services
{
    internal interface ICryptocurrencieService
    {
        Task<IReadOnlyList<Cryptocurrencie>> GetCryptocurrenciesAsync(CancellationToken cancellationToken = default);
    }
}
