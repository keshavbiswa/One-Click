using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Helpers;
using System.ComponentModel;


namespace OneClick.Domain._Entities
{
    public class Note
    {
        [HiddenInput(DisplayValue = false)]
        public int NoteId { get; set; }
        [Required(ErrorMessage = "Please enter an event name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage="Please enter the Date and Time ")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd 0:hh:MM}", ApplyFormatInEditMode = true)]
        public float DateTime { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }
        public int Download { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }
        public virtual User users { get; set; }
        public int FileId { get; set; }
        public virtual ICollection<File> Files { get; set; }
       }
}
