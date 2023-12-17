using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaturitetnaSpletnaStran.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            await HttpContext.SignOutAsync("MyAuthScheme");

            // Redirect to a confirmation or success page
            return RedirectToPage("/Index");
        }
    }
}
