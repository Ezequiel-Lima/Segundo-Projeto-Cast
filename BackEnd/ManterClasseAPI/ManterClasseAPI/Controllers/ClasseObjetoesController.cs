using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManterClasseAPI.Data;
using ManterClasseAPI.Models;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using Serilog;

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
            var result = from obj in _context.ClasseObjeto select obj;
            result = result.Where(x => x.Ativo == true);
            return await result.ToListAsync();
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
                Log.Warning("Atualização: " + classeObjeto.Descricao);
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

        [HttpPut("{id}/status")]
        public async Task<IActionResult> PutStatusClasseObjeto(int id, ClasseObjeto classeObjeto)
        {
            if (id != classeObjeto.Id)
            {
                return BadRequest();
            }

            _context.Entry(classeObjeto).State = EntityState.Modified;

            try
            {
                classeObjeto.Ativo = false;
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
            Log.Warning("Inclusão: " + classeObjeto.Descricao);
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
