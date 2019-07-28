using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyShopK6.Models
{
    public class MyTool
    {
        public static string UploadHinh(IFormFile fHinh, string folder)
        {
            string fileNameReturn = string.Empty;
            if (fHinh != null)
            {
                fileNameReturn = $"_{DateTime.Now.Ticks}{fHinh.FileName}";
                var fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", folder, fileNameReturn);
                using (var file = new FileStream(fileName, FileMode.Create))
                {
                    fHinh.CopyTo(file);
                }
            }
            return fileNameReturn;
        }

        //Ham random key 
        public static string GenerateRandomKey()
        {
            Random rd = new Random();
            string pattern = @"zaqwsxdcuhrekcmnjv:;bzoiu1234567890_*&^%$#@!~?()+-/<>";

            //random tu 3 den 10
            //do ben kia khai bao max la 10 ki tu.
            int length = rd.Next(3, 11);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i< length; i++)
            {
                sb.Append(pattern[rd.Next(0, pattern.Length)]); //rd.Next(0,pattern.Length: lay chuoi thu bao nhieu ??
            }
            return sb.ToString();
        }
    }

    //extension method:
    public static class StaticClass
    {

        //extension method:
        public static string ToMD5(this string str)
        {
            //hash : ma 1 chieu
            //1khai bao
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str)); //chuyen vo chuoi sau do chuyen sang mang byte

            //sau do chuyen hash ve chuoi
            StringBuilder sbHash = new StringBuilder();
            foreach (byte b in bHash)
                sbHash.Append(String.Format("{0:x2}", b));
            return sbHash.ToString();
        }

        public static string ToVND(this double dongia)
        {
            return $"{dongia.ToString("#,##0")} đ";
        }

        public static string ToUrlFriendly(this string url)
        {
            url = url.ToLower();

            //Lọc bỏ từ tiếng Việt
            url = Regex.Replace(url, @"[áàạảãâấầậẩẫăắằặẳẵ]", "a");
            url = Regex.Replace(url, @"[éèẹẻẽêếềệểễ]", "e");
            url = Regex.Replace(url, @"[óòọỏõôốồộổỗơớờợởỡ]", "o");
            url = Regex.Replace(url, @"[úùụủũưứừựửữ]", "u");
            url = Regex.Replace(url, @"[íìịỉĩ]", "i");
            url = Regex.Replace(url, @"đ", "d");
            url = Regex.Replace(url, @"[ýỳỵỷỹ]", "y");

            //thay thế theo chuẩn URL friendly
            url = Regex.Replace(url, @"[^a-z0-9\s-]", "");
            url = Regex.Replace(url, @"\s+", "-");
            url = Regex.Replace(url, @"\s", "-");

            return url;
        }
    }
}
