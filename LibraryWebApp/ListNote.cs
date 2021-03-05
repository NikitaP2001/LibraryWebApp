using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LibraryWebApp
{
    public partial class ListNote
    {
        public int Id { get; set; }
        [Display(Name = "Статус")]
        public bool Status { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
