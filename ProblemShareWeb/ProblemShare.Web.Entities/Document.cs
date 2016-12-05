using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemShare.Web.Entities
{
    public class Document
    {
        public Guid DocumentId { get; set; }
        public string Name { get; set; }
        public Guid InstitutionId { get; set; }
        public Institution Institution { get; set; }
    }
}
