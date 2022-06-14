using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalParties.BusinessLayer.ViewModels
{
    public class RegisterPoliticalLeaderViewModel
    {
        [Key]
        public long PoliticalLeaderId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Minimum 3 Maximum 100 characters")]
        public string CandidateName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Minimum 3 Maximum 100 characters")]
        public string StateName { get; set; }
        [Required]
        public long PoliticalPartyId { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
