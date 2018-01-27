using OneClick.Domain._Entities;
using OneClick.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneClick.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IEventRepository repository;

        public AdminController(IEventRepository repo)
        {
            repository = repo;
        }
        public ActionResult Index()
        {
            return View(repository.Events);
        }
        public ViewResult Create()
        {
            return View(new Event());
        }
        [HttpPost]
        public ActionResult Create (Event events)
        {
            if (ModelState.IsValid)
            {
                repository.SaveEvent(events);
                TempData["message"] = string.Format("{0} has been saved", events.Name);
                return RedirectToAction("Index");
            }
            else
            {
                //Somethings wrong with the data values need to remember before presentation
                return View(events);
            }
        }

        [HttpPost]
        public ActionResult Delete (int eventId)
        {
            Event deletedEvent = repository.DeleteEvent(eventId);
            if(deletedEvent != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedEvent.Name);
            }
            return RedirectToAction("Index");
        }
        
        public ViewResult Edit (int eventId)
        {
            Event events = repository.Events.FirstOrDefault(p => p.EventId == eventId);
            
            return View (events);
        }
        [HttpPost]
        public ActionResult Edit(Event events)
        {
            if(ModelState.IsValid)
            {
                repository.SaveEvent(events);
                TempData["message"] = string.Format("{0} has been saved", events.Name);
                return RedirectToAction("Index");
            }
            else
            {
                //Somethings wrong with the data values need to remember before presentation
                return View(events);
            }
        }

    }  
            
}
	
