
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
        #region ISBN Unit Test
        readonly LbraryRepository lb = new LbraryRepository();

        [TestMethod]
        public void GetLibraryItemsList()
        {
            Assert.IsTrue(lb.Get(Guid.Empty) == null);
        }



        #endregion
    }
}
