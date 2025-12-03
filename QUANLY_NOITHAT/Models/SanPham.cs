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
