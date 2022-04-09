namespace ApiAuth.Models
{
    public class User
    {
        #region Properties
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        #endregion
    }
}
