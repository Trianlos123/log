using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loginn.Services
{
    public interface IQrScanningService
    {
        Task<string> ScanAsync();
    }
}
