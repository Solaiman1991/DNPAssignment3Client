using System.Threading.Tasks;
using Assingment1.Data.Models;

namespace Assingment1.Data.Services {
public interface IUserService
{
    public Task<User> AddUser(User user);
    public Task<User> ValidateUser(string userName, string password);
}
}