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
        public bool Delete(Guid id, Guid institutionId)
        {
            throw new NotImplementedException();
        }

        public DocumentViewModel Load(Guid id)
        {
            throw new NotImplementedException();
        }

        public Guid Save(DocumentViewModel document, Guid institutionId)
        {
            using (var db = new PSContext())
            {
                var dbItemNew = new Document()
                {
                    DocumentId = document.Id,
                    InstitutionId = institutionId,
                    Name = document.Name
                };

                var dbItem = db.Documents.Where(x => x.DocumentId == document.Id).FirstOrDefault();

                if (dbItem != null)
                {
                    dbItem = dbItemNew;
                }
                else
                {
                    dbItemNew.DocumentId = Guid.NewGuid();
                    db.Documents.Add(dbItemNew);
                }

                db.SaveChanges();

                return dbItemNew.DocumentId;
            }
        }
    }
}
