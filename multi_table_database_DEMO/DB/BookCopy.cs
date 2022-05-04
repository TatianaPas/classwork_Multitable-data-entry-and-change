using System;
using System.Collections.Generic;

namespace multi_table_database_DEMO.DB
{
    public partial class BookCopy
    {
        public int BookCopyId { get; set; }
        public string CopyNumber { get; set; } = null!;
        public string? Edition { get; set; }
        public int PublicationYear { get; set; }
        public string Isbn { get; set; } = null!;
        public string BookStatus { get; set; } = null!;
        public int BookTitleId { get; set; }

        public virtual BookTitle BookTitle { get; set; } = null!;
    }
}
