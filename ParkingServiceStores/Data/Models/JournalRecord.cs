using System;
using System.ComponentModel.DataAnnotations;

namespace ParkingServiceStores.Data.Models
{
    public class JournalRecord : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime EntryTime { get; set; }

        public DateTime LeavingTime { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
