using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class BuyerController : Controller
    {
        private readonly ECommerceContext _context;

        public BuyerController(ECommerceContext context)
        {
            _context = context;
        }

        // GET: Buyer
        public async Task<IActionResult> Index()
        {
              return _context.Buyer != null ? 
                          View(await _context.Buyer.ToListAsync()) :
                          Problem("Entity set 'ECommerceContext.Buyer'  is null.");
        }

        // GET: Buyer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Buyer == null)
            {
                return NotFound();
            }

            var buyer = await _context.Buyer
                .FirstOrDefaultAsync(m => m.BuyerId == id);
            if (buyer == null)
            {
                return NotFound();
            }

            return View(buyer);
        }

        // GET: Buyer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buyer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BuyerId,FirstName,LastName,EmailAddress,PhoneNumber,HouseAddress,RegistrationDate")] Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buyer);
        }

        // GET: Buyer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Buyer == null)
            {
                return NotFound();
            }

            var buyer = await _context.Buyer.FindAsync(id);
            if (buyer == null)
            {
                return NotFound();
            }
            return View(buyer);
        }

        // POST: Buyer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BuyerId,FirstName,LastName,EmailAddress,PhoneNumber,HouseAddress,RegistrationDate")] Buyer buyer)
        {
            if (id != buyer.BuyerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyerExists(buyer.BuyerId))
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
            return View(buyer);
        }

        // GET: Buyer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Buyer == null)
            {
                return NotFound();
            }

            var buyer = await _context.Buyer
                .FirstOrDefaultAsync(m => m.BuyerId == id);
            if (buyer == null)
            {
                return NotFound();
            }

            return View(buyer);
        }

        // POST: Buyer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Buyer == null)
            {
                return Problem("Entity set 'ECommerceContext.Buyer'  is null.");
            }
            var buyer = await _context.Buyer.FindAsync(id);
            if (buyer != null)
            {
                _context.Buyer.Remove(buyer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyerExists(int id)
        {
          return (_context.Buyer?.Any(e => e.BuyerId == id)).GetValueOrDefault();
        }
    }
}
