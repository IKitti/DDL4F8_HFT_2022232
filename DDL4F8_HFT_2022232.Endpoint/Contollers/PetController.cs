using DDL4F8_HFT_2022232.Logic.ClassLogic;
using DDL4F8_HFT_2022232.Logic.ClassLogicInterfaces;
using DDL4F8_HFT_2022232.Models;
using DDL4F8_HFT_2022232.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace DDL4F8_HFT_2022232.Endpoint.Contollers
{
    [Route("api/pet")]
    public class PetController : Controller
    {
        private readonly IPetLogic logic;
        public PetController(IPetLogic _logic)
        {
            this.logic = _logic;
        }

        [HttpGet]
        public IEnumerable<Pet> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Pet Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Pet item)
        {
            logic.Create(item);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Pet item)
        {
            logic.Update(item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
