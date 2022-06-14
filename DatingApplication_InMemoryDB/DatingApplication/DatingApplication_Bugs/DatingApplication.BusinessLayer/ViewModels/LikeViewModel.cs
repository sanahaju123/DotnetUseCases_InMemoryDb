using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.BusinessLayer.ViewModels
{
    public class LikeViewModel
    {
        [Key]
        public long LikeId { get; set; }
        [Required]
        public long UserId { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
