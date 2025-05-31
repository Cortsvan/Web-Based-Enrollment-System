using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMVCApplication.Data;
using MyMVCApplication.Models;

namespace MyMVCApplication.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? searchSubject)
        {
            var query = _context.Subject.AsQueryable();

            if (!string.IsNullOrEmpty(searchSubject))
            {
                query = query.Where(x => x.SFSUBJCODE.Contains(searchSubject));
            }

            var subjectList = await query.ToListAsync();
            return View(subjectList);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string subCode)
        {
            if (string.IsNullOrEmpty(subCode))
            {
                return NotFound();
            }

            var subject = await _context.Subject.FirstOrDefaultAsync(s => s.SFSUBJCODE == subCode);

            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                var existingSubject = await _context.Subject.FirstOrDefaultAsync(x => x.SFSUBJCODE == subject.SFSUBJCODE);

                if (existingSubject != null)
                {
                    existingSubject.SFSUBJDESC = subject.SFSUBJDESC;
                    existingSubject.SFSUBJUNITS = subject.SFSUBJUNITS;
                    existingSubject.SFSUBJCATEGORY = subject.SFSUBJCATEGORY;

                    await _context.SaveChangesAsync();
                    TempData["editSubject"] = "Subject updated successfully.";
                    return RedirectToAction("Index");
                }
            }
            return View(subject);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string subCode)
        {
            if (string.IsNullOrEmpty(subCode))
            {
                return NotFound();
            }

            var existingSubject = await _context.Subject.FirstOrDefaultAsync(x => x.SFSUBJCODE == subCode);

            if (existingSubject == null)
            {
                return NotFound();
            }

            _context.Subject.Remove(existingSubject);
            await _context.SaveChangesAsync();
            TempData["DeleteSubject"] = "Subject deleted successfully.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Subject addRequestSubject)
        {
            if (ModelState.IsValid)
            {
                if (await _context.Subject.AnyAsync(s => s.SFSUBJCODE == addRequestSubject.SFSUBJCODE))
                {
                    TempData["DuplicateError"] = $"Error! Duplicate Subject Code: {addRequestSubject.SFSUBJCODE}";
                    return View(addRequestSubject);
                }

                addRequestSubject.SFSUBJECTSTATUS = "AC";
                await _context.Subject.AddAsync(addRequestSubject);
                await _context.SaveChangesAsync();

                TempData["SubjectAdded"] = "Subject added successfully.";
                ModelState.Clear();
            }

            return View();
        }
    }
}
