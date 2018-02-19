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
    public class ŁawkiController : Controller
    {
        private ProjektEntities1 db = new ProjektEntities1();

        // GET: Ławki
        public ActionResult Index()
        {
            return View(db.Ławki.ToList());
        }

        // GET: Ławki/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ławki ławki = db.Ławki.Find(id);
            if (ławki == null)
            {
                return HttpNotFound();
            }
            return View(ławki);
        }

        // GET: Ławki/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ławki/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rodzaj_ławek")] Ławki ławki)
        {
            if (ModelState.IsValid)
            {
                db.Ławki.Add(ławki);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ławki);
        }

        // GET: Ławki/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ławki ławki = db.Ławki.Find(id);
            if (ławki == null)
            {
                return HttpNotFound();
            }
            return View(ławki);
        }

        // POST: Ławki/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rodzaj_ławek")] Ławki ławki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ławki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ławki);
        }

        // GET: Ławki/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ławki ławki = db.Ławki.Find(id);
            if (ławki == null)
            {
                return HttpNotFound();
            }
            return View(ławki);
        }

        // POST: Ławki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ławki ławki = db.Ławki.Find(id);
            db.Ławki.Remove(ławki);
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
