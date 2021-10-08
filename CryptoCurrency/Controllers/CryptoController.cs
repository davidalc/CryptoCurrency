using CryptoCurrency.BL;
using CryptoCurrency.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoCurrency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly MessariAssetsSettings configuration;

        public CryptoController(MessariAssetsSettings _configuration)
        {
            configuration = _configuration;
        }

        // GET api/<CryptoController>/5
        [HttpGet("{sort}/{limit}")]
        public async Task<List<CryptoData>> Get(SortField sort, int limit)
        {
            MessariConnector connector = new MessariConnector();

            CryptoResult res = await connector.GetMessariData(
              configuration.MessariAPI,
              configuration.MessariAPIFields,
              configuration.MessariAPIKey,
              sort,
              limit);

            return res.data;
        }
    }
}
