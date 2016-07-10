using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDevContractsRepository
    {
        IQueryable<DevContract> GetAll();
        void Add(DevContract newDeveloperConteract);
    }
}
