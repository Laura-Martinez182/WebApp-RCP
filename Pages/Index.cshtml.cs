using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp_RCP.Data;
using WebApp_RCP.Models;


namespace WebApp_RCP.Pages
{
    public class IndexModel : PageModel
    {

        private readonly WebApp_RCP.Data.WebApp_RCPContext _context;
        private readonly ILogger<PrivacyModel> _logger;
        public bool Empty { get; set; }
        public bool Found { get; set; }
        [BindProperty(SupportsGet = true)]
        public String UserID { get; set; }
        [BindProperty(SupportsGet = true)]
        public String Password { get; set; }
        


        public IndexModel(ILogger<PrivacyModel> logger, WebApp_RCP.Data.WebApp_RCPContext context)
        {
            _logger = logger;
            _context = context;
            Empty = false;
            Found = true;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            Empty = false;
            Found = true;

            if (UserID != null && Password != null)
            {
                var data = _context.User.FirstOrDefault(u => u.UserName == UserID && u.Password == Password);
                if (data is null)
                {
                    Found = false;
                    return Page();
                }
                else
                {
                    return RedirectToPage("./Users/Index");
                }
            }
            else
            {
                Empty = true;
                return Page();
            }
        }
    }
}
