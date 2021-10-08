using CryptoCurrency.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptoCurrency.BL
{
    internal class MessariConnector
    {
        internal async Task<CryptoResult> GetMessariData(string apiUrl, string fields, string MessariAPIKey, SortField sort, int limit)
        {
            if (limit == 0)
                limit = 20;
            else if (limit < 1 || limit > 500)
                throw new Exception("Limit out of range(1-500)");

            StringBuilder url = new StringBuilder(apiUrl);
            url.AppendFormat("?fields={0}", fields);
            url.AppendFormat("&limit={0}", limit);

            try
            {
                var client = new WebClient();
                client.Headers.Add("x-messari-api-key", MessariAPIKey);
                string response = await client.DownloadStringTaskAsync(url.ToString());

                CryptoResult res = JsonSerializer.Deserialize<CryptoResult>(response);

                if (sort == SortField.Price)
                    res.data.Sort((x, y) => y.metrics.market_data.price_usd.CompareTo(x.metrics.market_data.price_usd));

                return res;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving data from crypto API.");
            }
        }
    }
}
