using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApi.Api.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public static List<Todo> todo = new List<Todo>{
            new Todo{Id = 1, Name = "สั่งข้าว", IsComplete = false}
        };

        [HttpGet]
        public ActionResult<IEnumerable<Todo>> Get()
        {
            return todo.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> Get(int id)
        {
            return todo.FirstOrDefault(it => it.Id == id);
        }

        [HttpPost]
        public void Post(Todo model)
        {
            var id = todo.Max(it => it.Id) + 1;
            model.Id = id;
            todo.Add(model);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var selectedTodo = todo.FirstOrDefault(it => it.Id == id);
            todo.Remove(selectedTodo);
        }

        [HttpPut("{id}")]
        public void Put(int id, Todo model)
        {
            var selectedTodo = todo.FirstOrDefault(it => it.Id == id);
            todo.Remove(selectedTodo);

            model.Id = id;
            todo.Add(model);
        }
    }
}
