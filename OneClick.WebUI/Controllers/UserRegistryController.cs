using OneClick.Domain._Entities;
using OneClick.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneClick.WebUI.Controllers
{
    public class UserRegistryController : Controller
    {
        private IUserRepository repository;

        public UserRegistryController(IUserRepository repo)
        {
            repository = repo;
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(User users)
        {
            if (ModelState.IsValid)
            {
                repository.saveUser(users);
                TempData["message"] = string.Format("{0} has been saved", users.UserName);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Somethings wrong with the data values need to remember before presentation
                return View(users);
            }

        }
        public ViewResult Edit (int userId)
        {
            User users = repository.users.FirstOrDefault(p => p.UserId == userId);
            
            return View (users);
        }
        [HttpPost]
        public ActionResult Edit(User users)
        {
            if (ModelState.IsValid)
            {
                repository.saveUser(users);
                TempData["message"] = string.Format("{0}'s profile has been changed", users.UserName);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Somethings wrong with the data values need to remember before presentation
                return View(users);
            }
        }
	}
}