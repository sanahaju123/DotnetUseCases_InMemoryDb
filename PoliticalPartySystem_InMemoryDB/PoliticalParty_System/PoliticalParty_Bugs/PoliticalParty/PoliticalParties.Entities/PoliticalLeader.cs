using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalParties.Entities
{
    public class PoliticalLeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PoliticalLeaderId { get; set; }
        public string CandidateName { get; set; }
        public string StateName { get; set; }
        public long PoliticalPartyId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
