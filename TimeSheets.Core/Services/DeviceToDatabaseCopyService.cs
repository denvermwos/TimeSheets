using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TimeSheets.Core.Interfaces;
using TimeSheets.Core.Model;

namespace TimeSheets.Core.Services
{
    public class DeviceToDatabaseCopyService
    {
        private IDeviceService _deviceService;
        private IUnitOfWork _iUnitOfWork;

        public DeviceToDatabaseCopyService(IDeviceService deviceService, IUnitOfWork iUnitOfWork)
        {
            _deviceService = deviceService;
            _iUnitOfWork = iUnitOfWork;
        }

        public int Import(Device device)
        {
            //Device Error, Database Error


            IEnumerable<Scan> scans = _deviceService.GetAllScans(device);

            if (scans != null)
            {

                try
                {
                    _iUnitOfWork.ScanRepository.SaveMultiple(scans);
                    _iUnitOfWork.SaveChanges();
                }
                catch (Exception ex)
                {

                    return 2;
                }

                _deviceService.ClearAttendanceLogs(device);
            }
            return 0;
        }
    }
}
