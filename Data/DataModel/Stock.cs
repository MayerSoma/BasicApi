using System.Collections.Generic;

namespace WebApi.Data.DataModel
{
    public static class Stock
    {
        public static List<StockItem> stockList = new List<StockItem>();
        static Stock()
        {

            // Currencys (HUF) and their counters in stock
            stockList.Add(new StockItem(1, 0));
            stockList.Add(new StockItem(5, 0));
            stockList.Add(new StockItem(10, 0));
            stockList.Add(new StockItem(20, 0));
            stockList.Add(new StockItem(50, 0));
            stockList.Add(new StockItem(100, 0));
            stockList.Add(new StockItem(200, 0));
            stockList.Add(new StockItem(500, 0));
            stockList.Add(new StockItem(1000, 0));
            stockList.Add(new StockItem(2000, 0));
            stockList.Add(new StockItem(5000, 0));
            stockList.Add(new StockItem(10000, 0));
            stockList.Add(new StockItem(20000, 0));

        }
        public static void UpdateStock(int currency, int volume)
        {
            foreach (var stockItem in stockList)
            {
                if (stockItem.currency.Equals(currency))
                {
                    stockItem.volume += volume;
                }
            }
        }
        public static void ResetStock()
        {
            foreach (var stockItem in stockList)
            {
                stockItem.volume = 0;
            }
        }
        public static bool UpdateChangeStockIfExists(ref List<StockItem> changeStockList, int currency)
        {
            foreach (var stockItem in changeStockList)
            {
                if (stockItem.currency.Equals(currency))
                {
                    stockItem.volume += 1;
                    return true;
                }
            }
            return false;
        }
        public static void RemoveCurrency(int currency, int volume)
        {
            foreach (var stockItem in stockList)
            {
                if (stockItem.currency.Equals(currency))
                {
                    stockItem.volume -= volume;
                }
            }
        }
        public static int SummStockItems()
        {
            int result = 0;
            foreach (var stockItem in stockList)
            {
                result += (stockItem.currency * stockItem.volume);
            }
            return result;
        }

        // Calculates the change with the highest useable currencys
        public static List<StockItem> ChangeCalculator(int priceDiff)
        {
            List<StockItem> changeStockList = new List<StockItem>();

            while (priceDiff != 0)
            {
                if (priceDiff - 20000 >= 0)
                {
                    priceDiff -= 20000;
                    if (UpdateChangeStockIfExists(ref changeStockList, 20000))
                    {
                        continue;
                    }
                    else
                    {
                        changeStockList.Add(new StockItem(20000, 1));
                        continue;
                    }
                }
                if (priceDiff - 10000 >= 0)
                {
                    priceDiff -= 10000;
                    if (UpdateChangeStockIfExists(ref changeStockList, 10000))
                    {
                        continue;
                    }
                    else
                    {
                        changeStockList.Add(new StockItem(10000, 1));
                        continue;
                    }
                }
                if (priceDiff - 5000 >= 0)
                {
                    priceDiff -= 5000;
                    if (UpdateChangeStockIfExists(ref changeStockList, 5000))
                    {
                        continue;
                    }
                    else
                    {
                        changeStockList.Add(new StockItem(5000, 1));
                        continue;
                    }
                }
                if (priceDiff - 2000 >= 0)
                {
                    priceDiff -= 2000;
                    if (UpdateChangeStockIfExists(ref changeStockList, 2000))
                    {
                        continue;
                    }
                    else
                    {
                        changeStockList.Add(new StockItem(2000, 1));
                        continue;
                    }
                }
                if (priceDiff - 1000 >= 0)
                {
                    priceDiff -= 1000;
                    if (UpdateChangeStockIfExists(ref changeStockList, 1000))
                    {
                        continue;
                    }
                    else
                    {
                        changeStockList.Add(new StockItem(1000, 1));
                        continue;
                    }
                }
                if (priceDiff - 500 >= 0)
                {
                    priceDiff -= 500;
                    if (UpdateChangeStockIfExists(ref changeStockList, 500))
                    {
                        continue;
                    }
                    else
                    {
                        changeStockList.Add(new StockItem(500, 1));
                        continue;
                    }
                }
                if (priceDiff - 200 >= 0)
                {
                    priceDiff -= 200;
                    if (UpdateChangeStockIfExists(ref changeStockList, 200))
                    {
                        continue;
                    }
                    else
                    {
                        changeStockList.Add(new StockItem(200, 1));
                        continue;
                    }
                }
                if (priceDiff - 100 >= 0)
                {
                    priceDiff -= 100;
                    if (UpdateChangeStockIfExists(ref changeStockList, 100))
                    {
                        continue;
                    }
                    else
                    {
                        changeStockList.Add(new StockItem(100, 1));
                        continue;
                    }
                }
                if (priceDiff - 50 >= 0)
                {
                    priceDiff -= 50;
                    if (UpdateChangeStockIfExists(ref changeStockList, 50))
                    {
                        continue;
                    }
                    else
                    {
                        changeStockList.Add(new StockItem(50, 1));
                        continue;
                    }
                }
                if (priceDiff - 20 >= 0)
                {
                    priceDiff -= 20;
                    if (UpdateChangeStockIfExists(ref changeStockList, 20))
                    {
                        continue;
                    }
                    else
                    {
                        changeStockList.Add(new StockItem(20, 1));
                        continue;
                    }
                }
                if (priceDiff - 10 >= 0)
                {
                    priceDiff -= 10;
                    if (UpdateChangeStockIfExists(ref changeStockList, 10))
                    {
                        continue;
                    }
                    else
                    {
                        changeStockList.Add(new StockItem(10, 1));
                        continue;
                    }
                }
                if (priceDiff - 5 >= 0)
                {
                    priceDiff -= 5;
                    if (UpdateChangeStockIfExists(ref changeStockList, 5))
                    {
                        continue;
                    }
                    else
                    {
                        changeStockList.Add(new StockItem(5, 1));
                        continue;
                    }
                }
                if (priceDiff - 1 >= 0)
                {
                    priceDiff -= 1;
                    if (UpdateChangeStockIfExists(ref changeStockList, 1))
                    {
                        continue;
                    }
                    else
                    {
                        changeStockList.Add(new StockItem(1, 1));
                        continue;
                    }
                }
            }
            return changeStockList;
        }
    }
}
