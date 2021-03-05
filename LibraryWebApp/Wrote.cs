﻿using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryWebApp
{
    public partial class Wrote
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
