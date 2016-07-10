using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class GridFilterInputDto
    {
        public const int ItemsPerPage = 10;


        [MaxLength(50)]
        public string Name { get; set; }
        public ContractType? ContractType { get; set; }
        public int? ExperienceYears { get; set; }
        public decimal? Salary { get; set; }
        public bool OnlyProgrammersWith5YearsExperience { get; set; }
        public bool SalaryOver500 { get; set; }
        public int PageNr { get; set; }
        
    }
}
