using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCECommerce.Domain;

namespace MVCECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Administrators")]
    public class MembersController(UserManager<User> userManager, RoleManager<Role> roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var members = await userManager.Users
                .Include(p => p.UserRoles).ThenInclude(p => p.Role)
                .Where(p => p.UserRoles.Any(q => q.Role.Name != "Administrators"))
                .ToListAsync();
            return View(members);
        }

        public async Task<IActionResult> BanUser(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            user!.IsEnabled = false;
            await userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UnbanUser(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            user!.IsEnabled = true;
            await userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> SetRoles(Guid id)
        {
            var user = await userManager.Users
                .Include(p => p.UserRoles).ThenInclude(p => p.Role)
                .SingleAsync(p => p.Id == id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> SetRoles(Guid id, List<string> roles)
        {

            var user = await userManager.Users
             .Include(p => p.UserRoles).ThenInclude(p => p.Role)
             .SingleAsync(p => p.Id == id);

            await userManager.RemoveFromRolesAsync(user!, user.UserRoles.Select(p => p.Role.Name));
            await userManager.AddToRolesAsync(user!, roles);//birden fazla rol atamak için AddToRolesAsync metodu
            await userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }
    }
}
