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
    public class DocumentBO : IDocumentBO
    {
        public Guid Add(DocumentViewModel item, Guid institutionId)
        {
            using (var db = new PSContext())
            {
                // Create the new database object
                var dbItem = new Document()
                {
                    DocumentId = Guid.NewGuid(),
                    InstitutionId = institutionId,
                    Name = item.Name
                };

                db.Documents.Add(dbItem);

                db.SaveChanges();

                return dbItem.DocumentId;
            }
        }

        public bool Delete(Guid id, Guid institutionId)
        {
            using (var db = new PSContext())
            {
                var dbItem = db.Documents.Where(x => x.DocumentId == id && x.InstitutionId == institutionId).FirstOrDefault();

                if (dbItem != null)
                {
                    db.Documents.Remove(dbItem);

                    db.SaveChanges();

                    return true;
                }
                else return false;
            }
        }

        public DocumentViewModel Get(Guid id, Guid institutionId)
        {
            using (var db = new PSContext())
            {
                var dbItem = db.Documents.Where(x => x.DocumentId == id && x.InstitutionId == institutionId).FirstOrDefault();
                if (dbItem == null) return null;

                var vmItem = new DocumentViewModel()
                {
                    Id = dbItem.DocumentId,
                    Name = dbItem.Name
                };

                return vmItem;
            }
        }

        public List<DocumentViewModel> GetAll(Guid institutionId)
        {
            using (var db = new PSContext())
            {
                var dbItems = db.Documents.Where(x => x.InstitutionId == institutionId).ToList();
                var vmItems = new List<DocumentViewModel>();

                foreach (var dbItem in dbItems)
                {
                    var vmItem = new DocumentViewModel()
                    {
                        Id = dbItem.DocumentId,
                        Name = dbItem.Name
                    };
                    vmItems.Add(vmItem);
                }

                return vmItems;
            }
        }

        public bool Save(DocumentViewModel item, Guid institutionId)
        {
            using (var db = new PSContext())
            {
                // Try to get the item from the database
                var dbItem = db.Documents.Where(x => x.DocumentId == item.Id && x.InstitutionId == institutionId).FirstOrDefault();

                if (dbItem != null)
                {
                    // Update the properties
                    dbItem.Name = item.Name;

                    // Save changes to the database
                    db.SaveChanges();
                    return true;
                }
                // There was no matching item found
                else return false;
            }
        }
    }
}
