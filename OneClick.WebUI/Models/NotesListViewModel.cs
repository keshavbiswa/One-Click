using OneClick.Domain._Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OneClick.WebUI.Models
{
    public class NotesListViewModel
    {
        public IEnumerable<Note> Notes { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }        
    }
}