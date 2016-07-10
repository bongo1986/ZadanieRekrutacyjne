using BusinessLogic.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IDevContractsService
    {
        void Add(DevContractInputDto newDevContract);
        GridPageInfoOutputDto GetGridPage(GridFilterInputDto gridFilter);
    }
}
