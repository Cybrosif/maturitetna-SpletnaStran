using MaturitetnaSpletnaStran.DataDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;





public class Startup
{
    public IConfiguration configRoot
    {
        get;
    }
    public Startup(IConfiguration configuration)
    {
        configRoot = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<MaturitetnaContext>(options =>
            options.UseSqlServer("Server=.\\sqlexpress;Initial Catalog=Maturitetna;Integrated Security=True"));

        services.AddAuthentication("MyAuthScheme")
        .AddCookie("MyAuthScheme", options => {
            options.LoginPath = "/Index";
            //options.LogoutPath = "/Logout";
            //options.AccessDeniedPath = "/AccessDenied";
        });

		/*services.AddAuthorization(options =>
		{
			options.AddPolicy("RequireAnonymous", policy =>
			{
				policy.RequireClaim(ClaimTypes.NameIdentifier, "");
			});
		});*/

		services.AddHttpContextAccessor();
        
        services.AddRazorPages();
    }
    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapRazorPages();
        app.Run();
    }
}