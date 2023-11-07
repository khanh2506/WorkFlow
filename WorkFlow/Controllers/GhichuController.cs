using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WorkFlow.Models;

namespace WorkFlow.Controllers
{
    public class GhichuController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public GhichuController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Ghichu
        public ActionResult Create()
        {
            
            return View(); 
        }
        [HttpPost]
        public ActionResult Save(Ghichu viewmodel) 
        {
            if (ModelState.IsValid)
            {
                var note = new Ghichu
                {
                    UserId = User.Identity.GetUserId(),
                    Title = viewmodel.Title,
                    Content = viewmodel.Content,
                    DateTime = DateTime.Now
                };

                _dbContext.Ghichus.Add(note);
                _dbContext.SaveChanges();
                
            }

            return RedirectToAction("Sotay", "Ghichu");
        }
        public ActionResult Sotay()
        {
            List<Ghichu> notes = _dbContext.Ghichus.ToList();
            return View(notes); 
        }
        public ActionResult Edit(int id)
        {
            var note = _dbContext.Ghichus.Find(id);
            if (note == null)
            {
                
                return HttpNotFound();
            }

            return View(note);
        }
        
        [HttpPost]
        public ActionResult SaveEdit(Ghichu viewmodel)
        {
            if (ModelState.IsValid)
            {
                var note = _dbContext.Ghichus.Find(viewmodel.Id);
                if (note == null)
                {
                    
                    return HttpNotFound();
                }

                note.Title = viewmodel.Title;
                note.Content = viewmodel.Content;
                note.DateTime = DateTime.Now;


                viewmodel.UserId = note.UserId;

                _dbContext.SaveChanges();
            }

            return RedirectToAction("Sotay", "Ghichu");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            
            var note = _dbContext.Ghichus.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }

            
            _dbContext.Ghichus.Remove(note);
            _dbContext.SaveChanges();

            return RedirectToAction("Sotay", "Ghichu");
        }

    }
}