using ToDoListAPI.Models;

namespace ToDoListAPI.Interfaces
{
    public interface IToDoList
    {
        List<ToDoList> GetTasks();

        void PostTask(ToDoListDTO t);

        void UpdateTask(int id, ToDoListDTO t, string estado);

        void DeleteTask(int id);
    }
}
