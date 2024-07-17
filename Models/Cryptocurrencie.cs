using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencieApp.Models
{
    public class Cryptocurrencie
    {
        public string Id { get; set; }
        public int Rank { get; set; }  // Ранг
        public string Symbol { get; set; }  // Символ
        public string Name { get; set; }  // Назва
        public decimal Supply { get; set; }  // Кількість у наявності
        public decimal? MaxSupply { get; set; }  // Максимальна кількість
        public decimal MarketCapUsd { get; set; }  // Ринкова капіталізація в доларах США
        public decimal VolumeUsd24Hr { get; set; }  // Обсяг торгів за 24 години в доларах США
        public decimal PriceUsd { get; set; }  // Ціна в доларах США
        public decimal ChangePercent24Hr { get; set; }  // Відсоткова зміна за 24 години
        public decimal Vwap24Hr { get; set; }  // Середньозважена ціна за 24 години

    }
}
