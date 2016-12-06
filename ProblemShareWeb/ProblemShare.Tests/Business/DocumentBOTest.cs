using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemShare.Web.Models;
using ProblemShare.Web.Business;

namespace ProblemShare.Tests.Business
{
    [TestClass]
    public class DocumentBOTest
    {
        const string ORIGINL_NAME = "My Test Document";
        const string NEW_NAME = "My Test Document Updated";


        [TestMethod]
        public void Document_BO_Test1()
        {
            DocumentBO _docBO = new DocumentBO();
            Guid iId = new Guid("e4ca836a-14dd-4620-bf0b-91ba89450f96");

            DocumentViewModel vmItem = new DocumentViewModel()
            {
                Name = ORIGINL_NAME
            };

            Guid vmItemId = _docBO.Add(vmItem, iId);

            Assert.IsNotNull(vmItemId);
            Assert.AreNotEqual(Guid.Empty, vmItemId);

            vmItem.Id = vmItemId;
            vmItem.Name = NEW_NAME;

            bool result = _docBO.Save(vmItem, iId);

            Assert.IsTrue(result);

            string newName = _docBO.Get(vmItemId, iId).Name;

            Assert.AreEqual(NEW_NAME, newName);

            result = _docBO.Delete(vmItemId, iId);

            Assert.IsTrue(result);
        }
    }
}
