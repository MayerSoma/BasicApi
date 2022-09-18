using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebApi.Data.DataModel;

namespace WebApi.Controllers
{
    [ApiController]
   // [Route("[controller]")]
    public class SelfCheckOutController : ControllerBase
    {
        private readonly ILogger<SelfCheckOutController> _logger;
        private readonly int _price;
        public SelfCheckOutController(ILogger<SelfCheckOutController> logger)
        {
            _logger = logger;
            _price = 3200;
        }

        // TODO
        // Auth(OATH), SSL, Logger, DB?, DTO for Stock, Unit tests, DPI?, swagger documentation

        // GET 
        // Get all stock list
        [HttpGet]
        [Route("api/v1/Stock")]
        public IActionResult GetStock()
        {
            try
            {
                var result = Stock.stockList;

                if (!result.Any())
                {
                    return NotFound("NotFound");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in AddItemToStock: " + ex);
                return BadRequest("Something went wrong with the request, plase make sure using our documentation!");
            }
        }
        
        // Post 
        [HttpPost]
        [Route("api/v1/Stock")]
        public IActionResult AddItemToStock(StockItem stockItem)
        {
            try
            {
                if (stockItem.volume == 0 || stockItem.currency == 0)
                {
                    return BadRequest("The following request is logicaly invalid! \n"
                        + "Currency Type: " + stockItem.currency
                        + "\nCurrency Volume: " + stockItem.volume);
                }

                foreach (StockItem items in Stock.stockList)
                {
                    if (items.currency == stockItem.currency)
                    {
                        Stock.UpdateStock(stockItem.currency, stockItem.volume);
                        return Ok(Stock.stockList.Where(c => c.volume != 0));
                    }
                }
                return BadRequest("The following currency is not valid: " + stockItem.currency);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in AddItemToStock: " + ex + "\n" 
                    + " Used currency: " + stockItem.currency
                    + " Used volume: " + stockItem.volume);
                return BadRequest("Something went wrong with the request, plase make sure using our documentation!");
            }
            
        }

        // Post 
        // Finalize the checkout if the paid ammount more then the targeted price
        [HttpPost]
        [Route("api/v1/Checkout")]
        public IActionResult CheckOut(StockItem stockItem)
        {
            try
            {
                List<StockItem> changeItemList = new List<StockItem>();

                int currentSummPrice = Stock.SummStockItems();
                if (currentSummPrice >= _price)
                {
                    int purchaseDiff = currentSummPrice - _price;
                    changeItemList = Stock.ChangeCalculator(purchaseDiff);
                    Stock.ResetStock();
                    return Ok(changeItemList);
                }
                else
                {
                    CheckOutFail checkOutFail = new CheckOutFail(Stock.stockList.Where(c => c.volume != 0).ToList(), _price);
                    return BadRequest(JsonConvert.SerializeObject(checkOutFail));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in AddItemToStock: " + ex + "\n"
                    + " Used currency: " + stockItem.currency
                    + " Used volume: " + stockItem.volume);
                return BadRequest("Something went wrong with the request, plase make sure using our documentation!");
            }
        }
    }
}
