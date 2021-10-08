using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCurrency.DTO
{
    public class CryptoResult
    {
        public List<CryptoData> data { get; set; }
    }

    public class CryptoData
    {
        public string name { get; set; }
        public string symbol { get; set; }

        public CryptoMetrics metrics { get; set; }
    }

    public class CryptoMetrics
    {
        public CryptoMarketData market_data { get; set; }
        public CryptoMaketCap marketcap { get; set; }
    }

    public class CryptoMarketData
    {
        public float price_usd { get; set; }
    }

    public class CryptoMaketCap
    {
        public float current_marketcap_usd { get; set; }
    }
}



