using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Infrastructure.Data;
using System.Data.Entity;

namespace TimeSheetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSheetsContext context = new TimeSheetsContext();

            


            var res2 = context.Staff.Where(s => s.StaffShifts.Any(ss=> ss.PaidStartTime==null));
            foreach (var item in res2)
            {

                Console.WriteLine(item.Name);
            }

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
