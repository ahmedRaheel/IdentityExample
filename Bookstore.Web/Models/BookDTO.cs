using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Web.Models
{
    public class BookDTO
    {
        public long Id { get; set; }        
        public string Title { get; set; }       
        public string Description { get; set; }
        public DateTime PublishYear { get; set; }
        public Decimal Price { get; set; }
    }
}
