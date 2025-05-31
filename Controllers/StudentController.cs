using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMVCApplication.Data;
using MyMVCApplication.Models;
using System.Reflection.Metadata.Ecma335;

namespace MyMVCApplication.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;


        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var student = _context.Student.ToList();
            return View(student);

        }
        
        [HttpGet]

        public IActionResult Index(string searchStudent)
        {
            var findStudent = _context.Student.AsQueryable(); 

            if (!string.IsNullOrEmpty(searchStudent))
            {
                findStudent = findStudent.Where(x => x.STFSTUDID.Contains(searchStudent));
            }

            var studentList = findStudent.ToList(); 

            return View(studentList); 
        }
        //[HttpGet]
        //public IActionResult Edit(string? code)
        //{
        //    var studId = _context.Student.Where(s => s.STFSTUDID == code).FirstOrDefault();

        //    return View(studId);
        //}
        //[HttpPost]

        //public IActionResult Edit(Student studentEdit)
        //{
        //    var student = _context.Student.FirstOrDefault(s => s.STFSTUDID == studentEdit.STFSTUDID);

        //    if (student != null)
        //    {
        //        _context.Student.Remove(student);
        //        _context.Add(studentEdit);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(studentEdit);
        //}

        //[HttpPost]
        //public IActionResult Delete(string StudentId)
        //{
        //    if (string.IsNullOrEmpty(StudentId))
        //    {
        //        return NotFound();
        //    }
        //    var existingStudent = _context.Student.FirstOrDefault(x => x.STFSTUDID == StudentId);
        //    if (existingStudent == null)
        //    {
        //        return NotFound();

        //    }
        //    _context.Student.Remove(existingStudent);
        //    _context.SaveChanges();
        //    TempData["DeleteMessage"] = "Delete Success";
        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public IActionResult Edit(string StudentId)
        {
            if (StudentId == null)
            {

                return NotFound();
            }

            var student = _context.Student.SingleOrDefault(i => i.STFSTUDID == StudentId);

            if (student == null)
            {

                return NotFound();
            }

            return View(student);
        }

        //[HttpGet]
        //public IActionResult Edit(string? StudentId)
        //{

        //    var id = _context.Student.Where(i => i.STFSTUDID == StudentId).FirstOrDefault();
        //    return View(id);
        //}


        [HttpPost]
        public IActionResult Edit(Student student)
        {

            var existingStudent = _context.Student.FirstOrDefault(x => x.STFSTUDID == student.STFSTUDID);

            if (existingStudent != null)
            {

                existingStudent.STFSTUDLNAME = student.STFSTUDLNAME; 
                existingStudent.STFSTUDFNAME = student.STFSTUDFNAME; 
                existingStudent.STFSTUDMNAME = student.STFSTUDMNAME;                                               


                _context.SaveChanges();
                TempData["AlertMessage"] = "Student Update Success";
                return RedirectToAction("Index");
            }

            return View(student);
        }

        //public IActionResult Delete(string StudentId)
        //{
        //    var existingStudent = _context.Student.SingleOrDefault(s => s.STFSTUDID == StudentId);

        //    try {

        //        if (existingStudent != null)
        //        {
        //            _context.Student.Remove(existingStudent);
        //            _context.SaveChanges();
        //            TempData["SuccessMessage"] = "Student deleted successfully.";
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            TempData["SuccessMessage"] = "Student deleted successfully.";
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (Exception ex) {
        //        TempData["errorMesaage"] = ex.Message;
        //        return View();
        //    }


        //}
        [HttpPost]
        public IActionResult Delete(string StudentId)
        {
            if (string.IsNullOrEmpty(StudentId))
            {
                return NotFound(); 
            }
            var existingStudent = _context.Student.Where(x => x.STFSTUDID == StudentId).FirstOrDefault();
            if (existingStudent == null)
            {
                return NotFound();

            }
            _context.Student.Remove(existingStudent);
            _context.SaveChanges();
            TempData["DeleteMessage"] = "Delete Success";
            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(Student addRequestStudent)
        {
            
            if (ModelState.IsValid) {
                if (_context.Student.Any(s => s.STFSTUDID == addRequestStudent.STFSTUDID))
                {
                    TempData["DuplicateError"] = "Error! Duplicate ID NO: " + addRequestStudent.STFSTUDID;
                    return View(addRequestStudent);
                }
                else {
                    var student = new Student()
                    {
                        STFSTUDID = addRequestStudent.STFSTUDID,
                        STFSTUDLNAME = addRequestStudent.STFSTUDLNAME,
                        STFSTUDFNAME = addRequestStudent.STFSTUDFNAME,
                        STFSTUDMNAME = addRequestStudent.STFSTUDMNAME,
                        STFSTUDCOURSE = addRequestStudent.STFSTUDCOURSE,
                        STFSTUDYEAR = addRequestStudent.STFSTUDYEAR,
                        STFSTUDREMARKS = addRequestStudent.STFSTUDREMARKS,
                        STFSTUDSTATUS = "AC"

                    };
                    _context.Student.Add(student);
                    _context.SaveChanges();
                    TempData["StudentAdded"] = "Student Saved SUCCESFULLY";
                    ModelState.Clear();

                }
                
            }

          return View();

        }
    }
}
