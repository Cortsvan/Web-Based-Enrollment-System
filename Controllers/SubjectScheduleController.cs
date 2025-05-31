using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMVCApplication.Data;
using MyMVCApplication.Models;

namespace MyMVCApplication.Controllers
{
    public class SubjectScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubjectScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // INDEX METHOD (Displays Subject Schedule with Optional Search)
        public IActionResult Index(string SearchEdpCode)
        {
            // Fetch all SubjectSchedules
            var schedules = _context.SubjectSchedule.AsQueryable();

            // Apply search filter if a search term is provided
            if (!string.IsNullOrEmpty(SearchEdpCode))
            {
                schedules = schedules.Where(x => x.SSFEDPCODE.Contains(SearchEdpCode));
            }

            // Return the filtered or full list to the view
            var SubjectScheduleList = schedules.ToList();
            return View(SubjectScheduleList);
        }

        // SEARCH SUBJECT CODE AND RETURN DESCRIPTION (Case-Insensitive)
        [HttpGet]
        public async Task<IActionResult> SubjectVerify(string subjectCode)
        {
            if (!string.IsNullOrEmpty(subjectCode))
            {
                // Perform case-insensitive comparison
                var subject = await _context.Subject
                    .FirstOrDefaultAsync(s => s.SFSUBJCODE.ToLower() == subjectCode.ToLower());

                if (subject != null)
                {
                    // Return JSON with Subject Description
                    return Json(new { description = subject.SFSUBJDESC });
                }
            }

            // Return empty description if not found
            return Json(new { description = "" });
        }

        // ADD: RENDER ADD FORM
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // ADD: SAVE NEW SUBJECT SCHEDULE
        [HttpPost]
        public async Task<IActionResult> Add(SubjectSchedule addRequestsubjectSchedule)
        {
            if (ModelState.IsValid)
            {
                // Check for duplicate EDP Code asynchronously
                bool duplicateExists = await _context.SubjectSchedule
                    .AnyAsync(s => s.SSFEDPCODE == addRequestsubjectSchedule.SSFEDPCODE);

                if (duplicateExists)
                {
                    TempData["DuplicateError"] = "Error! Duplicate EDP Code: " + addRequestsubjectSchedule.SSFEDPCODE;
                    return View(addRequestsubjectSchedule);
                }

                // Populate SubjectSchedule Entity
                var subjectSchedule = new SubjectSchedule
                {
                    SSFEDPCODE = addRequestsubjectSchedule.SSFEDPCODE,  // EDP Code
                    SSFSUBJCODE = addRequestsubjectSchedule.SSFSUBJCODE,  // Subject Code
                    SSFSTARTTIME = addRequestsubjectSchedule.SSFSTARTTIME,
                    SSFENDTIME = addRequestsubjectSchedule.SSFENDTIME,
                    SSFDAYS = addRequestsubjectSchedule.SSFDAYS,
                    SSFROOM = addRequestsubjectSchedule.SSFROOM,
                    SSFCLASSSIZE = addRequestsubjectSchedule.SSFCLASSSIZE,
                    SSFSTATUS = addRequestsubjectSchedule.SSFSTATUS,  // Dropdown: Open/Close
                    SSFSECTION = addRequestsubjectSchedule.SSFSECTION,
                    SSFSCHOOLYEAR = addRequestsubjectSchedule.SSFSCHOOLYEAR
                };

                // Save to Database
                _context.SubjectSchedule.Add(subjectSchedule);
                await _context.SaveChangesAsync();

                TempData["ScheduleAdded"] = "Schedule Saved Successfully!";
                return RedirectToAction("Index");
            }

            return View(addRequestsubjectSchedule);
        }
    }
}
