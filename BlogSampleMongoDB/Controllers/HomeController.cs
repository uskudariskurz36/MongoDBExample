using BlogSampleMongoDB.Entities;
using BlogSampleMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;

namespace BlogSampleMongoDB.Controllers
{
    public class HomeController : Controller
    {
        // Mongo sunucuya bağlan..
        MongoClient client;

        // Mongo daki veri tabanına bağlan..
        IMongoDatabase database;

        // Veri tabanındaki koleksiyona bağlan.
        IMongoCollection<Blog> blogCollection;


        public HomeController()
        {
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("myblogdb");
            blogCollection = database.GetCollection<Blog>("blogs");
        }


        public IActionResult Index()
        {
            return View(blogCollection.AsQueryable().ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Blog blog = new Blog();
                blog.Id = ObjectId.GenerateNewId();
                blog.Title = model.Title;
                blog.Description = model.Description;
                blog.Category = model.Category;

                blogCollection.InsertOne(blog);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Edit(string id)
        {
            ObjectId objectId = ObjectId.Parse(id);
            Blog blog = blogCollection.AsQueryable().FirstOrDefault(x => x.Id == objectId);

            BlogEditViewModel model = new BlogEditViewModel
            {
                Title = blog.Title,
                Description = blog.Description,
                Category = blog.Category
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(string id, BlogEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                ObjectId objectId = ObjectId.Parse(id);
                Blog blog = blogCollection.AsQueryable().FirstOrDefault(x => x.Id == objectId);

                blog.Title = model.Title;
                blog.Description = model.Description;
                blog.Category = model.Category;

                blogCollection.ReplaceOne(x => x.Id == objectId, blog);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        public IActionResult Delete(string id)
        {
            ObjectId objectId = ObjectId.Parse(id);
            blogCollection.DeleteOne(x => x.Id == objectId);

            return RedirectToAction(nameof(Index));
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