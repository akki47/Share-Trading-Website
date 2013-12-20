using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Entities;
using ShareTradingModel;
using ShareTradingWebsite.Models;

namespace ShareTradingWebsite.Controllers
{   
    public class AddressController : BaseController
    {
		private readonly IAddressRepository addressRepository;
        
        public AddressController(IAddressRepository addressRepository)
        {
			this.addressRepository = addressRepository;
        }

        //
        // GET: /Address/

        public ViewResult Index()
        {
            return View(addressRepository.All);
        }

        //
        // GET: /Address/Details/5

        public ViewResult Details(long id)
        {
            return View(addressRepository.Find(id));
        }

        //
        // GET: /Address/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Address/Create

        [HttpPost]
        public ActionResult Create(Address address)
        {
            if (ModelState.IsValid) {
                addressRepository.InsertOrUpdate(address);
                addressRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Address/Edit/5
 
        public ActionResult Edit(long id)
        {
             return View(addressRepository.Find(id));
        }

        //
        // POST: /Address/Edit/5

        [HttpPost]
        public ActionResult Edit(Address address)
        {
            if (ModelState.IsValid) {
                addressRepository.InsertOrUpdate(address);
                addressRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Address/Delete/5
 
        public ActionResult Delete(long id)
        {
            return View(addressRepository.Find(id));
        }

        //
        // POST: /Address/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            addressRepository.Delete(id);
            addressRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                addressRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

