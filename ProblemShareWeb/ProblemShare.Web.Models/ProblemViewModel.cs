using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemShare.Web.Models
{
    public class ProblemViewModel
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Content { get; set; }
    }
}
