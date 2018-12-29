using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyDoktor.Entities;
using MyDoktor.BusinessLayer;
using MyDoktor.BusinessLayer.Results;
using MyDoktor.WebApp.Filters;

namespace MyDoktor.WebApp.Controllers
{
    [Auth]
    [AuthAdmin]
    [Exc]
    public class DoktorUserController : Controller
    {
        private DoktorUserManager DoktorUserManager = new DoktorUserManager();


        public ActionResult Index()
        {
            return View(DoktorUserManager.List());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DoktorUser DoktorUser = DoktorUserManager.Find(x => x.Id == id.Value);

            if (DoktorUser == null)
            {
                return HttpNotFound();
            }

            return View(DoktorUser);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DoktorUser DoktorUser)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                BusinessLayerResult<DoktorUser> res = DoktorUserManager.Insert(DoktorUser);

                if(res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(DoktorUser);
                }

                return RedirectToAction("Index");
            }

            return View(DoktorUser);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DoktorUser DoktorUser = DoktorUserManager.Find(x => x.Id == id.Value);

            if (DoktorUser == null)
            {
                return HttpNotFound();
            }

            return View(DoktorUser);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DoktorUser DoktorUser)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                BusinessLayerResult<DoktorUser> res = DoktorUserManager.Update(DoktorUser);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(DoktorUser);
                }

                return RedirectToAction("Index");
            }
            return View(DoktorUser);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DoktorUser DoktorUser = DoktorUserManager.Find(x => x.Id == id.Value);

            if (DoktorUser == null)
            {
                return HttpNotFound();
            }

            return View(DoktorUser);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoktorUser DoktorUser = DoktorUserManager.Find(x => x.Id == id);
            DoktorUserManager.Delete(DoktorUser);

            return RedirectToAction("Index");
        }
    }
}
