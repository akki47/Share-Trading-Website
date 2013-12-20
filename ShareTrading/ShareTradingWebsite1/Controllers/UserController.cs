using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using ShareTradingWebsite.Models;

namespace ShareTradingWebsite.Controllers
{   
    public class UserController : Controller
    {
		private readonly IPersonalDetailRepository personaldetailRepository;
		private readonly IUserRepository userRepository;
        
        public UserController(IPersonalDetailRepository personaldetailRepository, IUserRepository userRepository)
        {
			this.personaldetailRepository = personaldetailRepository;
			this.userRepository = userRepository;
        }

        //
        // GET: /User/

        public ViewResult Index()
        {
            return View(userRepository.AllIncluding(user => user.PersonalDetail, user => user.Portfolios, user => user.TransactionHistories));
        }

        //
        // GET: /User/Details/5

        public ViewResult Details(long id)
        {
            return View(userRepository.Find(id));
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
			ViewBag.PossiblePersonalDetails = personaldetailRepository.All;
            return View();
        } 

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid) {
                userRepository.InsertOrUpdate(user);
                userRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossiblePersonalDetails = personaldetailRepository.All;
				return View();
			}
        }
        
        //
        // GET: /User/Edit/5
 
        public ActionResult Edit(long id)
        {
			ViewBag.PossiblePersonalDetails = personaldetailRepository.All;
             return View(userRepository.Find(id));
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid) {
                userRepository.InsertOrUpdate(user);
                userRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossiblePersonalDetails = personaldetailRepository.All;
				return View();
			}
        }

        //
        // GET: /User/Delete/5
 
        public ActionResult Delete(long id)
        {
            return View(userRepository.Find(id));
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            userRepository.Delete(id);
            userRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                personaldetailRepository.Dispose();
                userRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

