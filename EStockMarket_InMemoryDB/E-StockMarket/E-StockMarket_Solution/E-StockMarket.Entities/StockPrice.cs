using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_StockMarket.Entities
{
    public class StockPrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long ComponyCode { get; set; }
        public double CurrentStockPrice { get; set; }
        public DateTime StockPriceDate { get; set; }
        public DateTime StockPriceTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
