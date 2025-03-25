using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;

namespace ToDoListAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> db) : base(db) { }
        public DbSet <ToDoList> task { get; set; }
        public DbSet<Usuario> users { get; set; }


    }
}
