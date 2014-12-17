using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.Core.Model
{
    public class Holiday
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        
        public string Name { get; set; }
    }
}

