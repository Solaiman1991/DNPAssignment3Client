using Assingment1.Data.Models;

namespace Assingment1.Data.Services {
public interface IUserService {
    User ValidateUser(string userName, string password);
}
}