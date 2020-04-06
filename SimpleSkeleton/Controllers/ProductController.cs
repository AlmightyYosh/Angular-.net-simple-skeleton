using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleSkeleton.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleSkeleton.Models;

namespace SimpleSkeleton.Controllers
{
    //the route control 
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get;  }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        //Get: meaning to get data from the database 
        //Post: adding a new thing to the database. 
        //put: which is updating the database
        //Patch: simple changing a small part of the database. 

        //[HttpPatch] "[FromBody]"
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery]string ProductId,
            [FromQuery]int Rating)
        {
            ProductService.AddRating(ProductId, Rating);
            return Ok();

            
        }
    }
}