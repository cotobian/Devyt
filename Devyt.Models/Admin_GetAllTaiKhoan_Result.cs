//------------------------------------------------------------------------------
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
    
    public partial class Admin_GetAllTaiKhoan_Result
    {
        public int Id { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string HoTen { get; set; }
        public Nullable<int> PhongBanId { get; set; }
        public Nullable<int> PhanQuyenId { get; set; }
        public Nullable<bool> isTaiXe { get; set; }
        public Nullable<int> TrangThai { get; set; }
        public string TenPhongBan { get; set; }
        public string TenPhanQuyen { get; set; }
    }
}