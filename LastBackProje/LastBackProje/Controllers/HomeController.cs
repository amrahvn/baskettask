using LastBackProje.DataAccesLAyer;
using LastBackProje.Models;
using LastBackProje.ViewModels.HomeVms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LastBackProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            HomeVm homeVm = new HomeVm
            {
                Sliders = await _context.Sliders.Where(s => s.IsDeleted == false).ToListAsync(),


                categories= await _context.Categories.Where(c => c.IsDeleted == false && c.IsMain == true).ToListAsync(),

                NewArrival = await _context.Products.Where(p=>p.IsDeleted == false && p.IsNewArrival).ToListAsync(),

                BestSeller = await _context.Products.Where(p => p.IsDeleted == false && p.IsBestSeller).ToListAsync(),

                Featured = await _context.Products.Where(p => p.IsDeleted == false && p.IsFeature).ToListAsync(),
            };


            return View(homeVm);
        }

       //public IActionResult SetCookie()
       // {
       //     Response.Cookies.Append("EmrahCookie", "Hello Guys");

       //     return Ok();
       // }

       // public IActionResult GetCookie()
       // {
       //    string cookie=  Request.Cookies["basket"];

       //     return Ok(cookie);
       // }
    }
}
