using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using Moq;
using System.Linq;
using BusinessLogic;
using System.Collections.Generic;
using BusinessLogic.Services;

namespace UnitTests
{
    [TestClass]
    public class DevContractsServiceTests
    {
        [TestMethod]
        public void DevContractsService_DeveloperExperienceBetween1And3_SalaryClaculatedCorrectly()
        {
            //Arrange
            List<DevContract> addedContract = new List<DevContract>();
            Mock<IDevContractsRepository> devContractsRepoMock = new Mock<IDevContractsRepository>();
            DevContractsService devContractSrv = new DevContractsService(devContractsRepoMock.Object);
            devContractsRepoMock.Setup(x => x.Add(It.IsAny<DevContract>())).Callback((DevContract dc) =>
            {
                addedContract.Add(dc);
            });            
            //Act
            devContractSrv.Add(new BusinessLogic.Dto.DevContractInputDto
            {
                ContractType = ContractType.developer,
                ExperienceYears = 1,
                Name = "TestDev"
            });
            devContractSrv.Add(new BusinessLogic.Dto.DevContractInputDto
            {
                ContractType = ContractType.developer,
                ExperienceYears = 2,
                Name = "TestDev2"
            });
            //Assert

            Assert.AreEqual(2500 + (1 * 125), addedContract[0].Salary);
            Assert.AreEqual(2500 + (2 * 125), addedContract[1].Salary);
        }

        [TestMethod]
        public void DevContractsService_DeveloperExperienceBetween3And5_SalaryClaculatedCorrectly()
        {
            //Arrange
            List<DevContract> addedContract = new List<DevContract>();
            Mock<IDevContractsRepository> devContractsRepoMock = new Mock<IDevContractsRepository>();
            DevContractsService devContractSrv = new DevContractsService(devContractsRepoMock.Object);
            devContractsRepoMock.Setup(x => x.Add(It.IsAny<DevContract>())).Callback((DevContract dc) =>
            {
                addedContract.Add(dc);
            });
            //Act
            devContractSrv.Add(new BusinessLogic.Dto.DevContractInputDto
            {
                ContractType = ContractType.developer,
                ExperienceYears = 3,
                Name = "TestDev"
            });
            devContractSrv.Add(new BusinessLogic.Dto.DevContractInputDto
            {
                ContractType = ContractType.developer,
                ExperienceYears = 5,
                Name = "TestDev2"
            });
            //Assert

            Assert.AreEqual(5000 + (3 * 125), addedContract[0].Salary);
            Assert.AreEqual(5000 + (5 * 125), addedContract[1].Salary);
        }
        [TestMethod]
        public void DevContractsService_DeveloperExperienceOver5_SalaryClaculatedCorrectly()
        {
            //Arrange
            List<DevContract> addedContract = new List<DevContract>();
            Mock<IDevContractsRepository> devContractsRepoMock = new Mock<IDevContractsRepository>();
            DevContractsService devContractSrv = new DevContractsService(devContractsRepoMock.Object);
            devContractsRepoMock.Setup(x => x.Add(It.IsAny<DevContract>())).Callback((DevContract dc) =>
            {
                addedContract.Add(dc);
            });
            //Act
            devContractSrv.Add(new BusinessLogic.Dto.DevContractInputDto
            {
                ContractType = ContractType.developer,
                ExperienceYears = 6,
                Name = "TestDev"
            });
            devContractSrv.Add(new BusinessLogic.Dto.DevContractInputDto
            {
                ContractType = ContractType.developer,
                ExperienceYears = 8,
                Name = "TestDev2"
            });
            //Assert

            Assert.AreEqual(5500 + (6 * 125), addedContract[0].Salary);
            Assert.AreEqual(5500 + (8 * 125), addedContract[1].Salary);
        }

