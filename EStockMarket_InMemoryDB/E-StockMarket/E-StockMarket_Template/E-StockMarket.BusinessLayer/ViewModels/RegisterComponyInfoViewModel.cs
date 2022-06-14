using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_StockMarket.BusinessLayer.ViewModels
{
    public class RegisterComponyInfoViewModel
    {
        [Key]
        public long ComponyCode { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Minimum 3 Maximum 100 characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Minimum 5 Maximum 100 characters")]
        public string CEO { get; set; }

        public double Turnover { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Minimum 5 Maximum 200 characters")]
        public string BoardOfDirectors { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Minimum 5 Maximum 255 characters")]
        public string Profile { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Minimum 3 Maximum 100 characters")]
        public string StockExchange { get; set; }

        public bool IsDeleted { get; set; }
    }
}
