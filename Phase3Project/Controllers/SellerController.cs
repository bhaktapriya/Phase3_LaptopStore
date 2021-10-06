using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Controllers
{
    public class SellerController : Controller
    {
        private readonly LaptopDBContext _context;

        public SellerController(LaptopDBContext context)
        {
            _context = context;
        }

        // GET: Seller
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tblaptops.ToListAsync());
        }

        // GET: Seller/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblaptop = await _context.Tblaptops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblaptop == null)
            {
                return NotFound();
            }

            return View(tblaptop);
        }

        // GET: Seller/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seller/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Colour,Quantity,CostPerLaptop")] Tblaptop tblaptop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblaptop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblaptop);
        }

        // GET: Seller/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblaptop = await _context.Tblaptops.FindAsync(id);
            if (tblaptop == null)
            {
                return NotFound();
            }
            return View(tblaptop);
        }

        // POST: Seller/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Colour,Quantity,CostPerLaptop")] Tblaptop tblaptop)
        {
            if (id != tblaptop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblaptop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblaptopExists(tblaptop.Id))
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
            return View(tblaptop);
        }

        // GET: Seller/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblaptop = await _context.Tblaptops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblaptop == null)
            {
                return NotFound();
            }

            return View(tblaptop);
        }

        // POST: Seller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblaptop = await _context.Tblaptops.FindAsync(id);
            _context.Tblaptops.Remove(tblaptop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblaptopExists(int id)
        {
            return _context.Tblaptops.Any(e => e.Id == id);
        }
    }
}
