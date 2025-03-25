using ToDoListAPI.Models;

namespace ToDoListAPI.Interfaces
{
    public interface IUsuario
    {
        string PostLogIn(LoginDTO user);
        string PostSignUp(SignUpDTO user);
    }
}
