using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using RenewalTracker_API.Models;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RenewalTracker_API.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("api/category")]
        public ActionResult GetAll()
        {
            var db = new MongoClient(configuration.mongoServer);
            var database = db.GetDatabase(configuration.mongoDatabase);
            var collection = database.GetCollection<Category>(configuration.categoriesCollection);

            var results = collection.AsQueryable()
                .Where(c => c.Active)
                .ToList();

            return Ok(results);
        }

        [HttpGet]
        [Route("api/category/{id}")]
        public ActionResult GetOne(int id)
        {
            var db = new MongoClient(configuration.mongoServer);
            var database = db.GetDatabase(configuration.mongoDatabase);
            var collection = database.GetCollection<Category>(configuration.categoriesCollection);

            var results = collection.AsQueryable()
                .FirstOrDefault(c => c.Id == id);

            return Ok(results);
        }
                
        [Route("api/category/create")]
        [HttpGet]
        public ActionResult Create(string name, string? notes, bool active = true)
        {
            var db = new MongoClient(configuration.mongoServer);
            var database = db.GetDatabase(configuration.mongoDatabase);
            var collection = database.GetCollection<Category>(configuration.categoriesCollection);

            try
            {
                Random rnd = new Random();

                var category = new Category
                {
                    Id = rnd.Next(100000,999999),
                    Name = name,
                    Notes = notes,
                    Active = true
                };

                collection.InsertOne(category);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/category/delete/{id}")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new MongoClient(configuration.mongoServer);
            var database = db.GetDatabase(configuration.mongoDatabase);
            var collection = database.GetCollection<Category>(configuration.categoriesCollection);

            try
            {
                return Ok(collection.DeleteOne(c => c.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
