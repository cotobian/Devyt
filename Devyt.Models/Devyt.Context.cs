﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Devyt.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DevytEntities : DbContext
    {
        public DevytEntities()
            : base("name=DevytEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin_ChiNhanh> Admin_ChiNhanh { get; set; }
        public virtual DbSet<Admin_Kho> Admin_Kho { get; set; }
        public virtual DbSet<Admin_PhanQuyen> Admin_PhanQuyen { get; set; }
        public virtual DbSet<Admin_PhanQuyenController> Admin_PhanQuyenController { get; set; }
        public virtual DbSet<Admin_PhongBan> Admin_PhongBan { get; set; }
        public virtual DbSet<Admin_TaiKhoan> Admin_TaiKhoan { get; set; }
        public virtual DbSet<Admin_ViTriKho> Admin_ViTriKho { get; set; }
        public virtual DbSet<DanhMuc_BieuCuocChuan> DanhMuc_BieuCuocChuan { get; set; }
        public virtual DbSet<DanhMuc_DiaDiem> DanhMuc_DiaDiem { get; set; }
        public virtual DbSet<DanhMuc_DonViTinh> DanhMuc_DonViTinh { get; set; }
        public virtual DbSet<DanhMuc_KhachHang> DanhMuc_KhachHang { get; set; }
        public virtual DbSet<DanhMuc_LoaiHang> DanhMuc_LoaiHang { get; set; }
        public virtual DbSet<DanhMuc_NhaCungCap> DanhMuc_NhaCungCap { get; set; }
        public virtual DbSet<DanhMuc_NhaXuatNhapKhau> DanhMuc_NhaXuatNhapKhau { get; set; }
        public virtual DbSet<DanhMuc_TaiXe> DanhMuc_TaiXe { get; set; }
        public virtual DbSet<DanhMuc_XeVanTai> DanhMuc_XeVanTai { get; set; }
        public virtual DbSet<NhapXuat_HangNhap> NhapXuat_HangNhap { get; set; }
        public virtual DbSet<NhapXuat_HangXuat> NhapXuat_HangXuat { get; set; }
        public virtual DbSet<NhapXuat_LoHang> NhapXuat_LoHang { get; set; }
        public virtual DbSet<NhapXuat_TonKho> NhapXuat_TonKho { get; set; }
        public virtual DbSet<VanTai_ChuyenDieuVan> VanTai_ChuyenDieuVan { get; set; }
        public virtual DbSet<VanTai_KeHoachVanTai> VanTai_KeHoachVanTai { get; set; }
        public virtual DbSet<VanTai_LenhVanChuyen> VanTai_LenhVanChuyen { get; set; }
        public virtual DbSet<DanhMuc_DonViVanTai> DanhMuc_DonViVanTai { get; set; }
    
        public virtual ObjectResult<Admin_GetAllKho_Result> Admin_GetAllKho()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Admin_GetAllKho_Result>("Admin_GetAllKho");
        }
    
        public virtual ObjectResult<Admin_GetAllPhongBan_Result> Admin_GetAllPhongBan()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Admin_GetAllPhongBan_Result>("Admin_GetAllPhongBan");
        }
    
        public virtual ObjectResult<Admin_GetAllTaiKhoan_Result> Admin_GetAllTaiKhoan()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Admin_GetAllTaiKhoan_Result>("Admin_GetAllTaiKhoan");
        }
    
        public virtual ObjectResult<Admin_GetAllViTriKho_Result> Admin_GetAllViTriKho()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Admin_GetAllViTriKho_Result>("Admin_GetAllViTriKho");
        }
    
        public virtual ObjectResult<string> Admin_GetPhanQuyenMethod(string controller, string method)
        {
            var controllerParameter = controller != null ?
                new ObjectParameter("controller", controller) :
                new ObjectParameter("controller", typeof(string));
    
            var methodParameter = method != null ?
                new ObjectParameter("method", method) :
                new ObjectParameter("method", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("Admin_GetPhanQuyenMethod", controllerParameter, methodParameter);
        }
    
        public virtual ObjectResult<DanhMuc_GetAllBieuCuocChuan_Result> DanhMuc_GetAllBieuCuocChuan()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DanhMuc_GetAllBieuCuocChuan_Result>("DanhMuc_GetAllBieuCuocChuan");
        }
    
        public virtual int DanhMuc_GetAllRoMooc()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DanhMuc_GetAllRoMooc");
        }
    
        public virtual ObjectResult<DanhMuc_GetAllTaiXeByChiNhanh_Result> DanhMuc_GetAllTaiXeByChiNhanh(Nullable<int> cnid)
        {
            var cnidParameter = cnid.HasValue ?
                new ObjectParameter("cnid", cnid) :
                new ObjectParameter("cnid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DanhMuc_GetAllTaiXeByChiNhanh_Result>("DanhMuc_GetAllTaiXeByChiNhanh", cnidParameter);
        }
    
        public virtual ObjectResult<DanhMuc_GetAllXeVanTai_Result> DanhMuc_GetAllXeVanTai()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DanhMuc_GetAllXeVanTai_Result>("DanhMuc_GetAllXeVanTai");
        }
    
        public virtual ObjectResult<NhapXuat_GetAllHangNhapByChiNhanh_Result> NhapXuat_GetAllHangNhapByChiNhanh(Nullable<int> cnid)
        {
            var cnidParameter = cnid.HasValue ?
                new ObjectParameter("cnid", cnid) :
                new ObjectParameter("cnid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NhapXuat_GetAllHangNhapByChiNhanh_Result>("NhapXuat_GetAllHangNhapByChiNhanh", cnidParameter);
        }
    
        public virtual ObjectResult<NhapXuat_GetAllHangXuatByChiNhanh_Result> NhapXuat_GetAllHangXuatByChiNhanh(Nullable<int> cnid)
        {
            var cnidParameter = cnid.HasValue ?
                new ObjectParameter("cnid", cnid) :
                new ObjectParameter("cnid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NhapXuat_GetAllHangXuatByChiNhanh_Result>("NhapXuat_GetAllHangXuatByChiNhanh", cnidParameter);
        }
    
        public virtual ObjectResult<NhapXuat_GetAllLoHang_Result> NhapXuat_GetAllLoHang()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NhapXuat_GetAllLoHang_Result>("NhapXuat_GetAllLoHang");
        }
    
        public virtual ObjectResult<NhapXuat_GetAllLoHangByChiNhanh_Result> NhapXuat_GetAllLoHangByChiNhanh(Nullable<int> cnid)
        {
            var cnidParameter = cnid.HasValue ?
                new ObjectParameter("cnid", cnid) :
                new ObjectParameter("cnid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NhapXuat_GetAllLoHangByChiNhanh_Result>("NhapXuat_GetAllLoHangByChiNhanh", cnidParameter);
        }
    
        public virtual ObjectResult<Report_BaoCaoTonKho_Result> Report_BaoCaoTonKho(Nullable<int> cnid)
        {
            var cnidParameter = cnid.HasValue ?
                new ObjectParameter("cnid", cnid) :
                new ObjectParameter("cnid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Report_BaoCaoTonKho_Result>("Report_BaoCaoTonKho", cnidParameter);
        }
    
        public virtual ObjectResult<VanTai_GetAllChuyenDieuVanTheoChiNhanh_Result> VanTai_GetAllChuyenDieuVanTheoChiNhanh(Nullable<int> cnid)
        {
            var cnidParameter = cnid.HasValue ?
                new ObjectParameter("cnid", cnid) :
                new ObjectParameter("cnid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VanTai_GetAllChuyenDieuVanTheoChiNhanh_Result>("VanTai_GetAllChuyenDieuVanTheoChiNhanh", cnidParameter);
        }
    
        public virtual ObjectResult<VanTai_GetAllKeHoachVanTaiTheoChiNhanh_Result> VanTai_GetAllKeHoachVanTaiTheoChiNhanh(Nullable<int> cnid)
        {
            var cnidParameter = cnid.HasValue ?
                new ObjectParameter("cnid", cnid) :
                new ObjectParameter("cnid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VanTai_GetAllKeHoachVanTaiTheoChiNhanh_Result>("VanTai_GetAllKeHoachVanTaiTheoChiNhanh", cnidParameter);
        }
    
        public virtual ObjectResult<VanTai_GetAllLenhVanChuyenTheoChiNhanh_Result> VanTai_GetAllLenhVanChuyenTheoChiNhanh(Nullable<int> cnid)
        {
            var cnidParameter = cnid.HasValue ?
                new ObjectParameter("cnid", cnid) :
                new ObjectParameter("cnid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VanTai_GetAllLenhVanChuyenTheoChiNhanh_Result>("VanTai_GetAllLenhVanChuyenTheoChiNhanh", cnidParameter);
        }
    }
}
