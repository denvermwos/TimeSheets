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
        [Key]
        public int Id;
        [Required]
        public string Name;
    }
}
