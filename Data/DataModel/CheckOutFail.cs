using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebApi.Data.DataModel
{
    [Serializable]
    public class CheckOutFail
    {
        public List<StockItem> stockItemList;
        public int price;

        public CheckOutFail(List<StockItem> stockItemList, int price)
        {
            this .stockItemList = stockItemList;
            this .price = price;
        }

    }
}
