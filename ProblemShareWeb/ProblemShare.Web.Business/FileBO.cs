using System;
using System.Collections.Generic;
using System.Linq;
using ProblemShare.Web.Entities;
using ProblemShare.Web.Interface;
using ProblemShare.Web.Models;

namespace ProblemShare.Web.Business
{
    public class FileBO : BO, IFileBO
    {
        public void Add(FileViewModel item, Guid institutionId)
        {
            using (var db = Context)
            {
                //var dbItem = new File()
                //{
                //    InstitutionId = institutionId,
                //    MimeType = item.MimeType,
                //    Name = item.Name,
                //    UserId = item.OwnerId,
                //    Path = item.
                //};
            }
        }

        public bool Delete(Guid id, Guid institutionId)
        {
            using (var db = Context)
            {
                throw new NotImplementedException();
            }
        }

        public FileViewModel Get(Guid id, Guid institutionId)
        {
            using (var db = Context)
            {
                return fileFromDb(db.Files.FirstOrDefault(x => x.InstitutionId == institutionId && x.FileId == id));
            }
        }
        
        public ICollection<FileViewModel> GetAll(Guid institutionId)
        {
            using (var db = Context)
            {
                return db.Files.Where(x => x.InstitutionId == institutionId).Select(fileFromDb).ToList();
            }
        }

        public bool Save(FileViewModel item, Guid institutionId)
        {
            using (var db = Context)
            {
                throw new NotImplementedException();
            }
        }

        private static FileViewModel fileFromDb(File file)
        {
            var item = new FileViewModel()
            {

            };
            return null;
        }
    }
}