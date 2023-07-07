using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]  // GET /api/users

    public class UsersController : ControllerBase
    {

        private readonly DataContext _context;

        public UsersController(DataContext context) //constructor  name of the class followed()with wanted parameters
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;

        }
        [HttpGet("{id}")]   //neo method gia na paroume enan sygkekrimeno user. parameter:id

        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);  //find user by id which is the primary key.
                                             //find method cant be used for anything else rather than a primary key
        }

    }
}