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

        PetownerLogic humanlogic;
        Mock<IRepository<Petowner>> mockPetownerRepo;

        List<Petowner> human;

        [SetUp]
        public void Init()
        {
            human = new List<Petowner>();
            human.Add(new Petowner() { Id = 1, Name = "Gergő", Sex = "Male", Age = 37, Money = 2700 });
            human.Add(new Petowner() { Id = 2, Name = "Zsófia", Sex = "Female", Age = 25, Money = 3100 });
            human.Add(new Petowner() { Id = 3, Name = "Máté", Sex = "Male", Age = 33, Money = 2400 });
            human.Add(new Petowner() { Id = 4, Name = "Dóra", Sex = "Female", Age = 30, Money = 2800 });
            human.Add(new Petowner() { Id = 5, Name = "Péter", Sex = "Male", Age = 26, Money = 2600 });

            mockPetownerRepo = new Mock<IRepository<Petowner>>();
            mockPetownerRepo.Setup(t => t.ReadAll()).Returns(human.AsQueryable());
            mockPetownerRepo.Setup(t => t.Create(It.IsAny<Petowner>())).Callback((Petowner e) => human.Add(e)).Verifiable();
            mockPetownerRepo.Setup(t => t.Read(It.IsAny<int>())).Returns((int i) => human.Where(x => x.Id == i).SingleOrDefault());
            mockPetownerRepo.Setup(t => t.Delete(It.IsAny<int>())).Callback((int i) => human.Remove(human.Where(x => x.Id == i).Single()));

            humanlogic = new PetownerLogic(mockPetownerRepo.Object);
        }



        [Test]
        public void RichOwnerTest()
        {
            // Arrange
            int moneyThreshold = 2700;

            // Act
            var result = humanlogic.RichOwner(moneyThreshold);

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
            var result = humanlogic.PoorhOwner(moneyThreshold);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.All(owner => owner.Money <= moneyThreshold));
        }

        [Test]
        public void deleteTest()
        {
            // Arrange
            int id = 1;

            // Act
            humanlogic.Delete(id);
            var valami = humanlogic.Read(id);

            // Assert
            mockPetownerRepo.Verify(t => t.Delete(id), Times.Once);
            Assert.IsNull(valami);
        }

    }
}
