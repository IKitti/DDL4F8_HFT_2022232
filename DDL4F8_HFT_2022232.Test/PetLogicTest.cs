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
    internal class PetLogicTest
    {
        PetLogic petlogic;
        Mock<IRepository<Pet>> mockPetRepo;

        [SetUp]

        public void Init()
        {
            mockPetRepo = new Mock<IRepository<Pet>>();
            mockPetRepo.Setup(t => t.ReadAll()).Returns(new List<Pet>()
            {
                new Pet() { Id = 1, Name = "Hoppy", Species = "Rabbit", Title = "Herbivore", Age = 2 },
                new Pet() { Id = 2, Name = "Shadow", Species = "Cat", Title = "Carnivore", Age = 4 },
                new Pet() { Id = 3, Name = "Max", Species = "Dog", Title = "Omnivore", Age = 3 },
                new Pet() { Id = 4, Name = "Tweeter", Species = "Bird", Title = "Omnivore", Age = 2 },
                new Pet() { Id = 5, Name = "Silver", Species = "Fish", Title = "Herbivore", Age = 3 },
                new Pet() { Id = 6, Name = "Nibbles", Species = "Hamster", Title = "Omnivore", Age = 2 },

            }.AsQueryable());

            petlogic = new PetLogic(mockPetRepo.Object);
        }

        [Test]
        public void OldPetTest()
        {
            // Arrange
            int ageThreshold = 3;

            // Act
            var result = petlogic.OldPet(ageThreshold);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.All(pet => pet.Age >= ageThreshold));
        }

        [Test]
        public void YoungPetTest()
        {
            // Arrangeas
            int ageThreshold = 3;

            // Act
            var result = petlogic.YoungPet(ageThreshold);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.All(pet => pet.Age <= ageThreshold));
        }


        [Test]
        public void createTest()
        {
            // Arrange
            Pet pet = new Pet() { Id = 7, Name = "Bunny", Species = "Rabbit", Title = "Herbivore", Age = 2 };

            // Act
            petlogic.Create(pet);

            // Assert
            mockPetRepo.Verify(t => t.Create(pet), Times.Once);
        }

        [Test]
        public void deleteTest()
        {
            // Arrange
            int id = 1;

            // Act
            petlogic.Delete(id);

            // Assert
            mockPetRepo.Verify(t => t.Delete(id), Times.Once);
        }

    }
}
