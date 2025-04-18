using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentsGroupsCollege.Data;
using StudentsGroupsCollege.Models;

namespace StudentsGroupsCollege.Controllers
{
    public class CollegeGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CollegeGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CollegeGroups
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CollegeGroups.Include(c => c.College);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CollegeGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeGroup = await _context.CollegeGroups
                .Include(c => c.College)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (collegeGroup == null)
            {
                return NotFound();
            }

            return View(collegeGroup);
        }

        // GET: CollegeGroups/Create
        public IActionResult Create()
        {
            ViewData["CollegeId"] = new SelectList(_context.Colleges, "Id", "Name");
            return View();
        }

        // POST: CollegeGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CollegeId")] CollegeGroup collegeGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collegeGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollegeId"] = new SelectList(_context.Colleges, "Id", "Name", collegeGroup.CollegeId);
            return View(collegeGroup);
        }

        // GET: CollegeGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeGroup = await _context.CollegeGroups.FindAsync(id);
            if (collegeGroup == null)
            {
                return NotFound();
            }
            ViewData["CollegeId"] = new SelectList(_context.Colleges, "Id", "Name", collegeGroup.CollegeId);
            return View(collegeGroup);
        }

        // POST: CollegeGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CollegeId")] CollegeGroup collegeGroup)
        {
            if (id != collegeGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collegeGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollegeGroupExists(collegeGroup.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollegeId"] = new SelectList(_context.Colleges, "Id", "Name", collegeGroup.CollegeId);
            return View(collegeGroup);
        }

        // GET: CollegeGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeGroup = await _context.CollegeGroups
                .Include(c => c.College)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (collegeGroup == null)
            {
                return NotFound();
            }

            return View(collegeGroup);
        }

        // POST: CollegeGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collegeGroup = await _context.CollegeGroups.FindAsync(id);
            if (collegeGroup != null)
            {
                _context.CollegeGroups.Remove(collegeGroup);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollegeGroupExists(int id)
        {
            return _context.CollegeGroups.Any(e => e.Id == id);
        }
    }
}
