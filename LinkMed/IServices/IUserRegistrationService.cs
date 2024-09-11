namespace LinkMed.IServices
{
    public interface IUserRegistrationService
    {
        bool UserExists(string username, string email);
        bool CreateUser(string username, string email, string password);
    }
}
