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
    public class ComponyInfoServices : IComponyInfoServices
    {
        private readonly IComponyInfoRepository _componyInfoRepository;
        private readonly StockMarketDbContext _stockMarketDbContext;
        public ComponyInfoServices(IComponyInfoRepository componyInfoRepository, StockMarketDbContext stockMarketDbContext)
        {
            _componyInfoRepository = componyInfoRepository;
            _stockMarketDbContext = stockMarketDbContext;
        }

        public async Task<ComponyInfo> FindComponyInfoById(long componyCode)
        {
            return null;
        }

        public async Task<IEnumerable<ComponyInfo>> ListAllComponyInfos()
        {
            return null;
        }

        public async Task<ComponyInfo> Register(ComponyInfo componyInfo)
        {
            return null;
        }

        public async Task<ComponyInfo> UpdateComponyInfo(RegisterComponyInfoViewModel model)
        {
            return await _componyInfoRepository.UpdateComponyInfo(model);
        }
    }
}
