//using System;
//using System.Collections.Generic;
//using System.Data.Common;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using Dapper;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.SqlClient;
//using Microsoft.Extensions.Logging;
//using UserDemo.Models;
//namespace UserDemo.Controllers
//{
//    public class HomeController : Controller
//    {
//        private AppDbContext appDbContext;
//        public HomeController(AppDbContext _appDbContext)
//        {
//            appDbContext = _appDbContext;
//        }
//        public ViewResult Create()
//        {
//            return View();
//        }
//        [HttpPost]
//        public IActionResult Create(User model)
//        {
//            if (ModelState.IsValid)
//            {
//                var user = appDbContext.Users.FirstOrDefault(e => e.Email == model.Email);
//                if (user == null)
//                {
//                    appDbContext.Add(model);
//                    appDbContext.SaveChanges();
//                    ViewBag.Messenger = "Tạo tài khoản thành công !";
//                }
//                else ViewBag.Messenger = "Email đã tồn tại. Hãy sử dụng email khác !";
//            }
//            else
//            {
//                ViewBag.Messenger = "Tài khoản không hợp lệ !";
//            }
//            return View();
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }
//        public IActionResult GetAllProvinces()
//        {
//            using (var connection = new SqlConnection("Server=LONGBLUE\\SQLEXPRESS;Database=Registration;Trusted_Connection=True;"))
//            {
//                string query = "select * from province";
//                var districts = connection.Query<District>(query);

//                return Ok(districts);
//            }
//        }
//        public IActionResult GetAllDistrictByProvinceId(int? id)
//        {
//            using (var connection = new SqlConnection("Server=LONGBLUE\\SQLEXPRESS;Database=Registration;Trusted_Connection=True;"))
//            {
//                string query = "select * from district where district._province_id= @Id";
//                var districts = connection.Query<District>(query, new { Id = id });

//                return Ok(districts);
//            }
//        }
//        public IActionResult GetAllWardByDistrictId(int? id)
//        {
//            using (var connection = new SqlConnection("Server=LONGBLUE\\SQLEXPRESS;Database=Registration;Trusted_Connection=True;"))
//            {
//                string query = "select * from ward where ward._district_id = @Id";
//                var districts = connection.Query<District>(query, new { Id = id });

//                return Ok(districts);
//            }
//        }
//        [HttpGet]
//        public IActionResult Login()
//        {
//            return View();
//        }
//        [HttpPost]
//        public IActionResult Login(User model)
//        {
//            return View();
//        }
//    }
//}