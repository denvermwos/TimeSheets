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
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Device> Devices { get; set; } 
    }
}
