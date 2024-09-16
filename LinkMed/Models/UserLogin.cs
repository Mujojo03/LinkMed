namespace LinkMed.Models
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
    //public bool Logout()
    //{
    //    if (_currentLoggedInUser != null)
    //    {
    //        _currentLoggedInUser = null; // Clear the logged-in user
    //        return true;
    //    }
    //    return false;
    //}
}
