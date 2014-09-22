namespace TelerikAcademy.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkHour
    {
        [Key]
        public int EntryID { get; set; }

        public int EmployeeID { get; set; }

        [Required]
        [StringLength(100)]
        public string Task { get; set; }

        public double Hours { get; set; }

        public string Comments { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
