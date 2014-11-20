using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.Core.Model
{
    public class Shift
    {
        public Shift()
        {
            StaffShifts = new List<StaffShift>();
        }
        [Key]
        public int Id { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        
        [DisplayName("Shift Start Time")]
        public DateTime StartDateTime { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Shift Finish Time")]
        public DateTime FinishDateTime { get; set; }
        
        [Required]
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public virtual ICollection<StaffShift> StaffShifts { get; set; }

    }
}
