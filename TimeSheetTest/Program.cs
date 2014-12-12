using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Model;
using TimeSheets.Infrastructure.Data;
using System.Data.Entity;

namespace TimeSheetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSheetsContext context = new TimeSheetsContext();

            StaffShift staffShift = context.StaffShifts.Where(ss => ss.Id == 1).Include("Shift.Branch").FirstOrDefault();

            Expression<Func<StaffShift, Branch>> exp = p => p.Shift.Branch;

            var maeExpression = (MemberExpression) exp.Body;
            Console.WriteLine((maeExpression.NodeType));
            Console.WriteLine((maeExpression.ToString()));
            Console.WriteLine(maeExpression.Member.Name);
            //Console.WriteLine((maeExpression.NodeType));
            Console.WriteLine();

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
