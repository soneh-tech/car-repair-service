namespace CommunicationSystem.Areas.Auth.Models
{
    public class UserDTO
    {
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; }
        public string? FacebookHandle { get; set; }
        public string? TwitterHandle { get; set; }
        public string? InstagramHandle { get; set; }
        public int? YearOfExperience { get; set; }
        public string? WorkShopAddress { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsEngineer { get; set; }
    }
}
