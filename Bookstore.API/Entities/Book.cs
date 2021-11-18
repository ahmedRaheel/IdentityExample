using System;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.API.Entities
{
    public class Book
    {
        public long Id { get; set; }

        [MaxLength(512)]
        public string Title { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        public DateTime PublishYear { get; set; }
        public Decimal Price { get; set; }       
    }
}
