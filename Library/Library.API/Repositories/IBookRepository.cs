using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Models.Domain.Book> GetAllBooks();
        IEnumerable<Models.Domain.Book> GetAuthorBooks(string author);

        Models.Domain.Book GetBookById(Guid id);
    }
}
