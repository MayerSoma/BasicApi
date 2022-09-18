using Newtonsoft.Json;

namespace WebApi.Data.DataModel
{
    public class StockItem
    {
        [JsonConstructor]
        StockItem()
        {

        }

        public StockItem(int currency, int volume)
        {
            this.currency = currency;
            this.volume = volume;
        }

        public int currency { get; set; }
        public int volume { get; set; }
    }
}
