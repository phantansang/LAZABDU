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
    
    public partial class AdminLog
    {
        public int C_ID { get; set; }
        public string C_By { get; set; }
        public Nullable<System.DateTime> C_Time { get; set; }
        public string C_Message { get; set; }
        public Nullable<int> C_Stauts { get; set; }
    
        public virtual AdminAccount AdminAccount { get; set; }
    }
}
