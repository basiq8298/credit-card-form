using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class PersonalInfoesController : Controller
    {
        private readonly UserDBContext _context;

        public PersonalInfoesController(UserDBContext context)
        {
            _context = context;
        }

        // GET: PersonalInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: PersonalInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInfo = await _context.User
                .SingleOrDefaultAsync(m => m.UserId == id);
            if (personalInfo == null)
            {
                return NotFound();
            }

            return View(personalInfo);
        }

        // GET: PersonalInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Name,Gender,DateOfBirth")] PersonalInfo personalInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalInfo);
        }

        // GET: PersonalInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInfo = await _context.User.SingleOrDefaultAsync(m => m.UserId == id);
            if (personalInfo == null)
            {
                return NotFound();
            }
            return View(personalInfo);
        }

        // POST: PersonalInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Name,Gender,DateOfBirth")] PersonalInfo personalInfo)
        {
            if (id != personalInfo.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalInfoExists(personalInfo.UserId))
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
            return View(personalInfo);
        }

        // GET: PersonalInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInfo = await _context.User
                .SingleOrDefaultAsync(m => m.UserId == id);
            if (personalInfo == null)
            {
                return NotFound();
            }

            return View(personalInfo);
        }

        // POST: PersonalInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalInfo = await _context.User.SingleOrDefaultAsync(m => m.UserId == id);
            _context.User.Remove(personalInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalInfoExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
