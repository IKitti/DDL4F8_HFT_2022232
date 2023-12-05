using DDL4F8_HFT_2022232.Logic.ClassLogicInterfaces;
using DDL4F8_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DDL4F8_HFT_2022232.Endpoint.Contollers
{
    [Route("api/petowner")]
    public class PetOwnerController : Controller
    {
        private readonly IPetownerLogic logic;

        public PetOwnerController(IPetownerLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Petowner> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Petowner Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Petowner item)
        {
            logic.Create(item);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Petowner item)
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
