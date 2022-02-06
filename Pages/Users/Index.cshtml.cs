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
        private readonly ILogger<PrivacyModel> _logger;

        [BindProperty]
        public string FindhUsername { get; set; }

        [BindProperty]
        public string FindPassword { get; set; }

        

        public IndexModel(ILogger<PrivacyModel> logger, WebApp_RCP.Data.WebApp_RCPContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IList<User> UsersList { get; set; }

        public async Task OnGetAsync()
        {

            UsersList = await _context.User.ToListAsync();

           
        }
    }
}
