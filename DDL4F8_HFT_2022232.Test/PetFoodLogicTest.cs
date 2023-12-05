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
    internal class PetFoodLogicTest
    {

        PetFoodLogic petfoodlogic;
        Mock<IRepository<PetFood>> mockPetFoodRepo;

        [SetUp]

        public void Init()
        {
            mockPetFoodRepo = new Mock<IRepository<PetFood>>();
            mockPetFoodRepo.Setup(t => t.ReadAll()).Returns(new List<PetFood>()
            {
                new PetFood() { Id = 1, PetRecommendation = "Spider", CasualFood = "Pellets", BestFood = "Nuts", BestFoodCost = 300 },
                new PetFood() { Id = 2, PetRecommendation = "Mouse", CasualFood = "Insects", BestFood = "Fruits", BestFoodCost = 200 },
                new PetFood() { Id = 3, PetRecommendation = "Pony", CasualFood = "Vegetables", BestFood = "Hay", BestFoodCost = 300 },
                new PetFood() { Id = 4, PetRecommendation = "Horse", CasualFood = "Grass", BestFood = "Oats", BestFoodCost = 400 },
            }.AsQueryable());

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
        public void CreateTest()
        {
            // Arrange
           PetFood petfood= new PetFood() { Id = 2, PetRecommendation = "Mouse", CasualFood = "Insects", BestFood = "Fruits", BestFoodCost = 200 },

            // Act
            petfoodlogic.Create(petfood);

            // Assert
            Assert.AreEqual(result)

        }


    }

}

