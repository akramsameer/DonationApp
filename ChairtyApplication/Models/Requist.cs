//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChairtyApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Requist
    {
        public int Id { get; set; }
        public Nullable<decimal> RequireMoney { get; set; }
        public string DetailsProblem { get; set; }
        public string UserId { get; set; }
        public string UserIdAssign { get; set; }
        public bool Done { get; set; }
    }
}
