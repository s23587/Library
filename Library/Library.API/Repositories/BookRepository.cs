using Library.API.Data;
using Library.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookRepository(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return libraryDbContext.Books.ToList();
        }

        public IEnumerable<Book> GetAuthorBooks(string author)
        {
            return libraryDbContext.Books.ToList();
        }

        public Book GetBookById(Guid id)
        {
            return libraryDbContext.Books.FirstOrDefault(x => x.id == id);
        }
    }
}
