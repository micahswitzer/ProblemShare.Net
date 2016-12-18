using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemShare.Web.Models;
using ProblemShare.Web.Business;
using System.Collections.Generic;
using ProblemShare.Web.Interface;

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

            _docBO.Add(vmItem, iId);

            Assert.IsNotNull(vmItem.Id);
            Assert.AreNotEqual(Guid.Empty, vmItem.Id);

            vmItem.Name = NEW_NAME;

            bool result = _docBO.Save(vmItem, iId);

            Assert.IsTrue(result);

            string newName = _docBO.Get(vmItem.Id, iId).Name;

            Assert.AreEqual(NEW_NAME, newName);

            result = _docBO.Delete(vmItem.Id, iId);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Document_BO_Test2()
        {
            IDocumentBO _docBO = new DocumentBO();
            IProblemBO _probBO = new ProblemBO();
            Guid iId = new Guid("e4ca836a-14dd-4620-bf0b-91ba89450f96");

            ProblemViewModel problem = new ProblemViewModel()
            {
                Number = 1,
                Content = "Test Number 1"
            };

            TestViewModel testVm = new TestViewModel()
            {
                Name = ORIGINL_NAME,
                Description = "Blah"
            };

            _docBO.Add(testVm, iId);
            _probBO.AddToCollection(problem, testVm.Id, iId);

            Assert.Inconclusive();
        }
    }
}
