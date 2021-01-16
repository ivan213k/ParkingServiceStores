using ParkingServiceStores.Data;
using ParkingServiceStores.Data.Models;
using System;
using Xunit;


namespace ParkingServiceStores.Tests
{
    public class DebtAmountCalculatorTest
    {
        DebtAmountCalculator calculator = new DebtAmountCalculator();
        Price price = new Price(oneHourPrice: 10, oneDayPrice: 200);
        [Fact]
        public void DebtAmountForTwoHoursTest()
        {
            TimeSpan timeSpan = new TimeSpan(2, 0, 0);
            decimal expected = 20;

            decimal result = calculator.CalculateDebtAmount(timeSpan, price);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DebtAmountFor24HoursTest()
        {
            TimeSpan timeSpan = new TimeSpan(24, 0, 0);
            decimal expected = 200;

            decimal result = calculator.CalculateDebtAmount(timeSpan, price);

            Assert.Equal(expected, result);
        }
        [Fact]
        public void DebtAmountFor56HoursTest()
        {
            TimeSpan timeSpan = new TimeSpan(56, 0, 0);
            decimal expected = 400+80;

            decimal result = calculator.CalculateDebtAmount(timeSpan, price);

            Assert.Equal(expected, result);
        }
    }
}
