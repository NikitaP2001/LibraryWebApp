using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LibraryWebApp
{
    public partial class Tag
    {
        public Tag()
        {
            Descriptions = new HashSet<Description>();
        }

        public int Id { get; set; }
        [Display(Name = "Тег")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Name { get; set; }
        [Display(Name = "Опис тегу")]
        public string Description { get; set; }

        public virtual ICollection<Description> Descriptions { get; set; }
    }
}
