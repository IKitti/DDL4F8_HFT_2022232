using DDL4F8_HFT_2022232.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DDL4F8_HFT_2022232.Repository
{
    public class PetsDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetFood> PetFoods { get; set;}
        public DbSet<Petowner> PetOwners { get; set; }

        public PetsDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("PetLife.txt");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Petowner>()
                       .HasMany(p => p.Pets)
                       .WithOne(p => p.Petowner)
                       .HasForeignKey(p => p.PetownerId)
                       .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PetFood>()
                .HasMany(pf => pf.Pets)
                .WithOne(p => p.PetFood)
                .HasForeignKey(p => p.PetFoodId)
                .OnDelete(DeleteBehavior.Cascade);



            var POs = new Petowner[]
{
    new Petowner() { Id = 1, Name = "János", Sex = "Male", Age = 34, Money= 2600 },
    new Petowner() { Id = 2, Name = "Katalin", Sex = "Female", Age = 28, Money= 2900 },
    new Petowner() { Id = 3, Name = "Gábor", Sex = "Male", Age = 42, Money= 2200 },
    new Petowner() { Id = 4, Name = "Eszter", Sex = "Female", Age = 36, Money= 2900 },
    new Petowner() { Id = 5, Name = "András", Sex = "Male", Age = 29, Money= 2500 },
    new Petowner() { Id = 6, Name = "Beáta", Sex = "Female", Age = 31, Money= 2300 },
    new Petowner() { Id = 7, Name = "Ferenc", Sex = "Male", Age = 45, Money= 2000 },
    new Petowner() { Id = 8, Name = "Erzsébet", Sex = "Female", Age = 40, Money= 2300 },
    new Petowner() { Id = 9, Name = "Miklós", Sex = "Male", Age = 26, Money= 2100 },
    new Petowner() { Id = 10, Name = "Anikó", Sex = "Female", Age = 33, Money= 2200 },
    new Petowner() { Id = 11, Name = "Gergő", Sex = "Male", Age = 38, Money= 2800 }
};

            var PFs = new PetFood[]
            {
    new PetFood() { Id = 1, PetRecommendation = "Cat", CasualFood = "Meat", BestFood = "Fish", BestFoodCost = 200},
    new PetFood() { Id = 2, PetRecommendation = "Dog", CasualFood = "Chicken", BestFood = "Beef", BestFoodCost = 800 },
    new PetFood() { Id = 3, PetRecommendation = "Bird", CasualFood = "Seeds", BestFood = "Insects", BestFoodCost = 100 },
    new PetFood() { Id = 4, PetRecommendation = "Fish", CasualFood = "Flakes", BestFood = "Pellets", BestFoodCost = 200 },
    new PetFood() { Id = 5, PetRecommendation = "Rabbit", CasualFood = "Hay", BestFood = "Vegetables", BestFoodCost = 400 },
    new PetFood() { Id = 6, PetRecommendation = "Hamster", CasualFood = "Pellets", BestFood = "Nuts", BestFoodCost = 300 },
    new PetFood() { Id = 7, PetRecommendation = "Reptile", CasualFood = "Insects", BestFood = "Fruits", BestFoodCost = 200 },
    new PetFood() { Id = 8, PetRecommendation = "GuineaPig", CasualFood = "Vegetables", BestFood = "Hay", BestFoodCost = 300 },
    new PetFood() { Id = 9, PetRecommendation = "Ferret", CasualFood = "Meat", BestFood = "Eggs", BestFoodCost = 400 },
    new PetFood() { Id = 10, PetRecommendation = "Turtle", CasualFood = "Pellets", BestFood = "Fish", BestFoodCost = 500 },
    new PetFood() { Id = 11, PetRecommendation = "Snake", CasualFood = "Mice", BestFood = "Birds", BestFoodCost = 700 }
            };

            var Ps = new Pet[]
            {
    new Pet() { Id = 1, Name = "Nyunyu", Species = "Rabbit", Title = "Herbivore", Age = 3 },
    new Pet() { Id = 2, Name = "Fluffy", Species = "Cat", Title = "Carnivore", Age = 2 },
    new Pet() { Id = 3, Name = "Buddy", Species = "Dog", Title = "Omnivore", Age = 4 },
    new Pet() { Id = 4, Name = "Tweety", Species = "Bird", Title = "Omnivore", Age = 1 },
    new Pet() { Id = 5, Name = "Goldie", Species = "Fish", Title = "Herbivore", Age = 1 },
    new Pet() { Id = 6, Name = "Whiskers", Species = "Hamster", Title = "Omnivore", Age = 1 },
    new Pet() { Id = 7, Name = "Spike", Species = "Reptile", Title = "Carnivore", Age = 3 },
    new Pet() { Id = 8, Name = "Cotton", Species = "Guinea Pig", Title = "Herbivore", Age = 2 },
    new Pet() { Id = 9, Name = "Bella", Species = "Ferret", Title = "Carnivore", Age = 2 },
    new Pet() { Id = 10, Name = "Shelly", Species = "Turtle", Title = "Herbivore", Age = 5 },
    new Pet() { Id = 11, Name = "Slinky", Species = "Snake", Title = "Carnivore", Age = 4 },
    new Pet() { Id = 12, Name = "Mittens", Species = "Cat", Title = "Carnivore", Age = 3 },
    new Pet() { Id = 13, Name = "Furry", Species = "Dog", Title = "Omnivore", Age = 2 },
    new Pet() { Id = 14, Name = "Rio", Species = "Bird", Title = "Omnivore", Age = 1 },
    new Pet() { Id = 15, Name = "Silver", Species = "Fish", Title = "Herbivore", Age = 1 },
    new Pet() { Id = 16, Name = "Paws", Species = "Hamster", Title = "Omnivore", Age = 1 },
    new Pet() { Id = 17, Name = "Rex", Species = "Reptile", Title = "Carnivore", Age = 3 },
    new Pet() { Id = 18, Name = "Whisper", Species = "Guinea Pig", Title = "Herbivore", Age = 2 },
    new Pet() { Id = 19, Name = "Shadow", Species = "Ferret", Title = "Carnivore", Age = 2 },
    new Pet() { Id = 20, Name = "Speedy", Species = "Turtle", Title = "Herbivore", Age = 5 },
            };

            modelBuilder.Entity<Petowner>().HasData(POs);
            modelBuilder.Entity<PetFood>().HasData(PFs);
            modelBuilder.Entity<Pet>().HasData(Ps);

            base.OnModelCreating(modelBuilder);
        }




    }
}
