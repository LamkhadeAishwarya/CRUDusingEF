using CRUDusingEF.Data;
using CRUDusingEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDusingEF.Controllers
{
    public class StudentController : Controller
    {
        ApplicationDbContext context;
        StudentDAL db;
        public StudentController(ApplicationDbContext context)
        {
            this.context = context;
            db = new StudentDAL(this.context);
        }

        // GET: StudentController
        public ActionResult Index()
        {
            return View(db.GetStudents());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var stud = db.GetStudentByRno(id);
            return View(stud);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student stud)
        {
            try
            {
                int result = db.AddStudent(stud);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var stud = db.GetStudentByRno(id);
            return View(stud);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student stud)
        {
            try
            {
                int result = db.UpdateStudent(stud);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {

            var stud = db.GetStudentByRno(id);
            return View(stud);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteStudent(int id)
        {
            try
            {
                int result = db.DeleteStudent(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
