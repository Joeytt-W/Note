using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Web.Models;

namespace OdeToFood.Web.Controllers
{
    public class StudentController : Controller
    {
        private static readonly List<Student> _students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Name = "张三",
                Address = "安徽",
                TotalScore = 685
            },
            new Student()
            {
                Id = 2,
                Name = "李四",
                Address = "江苏",
                TotalScore = 689
            },
            new Student()
            {
                Id = 3,
                Name = "王五",
                Address = "浙江",
                TotalScore = 700
            },
            new Student()
            {
                Id = 4,
                Name = "赵六",
                Address = "上海",
                TotalScore = 688
            }
        };

        // GET: Student
        [HttpGet]
        public ActionResult Index()
        {
            return View(_students);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student newStu)
        {
            newStu.Id = _students.Max(c => c.Id) + 1;
            _students.Add(newStu);
            return RedirectToAction(nameof(Index),_students);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var firstOrDefault = _students.FirstOrDefault(c => c.Id == id);
            return View(firstOrDefault);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student newStu)
        {
            var firstOrDefault = _students.FirstOrDefault(c=>c.Id==newStu.Id);

            if (firstOrDefault == null)
            {
                return RedirectToAction(nameof(Index));
            }

            firstOrDefault.Name=newStu.Name;
            firstOrDefault.Address=newStu.Address;
            firstOrDefault.TotalScore=newStu.TotalScore;

            return RedirectToAction(nameof(Index), _students);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var firstOrDefault = _students.FirstOrDefault(c => c.Id == id);
            return View(firstOrDefault);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var firstOrDefault = _students.FirstOrDefault(c => c.Id == id);
            _students.Remove(firstOrDefault);

            return RedirectToAction(nameof(Index), _students);
        }
    }
}