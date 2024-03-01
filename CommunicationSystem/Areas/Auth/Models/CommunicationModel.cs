namespace CommunicationSystem.Areas.Auth.Models
{
    public class AppUser : IdentityUser
    {

    }
    public class Owner
    {
        [Key]
        public int OwnerID { get; set; }
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string Id { get; set; }
        public AppUser? Appuser { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public List<Message>? Messages { get; set; }
        public List<ServiceHistory>? ServiceHistories { get; set; }
    }
    public class Engineer
    {
        [Key]
        public int EngineerID { get; set; }
        public string FullName { get; set; }
        public string? ImageURL { get; set; }
        public string? FacebookHandle { get; set; }
        public string? TwitterHandle { get; set; }
        public string? InstagramHandle { get; set; }
        public int? YearOfExperience { get; set; }
        public string? WorkShopAddress { get; set; }
        public int? CarID { get; set; }
        public int? ServiceTypeID { get; set; }
        public string Id { get; set; }
        public AppUser? Appuser { get; set; }
        public ServiceType? Speciality { get; set; }
        public Car? Car { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public List<Message>? Messages { get; set; }
        public List<ServiceHistory>? ServiceHistories { get; set; }
    }
    public class Car
    {
        public int CarID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public List<Engineer>? Specialists { get; set; }

    }
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public int CarID { get; set; }
        public virtual Car? Car { get; set; }
        public int EngineerID { get; set; }
        public virtual Engineer? Engineer { get; set; }
        public string OwnerID { get; set; }
        public virtual Owner? Owner { get; set; }
    }
    public class Message
    {
        public int MessageID { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public int EngineerID { get; set; }
        public virtual Engineer? Engineer { get; set; }
        public int OwnerID { get; set; }
        public virtual Owner? Owner { get; set; }
    }
    public class ServiceHistory
    {
        public int ServiceHistoryID { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public int ServiceTypeID { get; set; }
        public ServiceType? TypeOfService { get; set; }
        public int CarID { get; set; }
        public virtual Car? Car { get; set; }
        public int EngineerID { get; set; }
        public virtual Engineer? Engineer { get; set; }
        public int OwnerID { get; set; }
        public virtual Owner? Owner { get; set; }
    }
    public class ServiceType
    {
        public int ServiceTypeID { get; set; }
        public string TypeOfService { get; set; }
        public List<Engineer>? Engineers { get; set; }
    }
}
