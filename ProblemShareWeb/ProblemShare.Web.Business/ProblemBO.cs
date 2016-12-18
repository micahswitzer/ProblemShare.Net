using ProblemShare.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProblemShare.Web.Models;
using ProblemShare.Web.Entities;

namespace ProblemShare.Web.Business
{
    public class ProblemBO : IProblemBO
    {
        public void AddToCollection(ProblemViewModel item, Guid parentId, Guid institutionId)
        {
            if (item == null) throw new InvalidModelException();
            using (var db = new PSContext())
            {
                var dbParent = db.Tests.Where(x => x.DocumentId == parentId && x.InstitutionId == institutionId).FirstOrDefault();
                if (dbParent == null) throw new ArgumentException("Unable to find a matching test to assign the problem to");

                Problem dbItem = new Problem()
                {
                    Number = item.Number,
                    Body = item.Content
                };

                dbParent.Problems.Add(dbItem);

                db.SaveChanges();

                item.Id = dbItem.ProblemId;
            }
        }

        public ICollection<ProblemViewModel> GetAllForParent(Guid parentId, Guid institutionId)
        {
            using(var db = new PSContext())
            {
                var dbParent = db.Tests.Where(x => x.DocumentId == parentId && x.InstitutionId == institutionId).FirstOrDefault();
                if (dbParent == null) throw new ArgumentException("Unable to find matching parent item in database");

                return dbParent.Problems.Select(x => dbItemToViewModel(x)).ToList();
            }
        }

        public ProblemViewModel GetItem(Guid itemId, Guid institutionId)
        {
            using (var db = new PSContext())
            {
                var dbItem = db.Problems.Where(x => x.ProblemId == itemId && x.Test.InstitutionId == institutionId).FirstOrDefault();
                if (dbItem == null) return null;

                return dbItemToViewModel(dbItem);
            }
        }

        public bool RemoveItem(Guid itemId, Guid institutionId)
        {
            using (var db = new PSContext())
            {
                var dbItem = db.Problems.Where(x => x.ProblemId == itemId && x.Test.InstitutionId == institutionId).FirstOrDefault();
                if (dbItem == null) return false;

                db.Problems.Remove(dbItem);

                db.SaveChanges();

                return true;
            }
        }

        public bool UpdateItem(ProblemViewModel item, Guid institutionId)
        {
            if (item == null) return false;
            using (var db = new PSContext())
            {
                var dbItem = db.Problems.Where(x => x.ProblemId == item.Id && x.Test.InstitutionId == institutionId).FirstOrDefault();
                if (dbItem == null) return false;

                dbItem.Number = item.Number;
                dbItem.Body = item.Content;

                db.SaveChanges();

                return true;
            }
        }

        private ProblemViewModel dbItemToViewModel(Problem dbItem)
        {
            ProblemViewModel vmItem = new ProblemViewModel()
            {
                Id = dbItem.ProblemId,
                Number = dbItem.Number,
                Content = dbItem.Body
            };
            return vmItem;
        }
    }
}
