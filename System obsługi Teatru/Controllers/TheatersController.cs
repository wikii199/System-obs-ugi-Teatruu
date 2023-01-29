using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System_obsługi_Teatru.Models;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace System_obsługi_Teatru.Controllers
{
    public class TheatersController : Controller
    {
        private readonly AppDbContext _context;

        public TheatersController(AppDbContext context)
        {
            _context = context;
        }

    
        public async Task<IActionResult> Index()
        {
            return View(await _context.Theaters.ToListAsync());
        }

   
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theater = await _context.Theaters
                .FirstOrDefaultAsync(m => m.TheaterId == id);
            if (theater == null)
            {
                return NotFound();
            }

            return View(theater);
        }

      
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TheaterId,TheaterName,City,Password,Email,Address,NoOfScreen")] Theater theater)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theater);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SignInForTheater));
            }
            return View(theater);
        }

     
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theater = await _context.Theaters.FindAsync(id);
            if (theater == null)
            {
                return NotFound();
            }
            return View(theater);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TheaterId,TheaterName,City,Password,Email,Address,NoOfScreen")] Theater theater)
        {
            if (id != theater.TheaterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theater);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheaterExists(theater.TheaterId))
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
            return View(theater);
        }

    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theater = await _context.Theaters
                .FirstOrDefaultAsync(m => m.TheaterId == id);
            if (theater == null)
            {
                return NotFound();
            }

            return View(theater);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var theater = await _context.Theaters.FindAsync(id);
            _context.Theaters.Remove(theater);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TheaterExists(int id)
        {
            return _context.Theaters.Any(e => e.TheaterId == id);
        }

        [HttpGet]
        public IActionResult SignInForTheater()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignInForTheater(Theater theater)
        {
            var userDetails = _context.Theaters.Where(x => x.TheaterName == theater.TheaterName && x.Password == theater.Password).FirstOrDefault();

            if (userDetails == null)
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View("SignInForTheater");
            }
            else
            {
                HttpContext.Session.SetString("TheaterName", userDetails.TheaterName);
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult LogOutForTheater()
        {
            HttpContext.Session.SetString("TheaterName", "");
            return View("SignInForTheater");
        }
    }
}
