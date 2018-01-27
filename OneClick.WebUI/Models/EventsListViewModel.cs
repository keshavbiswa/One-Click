using OneClick.Domain._Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneClick.WebUI.Models
{
    public class EventsListViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set;}
    }
}