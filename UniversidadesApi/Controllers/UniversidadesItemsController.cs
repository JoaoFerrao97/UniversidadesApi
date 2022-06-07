using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversidadesApi.Models;
using Newtonsoft.Json;



namespace UniversidadesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversidadesItemsController : ControllerBase
    {
        private readonly UniversidadesContext _context;

        public UniversidadesItemsController(UniversidadesContext context)
        {
            _context = context;
        }


        // GET: api/UniversidadesItems
        [HttpGet]

        public object Get()
        {
            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.Add("APIKey", "Application/Json");
            string _context = http.GetAsync(" http://universities.hipolabs.com/search?country=portugal").Result.Content.ReadAsStringAsync().Result;
            List<UniversidadesItem> universidadesitemObject = JsonConvert.DeserializeObject<List<UniversidadesItem>>(_context);

            // int number_of_elements = universidadesitemObject.Count; // Número de elementos na lista.
            
            return universidadesitemObject; 
        }

        


        /*
        public async Task<ActionResult<IEnumerable<UniversidadesItem>>> GetUniversidadesItems()
        {
            if (_context.UniversidadesItems == null)
          {
              return NotFound();
          }


            Console.WriteLine(typeof(_context);
            return await _context.UniversidadesItems.ToListAsync();

        }*/


        /*
        // GET: api/UniversidadesItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UniversidadesItem>> GetUniversidadesItem(long id)
        {
          if (_context.UniversidadesItems == null)
          {
              return NotFound();
          }
            
          var universidadesItem = await _context.UniversidadesItems.FindAsync(id);

           if (universidadesItem == null)
           {
               return NotFound();
           }

            return universidadesItem;
        }
        /*
        // PUT: api/UniversidadesItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversidadesItem(long id, UniversidadesItem universidadesItem)
        {
            if (id != universidadesItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(universidadesItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversidadesItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/
        /*
        // POST: api/UniversidadesItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UniversidadesItem>> PostUniversidadesItem(UniversidadesItem universidadesItem)
        {
          if (_context.UniversidadesItems == null)
          {
              return Problem("Entity set 'UniversidadesContext.TodoItems'  is null.");
          }
            _context.UniversidadesItems.Add(universidadesItem);
            await _context.SaveChangesAsync();

           
            // return CreatedAtAction("GetUniversidadesItem", new { id = universidadesItem.Id }, universidadesItem);
            return CreatedAtAction(nameof(GetUniversidadesItem), new { id = universidadesItem.Id }, universidadesItem);
        }*/

        /*

        // DELETE: api/UniversidadesItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversidadesItem(long id)
        {
            if (_context.UniversidadesItems == null)
            {
                return NotFound();
            }
            var universidadesItem = await _context.UniversidadesItems.FindAsync(id);
            if (universidadesItem == null)
            {
                return NotFound();
            }

            _context.UniversidadesItems.Remove(universidadesItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/
        /*
        private bool UniversidadesItemExists(long id)
        {
            return (_context.UniversidadesItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
   
}

