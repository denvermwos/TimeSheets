using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TimeSheets.Core.Model
{
    public class Branch
    {
        public Branch()
        {
            Devices = new List<Device>();
            Shifts = new List<Shift>();
            Staff = new List<Staff>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
        
    }
}
