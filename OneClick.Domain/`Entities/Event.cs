using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace OneClick.Domain._Entities
{
    public class Event
    {
        [HiddenInput(DisplayValue = false)]
        public int EventId { get; set; }
        [Required(ErrorMessage="Please enter an event name")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Range(.01, double.MaxValue, ErrorMessage = "Please enter thg")]
        public double Time { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }        
    }
}
