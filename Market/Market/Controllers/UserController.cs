using Market.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        MarketContext context;
        public UserController(MarketContext _context)
        {
            context = _context;
        }

        [HttpPost]
        public  IActionResult AddUser(User user)
        {
             context.User.Add(user);
             context.SaveChanges();
            return Ok("User Added Successfully");

        }

        [HttpPut]

        public async Task<IActionResult> EditUser(int UserId, [FromBody] User updatedUser)
        {
            var existingUser = await context.User.FindAsync(UserId);
            if (existingUser == null) return NotFound();

          
            existingUser.Name = updatedUser.Name; 
            existingUser.Email = updatedUser.Email; 
            existingUser.Password = updatedUser.Password;

            
            await context.SaveChangesAsync();

            return Ok("User Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await context.User.FindAsync(id);
            if (user == null) return NotFound();

            context.User.Remove(user);
            await context.SaveChangesAsync();
            return Ok("User Deleted Successfully");
        }









    }
}
