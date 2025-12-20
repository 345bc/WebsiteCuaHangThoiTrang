using System;
using System.Collections.Generic;

namespace ESHOPPER.Models
{
    public class AdminViewModel
    {
        // 1. Thống kê Card (KPIs)
        public decimal TongDoanhThu { get; set; }
        public int DonHangMoi { get; set; } // Số đơn hàng trong tháng
        public int TongKhachHang { get; set; }
        public int TongSanPham { get; set; }

        // Tỉ lệ tăng trưởng (Giả lập hoặc tính toán nếu muốn)
        public double TangTruongDoanhThu { get; set; } 

        // 2. Dữ liệu Biểu đồ Doanh thu (12 tháng)
        public List<decimal> ChartDoanhThu { get; set; } 
        public List<string> ChartLabelThang { get; set; }

        // 3. Dữ liệu Biểu đồ Danh mục
        public List<string> ChartLabelDanhMuc { get; set; }
        public List<int> ChartDataDanhMuc { get; set; }

        // 4. Danh sách đơn hàng mới nhất
        public List<ESHOPPER.Models.DonHang> ListDonHangMoi { get; set; }
    }
}