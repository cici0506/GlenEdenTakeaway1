using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlenEdenTakeaway.Areas.Identity.Data;
using GlenEdenTakeaway.Models;
using Microsoft.AspNetCore.Authorization;

namespace GlenEdenTakeaway.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly IdentityContext _context;

        public CustomersController(IdentityContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index(string searchString)
        {
            /*if (_context.Customer == null)
            {
                return Problem("Entity set 'IdentityContext.Customers'  is null.");
            }

            var customers = from c in _context.Customer
                            select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.LastName!.StartsWith(searchString));
            }

            return View(await customers.ToListAsync());*/

            var identityContext = _context.Customer.Include(c => c.Payments);
            return View(await identityContext.ToListAsync());
        }
        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var Customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (Customer == null)
            {
                return NotFound();
            }

            return View(Customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,PhoneNumber,Email,Street,City,ZipCode")] Customer Customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var Customer = await _context.Customer.FindAsync(id);
            if (Customer == null)
            {
                return NotFound();
            }
            return View(Customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,PhoneNumber,Email,Street,City,ZipCode")] Customer Customer)
        {
            if (id != Customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(Customer.CustomerId))
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
            return View(Customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var Customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (Customer == null)
            {
                return NotFound();
            }

            return View(Customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'IdentityContext.Customer'  is null.");
            }
            var Customer = await _context.Customer.FindAsync(id);
            if (Customer != null)
            {
                _context.Customer.Remove(Customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
          return (_context.Customer?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
