using DDL4F8_HFT_2022232.Logic.ClassLogic;
using DDL4F8_HFT_2022232.Models;
using DDL4F8_HFT_2022232.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDL4F8_HFT_2022232.Test
{
    [TestFixture]
    internal class PetownerLogicTest
    {

        PetownerLogic petownerlogic;
        Mock<IRepository<Petowner>> mockPetownerRepo;

        [SetUp]
        public void Init()
        {
            mockPetownerRepo = new Mock<IRepository<Petowner>>();
            mockPetownerRepo.Setup(t => t.ReadAll()).Returns(new List<Petowner>()
            {
                new Petowner() { Id = 1, Name = "Gergő", Sex = "Male", Age = 37, Money = 2700 },
                new Petowner() { Id = 2, Name = "Zsófia", Sex = "Female", Age = 25, Money = 3100 },
                new Petowner() { Id = 3, Name = "Máté", Sex = "Male", Age = 33, Money = 2400 },
                new Petowner() { Id = 4, Name = "Dóra", Sex = "Female", Age = 30, Money = 2800 },
                new Petowner() { Id = 5, Name = "Péter", Sex = "Male", Age = 26, Money = 2600 },


            }.AsQueryable());          
        }



        [Test]
        public void RichOwnerTest()
        {
            // Arrange
            int moneyThreshold = 2700;

            // Act
            var result = petownerlogic.RichOwner(moneyThreshold);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.All(owner => owner.Money >= moneyThreshold));
        }

        [Test]
        public void PoorOwnerTest()
        {
            // Arrange
            int moneyThreshold = 2700;

            // Act
            var result = petownerlogic.PoorhOwner(moneyThreshold);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.All(owner => owner.Money <= moneyThreshold));
        }
    }
}
