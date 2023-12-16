using MaturitetnaSpletnaStran.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaturitetnaSpletnaStran.Pages
{
    public class ServerInfoModel : PageModel
    {
        public Server test { get; set; }
        public void OnGet()
        {
			test = new Server();
		}
    }
}
