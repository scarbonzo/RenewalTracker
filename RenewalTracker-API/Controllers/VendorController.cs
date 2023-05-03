using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using RenewalTracker_API.Models;

namespace RenewalTracker_API.Controllers
{
    [ApiController]
    public class VendorController : ControllerBase
    {
        [HttpGet]
        [Route("api/vendor")]
        public ActionResult GetAll()
        {
            var db = new MongoClient(configuration.mongoServer);
            var database = db.GetDatabase(configuration.mongoDatabase);
            var collection = database.GetCollection<Vendor>(configuration.vendorsCollection);

            var results = collection.AsQueryable()
                .Where(v => v.Active)
                .ToList();

            return Ok(results);
        }

        [HttpGet]
        [Route("api/vendor/{id}")]
        public ActionResult GetOne(int id)
        {
            var db = new MongoClient(configuration.mongoServer);
            var database = db.GetDatabase(configuration.mongoDatabase);
            var collection = database.GetCollection<Vendor>(configuration.vendorsCollection);

            var results = collection.AsQueryable()
                .FirstOrDefault(v => v.Id == id);

            return Ok(results);
        }

        [Route("api/vendor/create")]
        [HttpGet]
        public ActionResult Create(string name, string contactInfo, string? notes, bool active = true)
        {
            var db = new MongoClient(configuration.mongoServer);
            var database = db.GetDatabase(configuration.mongoDatabase);
            var collection = database.GetCollection<Vendor>(configuration.vendorsCollection);

            try
            {
                Random rnd = new Random();

                var vendor = new Vendor
                {
                    Id = rnd.Next(100000, 999999),
                    Name = name,
                    ContactInfo = contactInfo,
                    Notes = notes,
                    Active = true
                };

                collection.InsertOne(vendor);

                return Ok(vendor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/vendor/delete/{id}")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new MongoClient(configuration.mongoServer);
            var database = db.GetDatabase(configuration.mongoDatabase);
            var collection = database.GetCollection<Vendor>(configuration.vendorsCollection);

            try
            {
                return Ok(collection.DeleteOne(v => v.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
