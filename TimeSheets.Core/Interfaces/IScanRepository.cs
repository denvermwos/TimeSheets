using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Model;

namespace TimeSheets.Core.Interfaces
{
    public interface IScanRepository
    {
        IEnumerable<Scan> GetAllScans();
        Scan GetScanById(int id);
        IEnumerable<Scan> GetScansByDateTimeRange(DateTime start, DateTime end);
        bool Save(Scan scan);
        bool SaveMultiple(IEnumerable<Scan> scans);

    }
}
