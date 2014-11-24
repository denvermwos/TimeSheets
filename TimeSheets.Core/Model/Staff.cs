using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.Core.Model
{
    public class Staff
    {
        public Staff() 
        {
            Scans = new List<Scan>();
            StaffShifts = new List<StaffShift>();
            Branches = new List<Branch>();
        }
        public int Id { get; set; }
        [Required]
        public int StaffNumber { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Scan> Scans { get; set; }
        public virtual ICollection<StaffShift> StaffShifts { get; set; } 
        public virtual ICollection<Branch> Branches { get; set; } 



        

    }
}
