using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WApiSigoSFC.Models;
namespace WApiSigoSFC.Controllers
{
    [Produces("application/json")]
    [Route("api/Pais/{PaisId}/Provincia")]
    public class ProvinciaController : Controller
    {
        private readonly ApplicationDBContext context;

        public ProvinciaController(ApplicationDBContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IEnumerable<Provincia> GetAll(int PaisId)
        {
            return context.Provincias.Where(x => x.PaisId == PaisId).ToList();
        }
        [HttpGet("{id}", Name = "provinciaById")]
        public IActionResult GetById(int id)
        {
            var pais = context.Provincias.FirstOrDefault(x => x.Id == id);
            if (pais == null)
            {
                return NotFound();
            }
            return Ok(pais);
        }
        [HttpPost]
        public IActionResult Post([FromBody]Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                context.Provincias.Add(provincia);
                context.SaveChanges();
                return new CreatedAtRouteResult("provinciaById", new { id = provincia.Id }, provincia);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody]Provincia provincia, int id)
        {
            if (provincia.Id != id)
            {
                return BadRequest();
            }

            context.Entry(provincia).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var provincia = context.Provincias.FirstOrDefault(x => x.Id == id);
            if (provincia == null)
            {
                return NotFound();
            }

            context.Provincias.Remove(provincia);
            context.SaveChanges();
            return Ok(provincia);
        }
    }
}