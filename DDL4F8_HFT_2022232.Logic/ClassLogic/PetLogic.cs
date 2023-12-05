using DDL4F8_HFT_2022232.Logic.ClassLogicInterfaces;
using DDL4F8_HFT_2022232.Models;
using DDL4F8_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDL4F8_HFT_2022232.Logic.ClassLogic
{
    public class PetLogic : IPetLogic
    {   
        IRepository<Pet> repo;
        public PetLogic(IRepository<Pet> repo) { this.repo = repo; }

        // CRUD 
        public void Create(Pet item)
        {
            if (item == null) { throw new ArgumentNullException("Not correct"); }

            repo.Create(item);
        }

        public void Delete(int id)
        {
            var p = repo.Read(id);
            if (p is null) throw new ArgumentException("This is not exist!");
            repo.Delete(id);
        }

        public void Update(Pet item) { repo.Update(item); }

        public Pet Read(int id) { return repo.Read(id); }

        public IQueryable<Pet> ReadAll() { return repo.ReadAll(); }

        // NON-CRUD

        public IEnumerable<Pet> OldPet(int age)
        {
                return repo.ReadAll().Where(x => x.Age >= age);
        }
        public IEnumerable<Pet> YoungPet(int age)
        {
            return repo.ReadAll().Where(x => x.Age <= age);
        }

    }
}

