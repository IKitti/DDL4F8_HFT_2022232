using DDL4F8_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDL4F8_HFT_2022232.Logic.ClassLogicInterfaces
{
    internal interface IPetLogic
    {
        void Create(Pet item);
        void Delete(int id);
        Pet Read(int id);
        IQueryable<Pet> ReadAll();
        void Update(Pet item);
    }
}
