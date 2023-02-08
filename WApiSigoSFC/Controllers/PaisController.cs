using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WApiSigoSFC.Models;
namespace WApiSigoSFC.Controllers
{
    [Produces("application/json")]
    [Route("api/Pais")]
    public class PaisController : Controller
    {
        private readonly ApplicationDBContext context;

        public PaisController(ApplicationDBContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IEnumerable<Pais> Get()
        {
            return context.Paises.Include(x => x.Provincias).ToList();
        }
        [HttpGet("{id}", Name = "paisCreado")]
        public IActionResult GetById(int id)
        {
            var pais = context.Paises.FirstOrDefault(x => x.Id == id);
            if (pais == null)
            {
                return NotFound();
            }
            return Ok(pais);
        }
        [HttpPost]
        public IActionResult Post([FromBody]Pais pais)
        {
            if (ModelState.IsValid)
            {
                context.Paises.Add(pais);
                context.SaveChanges();
                return new CreatedAtRouteResult("paisCreado", new { id = pais.Id }, pais);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Pais pais, int id)
        {
            if (pais.Id != id)
            {
                return BadRequest();
            }

            context.Entry(pais).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pais = context.Paises.FirstOrDefault(x => x.Id == id);
            if (pais == null)
            {
                return NotFound();
            }

            context.Paises.Remove(pais);
            context.SaveChanges();
            return Ok(pais);
        }
    }
}