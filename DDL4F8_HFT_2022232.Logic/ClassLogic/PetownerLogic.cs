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
    public class PetownerLogic : IPetownerLogic
    {
        IRepository<Petowner> repo;
        public PetownerLogic(IRepository<Petowner> repo) { this.repo = repo; }

        // CRUD 
        public void Create(Petowner item)
        {
            if (item == null) { throw new ArgumentNullException("Not correct"); }

            repo.Create(item);
        }

        public void Delete(int id) { repo.Delete(id); }

        public void Update(Petowner item) { repo.Update(item); }

        public Petowner Read(int id) { return repo.Read(id); }

        public IQueryable<Petowner> ReadAll() { return repo.ReadAll(); }

        //NON-CRUD

        public IEnumerable<Petowner> RichOwner (int money)
        {
            return repo.ReadAll().Where(t => t.Money>= money);
        }
        public IEnumerable<Petowner> PoorhOwner(int money)
        {
            return repo.ReadAll().Where(t => t.Money <= money);
        }


    }

}
