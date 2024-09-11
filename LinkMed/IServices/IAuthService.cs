using LinkMed.Models;

namespace LinkMed.IServices
{
    public interface IAuthService
    {
        bool ValidateUser(string username, string password, string email);
        //User AuthenticateUser(string username, string password);
        List<User> GetUsers();
        bool UpdateUserPassword(string username, string newPassword);
        bool DeleteUser(string username);
    }
}
