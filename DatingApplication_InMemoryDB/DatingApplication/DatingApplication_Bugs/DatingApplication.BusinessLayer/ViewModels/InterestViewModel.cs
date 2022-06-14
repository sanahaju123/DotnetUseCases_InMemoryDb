using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.BusinessLayer.ViewModels
{
    public class InterestViewModel
    {
        [Key]
        public long InterestId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Maximum 100 characters")]
        public string InterestedIn { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Maximum 100 characters")]
        public string NotInterestedIn { get; set; }
        [Required]
        public string Hobbies { get; set; }
        [Required]
        public string ProfileUrl { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Maximum 100 characters")]
        public string About { get; set; }
        [Required]
        public long UserId { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
