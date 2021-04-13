using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LibraryWebApp
{
    public partial class Reader
    {
        public Reader()
        {
            Comments = new HashSet<Comment>();
            ListNotes = new HashSet<ListNote>();
        }

        public int Id { get; set; }
        [Display(Name = "Логін")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Login { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Password { get; set; }
        public string img { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ListNote> ListNotes { get; set; }
    }
}
