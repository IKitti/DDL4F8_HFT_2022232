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

        List<Pet> pet;

        [SetUp]

        public void Init()
        {
            pet = new List<Pet>();
            pet.Add(new Pet() { Id = 1, Name = "Hoppy", Species = "Rabbit", Title = "Herbivore", Age = 2 });
            pet.Add(new Pet() { Id = 2, Name = "Shadow", Species = "Cat", Title = "Carnivore", Age = 4 });
            pet.Add(new Pet() { Id = 3, Name = "Max", Species = "Dog", Title = "Omnivore", Age = 3 });
            pet.Add(new Pet() { Id = 4, Name = "Tweeter", Species = "Bird", Title = "Omnivore", Age = 2 });
            pet.Add(new Pet() { Id = 5, Name = "Silver", Species = "Fish", Title = "Herbivore", Age = 3 });
            pet.Add(new Pet() { Id = 6, Name = "Nibbles", Species = "Hamster", Title = "Omnivore", Age = 2 });

            mockPetRepo = new Mock<IRepository<Pet>>();
            mockPetRepo.Setup(t => t.ReadAll()).Returns(pet.AsQueryable());
            mockPetRepo.Setup(t => t.Create(It.IsAny<Pet>())).Callback((Pet e) => pet.Add(e)).Verifiable();
            mockPetRepo.Setup(t => t.Read(It.IsAny<int>())).Returns((int i) => pet.Where(x => x.Id == i).SingleOrDefault());
            mockPetRepo.Setup(t => t.Delete(It.IsAny<int>())).Callback((int i) => pet.Remove(pet.Where(x => x.Id == i).Single()));

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
