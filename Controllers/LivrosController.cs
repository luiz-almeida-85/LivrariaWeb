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
    public class LivrosController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Livros
        public async Task<ActionResult> Index()
        {
            var livros = db.Livros.Include(l => l.Escritor);
            return View(await livros.ToListAsync());
        }

        // GET: Livros/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livros livros = await db.Livros.FindAsync(id);
            if (livros == null)
            {
                return HttpNotFound();
            }
            return View(livros);
        }

        // GET: Livros/Create
        public ActionResult Create()
        {
            ViewBag.IdEscritor = new SelectList(db.Escritors, "Id", "Nome");
            return View();
        }

        // POST: Livros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Descricao,Npag,Gereno,IdEscritor")] Livros livros)
        {
            if (ModelState.IsValid)
            {
                db.Livros.Add(livros);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdEscritor = new SelectList(db.Escritors, "Id", "Nome", livros.IdEscritor);
            return View(livros);
        }

        // GET: Livros/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livros livros = await db.Livros.FindAsync(id);
            if (livros == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEscritor = new SelectList(db.Escritors, "Id", "Nome", livros.IdEscritor);
            return View(livros);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Descricao,Npag,Gereno,IdEscritor")] Livros livros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livros).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdEscritor = new SelectList(db.Escritors, "Id", "Nome", livros.IdEscritor);
            return View(livros);
        }

        // GET: Livros/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livros livros = await db.Livros.FindAsync(id);
            if (livros == null)
            {
                return HttpNotFound();
            }
            return View(livros);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Livros livros = await db.Livros.FindAsync(id);
            db.Livros.Remove(livros);
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
