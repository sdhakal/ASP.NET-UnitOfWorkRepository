using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWorkRepository.Models;
using UnitOfWorkRepository.Persistence;
using UnitOfWorkRepository.ViewModels;

namespace UnitOfWorkRepository.Controllers
{
    public class CourseController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public CourseController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            return View(_unitOfWork.Courses.GetCoursesWithAuthors());
        }
        public ActionResult Create()
        {
            var authors = _unitOfWork.Authors.GetAll();
            var tags = _unitOfWork.Tags.GetAll();
            var TagViewModels = new List<TagViewModel>();
            TagViewModels.Add(new TagViewModel());
            TagViewModels.Add(new TagViewModel());
            TagViewModels.Add(new TagViewModel());
            TagViewModels.Add(new TagViewModel());
            TagViewModels.Add(new TagViewModel());
            var courseViewModel = new CourseViewModel
            {
                Authors = authors,
                TagViewModels = TagViewModels
            };
            return View(courseViewModel);
        }
        [HttpPost]
        public ActionResult Create(Course Course)
        {
            _unitOfWork.Courses.Add(Course);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var course = _unitOfWork.Courses.Get(id);
            var authors = _unitOfWork.Authors.GetAll();
            var tags = _unitOfWork.Tags.GetAll();
            var courseViewModel = new CourseViewModel
            {
                Authors = authors,
                //Tags = tags,
                Course = course
            };
            return View(courseViewModel);
        }
        [HttpPost]
        public ActionResult Edit(Course Course)
        {
            _unitOfWork.Courses.Update(Course);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var Course = _unitOfWork.Courses.GetCoursesWithAuthors().Single(x => x.CourseId == id);
            return View(Course);
        }
        public ActionResult Delete(int id)
        {
            var Course = _unitOfWork.Courses.Get(id);
            _unitOfWork.Courses.Remove(Course);
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