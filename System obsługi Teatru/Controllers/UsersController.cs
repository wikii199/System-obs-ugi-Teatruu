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
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;
        

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

      
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

       
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SignInForUser));
            }
            return View(user);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,FirstName,LastName,UserName,Password,Gender,MobileNo,Email,Address")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Profile));
            }
            return View(user);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        [HttpGet]
        public IActionResult SignInForUser()
        {
            HttpContext.Session.SetString("UserName", "");
            return View();
        }

        [HttpPost]
        public IActionResult SignInForUser(User user)
        {
            if (user.UserName == "Admin" && user.Password == "Admin")
            {
                HttpContext.Session.SetString("UserName", "Admin" );
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var userDetails = _context.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();

                if (userDetails == null)
                {
                    ModelState.AddModelError("", "Invalid UserName or Password");
                    return View("SignInForUser");
                }
                else
                {
                    HttpContext.Session.SetString("UserName", userDetails.UserName);

                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public IActionResult LogOutForUser()
        {
            HttpContext.Session.SetString("UserName", "" );
            return View("SignInForUser");
        }

        public IActionResult Profile()
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == HttpContext.Session.GetString("UserName"));
            return View("Details",user);
        }

    }
}
