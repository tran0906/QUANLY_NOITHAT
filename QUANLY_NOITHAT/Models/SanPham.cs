namespace QUANLY_NOITHAT.Models
{
    public class SanPham
    {
        public string MaSP { get; set; } = string.Empty;
        public string? MaNhomSP { get; set; }
        public string? MaVL { get; set; }
        public string TenSP { get; set; } = string.Empty;
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public string? HinhAnh { get; set; }
        public string? MoTa { get; set; }
    }

    public class NhomSanPham
    {
        public string MaNhomSP { get; set; } = string.Empty;
        public string TenNhomSP { get; set; } = string.Empty;
        public string? MoTa { get; set; }
    }

    public class GioHang
    {
        public string MaSP { get; set; } = string.Empty;
        public string TenSP { get; set; } = string.Empty;
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public string? HinhAnh { get; set; }
        public decimal ThanhTien => DonGia * SoLuong;
    }
}


    public class VatLieu
    {
        public string MAVL { get; set; } = string.Empty;
        public string? TENVL { get; set; }
        public string? MAUVL { get; set; }
        public int? SOLUONG { get; set; }
        public string? MOTAVL { get; set; }
    }

    public class NhaCungCap
    {
        public string MANCC { get; set; } = string.Empty;
        public string? TENNCC { get; set; }
        public string? DIACHINCC { get; set; }
        public string? SDTNCC { get; set; }
        public string? EMAILNCC { get; set; }
        public string? SANPHAM { get; set; }
        public decimal? GIANHAP { get; set; }
        public DateTime? NGAYCAPNHATSP { get; set; }
    }

    public class MucDichSuDung
    {
        public string MAMDSD { get; set; } = string.Empty;
        public string? TENMDSD { get; set; }
        public string? MOTAMDSD { get; set; }
    }

    public class CungCap
    {
        public string MANCC { get; set; } = string.Empty;
        public string MASP { get; set; } = string.Empty;
        public int? SOLUONGSP { get; set; }
    }

    public class QuanBaSP
    {
        public string MADOTGIAMGIA { get; set; } = string.Empty;
        public string? USERID { get; set; }
        public DateTime? NGAYBATDAU { get; set; }
        public DateTime? NGAYKETTHUC { get; set; }
        public string? MANVCHON { get; set; }
    }

    public class QuangBa
    {
        public string MASP { get; set; } = string.Empty;
        public string MADOTGIAMGIA { get; set; } = string.Empty;
    }

    public class DonHang
    {
        public string MADONHANG { get; set; } = string.Empty;
        public string USERID { get; set; } = string.Empty;
        public string MAKH { get; set; } = string.Empty;
        public string? NGUOIDUYETID { get; set; }
        public string? GHICHU { get; set; }
        public string? TRANGTHAI { get; set; }
    }

    public class CTDonHang
    {
        public string MASP { get; set; } = string.Empty;
        public string MADONHANG { get; set; } = string.Empty;
        public int? SOLUONG { get; set; }
        public decimal? DONGIA { get; set; }
        public decimal? THANHTIEN { get; set; }
    }

    public class SuDung
    {
        public string MAMDSD { get; set; } = string.Empty;
        public string MASP { get; set; } = string.Empty;
    }

    public class ThanhToan
    {
        public string MATHANHTOAN { get; set; } = string.Empty;
        public string MADONHANG { get; set; } = string.Empty;
        public string USERID { get; set; } = string.Empty;
        public decimal? SOTIEN { get; set; }
        public string? PHUONGTHUC { get; set; }
        public string? MANVDUYET { get; set; }
    }

    public class PhieuXuatKho
    {
        public string MAPHIEUXUAT { get; set; } = string.Empty;
        public string USERID { get; set; } = string.Empty;
        public string MADONHANG { get; set; } = string.Empty;
        public DateTime? NGAYXUAT { get; set; }
        public string? MANVDUYET { get; set; }
    }

    public class VanChuyen
    {
        public string MAVANDON { get; set; } = string.Empty;
        public string USERID { get; set; } = string.Empty;
        public string MADONHANG { get; set; } = string.Empty;
        public string? DONVIVANCHUYEN { get; set; }
        public string? TRANGTHAIGIAO { get; set; }
        public string? MANVDIEUPHOI { get; set; }
    }
