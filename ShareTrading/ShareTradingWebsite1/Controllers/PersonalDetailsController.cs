using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using ShareTradingWebsite.Models;

namespace ShareTradingWebsite.Controllers
{   
    public class PersonalDetailsController : Controller
    {
		private readonly IAddressRepository addressRepository;
		private readonly IPersonalDetailRepository personaldetailRepository;
        
        public PersonalDetailsController(IAddressRepository addressRepository, IPersonalDetailRepository personaldetailRepository)
        {
			this.addressRepository = addressRepository;
			this.personaldetailRepository = personaldetailRepository;
        }

        //
        // GET: /PersonalDetails/

        public ViewResult Index()
        {
            return View(personaldetailRepository.AllIncluding(personaldetail => personaldetail.Address1, personaldetail => personaldetail.Address2, personaldetail => personaldetail.Companies, personaldetail => personaldetail.Users));
        }

        //
        // GET: /PersonalDetails/Details/5

        public ViewResult Details(long id)
        {
            return View(personaldetailRepository.Find(id));
        }

        //
        // GET: /PersonalDetails/Create

        public ActionResult Create()
        {
			ViewBag.PossibleAddress1 = addressRepository.All;
			ViewBag.PossibleAddress2 = addressRepository.All;
            return View();
        } 

        //
        // POST: /PersonalDetails/Create

        [HttpPost]
        public ActionResult Create(PersonalDetail personaldetail)
        {
            if (ModelState.IsValid) {
                personaldetailRepository.InsertOrUpdate(personaldetail);
                personaldetailRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleAddress1 = addressRepository.All;
				ViewBag.PossibleAddress2 = addressRepository.All;
				return View();
			}
        }
        
        //
        // GET: /PersonalDetails/Edit/5
 
        public ActionResult Edit(long id)
        {
			ViewBag.PossibleAddress1 = addressRepository.All;
			ViewBag.PossibleAddress2 = addressRepository.All;
             return View(personaldetailRepository.Find(id));
        }

        //
        // POST: /PersonalDetails/Edit/5

        [HttpPost]
        public ActionResult Edit(PersonalDetail personaldetail)
        {
            if (ModelState.IsValid) {
                personaldetailRepository.InsertOrUpdate(personaldetail);
                personaldetailRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleAddress1 = addressRepository.All;
				ViewBag.PossibleAddress2 = addressRepository.All;
				return View();
			}
        }

        //
        // GET: /PersonalDetails/Delete/5
 
        public ActionResult Delete(long id)
        {
            return View(personaldetailRepository.Find(id));
        }

        //
        // POST: /PersonalDetails/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            personaldetailRepository.Delete(id);
            personaldetailRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                addressRepository.Dispose();
                personaldetailRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

