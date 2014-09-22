namespace TelerikAcademy.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkHours_Log
    {
        [Key]
        public int EntryID { get; set; }

        public int? OldEmployeeID { get; set; }

        [StringLength(100)]
        public string OldTask { get; set; }

        public double? OldHours { get; set; }

        public string OldComments { get; set; }

        public int? NewEmployeeID { get; set; }

        [StringLength(100)]
        public string NewTask { get; set; }

        public double? NewHours { get; set; }

        public string NewComments { get; set; }

        [Required]
        [StringLength(50)]
        public string Operation { get; set; }
    }
}
