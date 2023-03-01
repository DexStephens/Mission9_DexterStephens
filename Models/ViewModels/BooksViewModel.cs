using System.Linq;

namespace Mission9_DexterStephens.Models.ViewModels
{
    public class BooksViewModel
    {
        public IQueryable<Books> Books { get; set; }
        public PageInfo PageInfo { get; set; }

        public BooksViewModel(IQueryable<Books> books, PageInfo pageInfo)
        {
            Books = books;
            PageInfo = pageInfo;
        }
    }
}
