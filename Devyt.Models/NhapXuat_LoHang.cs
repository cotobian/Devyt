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
    using System.Collections.Generic;
    
    public partial class NhapXuat_LoHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhapXuat_LoHang()
        {
            this.NhapXuat_HangNhap = new HashSet<NhapXuat_HangNhap>();
        }
    
        public int Id { get; set; }
        public string SoToKhai { get; set; }
        public Nullable<int> NhaXNKId { get; set; }
        public string ChuHang { get; set; }
        public string SoHopDong { get; set; }
        public Nullable<System.DateTime> NgayToKhai { get; set; }
        public Nullable<System.DateTime> NgayHopDong { get; set; }
        public Nullable<int> TrangThai { get; set; }
        public Nullable<int> KhoId { get; set; }
    
        public virtual DanhMuc_NhaXuatNhapKhau DanhMuc_NhaXuatNhapKhau { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhapXuat_HangNhap> NhapXuat_HangNhap { get; set; }
    }
}