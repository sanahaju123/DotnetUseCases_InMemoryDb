using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalParties.BusinessLayer.ViewModels
{
    public class RegisterDevelopmentViewModel
    {
        [Key]
        public long DevelopmentId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Minimum 3 Maximum 100 characters")]
        public string Title { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Minimum 3 Maximum 100 characters")]
        public string Activity { get; set; }
        [Required]
        
        public decimal Budget { get; set; }
        [Required]
        public long PoliticalLeaderId { get; set; }
        [Range(1, 12, ErrorMessage = "Month range is from 1 to 12")]
        public int ActivityMonth { get; set; }
        [Range(2021, 2040, ErrorMessage = "Month range is from 2021 to 2040")]
        public int ActivityYear { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
