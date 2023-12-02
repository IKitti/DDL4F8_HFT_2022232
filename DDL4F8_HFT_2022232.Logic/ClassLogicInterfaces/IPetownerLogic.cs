using DDL4F8_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDL4F8_HFT_2022232.Logic.ClassLogicInterfaces
{
    internal interface IPetownerLogic
    {
        void Create(Petowner item);
        void Delete(int id);
        Petowner Read(int id);
        IQueryable<Petowner> ReadAll();
        void Update(Petowner item);
    }
}
