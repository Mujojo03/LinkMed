namespace LinkMed.IServices
{
    public interface IUserRegistrationService
    {
        bool UserExists(string username, string email);
        bool CreateUser(string username, string email, string password);
        bool CreateDoctor(string username, string email, string password, string specialty, string department);
        bool IsUserLoggedIn();
        string GetLoggedInUsername();
        //bool Logout();
    }
}
