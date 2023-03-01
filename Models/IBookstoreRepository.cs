using System.Linq;

namespace Mission9_DexterStephens.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Books> Books { get; }
    }
}
