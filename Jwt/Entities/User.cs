namespace JWT.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string UserName { get; set; }
        
            
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }

        public List<Role> Roles { get; set; }
    }
}
