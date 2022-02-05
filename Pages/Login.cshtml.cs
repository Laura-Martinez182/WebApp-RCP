using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_RCP.Models;
namespace WebApp_RCP.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User userData { get; set; }
        public void OnGet()
        {
        }
    }
}
