using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto
{
    public class DevContractInputDto
    {
       [MaxLength(20)]
       public string Name { get; set; }
       public ContractType ContractType { get; set; }
       [Range(1,100)]
       public int ExperienceYears { get; set; }
    }
}
