using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWorkRepository.Models;
using UnitOfWorkRepository.Persistence;
using UnitOfWorkRepository.Persistence.Repositories;

namespace UnitOfWorkRepository.Controllers
{
    public class AuthorController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public AuthorController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Details(int id)
        {
            var author = _unitOfWork.Authors.Get(id);
            //if (artist == null)
            //{
            //    return HttpNotFound();
            //}
            //else
            //{
				
            return View(author);
            //}
        }
        public ActionResult Index()
        {
            return View(_unitOfWork.Authors.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Author author)
        {
            //if (!ModelState.IsValid)
            //    return View(artist);
            _unitOfWork.Authors.Add(author);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var author = _unitOfWork.Authors.Get(id);
            //if (artist == null) return HttpNotFound();
            //else 
            return View(author);
        }

        [HttpPost]
        public ActionResult Edit(Author author)
        {
            //if (!ModelState.IsValid) return View(artist);

            //try
            //{
            //    using (TransactionScope scope = new TransactionScope())
            //    {
            _unitOfWork.Authors.Update(author);
            _unitOfWork.Complete();
            //    scope.Complete();
            //}
            return RedirectToAction("Index");
            //}
            //catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            //{
            //    ViewBag.Message = "Sorry, that didn't work!<br />Adam beat you to the punch";
            //    return View(artist);
            //}
        }
        public ActionResult Delete(int id)
        {
            var author = _unitOfWork.Authors.Get(id);
            _unitOfWork.Authors.Remove(author);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}