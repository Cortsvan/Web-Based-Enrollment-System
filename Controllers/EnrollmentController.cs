using Microsoft.AspNetCore.Mvc;
using MyMVCApplication.Data;
using MyMVCApplication.Models;

namespace MyMVCApplication.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Render Add Enrollment View
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // Action to fetch student details by ID
        [HttpGet]
        public IActionResult GetStudentDetails(string studentId)
        {
            if (string.IsNullOrWhiteSpace(studentId))
            {
                return Json(new { success = false, message = "Student ID is required." });
            }

            var student = _context.Student.FirstOrDefault(s => s.STFSTUDID == studentId);
            if (student == null)
            {
                return Json(new { success = false, message = "Student not found." });
            }

            return Json(new
            {
                success = true,
                data = new
                {
                    Name = $"{student.STFSTUDFNAME} {student.STFSTUDMNAME} {student.STFSTUDLNAME}",
                    Course = student.STFSTUDCOURSE,
                    Year = student.STFSTUDYEAR
                }
            });
        }

        [HttpGet]
        public IActionResult GetSubjectDetails(string edpCode)
        {
            if (string.IsNullOrWhiteSpace(edpCode))
            {
                return Json(new { success = false, message = "EDP Code is required." });
            }

            var subjectSchedule = _context.SubjectSchedule
                .Join(_context.Subject,
                      ss => ss.SSFSUBJCODE,
                      sub => sub.SFSUBJCODE,
                      (ss, sub) => new
                      {
                          ss.SSFEDPCODE,
                          ss.SSFSUBJCODE,
                          StartTime = ss.SSFSTARTTIME.HasValue ? ss.SSFSTARTTIME.Value.ToString("hh:mm tt") : null,
                          EndTime = ss.SSFENDTIME.HasValue ? ss.SSFENDTIME.Value.ToString("hh:mm tt") : null,
                          ss.SSFDAYS,
                          ss.SSFROOM,
                          Units = sub.SFSUBJUNITS,
                          ss.SSFSCHOOLYEAR
                      })
                .FirstOrDefault(x => x.SSFEDPCODE == edpCode);

            if (subjectSchedule == null)
            {
                return Json(new { success = false, message = "EDP Code not found." });
            }

            return Json(new { success = true, data = subjectSchedule });
        }

    }
}
