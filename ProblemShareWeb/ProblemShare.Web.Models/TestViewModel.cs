using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemShare.Web.Models
{
    public class TestViewModel : DocumentViewModel
    {
        public List<ProblemViewModel> Problems { get; set; }
    }
}