using E_StockMarket.BusinessLayer.ViewModels;
using E_StockMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_StockMarket.BusinessLayer.Interfaces
{
    public interface IComponyInfoServices
    {
        Task<ComponyInfo> Register(ComponyInfo componyInfo);
        Task<ComponyInfo> FindComponyInfoById(long componyCode);
        Task<ComponyInfo> UpdateComponyInfo(RegisterComponyInfoViewModel model);
        Task<IEnumerable<ComponyInfo>> ListAllComponyInfos();
    }
}
