using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bookshop;
using System.Collections.ObjectModel;

namespace BookshopTests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void AddAndDeleteTest()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            BooksMgmt model = viewModel.Model;
            Book book1 = new Book("Hello World", "Gal Anonim", 12042491, new DateTime(2019, 12, 20), Category.Crime);
            Book book2 = new Book("Hello Guy", "Adam Malysz", 2333424, new DateTime(2015, 12, 20), Category.Poetry);
            Book book3 = new Book("Hello May", "Matejko Jan", 1252525, new DateTime(2013, 12, 20), Category.Fantasy);

            model.AddBook(book1);
            model.AddBook(book2);
            model.AddBook(book3);

            Assert.IsTrue(model.GetBooks().Contains(book1));
            Assert.IsTrue(model.GetBooks().Contains(book2));
            Assert.IsTrue(model.GetBooks().Contains(book3));

            model.DeleteBook(book1);

            Assert.IsFalse(model.GetBooks().Contains(book1));
            Assert.IsTrue(model.GetBooks().Contains(book2));
            Assert.IsTrue(model.GetBooks().Contains(book3));

            model.DeleteBook(book2);

            Assert.IsFalse(model.GetBooks().Contains(book1));
            Assert.IsFalse(model.GetBooks().Contains(book2));
            Assert.IsTrue(model.GetBooks().Contains(book3));

            model.DeleteBook(book3);

            Assert.IsFalse(model.GetBooks().Contains(book1));
            Assert.IsFalse(model.GetBooks().Contains(book2));
            Assert.IsFalse(model.GetBooks().Contains(book3));
        }
    }
}
