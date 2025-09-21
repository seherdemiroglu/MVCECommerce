using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCECommerce.Domain;
using NETCore.MailKit.Core;

namespace MVCECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrators,OrderAdministrators")]
    public class OrdersController(MVCECommerceDbContext dbContext, IEmailService emailService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Yeni Siparişler";
            var model = await dbContext.Orders
                .Include(p => p.User)
                .Include(p => p.Items)
                .ThenInclude(p => p.Product)
                .Where(p => p.Status == OrderStatus.New)
                .OrderBy(p => p.Date)
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> InProgress()
        {
            ViewData["Title"] = "Aktif Siparişler";

            var model = await dbContext
                .Orders
                .Include(p => p.User)
                .Include(p => p.Items).ThenInclude(p => p.Product)
                .OrderBy(p => p.Date)
                .Where(p => p.Status == OrderStatus.InProgress)
                .ToListAsync();
            return View("Index", model);
        }

        public async Task<IActionResult> Shipped()
        {
            ViewData["Title"] = "Tamamlanan Siparişler";

            var model = await dbContext
                .Orders
                .Include(p => p.User)
                .Include(p => p.Items).ThenInclude(p => p.Product)
                .OrderBy(p => p.Date)
                .Where(p => p.Status == OrderStatus.Shipped)
                .ToListAsync();
            return View("Index", model);
        }
        public async Task<IActionResult> Cancelled()
        {
            ViewData["Title"] = "İptal Olan Siparişler";

            var model = await dbContext
                .Orders
                .Include(p => p.User)
                .Include(p => p.Items).ThenInclude(p => p.Product)
                .OrderBy(p => p.Date)
                .Where(p => p.Status == OrderStatus.Cancelled)
                .ToListAsync();
            return View("Index", model);
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            var item=await dbContext.Orders
                .Include(p=>p.User)
                .Include(p=>p.Items).ThenInclude(p => p.Product)
                .SingleAsync(p=>p.Id == id);
            return View(item);
        }

        public async Task<IActionResult> ToInProgress(Guid id)
        {
            var item = await dbContext
                .Orders
                .Include(p => p.User)
                .SingleAsync(p => p.Id == id);

            item.Status = OrderStatus.InProgress;
            dbContext.Update(item);
            await dbContext.SaveChangesAsync();

            var body = $@"<h4>Merhabalar Sn. {item.User!.GivenName}</h4><p>Siparişiniz hazırlanıyor</p>";

            await emailService.SendAsync(
                item.User.Email,
                "MVCECommerce Siparişiniz Hkk.",
                body,
                true
                );

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ToShipped(Guid id)
        {
            var item = await dbContext
                .Orders
                .Include(p => p.User)
                .SingleAsync(p => p.Id == id);

            item.Status = OrderStatus.Shipped;
            dbContext.Update(item);
            await dbContext.SaveChangesAsync();

            var body = $@"<h4>Merhabalar Sn. {item.User!.GivenName}</h4><p>Siparişiniz yola çıkmıştır</p>";

            await emailService.SendAsync(
                item.User.Email,
                "MVCECommerce Siparişiniz Hkk.",
                body,
                true
                );

            return RedirectToAction(nameof(Index));
        }
    }
}
