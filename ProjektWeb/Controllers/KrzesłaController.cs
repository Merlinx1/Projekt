using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjektWeb.Models;

namespace ProjektWeb.Controllers
{
    public class KrzesłaController : Controller
    {
        private ProjektEntities1 db = new ProjektEntities1();

        // GET: Krzesła
        public ActionResult Index()
        {
            return View(db.Krzesła.ToList());
        }

        // GET: Krzesła/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Krzesła krzesła = db.Krzesła.Find(id);
            if (krzesła == null)
            {
                return HttpNotFound();
            }
            return View(krzesła);
        }

        // GET: Krzesła/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Krzesła/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rodzaj_Krzeseł")] Krzesła krzesła)
        {
            if (ModelState.IsValid)
            {
                db.Krzesła.Add(krzesła);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(krzesła);
        }

        // GET: Krzesła/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Krzesła krzesła = db.Krzesła.Find(id);
            if (krzesła == null)
            {
                return HttpNotFound();
            }
            return View(krzesła);
        }

        // POST: Krzesła/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rodzaj_Krzeseł")] Krzesła krzesła)
        {
            if (ModelState.IsValid)
            {
                db.Entry(krzesła).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(krzesła);
        }

        // GET: Krzesła/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Krzesła krzesła = db.Krzesła.Find(id);
            if (krzesła == null)
            {
                return HttpNotFound();
            }
            return View(krzesła);
        }

        // POST: Krzesła/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Krzesła krzesła = db.Krzesła.Find(id);
            db.Krzesła.Remove(krzesła);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
