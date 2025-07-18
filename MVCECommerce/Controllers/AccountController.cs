using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCECommerce.Domain;
using MVCECommerce.Models;
using NETCore.MailKit.Core;
using System.Security.Claims;

namespace MVCECommerce.Controllers;

public class AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
        IEmailService emailService) : Controller//burada hem UserManager hem de SignInManager inject edildi
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {

        var result = await signInManager.PasswordSignInAsync(
            model.UserName!,
            model.Password!,
            isPersistent: false,
            lockoutOnFailure: false);

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
}

