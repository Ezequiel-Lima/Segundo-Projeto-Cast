using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManterClasseAPI.Data;
using ManterClasseAPI.Models;

namespace ManterClasseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasseObjetoesController : ControllerBase
    {
        private readonly ManterClasseAPIContext _context;

        public ClasseObjetoesController(ManterClasseAPIContext context)
        {
            _context = context;
        }

        // GET: api/ClasseObjetoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClasseObjeto>>> GetClasseObjeto()
        {
            return await _context.ClasseObjeto.ToListAsync();
        }

        // GET: api/ClasseObjetoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClasseObjeto>> GetClasseObjeto(int id)
        {
            var classeObjeto = await _context.ClasseObjeto.FindAsync(id);

            if (classeObjeto == null)
            {
                return NotFound();
            }

            return classeObjeto;
        }

        // PUT: api/ClasseObjetoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasseObjeto(int id, ClasseObjeto classeObjeto)
        {
            if (id != classeObjeto.Id)
            {
                return BadRequest();
            }

            _context.Entry(classeObjeto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasseObjetoExists(id))
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

        // POST: api/ClasseObjetoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClasseObjeto>> PostClasseObjeto(ClasseObjeto classeObjeto)
        {
            _context.ClasseObjeto.Add(classeObjeto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClasseObjeto", new { id = classeObjeto.Id }, classeObjeto);
        }

        // DELETE: api/ClasseObjetoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClasseObjeto(int id)
        {
            var classeObjeto = await _context.ClasseObjeto.FindAsync(id);
            if (classeObjeto == null)
            {
                return NotFound();
            }

            _context.ClasseObjeto.Remove(classeObjeto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClasseObjetoExists(int id)
        {
            return _context.ClasseObjeto.Any(e => e.Id == id);
        }
    }
}
