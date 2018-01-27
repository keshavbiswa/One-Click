using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneClick.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="User name is required")]
        public string Username { get; set; }
        [Required(ErrorMessage="Password is required")]
        [StringLength(50,MinimumLength=6)]
        public string Password { get; set; }

    }
}