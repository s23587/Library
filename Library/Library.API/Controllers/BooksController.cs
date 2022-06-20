using Library.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        /*
         * Poniżej pseudo baza danych w razie gdyby chciał Pan sprawdzić program u siebie, ponieważ u mnie aplikacja pobiera dane z SSMS
         * 
         * List<Models.Domain.Book> books = new List<Models.Domain.Book>() {

                 new Models.Domain.Book{
                     id= Guid.NewGuid(),
                     title = "Przygody Mikołajka", 
                     year = 1960,
                     pages = 80,
                     author = "Rene Goscinny"
                 },

                 new Models.Domain.Book{
                     id= Guid.NewGuid(),
                     title = "Chlopcy z placu broni",
                     year = 1878,
                     pages = 200,
                     author = "Ferenc Molnar"
                 },

                 new Models.Domain.Book{
                     id= Guid.NewGuid(),
                     title = "Quo Vadis",
                     year = 1896,
                     pages = 2000,
                     author = "Henryk Sienkiewicz"
                 },

                 new Models.Domain.Book{
                     id= Guid.NewGuid(),
                     title = "W pustyni i w puszczy",
                     year = 1911,
                     pages = 1000,
                     author = "Henryk Sienkiewicz"
                 },

                 new Models.Domain.Book{
                     id= Guid.NewGuid(),
                     title = "Kamienie na Szaniec",
                     year = 1943,
                     pages = 400,
                     author = "Aleksander Kamiński"
                 }
             };*/

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {

            var books = bookRepository.GetAllBooks();
            var booksDTO = new List<Models.DTO.Book>();

            books.ToList().ForEach(book =>
            {
                var bookDTO = new Models.DTO.Book()
                {
                    id = book.id,
                    title = book.title,
                    year = book.year,
                    pages = book.pages,
                    author = book.author
                };

                booksDTO.Add(bookDTO);
            });

            return Ok(books);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetBookById(Guid id)
        {
            var book = bookRepository.GetBookById(id);
            var bookDTO = new Models.DTO.Book()
            {
                id = book.id,
                title = book.title,
                year = book.year,
                pages = book.pages,
                author = book.author
            };


            return Ok(bookDTO);
        }
        
        [HttpGet]
        [Route("{author}")]
        public IActionResult GetAuthorBooks(string author)
        {
            var books = bookRepository.GetAuthorBooks(author);
            var booksDTO = new List<Models.DTO.Book>();

            books.ToList().ForEach(book =>
            {
                if (book.author == author)
                {

                    var bookDTO = new Models.DTO.Book()
                    {
                        id = book.id,
                        title = book.title,
                        year = book.year,
                        pages = book.pages,
                        author = book.author
                    };

                    booksDTO.Add(bookDTO);
                }
            });

            return Ok(booksDTO);
        }


    }
}
