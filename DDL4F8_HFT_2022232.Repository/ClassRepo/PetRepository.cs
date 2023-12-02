using DDL4F8_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDL4F8_HFT_2022232.Repository.ClassRepo
{
    public class PetRepository : Repository<Pet>, IRepository<Pet>
    {
        public PetRepository(PetsDbContext ctx) : base(ctx)
        {
        }

        public override Pet Read(int id)
        {
            return ctx.Pets.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Pet item)
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
