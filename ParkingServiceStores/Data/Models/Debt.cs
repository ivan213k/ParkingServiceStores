using System.ComponentModel.DataAnnotations;

namespace ParkingServiceStores.Data.Models
{
    public class Debt
    {
        [Key]
        public int Id { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
        public decimal DebtAmount { get; set; }
        public bool IsPayed { get; set; }
    }
}
