using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SachOnline.Models
{
    public partial class SachOnlineDbContext : DbContext
    {
        public SachOnlineDbContext()
            : base("name=SachOnlineDbContext")
        {
        }

        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<CHITIETDATHANG> CHITIETDATHANGs { get; set; }
        public virtual DbSet<CHUDE> CHUDEs { get; set; }
        public virtual DbSet<DONDATHANG> DONDATHANGs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBANs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<TACGIA> TACGIAs { get; set; }
        public virtual DbSet<VIETSACH> VIETSACHes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMIN>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDATHANG>()
                .Property(e => e.DonGia)
                .HasPrecision(9, 2);

            modelBuilder.Entity<DONDATHANG>()
                .HasMany(e => e.CHITIETDATHANGs)
                .WithRequired(e => e.DONDATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.GiaBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SACH>()
                .Property(e => e.AnhBia)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CHITIETDATHANGs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.VIETSACHes)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TACGIA>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<TACGIA>()
                .HasMany(e => e.VIETSACHes)
                .WithRequired(e => e.TACGIA)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<SachOnline.Models.ReportInfo> ReportInfoes { get; set; }
    }
}
