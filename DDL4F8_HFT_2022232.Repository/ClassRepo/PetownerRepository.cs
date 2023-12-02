using DDL4F8_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDL4F8_HFT_2022232.Repository.ClassRepo
{
    public class PetownerRepository : Repository<Petowner>, IRepository<Petowner>
    {
        public PetownerRepository(PetsDbContext ctx) : base(ctx)
        {
        }

        public override Petowner Read(int id)
        {
            return ctx.PetOwners.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Petowner item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }

            ctx.SaveChanges();
        }
    }
}
