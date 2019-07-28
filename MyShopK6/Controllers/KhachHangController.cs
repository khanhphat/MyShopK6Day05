using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        //cần lưu trữ lại đăng nhập trước đó. ReturnUrl
        public IActionResult Login(string ReturnUrl = null)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModels model)
        {
            //di kiem thang email:
            KhachHang khachHang = _content.KhachHangs.SingleOrDefault(p => p.Email == model.Email && ((model.MatKhau + p.RandomKey).ToMD5() == p.MatKhau));
            return View();
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