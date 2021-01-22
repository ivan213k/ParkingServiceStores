using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParkingServiceStores.Data.Models
{
    public class Car : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PlateNumber { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public CarOwner Owner { get; set; }

        public ICollection<JournalRecord> JournalRecords { get; set; }

        public ICollection<Debt> Debts { get; set; }

        public override string ToString()
        {
            return $"{Model} : {PlateNumber}";
        }
    }
}
