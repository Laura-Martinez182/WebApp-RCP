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

        public new IList<User> UsersList { get; set; }

        public IndexModel(ILogger<PrivacyModel> logger, WebApp_RCP.Data.WebApp_RCPContext context)
        {
            _logger = logger;
            _context = context;

        }

        public async Task OnGetAsync()
        {
            var users = from m in _context.User
                        select m;

            if (!string.IsNullOrEmpty(FindhUsername))
            {
                users = users.Where(s => s.UserName.Equals(FindhUsername));
            }

            UsersList = await users.ToListAsync();

            if (UsersList.Count == 1)
            {
                if (UsersList.ElementAt(0).Password.Equals(FindPassword) && !string.IsNullOrEmpty(FindPassword))
                {
                    ViewData["Message"] = UsersList.ElementAt(0).UserName;
                    UsersList = await users.ToListAsync();
                }
                else
                {
                    Response.Redirect("./Index");
                }
            }

            else
            {
                Response.Redirect("./Index");
            }
        }
    }
}
