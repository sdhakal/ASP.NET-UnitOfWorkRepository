using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWorkRepository.Models;
using UnitOfWorkRepository.Persistence;

namespace UnitOfWorkRepository.Controllers
{
    public class TagController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public TagController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            return View(_unitOfWork.Tags.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Tag Tag)
        {
            _unitOfWork.Tags.Add(Tag);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var Tag = _unitOfWork.Tags.Get(id);
            return View(Tag);
        }
        [HttpPost]
        public ActionResult Edit(Tag Tag)
        {
            _unitOfWork.Tags.Update(Tag);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var tag = _unitOfWork.Tags.Get(id);
             return View(tag);
        }
        public ActionResult Delete(int id)
        {
            var Tag = _unitOfWork.Tags.Get(id);
            _unitOfWork.Tags.Remove(Tag);
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