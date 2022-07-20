
using System;
using System.Collections.Generic;
using Library.DAL;
using Library.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        #region Library Repositor Unit Test
        readonly LbraryRepository lb = new LbraryRepository();
        readonly DataMock dm = new DataMock();
        Book b1 = new Book("", DateTime.Now, "adwq");

        [TestMethod]
        public void GetLibraryItem()
        {
            Assert.IsTrue(lb.Get(Guid.Empty) == null);
        }

        [TestMethod]
        public void GetLibraryItemsList()
        {
            Assert.IsTrue(lb.Get() == dm.LibraryItemsList);
        }

        [TestMethod]
        public void AddLibraryItemsToList()
        {

            Assert.IsNotNull(lb.Add((LibraryItem)b1));
        }

        [TestMethod]
        public void GetLibreryItemById()
        {
            Guid id = b1.Id;
            Assert.IsTrue(lb.Get(id) == b1);
        }

        [TestMethod]
        public void UpddateLibraryItem()
        {
            b1.Title = "1111";
            Assert.IsTrue(lb.Update(b1) == b1);
        }

        #endregion
    }
}
