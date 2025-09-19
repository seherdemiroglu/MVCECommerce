using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCECommerce.Domain;
using MVCECommerce.Models;
using NETCore.MailKit.Core;
using System.Security.Claims;

namespace MVCECommerce.Controllers;

public class AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
        IEmailService emailService, MVCECommerceDbContext dbContext) : Controller//burada hem UserManager hem de SignInManager inject edildi
{
    public IActionResult Login()
    {
        return View(new LoginViewModel {});//checkbox tikli gelsin diye
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {

        var result = await signInManager.PasswordSignInAsync(
            model.UserName!,
            model.Password!,
            isPersistent: model.IsPersistent,//session tabanlı değil süre tabanlı oldu true yapınca
            lockoutOnFailure: true);//5 kere yanlış şifre girince banlar

        if (result.Succeeded)
        {
            return Redirect(model.ReturnUrl ?? "/");
        }
        ModelState.AddModelError("", "Geçersiz kullanıcı girişi");
        return View(model);
    }


    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        var user = new User
        {
            UserName = model.Username,
            Email = model.Username,
            GivenName = model.GivenName!,
            Date = DateTime.UtcNow,
            Gender=model.Gender

        };
        var result = await userManager.CreateAsync(user, model.Password!);
        if (result.Succeeded)
        {
            //cookie de otomatik olarak kullanıcının id ve kullanıcı adı kaydolur. ek olarak biz GivenName ekledik Claim ile
            await userManager.AddClaimAsync(user, new Claim(ClaimTypes.GivenName, model.GivenName!));
            await userManager.AddToRoleAsync(user, "Members");
            await signInManager.SignInAsync(user, isPersistent: false);//isPersistent: false:login oldu.browser kapatıldı. login kalmayacaksa


            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var link = Url.Action("EmailConfirmation", "Account", new { id = user.Id, token }, Request.Scheme);

            var body = $@"<h4>merhabalar sn {user.GivenName}</h4><p>...</p><a href=""{link}"">Link</a>";
            await emailService.SendAsync(user.Email, "MvcForum EPosta Doğrulama Mesajı", body, true);

            return View("RegisterSuccess");
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return RedirectToAction("Home", "Index");
    }

    public async Task<IActionResult> EmailConfirmation(Guid id, string token)
    {
        var user = await userManager.FindByIdAsync(id.ToString());
        var result = await userManager.ConfirmEmailAsync(user, token);
        if (result.Succeeded)
        {
            await signInManager.SignInAsync(user, isPersistent: false);//isPersistent: false:login oldu.browser kapatıldı. login kalmayacaksa
            return RedirectToAction("Index", "Home");
        }
        return View();//sign in yapamazsa buraya yönlendir
    }



    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }

    public IActionResult ResetPassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ResetPasswordAsync(ResetPasswordViewModel model)
    {
        var user = await userManager.FindByNameAsync(model.UserName!);
        if (user == null)
        {
            ModelState.AddModelError("", "Kullanıcı bulunamıyor");
            return View(model);
        }
        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        var link = Url.Action("SetPassword", "Account", new { id = user.Id, token }, Request.Scheme);

        var body = $@"<h4>merhabalar sn {user.GivenName}</h4><p>...</p><a href=""{link}"">Link</a>";
        await emailService.SendAsync(user.Email, "MvcForum Parola Yenileme Mesajı", body, true);
        return View("ResetPasswordSuccess");
    }
    public IActionResult SetPassword(Guid id, string token)
    {

        return View(new SetPasswordViewModel { Id = id, Token = token });
    }

    [HttpPost]
    public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
    {
        var user = await userManager.FindByIdAsync(model.Id.ToString()!);
        var result = await userManager.ResetPasswordAsync(user!, model.Token!, model.Password!);
        return View("SetPasswordSuccess");
    }

    [Authorize]
    public async Task<IActionResult> AddToCart(Guid id)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var product = await dbContext.Products.SingleAsync(p => p.Id == id);
        var item = await dbContext.ShoppingCartItems.SingleOrDefaultAsync(p => p.UserId == userId && p.ProductId == id);
        if (item == null)
        {
            item = new ShoppingCartItem
            {
                ProductId = id,
                UserId = userId,
                Quantity = 1,
            };
            dbContext.ShoppingCartItems.Add(item);
        }
        else
        {
            item.Quantity++;
            dbContext.ShoppingCartItems.Update(item);
        }
        TempData["success"] = "Product added to your cart successfully!";
        await dbContext.SaveChangesAsync();
        return RedirectToRoute("Product", new { id, name = product.NameEn.ToSafeUrlString() });
    }


    [Authorize]
    public async Task<IActionResult> RemoveFromCart(Guid id)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        await dbContext.ShoppingCartItems.Where(p => p.Id == id && p.UserId == userId!).ExecuteDeleteAsync();
        return RedirectToAction(nameof(Checkout));
    }

    [Authorize]
    public IActionResult Checkout()
    {
        return View();
    }
    [Authorize]
    public IActionResult Payment()
    {
        return View();
    }

    [Authorize]
    public async Task<IActionResult> SetQuantity(Guid id, int Quantity)
    {
        var item = await dbContext.ShoppingCartItems.SingleOrDefaultAsync(p => p.Id == id);
        item.Quantity = Quantity;
        dbContext.Update(item);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Checkout));
    }
    [Authorize]
    public async Task<IActionResult> IncreaseQuantity(Guid id)
    {
        var item = await dbContext.ShoppingCartItems.SingleOrDefaultAsync(p => p.Id == id);
        item.Quantity++;
        dbContext.Update(item);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Checkout));
    }

    [Authorize]
    public async Task<IActionResult> DecreaseQuantity(Guid id)
    {
        var item = await dbContext.ShoppingCartItems.SingleOrDefaultAsync(p => p.Id == id);
        if (item.Quantity > 1)
            item.Quantity--;
        dbContext.Update(item);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Checkout));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAddress([FromBody] AddressViewModel model)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var address = new Address
        {
            CityId = model.CityId,
            Name = model.Name,
            Text = model.Text,
            ZipCode = model.ZipCode,
            UserId = userId,
        };
        dbContext.Add(address);
        await dbContext.SaveChangesAsync();

        return Ok();
    }

    [Authorize]
    public async Task<IActionResult> UserAddresses()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var model = await dbContext
            .Addresses
            .Where(p => p.UserId == userId)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Text,
            })
            .ToListAsync();

        return Json(model);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Pay([FromBody] PaymentViewModel model)
    {
        //payment logic ....
#if DEBUG
        Thread.Sleep(5000);
#endif
        // /payment logic

        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var order = new Order
        {
            Date = DateTime.Now,
            ShippingAddressId = model.ShippingAddressId,
            UserId = userId,
            Items = dbContext
                .ShoppingCartItems
                .Include(p => p.Product)
                .Where(p => p.UserId == userId).Select(p => new OrderItem
                {
                    Price = p.Product.Price,
                    Quantity = p.Quantity,
                    ProductId = p.ProductId,
                }).ToList(),
        };

        dbContext.Add(order);
        await dbContext.SaveChangesAsync();
        await dbContext.ShoppingCartItems.Where(p => p.UserId == userId).ExecuteDeleteAsync();

        return Ok();
    }


    [Authorize]
    public async Task<IActionResult> Profile()
    {
        var user = await userManager.GetUserAsync(User);
        return View(user);
    }
}

