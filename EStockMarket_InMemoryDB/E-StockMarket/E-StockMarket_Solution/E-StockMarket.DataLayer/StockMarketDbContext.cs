using E_StockMarket.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_StockMarket.DataLayer
{
    public class StockMarketDbContext : DbContext
    {
        public StockMarketDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ComponyInfo> ComponyInfos { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }
    }
}
