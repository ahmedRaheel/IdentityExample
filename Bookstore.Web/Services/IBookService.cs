using Bookstore.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Web.Services
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetBooks();
        Task<BookDTO> GetBookById(long Id);
        Task<BookDTO> AddBook(BookDTO book);
        Task<BookDTO> UpdateBook(BookDTO book);
        Task DeleteBooks(long Id);
    }
}
