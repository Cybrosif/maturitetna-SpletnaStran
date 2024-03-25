using maturitetna_NovaTestnaStran.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace maturitetna_NovaTestnaStran.Controllers;

public class GetUserInfo
{
    private static ApplicationDbContext _context;
    private static  UserManager<IdentityUser> _userManager;
    private static HttpContext _httpContext;
        
    public GetUserInfo(ApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _context = context;
        _httpContext = httpContextAccessor.HttpContext;
    }
        
    public static async Task<string?> GetUserDomain()
    {
        // Get user information from HttpContext
        IdentityUser user = await _userManager.GetUserAsync(_httpContext.User);
        string userId = user.Id;
        int domainId = await _context.UserDomain
            .Where(ud => ud.UserId == userId)
            .Select(ud => ud.DomainId)
            .FirstOrDefaultAsync();
        string domain = await _context.Domain
            .Where(d => d.Id == domainId)
            .Select(ud => ud.Domain)
            .FirstOrDefaultAsync();

        return domain;
    }
}