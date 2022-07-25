using Library.DAL;
using Library.Model;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        LbraryRepository lb = new LbraryRepository();
        ISBN isbn = new ISBN();
        Book b1 = new Book("name",DateTime.Now);
        [TestMethod]
        public void TestMethod1()
        {
            Book b1 = new Book("name", DateTime.Now);
            Book b2 = new Book("name", DateTime.Now);
            Assert.IsTrue(b1.Equals(b2));
        }
    }
}
