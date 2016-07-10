using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto
{
    public class DevContractOutputDto
    {
        public string Name { get; set; }
        public ContractType ContractType { get; set; }
        public int ExperienceYears { get; set; }
        public decimal Salary { get; set; }
    }
}
