using E_StockMarket.BusinessLayer.ViewModels;
using E_StockMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_StockMarket.BusinessLayer.Interfaces
{
    public interface IStockPriceServices
    {
        Task<StockPrice> Register(StockPrice stockPrice);
        Task<StockPrice> FindStockPriceById(long stockPriceId);
        Task<StockPrice> UpdateStockPrice(RegisterStockPriceViewModel model);
        Task<IEnumerable<StockPrice>> ListAllStockPrices();
        Task<IEnumerable<StockPrice>> GetStockPriceIndex(long componyCode,DateTime startDate,DateTime endDate);
    }
}
