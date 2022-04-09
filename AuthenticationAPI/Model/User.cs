namespace AuthenticationAPI.Models
{
    public class User
    {
        #region Properties
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User()
        {
        }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        #endregion
    }
}
