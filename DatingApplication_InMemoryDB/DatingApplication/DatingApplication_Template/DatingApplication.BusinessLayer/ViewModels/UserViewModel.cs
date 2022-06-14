using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.BusinessLayer.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public long UserId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Maximum 100 characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 18, ErrorMessage = "Min Age is 18 and Maximum Age is 0")]
        public int Age { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Maximum 100 characters")]
        public string Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Should be 10 digit only")]
        public string Phone { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
