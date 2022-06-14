using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.BusinessLayer.ViewModels
{
    public class DislikeViewModel
    {
        [Key]
        public long DislikeId { get; set; }

        [Required]
        public long UserId { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
