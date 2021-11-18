using Bookstore.EnterpriseLibrary.Constants;
using Bookstore.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bookstore.Web.Services
{
    public class BookService : BaseHttpClient, IBookService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<BookService> _logger;

        public BookService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor,
                           ILogger<BookService> logger) :   base(httpClientFactory)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<BookDTO> AddBook(BookDTO book)
        {
           return  await Execute<BookDTO>(HttpMethod.Post, Url.Books, book);
        }

        public async Task DeleteBooks(long Id)
        {
            await Execute<BookDTO>(HttpMethod.Delete, string.Format(Url.Books_Id, Id), default);
        }

        public async Task<BookDTO> GetBookById(long Id)
        {
            return await Execute<BookDTO>(HttpMethod.Get, string.Format(Url.Books_Id, Id), default);
        }

        public async Task<List<BookDTO>> GetBooks()
        {
           return  await Execute<List<BookDTO>>(HttpMethod.Get, Url.Books , default);
        }

        public async Task<BookDTO> UpdateBook(BookDTO book)
        {
            return await Execute<BookDTO>(HttpMethod.Put, Url.Books, book);
        }
    }
}
