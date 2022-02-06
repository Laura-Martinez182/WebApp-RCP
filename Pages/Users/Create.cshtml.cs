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
        

        public CreateModel(WebApp_RCP.Data.WebApp_RCPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.User.Add(User);
            await _context.SaveChangesAsync();
            return RedirectToPage("../Index");
        }
    }
}
