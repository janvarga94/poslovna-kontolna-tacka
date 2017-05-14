using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Poslovna4Real.Models;
using System.Linq.Expressions;

namespace Poslovna4Real.Controllers
{
    public class DrzaveController : Controller
    {
        private Poslovna4RealContext db = new Poslovna4RealContext();

        // GET: Drzave
        public async Task<ActionResult> Index()
        {
            return View(await db.Drzavas.ToListAsync());
        }

        public async Task<ActionResult> FilteredIndex(string naziv)
        {
            if (naziv == null) naziv = "";
            return View("Index",db.Drzavas.ToList().Where(a => a.Naziv.ToLower().Contains(naziv.ToLower())));
        }

        // GET: Drzave/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drzava drzava = await db.Drzavas.FindAsync(id);
            if (drzava == null)
            {
                return HttpNotFound();
            }
            return View(drzava);
        }

        // GET: Drzave/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drzave/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Naziv")] Drzava drzava)
        {
            if (ModelState.IsValid)
            {
                db.Drzavas.Add(drzava);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(drzava);
        }

        // GET: Drzave/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drzava drzava = await db.Drzavas.FindAsync(id);
            if (drzava == null)
            {
                return HttpNotFound();
            }
            return View(drzava);
        }

        // POST: Drzave/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Naziv")] Drzava drzava)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drzava).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(drzava);
        }

        // GET: Drzave/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drzava drzava = await db.Drzavas.FindAsync(id);
            if (drzava == null)
            {
                return HttpNotFound();
            }
            return View(drzava);
        }

        // POST: Drzave/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Drzava drzava = await db.Drzavas.FindAsync(id);
            db.Drzavas.Remove(drzava);
            await db.SaveChangesAsync();
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
