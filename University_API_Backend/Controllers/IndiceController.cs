using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_API_Backend.DataAcces;
using University_API_Backend.Models;
using University_API_Backend.Services;

namespace University_API_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndiceController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly IIndicesService _indicesService;

        public IndiceController(UniversityDBContext context, IIndicesService indicesService)
        {
            _context = context;
            _indicesService = indicesService;
        }

        // GET: api/Indice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Indice>>> GetIndices()
        {
            return await _context.Indices.ToListAsync();
        }

        // GET: api/Indice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Indice>> GetIndice(int id)
        {
            var indice = await _context.Indices.FindAsync(id);

            if (indice == null)
            {
                return NotFound();
            }

            return indice;
        }

        // PUT: api/Indice/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutIndice(int id, Indice indice)
        {
            if (id != indice.Id)
            {
                return BadRequest();
            }

            _context.Entry(indice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndiceExists(id))
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

        // POST: api/Indice
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<Indice>> PostIndice(Indice indice)
        {
            _context.Indices.Add(indice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIndice", new { id = indice.Id }, indice);
        }

        // DELETE: api/Indice/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteIndice(int id)
        {
            var indice = await _context.Indices.FindAsync(id);
            if (indice == null)
            {
                return NotFound();
            }

            _context.Indices.Remove(indice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IndiceExists(int id)
        {
            return _context.Indices.Any(e => e.Id == id);
        }
    }
}
