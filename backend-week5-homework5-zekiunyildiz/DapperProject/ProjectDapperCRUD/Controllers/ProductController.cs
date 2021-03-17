using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectDapperCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDapperCRUD.Controllers
{
    [ApiController]
    [Route("/[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly ProductRepo productRepo;
        public ProductController()
        {
            productRepo = new ProductRepo();
        }


        [HttpGet]
        public  IEnumerable<Product> Get()
        {
            return productRepo.GetAll();
        }


        [HttpGet]
        public  Product Get(int id)
        {
            return productRepo.GetById(id);
        }


        [HttpGet]
        public IActionResult Post([FromBody]Product product)
        {
            if (ModelState.IsValid)
                productRepo.Add(product);
            return Ok();
        }


        [HttpGet]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            product.ProductId = id;
            if (ModelState.IsValid)
                productRepo.Update(product);
            return Ok();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            productRepo.Delete(id);
            return Ok();
        }
    }
}
