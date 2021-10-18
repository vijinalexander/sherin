using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly pharmvcContext db;
        public AdminController(pharmvcContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await db.ProductDetails.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDetail p)
        {
            db.ProductDetails.Add(p);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditProduct(int id, ProductDetail p)
        {
            //ProductDetail p  =db.ProductDetails.Find(id);
            db.Entry(p).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            ProductDetail i = db.ProductDetails.Find(id);
            db.ProductDetails.Remove(i);
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("GetbyId")]
        public async Task<IActionResult> GetByProductId(int id)
        {
            ProductDetail i = await db.ProductDetails.FindAsync(id);
            return Ok(i);
        }
    }
}
