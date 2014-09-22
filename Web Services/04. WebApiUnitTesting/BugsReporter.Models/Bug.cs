using System;
using System.ComponentModel.DataAnnotations;

namespace BugsReporter.Models
{
    public class Bug
    {
        public Bug()
        {
            this.LogDate = DateTime.Now;
            this.Status = Status.Pending;
        }

        public int BugID { get; set; }

        [Required]
        [MinLength(2)]
        public string Text { get; set; }

        [Required]
        public DateTime LogDate { get; set; }

        public Status Status { get; set; }

        public override bool Equals(object obj)
        {
            var objAsBug = obj as Bug;
            if (objAsBug == null)
            {
                return false;
            }

            return this.BugID == objAsBug.BugID &&
                   this.LogDate == objAsBug.LogDate &&
                   this.Status == objAsBug.Status &&
                   this.Text == objAsBug.Text;
        }
    }
}
