using E_StockMarket.BusinessLayer.Interfaces;
using E_StockMarket.BusinessLayer.Services.Repository;
using E_StockMarket.BusinessLayer.ViewModels;
using E_StockMarket.DataLayer;
using E_StockMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_StockMarket.BusinessLayer.Services
{
    public class StockPriceServices : IStockPriceServices
    {
        private readonly IStockPriceRepository _stockPriceRepository;
        private readonly StockMarketDbContext _stockMarketDbContext;
        public StockPriceServices(IStockPriceRepository stockPriceRepository, StockMarketDbContext stockMarketDbContext)
        {
            _stockPriceRepository = stockPriceRepository;
            _stockMarketDbContext = stockMarketDbContext;
        }

        public async Task<StockPrice> FindStockPriceById(long stockPriceId)
        {
            return await _stockPriceRepository.FindStockPriceById(stockPriceId);
        }

        public async Task<IEnumerable<StockPrice>> GetStockPriceIndex(long componyCode, DateTime startDate, DateTime endDate)
        {
            return await _stockPriceRepository.GetStockPriceIndex(componyCode,startDate,endDate);
        }

        public async Task<IEnumerable<StockPrice>> ListAllStockPrices()
        {
            return await _stockPriceRepository.ListAllStockPrices();
        }

        public async Task<StockPrice> Register(StockPrice stockPrice)
        {
            return await _stockPriceRepository.Register(stockPrice);
        }

        public async Task<StockPrice> UpdateStockPrice(RegisterStockPriceViewModel model)
        {
            return await _stockPriceRepository.UpdateStockPrice(model);
        }
    }
}
