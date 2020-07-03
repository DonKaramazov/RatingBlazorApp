namespace DAL.Models
{
    public class UserModel
    {
        public int IdUse { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
