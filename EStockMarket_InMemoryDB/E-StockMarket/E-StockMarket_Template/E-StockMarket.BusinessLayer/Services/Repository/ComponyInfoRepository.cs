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
    public class ComponyInfoRepository : IComponyInfoRepository
    {
        private readonly StockMarketDbContext _stockMarketDbContext;
        public ComponyInfoRepository(StockMarketDbContext stockMarketDbContext)
        {
            _stockMarketDbContext = stockMarketDbContext;
        }

        public async Task<ComponyInfo> FindComponyInfoById(long componyCode)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ComponyInfo>> ListAllComponyInfos()
        {
            throw new NotImplementedException();
        }

        public async Task<ComponyInfo> Register(ComponyInfo componyInfo)
        {
            throw new NotImplementedException();
        }

        public async Task<ComponyInfo> UpdateComponyInfo(RegisterComponyInfoViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
