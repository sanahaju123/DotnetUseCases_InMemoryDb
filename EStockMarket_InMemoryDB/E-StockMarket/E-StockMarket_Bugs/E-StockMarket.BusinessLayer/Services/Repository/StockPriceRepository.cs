using E_StockMarket.BusinessLayer.ViewModels;
using E_StockMarket.DataLayer;
using E_StockMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_StockMarket.BusinessLayer.Services.Repository
{
    public class StockPriceRepository : IStockPriceRepository
    {
        private readonly StockMarketDbContext _stockMarketDbContext;
        public StockPriceRepository(StockMarketDbContext stockMarketDbContext)
        {
            _stockMarketDbContext = stockMarketDbContext;
        }

        public async Task<StockPrice> FindStockPriceById(long stockPriceId)
        {
            try
            {
                return await _stockMarketDbContext.StockPrices.FindAsync(stockPriceId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<StockPrice>> GetStockPriceIndex(long componyCode, DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = _stockMarketDbContext.StockPrices.
                Where(x => x.ComponyCode==componyCode  && x.StockPriceDate > startDate && x.StockPriceDate < endDate).Take(10).ToList();
                return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<StockPrice>> ListAllStockPrices()
        {
            try
            {
                var result = _stockMarketDbContext.StockPrices.
                OrderByDescending(x => x.Id).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<StockPrice> Register(StockPrice stockPrice)
        {
            try
            {
                var result = await _stockMarketDbContext.StockPrices.AddAsync(stockPrice);
                await _stockMarketDbContext.SaveChangesAsync();
                return stockPrice;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<StockPrice> UpdateStockPrice(RegisterStockPriceViewModel model)
        {
            var updateStockPriceInfo = await _stockMarketDbContext.StockPrices.FindAsync(model.Id);
            try
            {

                updateStockPriceInfo.ComponyCode = model.ComponyCode;
                updateStockPriceInfo.CurrentStockPrice = model.CurrentStockPrice;

                _stockMarketDbContext.StockPrices.Update(updateStockPriceInfo);
                await _stockMarketDbContext.SaveChangesAsync();
                return updateStockPriceInfo;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
