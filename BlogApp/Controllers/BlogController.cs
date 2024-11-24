using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        private static int _nextId = 1;
        private static List<BlogPost> _posts = new List<BlogPost>();
        public IActionResult Index()
        {
            ViewBag.TotalPosts =_posts.Count;
            ViewData["PageTitle"] = "Blog Gönderileri";
            return View(_posts);
        }
        public IActionResult Create()
        {
            ViewBag.CurrentTime = DateTime.Now;
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogPost blogpost)
        {
            if (ModelState.IsValid)
            {
                blogpost.Id = _nextId++;
                _posts.Add(blogpost);
                TempData["SuccessMessage"] = "Blog gönderisi başarı ile oluşturuldu";

                return RedirectToAction(nameof(Index));
            }
            ViewBag.CurrentTime = DateTime.Now; 
            return View(blogpost);
        }

        public IActionResult Details(int id)
        {
            var posts = _posts.FirstOrDefault(x => x.Id == id);
            if(posts == null)
            {
                return NotFound();
            }

            ViewData["CreatedAgo"] = $"{(DateTime.Now - posts.CreateAt).TotalMinutes} dakika önce";
            return View(posts);
        }
    }
}
