using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.CQRS.Data;
using WebApp.Sipmple.Pattern.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Sipmple.Pattern.Controllers
{
    [Route("api/v1.1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly MyAppDbContext _myWorldDbContext;

        public ProductController(MyAppDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            var prod =  _myWorldDbContext.Products
           .Select(_ => new GetProductsResponseModel
           {
               Description = _.Description,
               ProductId = _.Id,
               Manufacturer = _.Manufacture,
               Name = _.Name,
               Price = _.Price
           }).ToList();
             
            return Ok(prod);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        [Route("create")]
        public IActionResult Post([FromBody] SaveProductRequestModel request)
        {

            byte[] randomBytes = new byte[4];
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                rnd.NextBytes(randomBytes);
                var newProducts = new Product
                {
                    Description = request.Description + randomBytes[0].ToString(),
                    Manufacture = request.Manufacturer + randomBytes[1].ToString(),
                    Name = request.Name + randomBytes[2].ToString(),
                    Price = request.Price + randomBytes[3]
                };
                System.Threading.Thread.Sleep(12);
                _myWorldDbContext.Products.Add(newProducts);
                var rr = _myWorldDbContext.SaveChanges();
            }

            return Ok("1");
       
        }

        //// PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
