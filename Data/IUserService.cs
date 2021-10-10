namespace LoginExample.Data.Models {
public interface IUserService {
    User ValidateUser(string userName, string password);
}
}