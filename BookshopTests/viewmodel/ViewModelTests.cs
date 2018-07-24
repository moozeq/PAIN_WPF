using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bookshop;
using System.Collections.ObjectModel;

namespace BookshopTests
{
    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        public void AddAndViewTest()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            Book book1 = new Book("Hello World", "Gal Anonim", 12042491, new DateTime(2019, 12, 20), Category.Crime);
            Book book2 = new Book("Hello Guy", "Adam Malysz", 2333424, new DateTime(2015, 12, 20), Category.Poetry);
            Book book3 = new Book("Hello May", "Matejko Jan", 1252525, new DateTime(2013, 12, 20), Category.Fantasy);

            viewModel.Model.AddBook(book1);
            viewModel.Model.AddBook(book2);
            viewModel.Model.AddBook(book3);

            Book book11 = viewModel.Books[0];
            Book book21 = viewModel.Books[1];
            Book book31 = viewModel.Books[2];

            Assert.IsTrue(book11.Title == "Hello World" && book11.Author == "Gal Anonim" && book11.ISBN == 12042491 && book11.Category == Category.Crime && book11.Published.Year == 2019);
            Assert.IsTrue(book21.Title == "Hello Guy" && book21.Author == "Adam Malysz" && book21.ISBN == 2333424 && book21.Category == Category.Poetry && book21.Published.Year == 2015);
            Assert.IsTrue(book31.Title == "Hello May" && book31.Author == "Matejko Jan" && book31.ISBN == 1252525 && book31.Category == Category.Fantasy && book31.Published.Year == 2013);

            
        }

        [TestMethod]
        public void FilterTest()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            Book book1 = new Book("Hello World", "Gal Anonim", 12042491, new DateTime(2019, 12, 20), Category.Crime);
            Book book2 = new Book("Hello Guy", "Adam Malysz", 2333424, new DateTime(2015, 12, 20), Category.Poetry);
            Book book3 = new Book("Hello May", "Matejko Jan", 1252525, new DateTime(2013, 12, 20), Category.Fantasy);

            viewModel.Model.AddBook(book1);
            viewModel.Model.AddBook(book2);
            viewModel.Model.AddBook(book3);

            viewModel.Filter = 2016;
            viewModel.FilterBefore = true;
            viewModel.FilterActive = true;
            Assert.IsTrue(viewModel.BooksViewSource.View.Contains(book2));
            Assert.IsTrue(viewModel.BooksViewSource.View.Contains(book3));
            Assert.IsFalse(viewModel.BooksViewSource.View.Contains(book1));

            viewModel.FilterBefore = false;
            Assert.IsFalse(viewModel.BooksViewSource.View.Contains(book2));
            Assert.IsFalse(viewModel.BooksViewSource.View.Contains(book3));
            Assert.IsTrue(viewModel.BooksViewSource.View.Contains(book1));
        }
    }
}
