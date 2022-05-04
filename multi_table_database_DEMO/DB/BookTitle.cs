using System;
using System.Collections.Generic;

namespace multi_table_database_DEMO.DB
{
    public partial class BookTitle
    {
        public BookTitle()
        {
            BookCopies = new HashSet<BookCopy>();
        }

        public int BookTitleId { get; set; }
        public string Author { get; set; } = null!;
        public string Publisher { get; set; } = null!;

        public virtual ICollection<BookCopy> BookCopies { get; set; }
    }
}
