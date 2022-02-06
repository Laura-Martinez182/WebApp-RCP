#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp_RCP.Data;
using WebApp_RCP.Models;

namespace WebApp_RCP.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly WebApp_RCP.Data.WebApp_RCPContext _context;
        [BindProperty]
        public User User { get; set; }
        public IList<User> UsersList { get; set; }

        public string CheckPassword { get; set; }

        public CreateModel(WebApp_RCP.Data.WebApp_RCPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task findUsername()
        {
            var users = from m in _context.User
                             select m;
            
            if (!string.IsNullOrEmpty(User.UserName))
            {
                users = users.Where(s => s.UserName.Equals(User.UserName));
            }

            UsersList = await users.ToListAsync();

            if (UsersList.Count == 1)
            {
                ViewData["Message"] = "This user is already registered on the platform, try again";
            }
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            ViewData["Message"] = null;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (CheckPassword.Equals(User.Password))
            {
                await findUsername();

                if (ViewData["Message"] == null)
                {
                    _context.User.Add(User);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("../Index");
                }
            }

            else
            {
                ViewData["Message"] = "Passwords don't match, try again";
            }
            return RedirectToPage("./Index");
        }
    }
}
