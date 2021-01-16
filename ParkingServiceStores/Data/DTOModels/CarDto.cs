using System.ComponentModel.DataAnnotations;

namespace ParkingServiceStores.Data.DTOModels
{
    public class CarDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Model is too short")]
        [MaxLength(25, ErrorMessage = "Model is too long")]
        public string Model { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Plate number is too short")]
        public string PlateNumber { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name is too short")]
        public string OwnerName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9\-\+]{9,15}$", ErrorMessage = "Phone format is not correct")]
        public string OwnerPhoneNumber { get; set; }

        public int OwnerId { get; set; }
    }
}
