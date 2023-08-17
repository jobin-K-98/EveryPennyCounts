using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EveryPennyCountsAPI.Data;
using EveryPennyCounts.Models;

namespace EveryPennyCountsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyMembersController : ControllerBase
    {
        private readonly EveryPennyCountsAPIContext _context;

        public FamilyMembersController(EveryPennyCountsAPIContext context)
        {
            _context = context;
        }

        // GET: api/FamilyMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamilyMember>>> GetFamilyMember()
        {
            if (_context.FamilyMembers == null)
            {
                return NotFound();
            }
            return await _context.FamilyMembers.ToListAsync();
        }

        // GET: api/FamilyMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FamilyMember>> GetFamilyMember(int id)
        {
            if (_context.FamilyMembers == null)
            {
                return NotFound();
            }
            var familyMember = await _context.FamilyMembers.FindAsync(id);

            if (familyMember == null)
            {
                return NotFound();
            }

            return familyMember;
        }

        [HttpGet("{id}/Transactions")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetFamilyMembersTransactions(int id)
        {
            if (_context.Transactions == null)
            {
                return NotFound();
            }
            var transactions = await _context.Transactions.Where(x=> x.FamilyMemberId ==id).ToArrayAsync();

            if (transactions == null)
            {
                return NotFound();
            }

            return transactions;
        }

        // PUT: api/FamilyMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamilyMember(int id, FamilyMember familyMember)
        {
            if (id != familyMember.FamilyMemberId)
            {
                return BadRequest();
            }

            _context.Entry(familyMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilyMemberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FamilyMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FamilyMember>> PostFamilyMember(FamilyMember familyMember)
        {
            if (_context.FamilyMembers == null)
            {
                return Problem("Entity set 'EveryPennyCountsAPIContext.FamilyMember'  is null.");
            }
            _context.FamilyMembers.Add(familyMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFamilyMember), new { id = familyMember.FamilyMemberId }, familyMember);
        }

        // DELETE: api/FamilyMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamilyMember(int id)
        {
            if (_context.FamilyMembers == null)
            {
                return NotFound();
            }
            var familyMember = await _context.FamilyMembers.FindAsync(id);
            if (familyMember == null)
            {
                return NotFound();
            }

            _context.FamilyMembers.Remove(familyMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FamilyMemberExists(int id)
        {
            return (_context.FamilyMembers?.Any(e => e.FamilyMemberId == id)).GetValueOrDefault();
        }
    }
}
