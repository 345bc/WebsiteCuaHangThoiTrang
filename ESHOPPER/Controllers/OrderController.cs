using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ESHOPPER.Models;

namespace ESHOPPER.Controllers
{
    public class OrderController : Controller
    {
        private QlyFashionShopEntities db = new QlyFashionShopEntities();

        // GET: Order
        public ActionResult Index()
        {
            var donHangs = db.DonHangs.Include(d => d.KhachHang).Include(d => d.TTDONHANG);
            ViewBag.trangthai = db.TTDONHANGs;
            return View(donHangs.ToList());
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            // Lấy danh sách sản phẩm (Chi tiết đơn hàng) theo Mã Đơn Hàng
            var listChiTiet = db.ChiTietDonHangs
                .Where(x => x.MaDH == id)
                .Include("BienTheSanPham.SanPham")    // Để lấy tên & ảnh sản phẩm
                .Include("BienTheSanPham.MauSac")     // Để lấy tên màu
                .Include("BienTheSanPham.KichThuoc")  // Để lấy tên size
                .Include("DonHang")                   // Để lấy thông tin người nhận, địa chỉ
                .ToList();                            // <--- QUAN TRỌNG: Chuyển thành List để khớp View

            // Kiểm tra nếu không tìm thấy dữ liệu
            if (listChiTiet == null || listChiTiet.Count == 0)
            {
                TempData["Error"] = "Không tìm thấy đơn hàng hoặc đơn hàng rỗng.";
                return RedirectToAction("Index");
            }

            return View(listChiTiet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