        [TestMethod]
        public void DevContractsService_TesterExperienceIs1_SalaryClaculatedCorrectly()
        {
            //Arrange
            List<DevContract> addedContract = new List<DevContract>();
            Mock<IDevContractsRepository> devContractsRepoMock = new Mock<IDevContractsRepository>();
            DevContractsService devContractSrv = new DevContractsService(devContractsRepoMock.Object);
            devContractsRepoMock.Setup(x => x.Add(It.IsAny<DevContract>())).Callback((DevContract dc) =>
            {
                addedContract.Add(dc);
            });
            //Act
            devContractSrv.Add(new BusinessLogic.Dto.DevContractInputDto
            {
                ContractType = ContractType.tester,
                ExperienceYears = 1,
                Name = "TestTester"
            });
           
            //Assert

            Assert.AreEqual(2000 + (1 * 100 + (2000/4)), addedContract[0].Salary);
           
        }
        [TestMethod]
        public void DevContractsService_TesterExperienceBetween2And4_SalaryClaculatedCorrectly()
        {
            //Arrange
            List<DevContract> addedContract = new List<DevContract>();
            Mock<IDevContractsRepository> devContractsRepoMock = new Mock<IDevContractsRepository>();
            DevContractsService devContractSrv = new DevContractsService(devContractsRepoMock.Object);
            devContractsRepoMock.Setup(x => x.Add(It.IsAny<DevContract>())).Callback((DevContract dc) =>
            {
                addedContract.Add(dc);
            });
            //Act
            devContractSrv.Add(new BusinessLogic.Dto.DevContractInputDto
            {
                ContractType = ContractType.tester,
                ExperienceYears = 2,
                Name = "TestDev"
            });
            devContractSrv.Add(new BusinessLogic.Dto.DevContractInputDto
            {
                ContractType = ContractType.tester,
                ExperienceYears = 4,
                Name = "TestDev2"
            });
            //Assert

            Assert.AreEqual(2700 + (2 * 100 + (2700 / 4)), addedContract[0].Salary);
            Assert.AreEqual(2700 + (4 * 100 + (2700 / 4)), addedContract[1].Salary);
        }
        [TestMethod]
        public void DevContractsService_TesterExperienceOver4_SalaryClaculatedCorrectly()
        {
            //Arrange
            List<DevContract> addedContract = new List<DevContract>();
            Mock<IDevContractsRepository> devContractsRepoMock = new Mock<IDevContractsRepository>();
            DevContractsService devContractSrv = new DevContractsService(devContractsRepoMock.Object);
            devContractsRepoMock.Setup(x => x.Add(It.IsAny<DevContract>())).Callback((DevContract dc) =>
            {
                addedContract.Add(dc);
            });
            //Act
            devContractSrv.Add(new BusinessLogic.Dto.DevContractInputDto
            {
                ContractType = ContractType.tester,
                ExperienceYears = 5,
                Name = "TestDev"
            });
            devContractSrv.Add(new BusinessLogic.Dto.DevContractInputDto
            {
                ContractType = ContractType.tester,
                ExperienceYears = 10,
                Name = "TestDev2"
            });
            //Assert

            Assert.AreEqual(3200 + (5 * 100 + (3200 / 4)), addedContract[0].Salary);
            Assert.AreEqual(3200 + (10 * 100 + (3200 / 4)), addedContract[1].Salary);
        }

   
        [TestMethod]
        public void DevContractsService_FilteredByContractType_ResultsFilteres()
        {
            //Arrange
            Mock<IDevContractsRepository> devContractsRepoMock = new Mock<IDevContractsRepository>();
            DevContractsService devContractSrv = new DevContractsService(devContractsRepoMock.Object);
            var items = new List<DevContract>{
                new DevContract{
                    ContractType = ContractType.developer,
                    ExperienceYears = 1,
                    Name = "aaa",
                    Salary = 1234,
                },
                new DevContract{
                    ContractType = ContractType.tester,
                    ExperienceYears = 1,
                    Name = "bbb",
                    Salary = 1234,
                },
                new DevContract{
                    ContractType = ContractType.developer,
                    ExperienceYears = 1,
                    Name = "ccc",
                    Salary = 1234,
                }
            };
            
            devContractsRepoMock.Setup(x => x.GetAll()).Returns(items.AsQueryable());
            //Act
            var result = devContractSrv.GetGridPage(new GridFilterInputDto
            {
                ContractType = ContractType.tester
            });

            //Assert

            Assert.AreEqual(1, result.DevContractsPage.Count);
            Assert.AreEqual("bbb", result.DevContractsPage[0].Name);
        }

