using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemShare.Web.Interface
{
    public interface IUserBO
    {
        Guid? GetInstitutionIdForUser(Guid userId);
        Guid? GetUserIdForUsername(string userName);
    }
}