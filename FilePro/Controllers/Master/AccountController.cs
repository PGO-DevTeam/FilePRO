using FilePro.Data;
using FilePro.Models.Master;
using FilePro.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;

namespace FilePro.Controllers.Master
{
    public class AccountController : Controller
    {

        private readonly AppDbContext _context;
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AccountController(AppDbContext context, UserManager<Users> userManager, IWebHostEnvironment webHostEnvironment, SignInManager<Users> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _signInManager = signInManager;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> Save(RegisterVM data)
        {
            var success = false;
            try
            {
                if (data.Id == null)
                {
                    var user = new Users
                    {
                        Nama = data.Nama,
                        Contact = data.Contact,
                        VendorId = data.VendorId,
                        TanggalJoin = data.TanggalJoin,
                        IsDeleted = false,
                        EmailConfirmed = false,
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = false,
                        AccessFailedCount = 0
                    };
                    var pwd = data.Password;
                    var result = await _userManager.CreateAsync(user, pwd);
                    if (result.Succeeded)
                    {
                        return Json(success);
                    }
                }
                else
                {
                    var UserDb = _context.User.Where(x => x.Id == data.Id).SingleOrDefault();
                    UserDb!.Nama = data.Nama;
                    UserDb.Contact = data.Contact;
                    UserDb.VendorId = data.VendorId;
                    UserDb.TanggalJoin = data.TanggalJoin;

                    success = true;
                }
                return Json(success);
            }
            catch (Exception e)
            {

                return Json(e.Message);
            }
  
        }

        [Authorize(Roles = "Admin")]
        public JsonResult Delete(string Id)
        {
            var result = false;
            var data = _context.User.FirstOrDefault(x => x.Id == Id);
            if (data != null)
            {
                data.IsDeleted = true;
                _context.Entry(data).State = EntityState.Modified;
                _context.SaveChanges();
                result = true;
            }
            return Json(result);
        }

        [HttpGet]
        public IActionResult GetList(string? id)
        {
            if (id != null)
            {
                var result = _context.User.Include(x => x.Vendor).SingleOrDefault();

                return Ok(new { data = result });
            }
            else
            {

                var result = _context.User
                    .Include(x => x.Vendor).Where(x => x.IsDeleted == false).ToList();
                return Ok(new { data = result });
            }


        }

        public IActionResult GetById(string id)
        {

            var result = _context.User.Where(x => x.Id == id).FirstOrDefault();

            return Ok(new
            {
                data = result,
            });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM user)
        {
            if (ModelState.IsValid)
            {
                //var userData = _context.User.SingleOrDefault(x => x.NPP == user.NPP);
                var result = await _signInManager.PasswordSignInAsync(user.NoPeg, user.Password, user.RememberMe, false);
                var userd = _context.User.Where(x => x.NoPeg == user.NoPeg).SingleOrDefault();

                if (result.Succeeded!)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(String.Empty, "Incorrect Username or Password ");

            }
            else
            {
                ModelState.AddModelError(String.Empty, "Username  atau password salah");
            }
            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [Authorize]
        [HttpGet]
        public IActionResult AccessDenied(string? ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;

            return View();
        }
    }
}
