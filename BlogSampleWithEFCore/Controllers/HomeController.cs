using BlogSampleWithEFCore.Entities;
using BlogSampleWithEFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BlogSampleWithEFCore.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext _databaseContext;

        public HomeController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            Post post = _databaseContext.Posts
                .Include(x => x.Category)
                .Include(x => x.Author)
                .Include(x => x.Comments)
                .Include(x => x.Tags)
                .Include(x => x.LikeUsers)
                .First();


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}