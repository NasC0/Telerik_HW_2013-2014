//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CompanyDb.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Report
    {
        public int ReportID { get; set; }
        public System.DateTime StartWork { get; set; }
        public int EmployeeID { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
