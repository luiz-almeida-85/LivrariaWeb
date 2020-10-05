using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LivrariaWeb.Data;
using LivrariaWeb.Models;

namespace LivrariaWeb.Controllers
{
    public class EscritorController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Escritor
        public async Task<ActionResult> Index()
        {
            return View(await db.Escritors.ToListAsync());
        }

        // GET: Escritor/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escritor escritor = await db.Escritors.FindAsync(id);
            if (escritor == null)
            {
                return HttpNotFound();
            }
            return View(escritor);
        }

        // GET: Escritor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Escritor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Email,Telefone,Editora,Endereço")] Escritor escritor)
        {
            if (ModelState.IsValid)
            {
                db.Escritors.Add(escritor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(escritor);
        }

        // GET: Escritor/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escritor escritor = await db.Escritors.FindAsync(id);
            if (escritor == null)
            {
                return HttpNotFound();
            }
            return View(escritor);
        }

        // POST: Escritor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Email,Telefone,Editora,Endereço")] Escritor escritor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escritor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(escritor);
        }

        // GET: Escritor/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escritor escritor = await db.Escritors.FindAsync(id);
            if (escritor == null)
            {
                return HttpNotFound();
            }
            return View(escritor);
        }

        // POST: Escritor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Escritor escritor = await db.Escritors.FindAsync(id);
            db.Escritors.Remove(escritor);
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
