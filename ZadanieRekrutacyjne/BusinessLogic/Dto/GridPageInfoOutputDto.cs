using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto
{
    public class GridPageInfoOutputDto
    {
        public List<DevContractOutputDto> DevContractsPage { get; set; }

        public int PageNr { get; set; }
        public int TotalNumberOfItems { get; set; }
    }
}
