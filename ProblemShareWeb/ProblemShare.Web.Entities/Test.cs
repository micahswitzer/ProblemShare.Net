using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemShare.Web.Entities
{
    public class Test : Document
    {
        public ICollection<Problem> Problems { get; set; }
    }
}