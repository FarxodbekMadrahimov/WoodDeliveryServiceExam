using JWT.Data;
using JWT.DTOs;
using JWT.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserAdminsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserAdminsController(AppDbContext context)
            => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetUserAdminsAsync()
        {
            return Ok(await _context.UserAdmin.AsNoTracking().Include(x => x.Roles)
                .ThenInclude(x => x.Permissions).ToListAsync());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAdminsAsync(int id, UpdateUserDTO userDTO)
        {
            var user = await _context.UserAdmin
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null) { /**/ }

            user.FirstName = userDTO.Fullname;
            user.UserName = userDTO.Username;
            

            List<Role> roles = new();

            foreach (var role in userDTO.Roles)
            {
                var listItem = await _context.Roles.FirstOrDefaultAsync(x => x.Id == role);
                if (listItem == null) { /**/ }
                else
                {
                    roles.Add(listItem);
                }
            }

            user.Roles = roles;

            var entityEntry = _context.Update(user);
            await _context.SaveChangesAsync();

            return Ok(entityEntry.Entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAdmin(int id)
        {
            var user = await _context.UserAdmin
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null) { /**/ }

            var entityEntry = _context.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(entityEntry.Entity);
        }
    }
}
