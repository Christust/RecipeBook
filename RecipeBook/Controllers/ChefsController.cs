using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Data;
using RecipeBook.DTOs.Chef;
using RecipeBook.DTOs.Recipe;
using RecipeBook.Models;

namespace RecipeBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly DataContext _context;

        public ChefsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Chefs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RetrieveChef>>> GetChefs()
        {
            return await _context.Chefs.Select(ch=> new RetrieveChef
            {
                Id = ch.Id,
                Name = ch.Name,
                LastName = ch.LastName,
                Recipes = (ICollection<RetrieveChefRecipes>)ch.Recipes.Select(r => new RetrieveChefRecipes { Id = r.Id, Name = r.Name, Description = r.Description }),
            }).ToListAsync();
        }

        // GET: api/Chefs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RetrieveChef>> GetChef(int id)
        {
            var chef = await _context.Chefs.Select(ch => new RetrieveChef
            {
                Id = ch.Id,
                Name = ch.Name,
                LastName = ch.LastName,
                Recipes = (ICollection<RetrieveChefRecipes>)ch.Recipes.Select(r => new RetrieveChefRecipes { Id = r.Id, Name = r.Name, Description = r.Description }),
            }).FirstOrDefaultAsync(ch=>ch.Id==id);

            if (chef == null)
            {
                return NotFound();
            }

            return chef;
        }

        // PUT: api/Chefs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChef(int id, Chef chef)
        {
            if (id != chef.Id)
            {
                return BadRequest();
            }

            _context.Entry(chef).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChefExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Chefs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chef>> PostChef(CreateChef createChef)
        {
            var chef = new Chef
            {
                Name = createChef.Name,
                LastName = createChef.LastName,
            };
            _context.Chefs.Add(chef);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChef", new { id = chef.Id }, chef);
        }

        // DELETE: api/Chefs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChef(int id)
        {
            var chef = await _context.Chefs.FindAsync(id);
            if (chef == null)
            {
                return NotFound();
            }

            _context.Chefs.Remove(chef);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChefExists(int id)
        {
            return _context.Chefs.Any(e => e.Id == id);
        }
    }
}
