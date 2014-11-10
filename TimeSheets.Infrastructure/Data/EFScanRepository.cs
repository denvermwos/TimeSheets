using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Interfaces;
using TimeSheets.Core.Model;

namespace TimeSheets.Infrastructure.Data
{
    public class EFScanRepository : IScanRepository
    {
        private TimeSheetsContext _timeSheetsContext;
        public EFScanRepository(TimeSheetsContext timeSheetsContext)
        {
            _timeSheetsContext = timeSheetsContext;
        }
        public IEnumerable<Scan> GetAllScans()
        {
            throw new NotImplementedException();
        }

        public Scan GetScanById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Scan> GetScansByDateTimeRange(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }


        public bool Save(Scan scan)
        {
            throw new NotImplementedException();
        }

        public bool SaveMultiple(IEnumerable<Scan> scans)
        {
            throw new NotImplementedException();
        }
    }
}
