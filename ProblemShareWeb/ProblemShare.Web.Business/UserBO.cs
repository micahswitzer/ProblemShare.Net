using ProblemShare.Web.Entities;
using ProblemShare.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemShare.Web.Business
{
    public class UserBO : IUserBO
    {
        public Guid? GetInstitutionIdForUser(Guid userId)
        {
            using (var db = new PSContext())
            {
                return db.Users.Where(x => x.UserId == userId).Select(x => (Guid?)x.InstitutionId).FirstOrDefault();
            }
        }

        public Guid? GetUserIdForUsername(string userName)
        {
            using (var db = new PSContext())
            {
                return db.Users.Where(x => x.UserName == userName).Select(x => (Guid?)x.UserId).FirstOrDefault();
            }
        }
    }
}
