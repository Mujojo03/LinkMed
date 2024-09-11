using LinkMed.IServices;
using LinkMed.Models;

namespace LinkMed.Services
{
    public class UserRegistrationSercvice : IUserRegistrationService
    {
        private readonly List<User> _users = new List<User> 
        { 
        
        new User { Username = "John", Email = "john@gmail.com", Password = "123John" },
        new User { Username = "Jane", Email = "jane@gmail.com", Password = "123Jane" },
        new User { Username = "Alex", Email = "jane@gmail.com", Password = "123Alex" }
        };
        public bool UserExists(string username, string email)
        {
            return _users.Any(u => u.Username == username || u.Email == email);
        }

        public bool CreateUser(string username, string email, string password)
        {
            if(!_users.Any(u => u.Username == username || u.Email == email))
            {
                _users.Add(new User { Email = email, Username = username, Password = password });
                return true;
            }
            return false;
        }
    }
}
