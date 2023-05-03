using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using RenewalTracker_API.Models;

namespace RenewalTracker_API.Controllers
{
    [ApiController]
    public class RenewalController : ControllerBase
    {
        [HttpGet]
        [Route("api/renewal")]
        public ActionResult GetAll()
        {
            var db = new MongoClient(configuration.mongoServer);
            var database = db.GetDatabase(configuration.mongoDatabase);
            var collection = database.GetCollection<Renewal>(configuration.renewalsCollection);

            var results = collection.AsQueryable()
                .Where(r => r.Active)
                .ToList();

            return Ok(results);
        }

        [HttpGet]
        [Route("api/renewal/{id}")]
        public ActionResult GetOne(int id)
        {
            var db = new MongoClient(configuration.mongoServer);
            var database = db.GetDatabase(configuration.mongoDatabase);
            var collection = database.GetCollection<Renewal>(configuration.renewalsCollection);

            var results = collection.AsQueryable()
                .FirstOrDefault(v => v.Id == id);

            return Ok(results);
        }

        [Route("api/renewal/create")]
        [HttpGet]
        public ActionResult Create(string name, DateTime expiration, int categoryids, int priority, int currentvendorid, string? notes, bool active = true)
        {
            var db = new MongoClient(configuration.mongoServer);
            var database = db.GetDatabase(configuration.mongoDatabase);
            var collection = database.GetCollection<Renewal>(configuration.renewalsCollection);

            try
            {
                Random rnd = new Random();

                var renewal = new Renewal
                {
                    Id = rnd.Next(100000, 999999),
                    Name = name,
                    CategoryIds = categoryids,
                    Priority = priority,
                    Expiration = expiration,
                    CurrentVendorId = currentvendorid,
                    Notes = notes,
                    Active = true
                };

                collection.InsertOne(renewal);

                return Ok(renewal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/renewal/delete/{id}")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new MongoClient(configuration.mongoServer);
            var database = db.GetDatabase(configuration.mongoDatabase);
            var collection = database.GetCollection<Renewal>(configuration.renewalsCollection);

            try
            {
                return Ok(collection.DeleteOne(r => r.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/renewal/seed")]
        [HttpGet]
        public ActionResult Seed()
        {
            var db = new MongoClient(configuration.mongoServer);
            var database = db.GetDatabase(configuration.mongoDatabase);
            var collection = database.GetCollection<Renewal>(configuration.renewalsCollection);

            try
            {
                var renewal = new Renewal
                {
                    Id = 987654,
                    Name = "SSL Certificate - probononj.org",
                    CategoryIds = 747222,
                    Priority = 3,
                    Expiration = new DateTime(2023,05,05),
                    CurrentVendorId = 299606,
                    Notes = "This purchase is to renew the SSL Unified Communications Certificate that encrypts traffic on probononj.org.",
                    Active = true
                };

                collection.InsertOne(renewal);

                return Ok(renewal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
