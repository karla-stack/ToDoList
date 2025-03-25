using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoListAPI.Models
{
    public class Usuario
    {

        [Key] // Define la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Deja que SQL Server lo maneje
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }


        [JsonIgnore]
        public List<ToDoList> ToDoLists { get; set; } 
    }

}
