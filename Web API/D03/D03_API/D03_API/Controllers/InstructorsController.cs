using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using D03_API.Context;
using D03_API.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace D03_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly APIContext _context;

        public InstructorsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Instructors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instructor>>> GetInstructors()
        {
          if (_context.Instructors == null)
          {
              return NotFound();
          }
            return await _context.Instructors.ToListAsync();
        }

        // search by name 
        // GET: api/Instructors/name

        [HttpGet("{Name:alpha}")]
        public async Task<ActionResult<Instructor>> SearchByName(string Name)
        {
            if (_context.Instructors == null)
            {
                return NotFound();
            }
            var instructor = await _context.Instructors.FirstOrDefaultAsync(s => s.Name.ToLower() == Name.ToLower());

            if (instructor == null)
            {
                return NotFound();
            }

            return instructor;
        }

        
        // GET: api/Instructors/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Instructor>> SearchById(int id)
        {
          if (_context.Instructors == null)
          {
              return NotFound();
          }
            var instructor = await _context.Instructors.FindAsync(id);

            if (instructor == null)
            {
                return NotFound();
            }

            return instructor;
        }

        // PUT: api/Instructors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstructor(int id, Instructor instructor)
        {
            if (id != instructor.Id)
            {
                return BadRequest();
            }

            _context.Entry(instructor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructorExists(id))
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

        // POST: api/Instructors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Instructor>> PostInstructor(Instructor instructor)
        {
          if (_context.Instructors == null)
          {
              return Problem("Entity set 'APIContext.Instructors'  is null.");
          }
            _context.Instructors.Add(instructor);
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Signiture_Key_123"));

            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //// Generate token
            //var data = new List<Claim>();
            //data.Add(new Claim("name", instructor.Name));

            //var token = new JwtSecurityToken(

            //claims: data,
            //expires: DateTime.Now.AddMinutes(120),
            //signingCredentials: credentials);
            //return Ok(new JwtSecurityTokenHandler().WriteToken(token));

            try
            {
                await _context.SaveChangesAsync();
                return Ok();


            }
            catch
            {
                return NotFound();

            }


            //return CreatedAtAction("GetInstructor", new { id = instructor.Id }, instructor);
        }

        // DELETE: api/Instructors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            if (_context.Instructors == null)
            {
                return NotFound();
            }
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }

            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstructorExists(int id)
        {
            return (_context.Instructors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
