using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemShare.Web.Entities
{
    public class Institution
    {
        public Guid InstitutionId { get; set; }
        public string Name { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
