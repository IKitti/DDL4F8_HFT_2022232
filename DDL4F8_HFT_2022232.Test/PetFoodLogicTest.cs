﻿using DDL4F8_HFT_2022232.Logic.ClassLogic;
using DDL4F8_HFT_2022232.Models;
using DDL4F8_HFT_2022232.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DDL4F8_HFT_2022232.Test
{
    [TestFixture]
    internal class PetFoodLogicTest
    {

        PetFoodLogic petfoodlogic;
        Mock<IRepository<PetFood>> mockPetFoodRepo;

        List<PetFood> petfood;

        [SetUp]

        public void Init()
        {
            petfood = new List<PetFood>();
            petfood.Add(new PetFood() { Id = 1, PetRecommendation = "Spider", CasualFood = "Pellets", BestFood = "Nuts", BestFoodCost = 300 });
            petfood.Add(new PetFood() { Id = 2, PetRecommendation = "Mouse", CasualFood = "Insects", BestFood = "Fruits", BestFoodCost = 200 });
            petfood.Add(new PetFood() { Id = 3, PetRecommendation = "Pony", CasualFood = "Vegetables", BestFood = "Hay", BestFoodCost = 300 });
            petfood.Add(new PetFood() { Id = 4, PetRecommendation = "Horse", CasualFood = "Grass", BestFood = "Oats", BestFoodCost = 400 });

            mockPetFoodRepo = new Mock<IRepository<PetFood>>();
            mockPetFoodRepo.Setup(t => t.ReadAll()).Returns(petfood.AsQueryable());
            mockPetFoodRepo.Setup(t => t.Create(It.IsAny<PetFood>())).Callback((PetFood e) => petfood.Add(e)).Verifiable();
            mockPetFoodRepo.Setup(t => t.Read(It.IsAny<int>())).Returns((int i) => petfood.Where(x => x.Id == i).SingleOrDefault());
            mockPetFoodRepo.Setup(t => t.Delete(It.IsAny<int>())).Callback((int i) => petfood.Remove(petfood.Where(x => x.Id == i).Single()));

            petfoodlogic = new PetFoodLogic(mockPetFoodRepo.Object);
        }


        [Test]
        public void minCostTest()
        {
            // Arrange
            int costThreshold = 250;
            var expectedPetFoods = new List<PetFood>()
            {
                new PetFood() { Id = 1, PetRecommendation = "Spider", CasualFood = "Pellets", BestFood = "Nuts", BestFoodCost = 300 },
                new PetFood() { Id = 3, PetRecommendation = "Pony", CasualFood = "Vegetables", BestFood = "Hay", BestFoodCost = 300 },
                new PetFood() { Id = 4, PetRecommendation = "Horse", CasualFood = "Grass", BestFood = "Oats", BestFoodCost = 400 },
            };

            // Act
            var result = petfoodlogic.minCost(costThreshold).ToList();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedPetFoods.Count, result.Count());
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedPetFoods[i].Id, result[i].Id);
            }
        }

        [Test]
        public void maxCostTest()
        {
            // Arrange
            int costThreshold = 250;
            var expectedPetFoods = new List<PetFood>()
        {
            new PetFood() { Id = 2, PetRecommendation = "Mouse", CasualFood = "Insects", BestFood = "Fruits", BestFoodCost = 200 },
        };

            // Act
            var result = petfoodlogic.maxCost(costThreshold).ToList();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedPetFoods.Count, result.Count());
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedPetFoods[i].Id, result[i].Id);
            }

        }

        [Test]
        public void createTest()
        {
            // Arrange
            PetFood petfood = new PetFood() { Id = 5, PetRecommendation = "Dog", CasualFood = "Chicken", BestFood = "Beef", BestFoodCost = 800 };

            // Act
            petfoodlogic.Create(petfood);

            // Assert
            mockPetFoodRepo.Verify(t => t.Create(petfood), Times.Once);
        }

        [Test]
        public void deleteTest()
        {
            // Arrange
            int id = 1;

            // Act
            petfoodlogic.Delete(id);

            // Assert
            mockPetFoodRepo.Verify(t => t.Delete(id), Times.Once);
        }

    }

}

