//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChairtyApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class requestTbl
    {
        public int requestId { get; set; }
        public string probStatment { get; set; }
        public int userId { get; set; }
    
        public virtual userTbl userTbl { get; set; }
    }
}
