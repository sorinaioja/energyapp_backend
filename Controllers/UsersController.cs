using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Models;
using Microsoft.AspNetCore.Authorization;

namespace App.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ClientContext _context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public UsersController(ClientContext context)
        {
            _context = context;
        }

        /*public UsersController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }*/

        
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
            
        }
        
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }


        
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetClient", new { id = client.Id }, client);
            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
            try
            {
                var userDB = await _context.Users.Where(u => u.Username == user.Username).SingleOrDefaultAsync();

                if (userDB == null)
                {
                    return BadRequest("Invalid username or password");
                }

                if (userDB.Password != user.Password)
                {
                    return BadRequest(new { message = "Incorrect username or password" });
                }
                Console.Write("MERGE");
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return UnprocessableEntity();
            }
            catch (NullReferenceException)
            {
                return UnprocessableEntity();
            }
        }



        /*
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate( User user)
        {
            var token = jwtAuthenticationManager.Authenticate(user.Username, user.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }*/
    }
}
