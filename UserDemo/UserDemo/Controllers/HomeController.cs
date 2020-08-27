
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using UserDemo.Models;
using UserDemo.Views.ViewModels;

namespace UserDemo.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext appDbContext;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public HomeController(AppDbContext _appDbContext, UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> signInManager)
        {
            appDbContext = _appDbContext;
            userManager = _userManager;
            this.signInManager = signInManager;
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User model)
        {

            if (ModelState.IsValid)
            {
                var a = appDbContext.Users.FirstOrDefault(e => e.Email == model.Email);
                if (a == null)
                {
                    var user = new IdentityUser { UserName = model.Username, Email = model.Email };
                    var result = await userManager.CreateAsync(user, model.Pwd);

                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect("~/Home/Login");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else ViewBag.Messenger = "Tên người dùng đã tồn tại. Hãy sử dụng tên khác.";
            }
            else
            {
                ViewBag.Messenger = "Tài khoản không hợp lệ !";
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllProvinces()
        {
            using (var connection = new SqlConnection("Server=LONGBLUE\\SQLEXPRESS;Database=Registration;Trusted_Connection=True;"))
            {
                string query = "select * from province";
                var districts = connection.Query<District>(query);

                return Ok(districts);
            }
        }
        public IActionResult GetAllDistrictByProvinceId(int? id)
        {
            using (var connection = new SqlConnection("Server=LONGBLUE\\SQLEXPRESS;Database=Registration;Trusted_Connection=True;"))
            {
                string query = "select * from district where district._province_id= @Id";
                var districts = connection.Query<District>(query, new { Id = id });

                return Ok(districts);
            }
        }
        public IActionResult GetAllWardByDistrictId(int? id)
        {
            using (var connection = new SqlConnection("Server=LONGBLUE\\SQLEXPRESS;Database=Registration;Trusted_Connection=True;"))
            {
                string query = "select * from ward where ward._district_id = @Id";
                var districts = connection.Query<District>(query, new { Id = id });

                return Ok(districts);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password,
                                                                        model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attemp");
            }
            return View(model);
        }
    }


}
