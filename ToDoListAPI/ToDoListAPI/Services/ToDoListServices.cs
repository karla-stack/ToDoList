using ToDoListAPI.Data;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ToDoListAPI.Services
{
    public class ToDoListServices : IToDoList
    {

        private readonly ApiContext context;

        public ToDoListServices(ApiContext context)
        {
            this.context = context;
        }

        public List<ToDoList> GetTasks()
        {
            return context.task.ToList();
        }

        public void PostTask(ToDoListDTO t)
        {

            var newtask = new ToDoList
            {
                nombre = t.nombre,
                estado = t.estado,
                descripcion = t.descripcion
            };

            context.task.Add(newtask);
            context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var registro = context.task.Find(id);
            context.task.Remove(registro);
            context.SaveChanges();
        }

        public void UpdateTask(int id, ToDoListDTO t, string estado)
        {
            var task = context.task.Find(id);

            if (task == null)
            {
                // Opcional: Lanza una excepción o maneja el caso cuando la tarea no se encuentra.
                throw new Exception("Task not found");
            }

            // Actualizar los valores de la tarea
            task.nombre = t.nombre;
            task.estado = estado; // Actualiza el estado con el parámetro recibido
            task.descripcion = t.descripcion;

            // Guardar los cambios
            context.SaveChanges();
        }
    }
}
