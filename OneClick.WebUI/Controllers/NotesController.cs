using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OneClick.Domain._Entities;
using OneClick.Domain.Concrete;
using OneClick.WebUI.Models;
using OneClick.Domain.Abstract;


namespace OneClick.WebUI.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {
        public int PageSize = 6;
        private EFDbContext db = new EFDbContext();
        private readonly INoteRepository repository;
        public NotesController (INoteRepository repo)
        {
            repository = repo;
        }
        // GET: /Notes/
        public ActionResult Index()
        {
            var notes = db.Notes.Include(n => n.users);
            return View(notes.ToList());
        }

        // GET: /Notes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // GET: /Notes/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: /Notes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Note note,  HttpPostedFileBase uploadNote,File file2)
        {
            if (ModelState.IsValid)
            {
                if (uploadNote != null && uploadNote.ContentLength > 0)
                {
                    var reader2 = new System.IO.BinaryReader(uploadNote.InputStream);

                    file2.FileId = note.NoteId;
                    file2.FileName = note.Name;
                    file2.ContentType = uploadNote.ContentType;
                    file2.Content = reader2.ReadBytes(uploadNote.ContentLength);
                }
                db.Files.Add(file2);
                db.Notes.Add(note);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(note);
        }
     
        public FileContentResult Download(int? id,int? id2)
        {
            byte[] fileData;
            string fileName;

            File file = db.Files.Find(id);
            Note note = db.Notes.Find(id2);
            fileName = file.FileName;
            fileData = (byte[])file.Content.ToArray();

            note.Download = note.Download + 1;

            db.SaveChanges();

            return File(fileData, "text", fileName);
        }
        // GET: /Notes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", note.UserId);
            return View(note);
        }

        // POST: /Notes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="NoteId,Name,Description,DateTime,Category,ContentType,Content,Download,UserId")] Note note)
        {
            if (ModelState.IsValid)
            {
                db.Entry(note).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", note.UserId);
            return View(note);
        }

        // GET: /Notes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: /Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Note note = db.Notes.Find(id);
            db.Notes.Remove(note);
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
        public ViewResult List(string category, int page = 1)
        {
            NotesListViewModel model = new NotesListViewModel
            {
                Notes = repository.notes
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.NoteId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                                repository.notes.Count() :
                                repository.notes.Where(p => p.Category == category).Count()
                },
                CurrentCategory = category

            };
            return View(model);
        }
    }
}
