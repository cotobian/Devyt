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
    
    public partial class Admin_ViTriKho
    {
        public int Id { get; set; }
        public string ViTri { get; set; }
        public Nullable<int> KhoId { get; set; }
    
        public virtual Admin_Kho Admin_Kho { get; set; }
    }
}
