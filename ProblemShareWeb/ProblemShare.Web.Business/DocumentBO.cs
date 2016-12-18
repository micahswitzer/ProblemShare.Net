﻿using ProblemShare.Web.Interface;
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
        public void Add(DocumentViewModel item, Guid institutionId)
        {
            if (item == null) throw new InvalidModelException();
            using (var db = new PSContext())
            {
                // Create the new database object
                var dbItem = createDocumentFromViewModel(item);
                dbItem.InstitutionId = institutionId; // Assign it to the correct institution

                db.Documents.Add(dbItem);

                db.SaveChanges();

                // We don't need to explicitly set the new Id because the database handles that for us
                item.Id = dbItem.DocumentId; // Simply update the view model object with the new Id
            }
        }

        public bool Delete(Guid id, Guid institutionId)
        {
            using (var db = new PSContext())
            {
                var dbItem = db.Documents.Where(x => x.DocumentId == id && x.Institution.InstitutionId == institutionId).FirstOrDefault();

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
                var dbItem = db.Documents.Where(x => x.DocumentId == id && x.Institution.InstitutionId == institutionId).FirstOrDefault();
                if (dbItem == null) return null;

                var vmItem = new DocumentViewModel()
                {
                    Id = dbItem.DocumentId,
                    Name = dbItem.Name
                };

                return vmItem;
            }
        }

        public ICollection<DocumentViewModel> GetAll(Guid institutionId)
        {
            using (var db = new PSContext())
            {
                var dbItems = db.Documents.Where(x => x.Institution.InstitutionId == institutionId).ToList();
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
                var dbItem = db.Documents.Where(x => x.DocumentId == item.Id && x.Institution.InstitutionId == institutionId).FirstOrDefault();

                if (dbItem != null)
                {
                    // Update the properties
                    updateDocumentFromViewModel(item, dbItem);

                    // Save changes to the database
                    db.SaveChanges();
                    return true;
                }
                // There was no matching item found
                else return false;
            }
        }

        private Document createDocumentFromViewModel(DocumentViewModel item)
        {
            if (item == null) return null; // Return right away if we have a null value
            Document dbDoc = new Document() // Create our new database object will all of the base values
            {
                DocumentId = item.Id,
                Name = item.Name 
            };
            // Perform class specific operations here
            if (item is TestViewModel) // use the 'is' operator to determine if item fits the more specific type
            {
                Test dbTest = dbDoc as Test;
                dbTest.Problems = new List<Problem>(); // Don't have any problems when the test is first created
                return dbTest;
            }
            else return dbDoc; // Just return the good 'ol document class because we don't have anything special
        }

        /// <summary>
        /// Updates an item in the database based on the corresponding view model
        /// </summary>
        /// <param name="item">The view model to update from</param>
        /// <param name="dbItem">The database item to update</param>
        private void updateDocumentFromViewModel(DocumentViewModel item, Document dbItem)
        {
            if (item == null || dbItem == null) throw new ArgumentNullException(); // Return right away if either variable is null

            // Update base properties
            dbItem.Name = item.Name;

            if ((item is TestViewModel) && (dbItem is Test))
            {
                var dbTest = dbItem as Test;

                // Make specific update
            }

            // Nothing to return, dbItem has been updated already (just don't forget to db.SaveChanges()!)
        }
    }
}