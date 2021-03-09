using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LibraryWebApp
{
    public partial class Book
    {
        public Book()
        {
            Comments = new HashSet<Comment>();
            Descriptions = new HashSet<Description>();
            ListNotes = new HashSet<ListNote>();
            Publisheds = new HashSet<Published>();
            Wrotes = new HashSet<Wrote>();
        }

        public int Id { get; set; }
        [Display(Name = "Книга")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Name { get; set; }
        [Display(Name = "Рік написання")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int YearWritten { get; set; }
        [Display(Name = "ISBN")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int Isbn { get; set; }
        public int GenreId { get; set; }
        [Display(Name = "Жанр")]
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Description> Descriptions { get; set; }
        public virtual ICollection<ListNote> ListNotes { get; set; }
        public virtual ICollection<Published> Publisheds { get; set; }
        public virtual ICollection<Wrote> Wrotes { get; set; }
    }
}
