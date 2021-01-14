using System.ComponentModel.DataAnnotations;

namespace ParkingServiceStores.Data.Models
{
    public class CarOwner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
