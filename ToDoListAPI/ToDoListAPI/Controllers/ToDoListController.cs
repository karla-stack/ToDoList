using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Models;
using ToDoListAPI.Data;
using System.Data;
using System.Data.SqlClient;
using ToDoListAPI.Interfaces;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {

        private readonly IToDoList service;

        public ToDoListController(IToDoList service)
        {
            this.service = service;
        }

        [HttpGet("get-task")]
        public List<ToDoList> GetTasks()
        {
            return service.GetTasks();
        }

        [HttpPost("post-task")]
        public void PostTask(ToDoListDTO t)
        {
            service.PostTask(t);
        }

        [HttpPut("put-task")]
        public void UpdateTask(int ID, ToDoListDTO t, string estado)
        {
            service.UpdateTask(ID, t, estado);
        }

        [HttpDelete("delete-task")]
        public void DeletePersona(int id)
        {
             service.DeleteTask(id);
        }
    }
}
