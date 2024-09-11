using LinkMed.IServices;
using LinkMed.Models;

namespace LinkMed.Services
{
    public class AuthService : IAuthService
    {
        private readonly List<User> _users = new List<User>
        {
            new User{Username = "Jane", Password = "123Jane", Email = "jane@gmail.com"},
            new User{Username = "John", Password = "123John", Email = "john@gmail.com"},
            new User{Username = "Alex", Password = "123Alex", Email = "alex@gmail.com"}
        };
        private int _nextId = 1;
        private int Id;

        //for POST method
        public bool ValidateUser(string username, string password, string email)
        {
            return _users.Any(u => u.Username == username && u.Password == password && u.Email == email);
        }

        //for GET MEETHOD
        public List<User> GetUsers()
        {
            foreach (var user in _users)
            {
                Id = _nextId++;
            }
            //User.Id = _nextId++;
            return _users;
        }

        //for PUT method
        public bool UpdateUserPassword(string username, string newPassword)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                user.Password = newPassword;
                return true;
            }
            return false;
        }

        //for DELETE method
        public bool DeleteUser(string username)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                _users.Remove(user);
                return true;
            }
            return false;
        }

    }
}
