#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp_RCP.Data;
using WebApp_RCP.Models;

namespace WebApp_RCP.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly WebApp_RCP.Data.WebApp_RCPContext _context;

        public IndexModel(WebApp_RCP.Data.WebApp_RCPContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
