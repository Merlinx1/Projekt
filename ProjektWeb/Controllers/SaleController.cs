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
    public class SaleController : Controller
    {
        private ProjektEntities1 db = new ProjektEntities1();

        // GET: Sale
        public ActionResult Index()
        {
            var sale = db.Sale.Include(s => s.Krzesła).Include(s => s.Ławki);
            return View(sale.ToList());
        }

        // GET: Sale/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sale.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: Sale/Create
        public ActionResult Create()
        {
            ViewBag.Rodzaj_krzeseł = new SelectList(db.Krzesła, "Id", "Rodzaj_Krzeseł");
            ViewBag.Rodzaj_ławek = new SelectList(db.Ławki, "Id", "Rodzaj_ławek");
            return View();
        }

        // POST: Sale/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nr_Sali,Rodzaj_sali,Ilość_miejsc,Rodzaj_krzeseł,Rodzaj_ławek,Projektor")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sale.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Rodzaj_krzeseł = new SelectList(db.Krzesła, "Id", "Rodzaj_Krzeseł", sale.Rodzaj_krzeseł);
            ViewBag.Rodzaj_ławek = new SelectList(db.Ławki, "Id", "Rodzaj_ławek", sale.Rodzaj_ławek);
            return View(sale);
        }

        // GET: Sale/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sale.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.Rodzaj_krzeseł = new SelectList(db.Krzesła, "Id", "Rodzaj_Krzeseł", sale.Rodzaj_krzeseł);
            ViewBag.Rodzaj_ławek = new SelectList(db.Ławki, "Id", "Rodzaj_ławek", sale.Rodzaj_ławek);
            return View(sale);
        }

        // POST: Sale/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nr_Sali,Rodzaj_sali,Ilość_miejsc,Rodzaj_krzeseł,Rodzaj_ławek,Projektor")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Rodzaj_krzeseł = new SelectList(db.Krzesła, "Id", "Rodzaj_Krzeseł", sale.Rodzaj_krzeseł);
            ViewBag.Rodzaj_ławek = new SelectList(db.Ławki, "Id", "Rodzaj_ławek", sale.Rodzaj_ławek);
            return View(sale);
        }

        // GET: Sale/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sale.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sale sale = db.Sale.Find(id);
            db.Sale.Remove(sale);
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
