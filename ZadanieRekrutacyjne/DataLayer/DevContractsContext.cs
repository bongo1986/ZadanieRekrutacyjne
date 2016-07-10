using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public  class DevContractsContext : DbContext, IDevContractsContext
    {
        public DbSet<DevContract> DeveloperContracts { get; set; }


        public new void SaveChanges()
        {
           base.SaveChanges();
        }

       
    }
}
