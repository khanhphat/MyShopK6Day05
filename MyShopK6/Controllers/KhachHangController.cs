using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShopK6.Models;

namespace MyShopK6.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly MyDbContext _content;
        private readonly IMapper _mapper;
        public KhachHangController (MyDbContext db, IMapper mapper)
        {
            _content = db; _mapper = mapper;
        }
        public IActionResult Resgiter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Resgiter(KhachHangView model)
        {
            if(ModelState.IsValid)
            {
                
                //map tu KhachHang sang model
                KhachHang khachHang = _mapper.Map<KhachHang>(model);

                //viet xu ly tren mytool
                //Ham GenerateRandomKey, ToMD5.  viet ben my tool
                khachHang.RandomKey = MyTool.GenerateRandomKey();
                khachHang.MatKhau = (model.MatKhau + khachHang.RandomKey).ToMD5();

                _content.Add(khachHang);
                _content.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }
        
        public IActionResult CheckEmailAvaible(string Email)
        {
            var item = _content.KhachHangs.SingleOrDefault(p => p.Email == Email);
            //khi tim ko co tra ve true
            if (item != null)
            {
                return Json(data: "email da duoc dang ky");
            }
            return Json(data: true);
        }

        //cần lưu trữ lại đăng nhập trước đó. 
        //ReturnUrl
        public IActionResult Login(string ReturnUrl = null)
        {
            //lay viewbag de truyen qua view login httppost
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModels model)
        {
            //di kiem thang email:
            KhachHang khachHang = _content.KhachHangs.SingleOrDefault(p => p.Email == model.Email && ((model.MatKhau + p.RandomKey).ToMD5() == p.MatKhau));

            if (khachHang == null)//không khớp
            {
                ViewBag.ThongBaoLoi = "Sai thông tin đăng nhập";
                return View();
            }
            //ghi nhận đăng nhập thành công
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, khachHang.HoTen) };
            ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");

            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);
            if (Url.IsLocalUrl(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }
            
            
        return RedirectToAction("Profile", "KhachHang");//default
            
        }
        [Authorize]
        public IActionResult Logout()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }
    }
}