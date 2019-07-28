using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopK6.Models
{
    public class HangHoaChiTiet : HangHoa
    {
        public double GiaBan => DonGia * (1 - GiamGia / 100.0);
        public bool ConHang => SoLuong > 0;
        public string TinhTrang
        {
            get
            {
                if (!ConHang) return "Hết hàng";
                if (SoLuong > 4) return "Còn hàng";
                return "Sắp hết";
            }
        }
    }
}
