using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
    public class UsuarioServices : IUsuario
    {

        private readonly ApiContext context;

        public UsuarioServices(ApiContext context)
        {
            this.context = context;
        }
        public string PostLogIn(LoginDTO user)
        {
            var usuario = context.users.FirstOrDefault(u => u.Email == user.Email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(user.Contraseña, usuario.Contraseña))
            {
                return "Credenciales incorrectas";
            }

            return "Inicio de sesión exitoso";
        }

        public string PostSignUp(SignUpDTO user)
        {
            if(context.users.Any(u => u.Email == user.Email))
            {
                return "El email ya está registrado";
            }

            var nuevoUsuario = new Usuario
            {
                Nombre = user.Nombre,
                Email = user.Email,
                Contraseña = BCrypt.Net.BCrypt.HashPassword(user.Contraseña)
            };

            context.users.Add(nuevoUsuario);
            context.SaveChanges();

            return "Usuario registrado exitosamente";

        }
    }
}
