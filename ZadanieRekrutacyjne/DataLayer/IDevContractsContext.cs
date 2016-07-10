using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDevContractsContext
    {
        DbSet<DevContract> DeveloperContracts { get; set; }
        void SaveChanges();
    }
}
