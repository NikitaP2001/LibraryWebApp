using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LibraryWebApp
{
    public partial class Comment
    {
        public int Id { get; set; }
        [Display(Name = "Текст коментаря")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Text { get; set; }
        public int BookId { get; set; }
        public int ReaderId { get; set; }
        public string ReaderName { get; set; }
        [Display(Name = "Дата написання")]
        public DateTime DateWritten { get; set; }

        public virtual Book Book { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
