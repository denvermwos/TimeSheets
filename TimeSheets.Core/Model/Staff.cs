using System;
using System.Collections.Generic;
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
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Scan> Scans { get; set; }

        

    }
}
