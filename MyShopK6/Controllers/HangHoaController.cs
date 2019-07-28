using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyShopK6.Models;

namespace MyShopK6.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly IMapper mapper;
        private readonly MyDbContext ctx;
        public HangHoaController(MyDbContext db, IMapper map)
        {
            ctx = db; mapper = map; 
        }
        public IActionResult Index(int? id)
        {
            var dsHangHoa = ctx.HangHoas.AsQueryable();
            if(id.HasValue)
            {
                dsHangHoa = dsHangHoa.Where(p => p.MaLoai == id);
            }

            //map HangHoa ---> HangHoaView
            var hangHoas = mapper.Map<List<HangHoaView>>(dsHangHoa.ToList());

            if (id.HasValue)
            {
                Loai loai = ctx.Loais.SingleOrDefault(p => p.MaLoai == id.Value);
                ViewBag.Loai = loai;
            }

            return View(hangHoas);
        }

        public IActionResult ChiTiet(int id)
        {
            HangHoa hh = ctx.HangHoas.SingleOrDefault(p => p.MaHh == id);
            if(hh != null)
            {
                HangHoaChiTiet hhct = mapper.Map<HangHoaChiTiet>(hh);

                return View(hhct);
            }

            return RedirectToAction(controllerName: "Home", actionName: "Error");
        }

        [Route("[controller]/{url}")]
        public IActionResult ChiTietHH(string url)
        {
            HangHoa hh = ctx.HangHoas.SingleOrDefault(p => p.TenHhFriendly == url);
            if (hh != null)
            {
                HangHoaChiTiet hhct = mapper.Map<HangHoaChiTiet>(hh);

                return View("ChiTiet", hhct);
            }

            return RedirectToAction(controllerName: "Home", actionName: "Error");
        }

        public IActionResult TimKiem(string TuKhoa, int? MaLoai)
        {
            var dsHangHoa = ctx.HangHoas
                .Where(p => p.TenHh.ToLower().Contains(TuKhoa))
                .AsQueryable();
            if (MaLoai.HasValue)
            {
                dsHangHoa = dsHangHoa.Where(p => p.MaLoai == MaLoai);
            }            

            //map HangHoa ---> HangHoaView
            var hangHoas = mapper.Map<List<HangHoaView>>(dsHangHoa.ToList());

            return PartialView(hangHoas);
        }
    }
}