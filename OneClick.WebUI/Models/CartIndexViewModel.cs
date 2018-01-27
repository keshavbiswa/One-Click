using OneClick.Domain._Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneClick.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}