using System;

namespace Mission9_DexterStephens.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set;}
        public int CurrentPage { get; set;}
        public int TotalPages => (int)Math.Ceiling(((double)TotalNumBooks / BooksPerPage));

        public PageInfo(int totalNumBooks, int booksPerPage, int currentPage)
        {
            TotalNumBooks = totalNumBooks;
            BooksPerPage = booksPerPage;
            CurrentPage = currentPage;
        }
    }
}
