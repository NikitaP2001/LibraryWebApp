using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryWebApp
{
    public partial class Description
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
