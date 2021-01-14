using System;
using System.ComponentModel.DataAnnotations;

namespace ParkingServiceStores.Data.Models
{
    public class Price
    {
        public Price()
        {

        }
        public Price(decimal oneHourPrice, decimal oneDayPrice, DateTime date)
        {
            OneHourPrice = oneHourPrice;
            OneDayPrice = oneDayPrice;
            Date = date;
        }

        public Price(decimal oneHourPrice, decimal oneDayPrice)
        {
            OneHourPrice = oneHourPrice;
            OneDayPrice = oneDayPrice;
            Date = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal OneHourPrice { get; set; }
        public decimal OneDayPrice { get; set; }
    }
}
