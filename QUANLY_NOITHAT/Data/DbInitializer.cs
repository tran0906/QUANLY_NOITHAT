using QUANLY_NOITHAT.Models;

namespace QUANLY_NOITHAT.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Tạo database nếu chưa tồn tại
            context.Database.EnsureCreated();

            // Kiểm tra nếu đã có dữ liệu
            if (context.Users.Any())
            {
                return; // DB đã được seed
            }

            // Thêm dữ liệu mẫu cho User
            var users = new User[]
            {
                new User
                {
                    UserId = "admin",
                    TenUser = "admin",
                    MatKhau = "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=", // Admin123 hashed
                    VaiTro = "Admin",
                    HoTen = "Quản trị viên",
                    NgayTao = DateTime.UtcNow
                },
                new User
                {
                    UserId = "user",
                    TenUser = "user",
                    MatKhau = "BPiZbadjt6lpsQKO4wB1aerzpjVIbdqyEdUSyFud+Ps=", // User123 hashed
                    VaiTro = "KhachHang",
                    HoTen = "Khách hàng",
                    NgayTao = DateTime.UtcNow
                }
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            // Thêm dữ liệu mẫu cho Nhóm sản phẩm
            var nhomSanPhams = new NhomSanPham[]
            {
                new NhomSanPham { MaNhomSP = "NSP001", TenNhomSP = "Phòng khách", MoTa = "Nội thất phòng khách" },
                new NhomSanPham { MaNhomSP = "NSP002", TenNhomSP = "Phòng ngủ", MoTa = "Nội thất phòng ngủ" },
                new NhomSanPham { MaNhomSP = "NSP003", TenNhomSP = "Phòng bếp", MoTa = "Nội thất phòng bếp" },
                new NhomSanPham { MaNhomSP = "NSP004", TenNhomSP = "Phòng làm việc", MoTa = "Nội thất phòng làm việc" }
            };
            context.NhomSanPhams.AddRange(nhomSanPhams);
            context.SaveChanges();

            // Thêm dữ liệu mẫu cho Vật liệu
            var vatLieus = new VatLieu[]
            {
                new VatLieu { MAVL = "VL001", TENVL = "Gỗ sồi", MAUVL = "Nâu", SOLUONG = 100 },
                new VatLieu { MAVL = "VL002", TENVL = "Gỗ óc chó", MAUVL = "Nâu đậm", SOLUONG = 80 },
                new VatLieu { MAVL = "VL003", TENVL = "Vải nỉ", MAUVL = "Xám", SOLUONG = 200 },
                new VatLieu { MAVL = "VL004", TENVL = "Da thật", MAUVL = "Đen", SOLUONG = 50 }
            };
            context.VatLieus.AddRange(vatLieus);
            context.SaveChanges();

            // Thêm dữ liệu mẫu cho Sản phẩm
            var sanPhams = new SanPham[]
            {
                new SanPham
                {
                    MaSP = "SP001",
                    MaNhomSP = "NSP001",
                    MaVL = "VL003",
                    TenSP = "Sofa Góc Hiện Đại",
                    GiaBan = 15000000,
                    SoLuongTon = 10,
                    HinhAnh = "/images/sofa.jpg",
                    MoTa = "Sofa góc hiện đại, chất liệu vải nỉ cao cấp"
                },
                new SanPham
                {
                    MaSP = "SP002",
                    MaNhomSP = "NSP002",
                    MaVL = "VL001",
                    TenSP = "Giường Ngủ Gỗ Sồi",
                    GiaBan = 12500000,
                    SoLuongTon = 8,
                    HinhAnh = "/images/giuong.jpg",
                    MoTa = "Giường ngủ gỗ sồi tự nhiên, thiết kế sang trọng"
                },
                new SanPham
                {
                    MaSP = "SP003",
                    MaNhomSP = "NSP003",
                    MaVL = "VL001",
                    TenSP = "Bộ Bàn Ăn 6 Ghế",
                    GiaBan = 8900000,
                    SoLuongTon = 15,
                    HinhAnh = "/images/banan.jpg",
                    MoTa = "Bộ bàn ăn 6 ghế gỗ sồi cao cấp"
                },
                new SanPham
                {
                    MaSP = "SP004",
                    MaNhomSP = "NSP002",
                    MaVL = "VL002",
                    TenSP = "Tủ Quần Áo Cánh Lùa",
                    GiaBan = 9500000,
                    SoLuongTon = 12,
                    HinhAnh = "/images/tuquanao.jpg",
                    MoTa = "Tủ quần áo cánh lùa gỗ óc chó"
                }
            };
            context.SanPhams.AddRange(sanPhams);
            context.SaveChanges();

            // Thêm dữ liệu mẫu cho Khách hàng
            var khachHangs = new KhachHang[]
            {
                new KhachHang
                {
                    MAKH = "KH001",
                    HOTENKH = "Nguyễn Văn A",
                    DIACHIKH = "123 Đường ABC, TP.HCM",
                    SDTKH = "0912345678",
                    EMAILKH = "nguyenvana@email.com"
                },
                new KhachHang
                {
                    MAKH = "KH002",
                    HOTENKH = "Trần Thị B",
                    DIACHIKH = "456 Đường XYZ, Hà Nội",
                    SDTKH = "0987654321",
                    EMAILKH = "tranthib@email.com"
                }
            };
            context.KhachHangs.AddRange(khachHangs);
            context.SaveChanges();
        }
    }
}
