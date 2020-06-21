using System;
using System.Collections.Generic;

namespace Test
{
    public partial class BookCategory
    {
        public BookCategory()
        {
            Book = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
