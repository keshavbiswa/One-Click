using OneClick.Domain.Abstract;
using OneClick.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneClick.WebUI.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        public int PageSize = 5;
        private readonly IEventRepository repository;
        public EventController(IEventRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string category, int page = 1)
        {
            EventsListViewModel model = new EventsListViewModel
            {
                Events = repository.Events
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.EventId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                                repository.Events.Count() :
                                repository.Events.Where(p => p.Category == category).Count()
                },
                CurrentCategory = category
                
            };
            return View(model);
        }
	}
}