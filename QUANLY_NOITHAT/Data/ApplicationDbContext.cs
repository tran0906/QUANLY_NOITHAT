using Microsoft.EntityFrameworkCore;
using QUANLY_NOITHAT.Models;

namespace QUANLY_NOITHAT.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet cho các bảng
        public DbSet<User> Users { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<MucDichSuDung> MucDichSuDungs { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<NhomSanPham> NhomSanPhams { get; set; }
        public DbSet<VatLieu> VatLieus { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<CungCap> CungCaps { get; set; }
        public DbSet<QuanBaSP> QuanBaSPs { get; set; }
        public DbSet<QuangBa> QuangBas { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<CTDonHang> CTDonHangs { get; set; }
        public DbSet<SuDung> SuDungs { get; set; }
        public DbSet<ThanhToan> ThanhToans { get; set; }
        public DbSet<PhieuXuatKho> PhieuXuatKhos { get; set; }
        public DbSet<VanChuyen> VanChuyens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình bảng User
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).HasMaxLength(10).IsRequired();
                entity.Property(e => e.TenUser).HasMaxLength(100);
                entity.Property(e => e.MatKhau).HasMaxLength(256);
                entity.Property(e => e.VaiTro).HasMaxLength(50);
                entity.Property(e => e.HoTen).HasMaxLength(150);
                entity.Property(e => e.NgayTao).HasDefaultValueSql("SYSUTCDATETIME()");
                entity.HasIndex(e => e.VaiTro).HasDatabaseName("IX_User_VaiTro");
            });

            // Cấu hình bảng KHACH_HANG
            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.ToTable("KHACH_HANG");
                entity.HasKey(e => e.MAKH);
                entity.Property(e => e.MAKH).HasMaxLength(10).IsRequired();
                entity.Property(e => e.HOTENKH).HasMaxLength(150);
                entity.Property(e => e.DIACHIKH).HasMaxLength(300);
                entity.Property(e => e.SDTKH).HasMaxLength(20);
                entity.Property(e => e.EMAILKH).HasMaxLength(150);
            });

            // Cấu hình bảng MUC_DICH_SU_DUNG
            modelBuilder.Entity<MucDichSuDung>(entity =>
            {
                entity.ToTable("MUC_DICH_SU_DUNG");
                entity.HasKey(e => e.MAMDSD);
                entity.Property(e => e.MAMDSD).HasMaxLength(10).IsRequired();
                entity.Property(e => e.TENMDSD).HasMaxLength(100);
                entity.Property(e => e.MOTAMDSD).HasColumnType("nvarchar(max)");
            });

            // Cấu hình bảng NHA_CUNG_CAP
            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.ToTable("NHA_CUNG_CAP");
                entity.HasKey(e => e.MANCC);
                entity.Property(e => e.MANCC).HasMaxLength(10).IsRequired();
                entity.Property(e => e.TENNCC).HasMaxLength(200);
                entity.Property(e => e.DIACHINCC).HasMaxLength(300);
                entity.Property(e => e.SDTNCC).HasMaxLength(20);
                entity.Property(e => e.EMAILNCC).HasMaxLength(150);
                entity.Property(e => e.SANPHAM).HasMaxLength(200);
                entity.Property(e => e.GIANHAP).HasColumnType("decimal(18,2)");
            });

            // Cấu hình bảng NHOM_SAN_PHAM
            modelBuilder.Entity<NhomSanPham>(entity =>
            {
                entity.ToTable("NHOM_SAN_PHAM");
                entity.HasKey(e => e.MaNhomSP);
                entity.Property(e => e.MaNhomSP).HasMaxLength(10).IsRequired();
                entity.Property(e => e.TenNhomSP).HasMaxLength(100);
                entity.Property(e => e.MoTa).HasColumnType("nvarchar(max)");
            });

            // Cấu hình bảng VAT_LIEU
            modelBuilder.Entity<VatLieu>(entity =>
            {
                entity.ToTable("VAT_LIEU");
                entity.HasKey(e => e.MAVL);
                entity.Property(e => e.MAVL).HasMaxLength(10).IsRequired();
                entity.Property(e => e.TENVL).HasMaxLength(100);
                entity.Property(e => e.MAUVL).HasMaxLength(50);
                entity.Property(e => e.MOTAVL).HasColumnType("nvarchar(max)");
            });

            // Cấu hình bảng SAN_PHAM
            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.ToTable("SAN_PHAM");
                entity.HasKey(e => e.MaSP);
                entity.Property(e => e.MaSP).HasMaxLength(10).IsRequired();
                entity.Property(e => e.MaNhomSP).HasMaxLength(10);
                entity.Property(e => e.MaVL).HasMaxLength(10);
                entity.Property(e => e.TenSP).HasMaxLength(200);
                entity.Property(e => e.GiaBan).HasColumnType("decimal(18,2)");
                entity.Property(e => e.HinhAnh).HasMaxLength(500);
                entity.Property(e => e.MoTa).HasColumnType("nvarchar(max)");

                entity.HasOne<NhomSanPham>()
                    .WithMany()
                    .HasForeignKey(e => e.MaNhomSP)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne<VatLieu>()
                    .WithMany()
                    .HasForeignKey(e => e.MaVL)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Cấu hình bảng CUNGCAP (composite key)
            modelBuilder.Entity<CungCap>(entity =>
            {
                entity.ToTable("CUNGCAP");
                entity.HasKey(e => new { e.MANCC, e.MASP });
                entity.Property(e => e.MANCC).HasMaxLength(10);
                entity.Property(e => e.MASP).HasMaxLength(10);

                entity.HasOne<NhaCungCap>()
                    .WithMany()
                    .HasForeignKey(e => e.MANCC)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<SanPham>()
                    .WithMany()
                    .HasForeignKey(e => e.MASP)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Cấu hình bảng QUAN_BA_SP
            modelBuilder.Entity<QuanBaSP>(entity =>
            {
                entity.ToTable("QUAN_BA_SP");
                entity.HasKey(e => e.MADOTGIAMGIA);
                entity.Property(e => e.MADOTGIAMGIA).HasMaxLength(10).IsRequired();
                entity.Property(e => e.USERID).HasMaxLength(10);
                entity.Property(e => e.MANVCHON).HasMaxLength(10);

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(e => e.USERID)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Cấu hình bảng QUANGBA (composite key)
            modelBuilder.Entity<QuangBa>(entity =>
            {
                entity.ToTable("QUANGBA");
                entity.HasKey(e => new { e.MASP, e.MADOTGIAMGIA });
                entity.Property(e => e.MASP).HasMaxLength(10);
                entity.Property(e => e.MADOTGIAMGIA).HasMaxLength(10);

                entity.HasOne<SanPham>()
                    .WithMany()
                    .HasForeignKey(e => e.MASP)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<QuanBaSP>()
                    .WithMany()
                    .HasForeignKey(e => e.MADOTGIAMGIA)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Cấu hình bảng DON_HANG
            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.ToTable("DON_HANG");
                entity.HasKey(e => e.MADONHANG);
                entity.Property(e => e.MADONHANG).HasMaxLength(10).IsRequired();
                entity.Property(e => e.USERID).HasMaxLength(10).IsRequired();
                entity.Property(e => e.MAKH).HasMaxLength(10).IsRequired();
                entity.Property(e => e.NGUOIDUYETID).HasMaxLength(20);
                entity.Property(e => e.GHICHU).HasColumnType("nvarchar(max)");
                entity.Property(e => e.TRANGTHAI).HasMaxLength(50);

                entity.HasOne<KhachHang>()
                    .WithMany()
                    .HasForeignKey(e => e.MAKH)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(e => e.USERID)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Cấu hình bảng CT_DONHANG (composite key)
            modelBuilder.Entity<CTDonHang>(entity =>
            {
                entity.ToTable("CT_DONHANG");
                entity.HasKey(e => new { e.MASP, e.MADONHANG });
                entity.Property(e => e.MASP).HasMaxLength(10);
                entity.Property(e => e.MADONHANG).HasMaxLength(10);
                entity.Property(e => e.DONGIA).HasColumnType("decimal(18,2)");
                entity.Property(e => e.THANHTIEN).HasColumnType("decimal(18,2)");

                entity.HasOne<SanPham>()
                    .WithMany()
                    .HasForeignKey(e => e.MASP)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne<DonHang>()
                    .WithMany()
                    .HasForeignKey(e => e.MADONHANG)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Cấu hình bảng SUDUNG (composite key)
            modelBuilder.Entity<SuDung>(entity =>
            {
                entity.ToTable("SUDUNG");
                entity.HasKey(e => new { e.MAMDSD, e.MASP });
                entity.Property(e => e.MAMDSD).HasMaxLength(10);
                entity.Property(e => e.MASP).HasMaxLength(10);

                entity.HasOne<MucDichSuDung>()
                    .WithMany()
                    .HasForeignKey(e => e.MAMDSD)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<SanPham>()
                    .WithMany()
                    .HasForeignKey(e => e.MASP)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Cấu hình bảng THANH_TOAN
            modelBuilder.Entity<ThanhToan>(entity =>
            {
                entity.ToTable("THANH_TOAN");
                entity.HasKey(e => e.MATHANHTOAN);
                entity.Property(e => e.MATHANHTOAN).HasMaxLength(10).IsRequired();
                entity.Property(e => e.MADONHANG).HasMaxLength(10).IsRequired();
                entity.Property(e => e.USERID).HasMaxLength(10).IsRequired();
                entity.Property(e => e.SOTIEN).HasColumnType("decimal(18,2)");
                entity.Property(e => e.PHUONGTHUC).HasMaxLength(50);
                entity.Property(e => e.MANVDUYET).HasMaxLength(10);

                entity.HasOne<DonHang>()
                    .WithMany()
                    .HasForeignKey(e => e.MADONHANG)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(e => e.USERID)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Cấu hình bảng PHIEU_XUAT_KHO
            modelBuilder.Entity<PhieuXuatKho>(entity =>
            {
                entity.ToTable("PHIEU_XUAT_KHO");
                entity.HasKey(e => e.MAPHIEUXUAT);
                entity.Property(e => e.MAPHIEUXUAT).HasMaxLength(10).IsRequired();
                entity.Property(e => e.USERID).HasMaxLength(10).IsRequired();
                entity.Property(e => e.MADONHANG).HasMaxLength(10).IsRequired();
                entity.Property(e => e.MANVDUYET).HasMaxLength(10);

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(e => e.USERID)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne<DonHang>()
                    .WithMany()
                    .HasForeignKey(e => e.MADONHANG)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Cấu hình bảng VAN_CHUYEN
            modelBuilder.Entity<VanChuyen>(entity =>
            {
                entity.ToTable("VAN_CHUYEN");
                entity.HasKey(e => e.MAVANDON);
                entity.Property(e => e.MAVANDON).HasMaxLength(10).IsRequired();
                entity.Property(e => e.USERID).HasMaxLength(10).IsRequired();
                entity.Property(e => e.MADONHANG).HasMaxLength(10).IsRequired();
                entity.Property(e => e.DONVIVANCHUYEN).HasMaxLength(100);
                entity.Property(e => e.TRANGTHAIGIAO).HasMaxLength(50);
                entity.Property(e => e.MANVDIEUPHOI).HasMaxLength(10);

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(e => e.USERID)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne<DonHang>()
                    .WithMany()
                    .HasForeignKey(e => e.MADONHANG)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
