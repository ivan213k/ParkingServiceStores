using ParkingServiceStores.Data.Models;
using System;

namespace ParkingServiceStores.Data
{
    public class DebtAmountCalculator
    {
        public decimal CalculateDebtAmount(TimeSpan period, Price price)
        {
            decimal totalAmount = 0;
            totalAmount += (decimal)period.Days * price.OneDayPrice;
            totalAmount += period.Hours * price.OneHourPrice;
            return totalAmount;
        }
    }
}
