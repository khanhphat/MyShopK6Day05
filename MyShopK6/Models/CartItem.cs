using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopK6.Models
{
    public class CartItem
    {
        public HangHoaView HangHoa { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien => SoLuong * HangHoa.DonGia * (1 - HangHoa.GiamGia / 100.0);
    }
}
