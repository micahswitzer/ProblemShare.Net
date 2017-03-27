using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemShare.Web.Business
{
    public class InvalidModelException : ArgumentException
    {
        public InvalidModelException(string message = "The model provided was not valid (is it null?)")
            : base(message, "item", null)
        {

        }
    }
}
