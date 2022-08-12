using Cours.Models;
namespace Cours.Service;

public class AuthService
{
    public List<IUserViewModel> ListUsers()
    {
        var List = new List<IUserViewModel>{
                new IUserViewModel{Name="Nirina",Email="t@gmail.com",Password="azetrt"},
                new IUserViewModel{Name="Nirina1",Email="t@2gmail.com",Password="azetrt"},
                new IUserViewModel{Name="Nirina2",Email="t2@gmail.com",Password="azetrt"}
        };
        return List;
    }
}