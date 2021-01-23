using FluentValidation;
using ParkingServiceStores.Data.Models;

namespace ParkingServiceStores.Data.FluentValidators
{
    public class PriceValidator : AbstractValidator<Price>
    {
        public PriceValidator()
        {
            RuleFor(price => price.OneDayPrice).Must(p => p > 0).WithMessage("One day price should be more then 0");
            RuleFor(price => price.OneHourPrice).Must(p => p > 0).WithMessage("One hour price should be more then 0");
            RuleFor(price => price.Date).NotEmpty().WithMessage("Date of price required");
        }
    }
}
