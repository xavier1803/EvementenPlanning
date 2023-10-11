using EvementenPlanning.Models;
using EvementenPlanning.Models.Classes;
using Microsoft.AspNetCore.Mvc;
using ToDoListModel.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventPlanningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ToDoTask Get(int id)
        {
            return ToDoTask.Read(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            ToDoTask t = new ToDoTask(value);
            t.Create();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id)
        {
            ToDoTask t = ToDoTask.Read(id);
            t.FinishTask();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ToDoTask a = ToDoTask.Read(id);
            a.Delete();
        }
    }
}
