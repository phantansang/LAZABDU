//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LAZABDU.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Interface
    {
        public string C_ID { get; set; }
        public string C_Location { get; set; }
        public string C_Name { get; set; }
        public string C_Src { get; set; }
        public string C_UpdateBy { get; set; }
        public Nullable<System.DateTime> C_CreateAt { get; set; }
        public Nullable<System.DateTime> C_ModifyAt { get; set; }
        public Nullable<int> C_Status { get; set; }
        public string C_Notes { get; set; }
        public string C_Logs { get; set; }
    
        public virtual AdminAccount AdminAccount { get; set; }
    }
}
