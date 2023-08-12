using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EveryPennyCounts.Models;
using EveryPennyCountsAPI.Data;

namespace EveryPennyCounts.Controllers
{
    public class FamilyMemberController : Controller
    {
        private readonly EveryPennyCountsAPIContext _context;

        public FamilyMemberController(EveryPennyCountsAPIContext context)
        {
            _context = context;
        }

        // GET: FamilyMember
        public async Task<IActionResult> Index()
        {
            return _context.FamilyMembers != null ?
                        View(await _context.FamilyMembers.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.FamilyMembers'  is null.");
        }


        // GET: FamilyMember/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new FamilyMember());
            else
                return View(_context.FamilyMembers.Find(id));

        }

        // POST: FamilyMember/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("FamilyMemberId,Name")] FamilyMember FamilyMember)
        {
            if (ModelState.IsValid)
            {
                if (FamilyMember.FamilyMemberId == 0)
                    _context.Add(FamilyMember);
                else
                    _context.Update(FamilyMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(FamilyMember);
        }


        // POST: FamilyMember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FamilyMembers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FamilyMembers'  is null.");
            }
            var FamilyMember = await _context.FamilyMembers.FindAsync(id);
            if (FamilyMember != null)
            {
                _context.FamilyMembers.Remove(FamilyMember);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
