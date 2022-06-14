using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DatingApplication.BusinessLayer.ViewModels
{
    public class MatchViewModel
    {
        [Key]
        public long MatchId { get; set; }
        [Required]
        public long UserId { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
