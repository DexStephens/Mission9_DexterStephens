using System.Linq;

namespace Mission9_DexterStephens.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext Context { get; set; }
        public EFBookstoreRepository(BookstoreContext context)
        {
            Context = context;
        }
        public IQueryable<Books> Books => Context.Books;
    }
}
