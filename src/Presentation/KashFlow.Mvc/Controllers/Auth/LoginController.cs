using System.Security.Claims;
using KashFlow.Infrastructure.Data;
using KashFlow.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KashFlow.Mvc.Controllers.Auth
{
  [Authorize]
  public class AuthController : Controller
  {
    public readonly BaseContext _context;
    private readonly AuthManager _authManager;

    public AuthController (BaseContext context, AuthManager authManager)
    {
      _context = context;
      _authManager = authManager;
    }

    [AllowAnonymous]
    public IActionResult Index ()
    {
      return View();
    }

    [AllowAnonymous]
    public async Task<IActionResult> Login (string userName, string password)
    {
      ClaimsPrincipal userClaims = _authManager.LoginMVC(userName, password);

      if(!userClaims.Identities.Any())
        return RedirectToAction("Index");
    
      await HttpContext.SignInAsync(userClaims);

      return RedirectToAction("Index", "Home");
    }

    // public async Task<IActionResult> Logout ()
    // {
    //   // Clear server cookies
    //   await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    //   HttpContext.Session.Clear();
    //   return RedirectToAction("Index");
    // }
  }
}