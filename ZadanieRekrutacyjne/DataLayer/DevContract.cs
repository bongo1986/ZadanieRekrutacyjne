using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public enum ContractType
    {
        developer,
        tester
    }

    public class DevContract
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public ContractType ContractType { get; set; }
        public int ExperienceYears { get; set; }
        public decimal Salary { get; set; }
    }
}
