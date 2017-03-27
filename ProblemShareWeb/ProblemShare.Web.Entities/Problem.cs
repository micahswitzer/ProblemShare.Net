using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemShare.Web.Entities
{
    public class Problem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProblemId { get; set; }
        public Guid DocumentId { get; set; }
        [ForeignKey("DocumentId")]
        public virtual Test Test { get; set; }
        public int Number { get; set; }
        public string Body { get; set; }
    }
}