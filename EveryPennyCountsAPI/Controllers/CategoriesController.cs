﻿using System;
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
    public class CategoriesController : ControllerBase
    {
        private readonly EveryPennyCountsAPIContext _context;

        public CategoriesController(EveryPennyCountsAPIContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            return await _context.Categories.ToListAsync();
        }
        // GET: api/Transactions/5
        [HttpGet("Income")]
        public async Task<ActionResult<IEnumerable<Category>>> GetIncomeCategory()
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var categories = await _context.Categories.Where(x => x.Type == "Income").ToArrayAsync();

            if (categories == null)
            {
                return NotFound();
            }

            return categories;
        }

        // GET: api/Transactions/5
        [HttpGet("Expense")]
        public async Task<ActionResult<IEnumerable<Category>>> GetExpenseCategory()
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var categories = await _context.Categories.Where(x => x.Type == "Expense").ToArrayAsync();

            if (categories == null)
            {
                return NotFound();
            }

            return categories;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'EveryPennyCountsAPIContext.Category'  is null.");
            }
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCategory), new { id = category.CategoryId }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return (_context.Categories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }
    }
}