using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bookstore.API.Entities;

namespace Bookstore.API.Data
{
    public class BookstoreAPIContext : DbContext
    {
        public BookstoreAPIContext (DbContextOptions<BookstoreAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Bookstore.API.Entities.Book> Book { get; set; }
    }
}
