﻿using DDL4F8_HFT_2022232.Logic.ClassLogicInterfaces;
using DDL4F8_HFT_2022232.Models;
using DDL4F8_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDL4F8_HFT_2022232.Logic.ClassLogic
{
    public class PetFoodLogic : IPetFoodLogic
    {
        IRepository<PetFood> repo;
        public PetFoodLogic(IRepository<PetFood> repo) { this.repo = repo; }

        // CRUD 
        public void Create(PetFood item) { repo.Create(item); }

        public void Delete(int id) { repo.Delete(id); }

        public void Update(PetFood item) { repo.Update(item); }

        public PetFood Read(int id) { return repo.Read(id); }

        public IQueryable<PetFood> ReadAll() { return repo.ReadAll(); }
    }
}
