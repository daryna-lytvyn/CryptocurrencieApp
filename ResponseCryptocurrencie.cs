using CryptocurrencieApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptocurrencieApp
{
    public class ResponseCryptocurrencie
    {
        public List<Cryptocurrencie> Data { get; set; }
        public long Timestamp { get; set; }

    }
}
