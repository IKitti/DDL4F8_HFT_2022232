using DDL4F8_HFT_2022232.Logic.ClassLogicInterfaces;
using DDL4F8_HFT_2022232.Models;
using DDL4F8_HFT_2022232.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DDL4F8_HFT_2022232.Endpoint.Contollers
{
    [Route("api/food")]
    public class PetFoodController : Controller
    {
        private readonly IPetFoodLogic logic;

        public PetFoodController(IPetFoodLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<PetFood> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public PetFood Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] PetFood item)
        {
            logic.Create(item);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] PetFood item)
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
