using Marketplace.SaaS.Accelerator.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.SaaS.Accelerator.DataAccess.Contracts;
public interface IMeteringLogsRepository : IBaseRepository<MeteringLogs>
{
    public IEnumerable<MeteringLogs> GetLogsByUserId(int userId);
}
