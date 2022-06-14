using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalParties.Entities
{
    public class Development
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DevelopmentId { get; set; }
        public string Title { get; set; }
        public string Activity { get; set; }
        public decimal Budget { get; set; }
        public long PoliticalLeaderId { get; set; }
        public int ActivityMonth { get; set; }
        public int ActivityYear { get; set; }
        public bool IsDeleted { get; set; }
    }
}
