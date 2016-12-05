using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemShare.Web.Models;
using ProblemShare.Web.Business;

namespace ProblemShare.Tests.Business
{
    [TestClass]
    public class DocumentBOTest
    {
        DocumentBO _docBO;
        DocumentViewModel _doc;
        Guid _institutionId;

        [TestInitialize]
        public void Init()
        {
            _docBO = new DocumentBO();
            _doc = new DocumentViewModel() { Name = "TestDocument" };
            _institutionId = Guid.NewGuid();
        }

        [TestCleanup]
        public void cleanup()
        {
            _doc = null;
            _docBO = null;
        }

        [TestMethod]
        public void Add()
        {
            _doc.Id = _docBO.Save(_doc, _institutionId);

            Assert.IsNotNull(_doc.Id);
            Assert.IsFalse(_doc.Id == Guid.Empty);
        }

        [TestMethod]
        public void Save()
        {
            _doc.Name = "RenamedTestDocument";

            Guid resId = _docBO.Save(_doc, _institutionId);

            Assert.AreEqual(_doc.Id, resId);
        }

        [TestMethod]
        public void Load()
        {
            DocumentViewModel _doc2;

            _doc2 = _docBO.Load(_doc.Id);

            Assert.AreEqual(_doc, _doc2);
        }

        [TestMethod]
        public void Delete()
        {
            bool result;

            result = _docBO.Delete(_doc.Id, _institutionId);

            Assert.IsTrue(result);
        }
    }
}
