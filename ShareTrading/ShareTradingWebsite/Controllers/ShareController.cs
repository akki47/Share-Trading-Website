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
    [Authorize]
    public class ShareController : BaseController
    {
		private readonly ICompanyRepository companyRepository;
		private readonly IShareRepository shareRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        //public ShareController() : this(new CompanyRepository(), new ShareRepository())
        //{
        //}

        public ShareController(ICompanyRepository companyRepository, IShareRepository shareRepository)
        {
			this.companyRepository = companyRepository;
			this.shareRepository = shareRepository;
        }

        //
        // GET: /Share/

        public ViewResult Index()
        {
            return View(shareRepository.AllIncluding(share => share.Company));
        }

        //
        // GET: /Share/Details/5

        public ViewResult Details(long id)
        {
            return View(shareRepository.Find(id));
        }

        //
        // GET: /Share/Create

        public ActionResult Create()
        {
			ViewBag.PossibleCompanies = companyRepository.All;
            return View();
        } 

        //
        // POST: /Share/Create

        [HttpPost]
        public ActionResult Create(Share share)
        {
            if (ModelState.IsValid) {
                shareRepository.InsertOrUpdate(share);
                shareRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleCompanies = companyRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Share/Edit/5
 
        public ActionResult Edit(long id)
        {
			ViewBag.PossibleCompanies = companyRepository.All;
             return View(shareRepository.Find(id));
        }

        //
        // POST: /Share/Edit/5

        [HttpPost]
        public ActionResult Edit(Share share)
        {
            if (ModelState.IsValid) {
                shareRepository.InsertOrUpdate(share);
                shareRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleCompanies = companyRepository.All;
				return View();
			}
        }

        //
        // GET: /Share/Delete/5
 
        public ActionResult Delete(long id)
        {
            return View(shareRepository.Find(id));
        }

        //
        // POST: /Share/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            shareRepository.Delete(id);
            shareRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                companyRepository.Dispose();
                shareRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

