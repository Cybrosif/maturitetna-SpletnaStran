using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace MaturitetnaSpletnaStran.Pages
{
    [Authorize]
    public class DashboardModel : PageModel
    {
        public string UserEmail { get; private set; }

        public void OnGet()
        {
            var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            if (userEmailClaim != null)
            {
                UserEmail = userEmailClaim.Value;
            }
        }

	}
}
