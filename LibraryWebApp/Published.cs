using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LibraryWebApp
{
    public partial class Published
    {
        public int Id { get; set; }
        [Display(Name = "Видавництво")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Office { get; set; }
        [Display(Name = "РІк видання")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int Year { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
