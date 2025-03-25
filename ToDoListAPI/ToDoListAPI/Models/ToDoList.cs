using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoListAPI.Models
{
    public class ToDoList
    {
        
        [Key] // Define la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Deja que SQL Server lo maneje
        public int Id { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public string descripcion { get; set; }

        [JsonIgnore]
        public Usuario? Usuario { get; set; }
    }
}
