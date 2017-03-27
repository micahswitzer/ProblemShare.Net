using ProblemShare.Web.Entities;
using ProblemShare.Web.Interface;
using ProblemShare.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemShare.Web.Business
{
    public class ProblemBO : BO, IProblemBO
    {
        public void AddToCollection(ProblemViewModel item, Guid parentId, Guid institutionId)
        {
            if (item == null) throw new InvalidModelException();
            using (var db = Context)
            {
                var dbParent = db.Tests.FirstOrDefault(x => x.DocumentId == parentId && x.InstitutionId == institutionId);
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
            using (var db = Context)
            {
                var dbParent = db.Tests.FirstOrDefault(x => x.DocumentId == parentId && x.InstitutionId == institutionId);
                if (dbParent == null) throw new ArgumentException("Unable to find matching parent item in database");

                return dbParent.Problems.Select(dbItemToViewModel).ToList();
            }
        }

        public ProblemViewModel GetItem(Guid itemId, Guid institutionId)
        {
            using (var db = Context)
            {
                var dbItem = db.Problems.FirstOrDefault(x => x.ProblemId == itemId && x.Test.InstitutionId == institutionId);
                return dbItem == null ? null : dbItemToViewModel(dbItem);
            }
        }

        public bool RemoveItem(Guid itemId, Guid institutionId)
        {
            using (var db = Context)
            {
                var dbItem = db.Problems.FirstOrDefault(x => x.ProblemId == itemId && x.Test.InstitutionId == institutionId);
                if (dbItem == null) return false;

                db.Problems.Remove(dbItem);

                db.SaveChanges();

                return true;
            }
        }

        public bool UpdateItem(ProblemViewModel item, Guid institutionId)
        {
            if (item == null) return false;
            using (var db = Context)
            {
                var dbItem = db.Problems.FirstOrDefault(x => x.ProblemId == item.Id && x.Test.InstitutionId == institutionId);
                if (dbItem == null) return false;

                dbItem.Number = item.Number;
                dbItem.Body = item.Content;

                db.SaveChanges();

                return true;
            }
        }

        private static ProblemViewModel dbItemToViewModel(Problem dbItem)
        {
            var vmItem = new ProblemViewModel()
            {
                Id = dbItem.ProblemId,
                Number = dbItem.Number,
                Content = dbItem.Body
            };
            return vmItem;
        }
    }
}
