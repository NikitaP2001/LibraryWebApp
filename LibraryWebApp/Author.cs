using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LibraryWebApp
{
    public partial class Author
    {
        public Author()
        {
            Wrotes = new HashSet<Wrote>();
        }

        public int Id { get; set; }
        [Display(Name = "Автор")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Name { get; set; }
        [Display(Name = "Інформація про автора")]
        public string Info { get; set; }

        public virtual ICollection<Wrote> Wrotes { get; set; }
    }
}
