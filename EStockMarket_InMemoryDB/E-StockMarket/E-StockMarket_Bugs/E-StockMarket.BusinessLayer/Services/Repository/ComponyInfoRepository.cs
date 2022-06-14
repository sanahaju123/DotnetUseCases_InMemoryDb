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
            try
            {
                return await _stockMarketDbContext.ComponyInfos.FindAsync(componyCode);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<ComponyInfo>> ListAllComponyInfos()
        {
            try
            {
                var result = _stockMarketDbContext.ComponyInfos.
                OrderByDescending(x => x.IsDeleted).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ComponyInfo> Register(ComponyInfo componyInfo)
        {
            try
            {
                var result = await _stockMarketDbContext.ComponyInfos.AddAsync(componyInfo);
                await _stockMarketDbContext.SaveChangesAsync();
                return componyInfo;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ComponyInfo> UpdateComponyInfo(RegisterComponyInfoViewModel model)
        {
            var updateComponyInfo = await _stockMarketDbContext.ComponyInfos.FindAsync(model.ComponyCode);
            try
            {

                updateComponyInfo.Turnover = model.Turnover;
                updateComponyInfo.BoardOfDirectors = model.BoardOfDirectors;
                updateComponyInfo.Profile = model.Profile;
                updateComponyInfo.StockExchange = model.StockExchange;
                updateComponyInfo.IsDeleted = model.IsDeleted;


                _stockMarketDbContext.ComponyInfos.Update(updateComponyInfo);
                await _stockMarketDbContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
