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
    public class CustomerController : Controller
    {
        private readonly LaptopDBContext _context;

        public CustomerController(LaptopDBContext context)
        {
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tblaptops.ToListAsync());
        }

        // GET: Customer/Details/5
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

        private bool TblaptopExists(int id)
        {
            return _context.Tblaptops.Any(e => e.Id == id);
        }

        public IActionResult Order()
        {
            return View();
        }
    }
}
