using DDL4F8_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDL4F8_HFT_2022232.Logic.ClassLogicInterfaces
{
    internal interface IPetFoodLogic
    {
        void Create(PetFood item);
        void Delete(int id);
        PetFood Read(int id);
        IQueryable<PetFood> ReadAll();
        void Update(PetFood item);
    }
}
