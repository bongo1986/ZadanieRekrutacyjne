using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DevContractsRepository : IDevContractsRepository
    {
        private IDevContractsContext _devContractsContext;

        public DevContractsRepository(IDevContractsContext devContractsContext)
        {
            _devContractsContext = devContractsContext;
        }

        public IQueryable<DevContract> GetAll()
        {
            return _devContractsContext.DeveloperContracts ;
        }

        public void Add(DevContract newDeveloperConteract)
        {
            _devContractsContext.DeveloperContracts.Add(newDeveloperConteract);
            _devContractsContext.SaveChanges();
        }
    }
}
