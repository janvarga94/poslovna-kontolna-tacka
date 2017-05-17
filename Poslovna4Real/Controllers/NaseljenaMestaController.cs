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

namespace Poslovna4Real.Controllers
{
    public class NaseljenaMestaController : Controller
    {
        private Poslovna4RealContext db = new Poslovna4RealContext();

        // GET: NaseljenaMesta
        public async Task<ActionResult> Index()
        {
            var naseljenoMestoes = db.NaseljenoMestoes.Include(n => n.Drzava);
            return View(await naseljenoMestoes.ToListAsync());
        }

        public async Task<ActionResult> FilteredIndex(string naziv, string ptt, string drzavaNaziv)
        {
            if (naziv == null) naziv = "";
            if (ptt == null) ptt = "";
            if (drzavaNaziv == null) drzavaNaziv = "";
            var naseljenoMestoes = db.NaseljenoMestoes.Include(n => n.Drzava);
            return View("Index",naseljenoMestoes.ToList().Where(a => 
                a.PTT.ToLower().Contains(ptt.ToLower())  &&
                a.Naziv.ToLower().Contains(naziv.ToLower())  &&
                a.Drzava.Naziv.ToLower().Contains(drzavaNaziv.ToLower())
            ));
        }

        // GET: NaseljenaMesta/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NaseljenoMesto naseljenoMesto = await db.NaseljenoMestoes.FindAsync(id);
            if (naseljenoMesto == null)
            {
                return HttpNotFound();
            }
            return View(naseljenoMesto);
        }

        // GET: NaseljenaMesta/Create
        public ActionResult Create()
        {
            ViewBag.DrzavaId = new SelectList(db.Drzavas, "Id", "Naziv");
            return View(new NaseljenoMestoISveDrzave() { SveDrzave = db.Drzavas.ToList() });
        }

        // POST: NaseljenaMesta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PTT,Naziv,DrzavaId")] NaseljenoMesto naseljenoMesto)
        {
            if (ModelState.IsValid)
            {
                db.NaseljenoMestoes.Add(naseljenoMesto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DrzavaId = new SelectList(db.Drzavas, "Id", "Naziv", naseljenoMesto.DrzavaId);
            return View(naseljenoMesto);
        }

        // GET: NaseljenaMesta/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NaseljenoMesto naseljenoMesto = await db.NaseljenoMestoes.FindAsync(id);
            if (naseljenoMesto == null)
            {
                return HttpNotFound();
            }
            ViewBag.DrzavaId = new SelectList(db.Drzavas, "Id", "Naziv", naseljenoMesto.DrzavaId);
            return View(naseljenoMesto);
        }

        // POST: NaseljenaMesta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PTT,Naziv,DrzavaId")] NaseljenoMesto naseljenoMesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(naseljenoMesto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DrzavaId = new SelectList(db.Drzavas, "Id", "Naziv", naseljenoMesto.DrzavaId);
            return View(naseljenoMesto);
        }

        // GET: NaseljenaMesta/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NaseljenoMesto naseljenoMesto = await db.NaseljenoMestoes.FindAsync(id);
            if (naseljenoMesto == null)
            {
                return HttpNotFound();
            }
            return View(naseljenoMesto);
        }

        // POST: NaseljenaMesta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NaseljenoMesto naseljenoMesto = await db.NaseljenoMestoes.FindAsync(id);
            db.NaseljenoMestoes.Remove(naseljenoMesto);
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
