using EduManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EduManager.Data
{
    /// <summary>
    /// DbContext cua he thong EduManager: cau noi giua cac Entity va SQL Server.
    /// </summary>
    public class EduManagerContext : DbContext
    {
        
        private const string ChuoiKetNoi =
            "Server=.\\SQLEXPRESS;Database=EduManagerDB2;Trusted_Connection=True;TrustServerCertificate=True;";

        /// <summary>Tap thuc the MonHoc (ung voi bang MONHOC).</summary>
        public DbSet<MonHoc> DanhSachMonHoc { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ChuoiKetNoi);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonHoc>(thucThe =>
            {
                // Rang buoc CHECK: so tin chi tu 1 den 6
                thucThe.ToTable("MONHOC", bang =>
                    bang.HasCheckConstraint("CK_MONHOC_SOTINCHI", "[SoTinChi] BETWEEN 1 AND 6"));

                thucThe.HasKey(m => m.MaMonHoc);

                thucThe.Property(m => m.MaMonHoc)
                       .HasColumnType("nvarchar(10)")
                       .IsRequired();

                thucThe.Property(m => m.TenMonHoc)
                       .HasColumnType("nvarchar(100)")
                       .IsRequired();

                thucThe.Property(m => m.SoTinChi).IsRequired();

                // Gia tri mac dinh TrangThai = 1 duoc dat trong script SQL (DEFAULT 1)
                // va trong Entity (TrangThai = true) de tranh loi EF bo qua gia tri false.
                thucThe.Property(m => m.TrangThai).IsRequired();
            });
        }
    }
}
