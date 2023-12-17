using MaturitetnaSpletnaStran.DataDB;
using MaturitetnaSpletnaStran.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MaturitetnaSpletnaStran.Pages
{
    public class Credentials
    {
        [Required]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

	//[Authorize(Policy = "RequireAnonymous")]
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
        private readonly MaturitetnaContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [BindProperty]
		public Credentials Credentials { get; set; }



        public IndexModel(ILogger<IndexModel> logger, MaturitetnaContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
		{
			if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
			{
				
				Response.Redirect("/Dashboard");
			}
		}

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();


            var user = _dbContext.ClientUsers
                .FirstOrDefault(u => u.Email == Credentials.Email && u.Password == Credentials.Password);

            if (user != null)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, "Admin")
                };
                var claimsIdentity = new ClaimsIdentity(claims, "MyAuthScheme");
                await _httpContextAccessor.HttpContext
                    .SignInAsync("MyAuthScheme",
                        new ClaimsPrincipal(claimsIdentity),
                        new AuthenticationProperties());

                _logger.LogInformation("User logged in successfully");
                return RedirectToPage("/Dashboard");
            }
            else
            {
                // User not found or invalid credentials, handle accordingly
                // For simplicity, let's just log a message
                _logger.LogWarning("Invalid credentials");
                return Page();
            }
        }
    }
}