        [TestMethod]
        public void DevContractsService_FilteredByExperienceYears_ResultsFilteres()
        {
            //Arrange
            Mock<IDevContractsRepository> devContractsRepoMock = new Mock<IDevContractsRepository>();
            DevContractsService devContractSrv = new DevContractsService(devContractsRepoMock.Object);
            var items = new List<DevContract>{
                new DevContract{
                    ContractType = ContractType.developer,
                    ExperienceYears = 2,
                    Name = "aaa",
                    Salary = 1234,
                },
                new DevContract{
                    ContractType = ContractType.tester,
                    ExperienceYears = 3,
                    Name = "bbb",
                    Salary = 1234,
                },
                new DevContract{
                    ContractType = ContractType.developer,
                    ExperienceYears = 1,
                    Name = "ccc",
                    Salary = 1234,
                }
            };

            devContractsRepoMock.Setup(x => x.GetAll()).Returns(items.AsQueryable());
            //Act
            var result = devContractSrv.GetGridPage(new GridFilterInputDto
            {
                ExperienceYears = 1
            });

            //Assert

            Assert.AreEqual(1, result.DevContractsPage.Count);
            Assert.AreEqual("ccc", result.DevContractsPage[0].Name);
        }
        [TestMethod]
        public void DevContractsService_FilteredByName_ResultsFilteres()
        {
            //Arrange
            Mock<IDevContractsRepository> devContractsRepoMock = new Mock<IDevContractsRepository>();
            DevContractsService devContractSrv = new DevContractsService(devContractsRepoMock.Object);
            var items = new List<DevContract>{
                new DevContract{
                    ContractType = ContractType.developer,
                    ExperienceYears = 2,
                    Name = "aaa",
                    Salary = 1234,
                },
                new DevContract{
                    ContractType = ContractType.tester,
                    ExperienceYears = 3,
                    Name = "bbb",
                    Salary = 1234,
                },
                new DevContract{
                    ContractType = ContractType.developer,
                    ExperienceYears = 1,
                    Name = "ccc",
                    Salary = 1234,
                }
            };

            devContractsRepoMock.Setup(x => x.GetAll()).Returns(items.AsQueryable());
            //Act
            var result = devContractSrv.GetGridPage(new GridFilterInputDto
            {
                Name = "bbb"
            });

            //Assert

            Assert.AreEqual(1, result.DevContractsPage.Count);
            Assert.AreEqual("bbb", result.DevContractsPage[0].Name);
        }
        [TestMethod]
        public void DevContractsService_FilteredByOnlyProgrammersWith5YearsExperience_ResultsFilteres()
        {
            //Arrange
            Mock<IDevContractsRepository> devContractsRepoMock = new Mock<IDevContractsRepository>();
            DevContractsService devContractSrv = new DevContractsService(devContractsRepoMock.Object);
            var items = new List<DevContract>{
                new DevContract{
                    ContractType = ContractType.developer,
                    ExperienceYears = 2,
                    Name = "aaa",
                    Salary = 1234,
                },
                new DevContract{
                    ContractType = ContractType.tester,
                    ExperienceYears = 3,
                    Name = "bbb",
                    Salary = 1234,
                },
                new DevContract{
                    ContractType = ContractType.developer,
                    ExperienceYears = 5,
                    Name = "ccc",
                    Salary = 1234,
                }
            };

            devContractsRepoMock.Setup(x => x.GetAll()).Returns(items.AsQueryable());
            //Act
            var result = devContractSrv.GetGridPage(new GridFilterInputDto
            {
                OnlyProgrammersWith5YearsExperience = true
            });

            //Assert

            Assert.AreEqual(1, result.DevContractsPage.Count);
            Assert.AreEqual("ccc", result.DevContractsPage[0].Name);

        }
        [TestMethod]
        public void DevContractsService_FilteredBySalaryOver500_ResultsFilteres()
        {
            //Arrange
            Mock<IDevContractsRepository> devContractsRepoMock = new Mock<IDevContractsRepository>();
            DevContractsService devContractSrv = new DevContractsService(devContractsRepoMock.Object);
            var items = new List<DevContract>{
                new DevContract{
                    ContractType = ContractType.developer,
                    ExperienceYears = 2,
                    Name = "aaa",
                    Salary = 1234,
                },
                new DevContract{
                    ContractType = ContractType.tester,
                    ExperienceYears = 3,
                    Name = "bbb",
                    Salary = 1234,
                },
                new DevContract{
                    ContractType = ContractType.developer,
                    ExperienceYears = 1,
                    Name = "ccc",
                    Salary = 5001,
                }
            };

            devContractsRepoMock.Setup(x => x.GetAll()).Returns(items.AsQueryable());
            //Act
            var result = devContractSrv.GetGridPage(new GridFilterInputDto
            {
                Name = "ccc"
            });

            //Assert

            Assert.AreEqual(1, result.DevContractsPage.Count);
            Assert.AreEqual("ccc", result.DevContractsPage[0].Name);
        }
        [TestMethod]
        public void DevContractsService_Paging_RightPagesReturned()
        {
            //Arrange
            Mock<IDevContractsRepository> devContractsRepoMock = new Mock<IDevContractsRepository>();
            DevContractsService devContractSrv = new DevContractsService(devContractsRepoMock.Object);
            var items = new List<DevContract>{
                new DevContract{ Name = "a"},
                new DevContract{ Name = "b"},
                new DevContract{ Name = "c"},
                new DevContract{ Name = "d"},
                new DevContract{ Name = "e"},

                new DevContract{ Name = "f"},
                new DevContract{ Name = "g"},
                new DevContract{ Name = "h"},
                new DevContract{ Name = "i"},
                new DevContract{ Name = "j"},

                new DevContract{ Name = "k"},
                new DevContract{ Name = "l"},
                new DevContract{ Name = "m"},
                new DevContract{ Name = "n"},
                new DevContract{ Name = "o"}
            };

            devContractsRepoMock.Setup(x => x.GetAll()).Returns(items.AsQueryable());
            //Act
            var page1 = devContractSrv.GetGridPage(new GridFilterInputDto
            {
                PageNr = 0
            });

            var page2 = devContractSrv.GetGridPage(new GridFilterInputDto
            {
                PageNr = 1
            });

            //Assert

            Assert.AreEqual(10, page1.DevContractsPage.Count);
            Assert.AreEqual("a", page1.DevContractsPage[0].Name);
            Assert.AreEqual("j", page1.DevContractsPage[9].Name);
            Assert.AreEqual(15, page1.TotalNumberOfItems);
            Assert.AreEqual(0, page1.PageNr);

            Assert.AreEqual(5, page2.DevContractsPage.Count);
            Assert.AreEqual("k", page2.DevContractsPage[0].Name);
            Assert.AreEqual("o", page2.DevContractsPage[4].Name);
            Assert.AreEqual(15, page2.TotalNumberOfItems);
            Assert.AreEqual(1, page2.PageNr);
        }
    }

}
