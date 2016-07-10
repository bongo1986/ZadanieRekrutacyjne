using BusinessLogic.Dto;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class DevContractsService : IDevContractsService
    {
        private IDevContractsRepository _devContractsRepo;

        

        public DevContractsService(IDevContractsRepository devContractsRepo)
        {
            _devContractsRepo = devContractsRepo;
        }

        public void Add(DevContractInputDto newDevContract)
        {
            decimal salary = 0;
            decimal baseSalary = 0;

            //All numbers should be difined as constants
            switch(newDevContract.ContractType){
                case ContractType.developer:
                    if (newDevContract.ExperienceYears >= 1 && newDevContract.ExperienceYears < 3)
                    {
                        baseSalary = 2500;
                    }
                    else if (newDevContract.ExperienceYears >= 3 && newDevContract.ExperienceYears <= 5)
                    {
                        baseSalary = 5000;
                    }
                    else if (newDevContract.ExperienceYears > 5 )
                    {
                        baseSalary = 5500;
                    }
                    break;
                case ContractType.tester:
                     if (newDevContract.ExperienceYears >= 1 && newDevContract.ExperienceYears < 2)
                    {
                        baseSalary = 2000;
                    }
                    else if (newDevContract.ExperienceYears >= 2 && newDevContract.ExperienceYears <= 4)
                    {
                        baseSalary = 2700;
                    }
                    else if (newDevContract.ExperienceYears > 4 )
                    {
                        baseSalary = 3200;
                    }
                    break;
                default:
                    break;
            }
            switch (newDevContract.ContractType)
            {
                case ContractType.developer:
                    salary = baseSalary + newDevContract.ExperienceYears * 125;
                    break;
                case ContractType.tester:
                    salary = baseSalary + newDevContract.ExperienceYears * 100 + baseSalary / 4;
                    break;
                default:
                    break;
            }
            _devContractsRepo.Add(new DevContract
            {
                ContractType = newDevContract.ContractType,
                ExperienceYears = newDevContract.ExperienceYears,
                Name = newDevContract.Name,
                Salary = salary
            });
        }

        public GridPageInfoOutputDto GetGridPage(GridFilterInputDto gridFilter)
        {
            var query = _devContractsRepo.GetAll();

            if (gridFilter.ContractType != null)
            {
                query = from item in query
                        where item.ContractType == gridFilter.ContractType
                        select item;
            }
            if (gridFilter.ExperienceYears != null)
            {
                query = from item in query
                        where item.ExperienceYears == gridFilter.ExperienceYears
                        select item;
            }
            if (String.IsNullOrEmpty(gridFilter.Name) == false)
            {
                query = from item in query
                        where item.Name == gridFilter.Name
                        select item;
            }
            if (gridFilter.OnlyProgrammersWith5YearsExperience)
            {
                query = from item in query
                        where item.ContractType == ContractType.developer && item.ExperienceYears == 5
                        select item;
            }
            if (gridFilter.SalaryOver500)
            {
                query = from item in query
                        where item.Salary > 5000
                        select item;
            }
            if (gridFilter.Salary != null)
            {
                query = from item in query
                        where item.Salary == gridFilter.Salary
                        select item;
            }
            // code could be less complex with automapper
            return new GridPageInfoOutputDto
            {
                DevContractsPage =
                    query.OrderBy(x => x.Name).Skip(gridFilter.PageNr * GridFilterInputDto.ItemsPerPage)
                    .Take(GridFilterInputDto.ItemsPerPage).Select(item => new DevContractOutputDto { 
                      ContractType = item.ContractType,
                      ExperienceYears = item.ExperienceYears,
                      Name = item.Name,
                      Salary = item.Salary
                    }).ToList(),
                    PageNr = gridFilter.PageNr,
                    TotalNumberOfItems = query.Count()
            };
        }
    }
}
