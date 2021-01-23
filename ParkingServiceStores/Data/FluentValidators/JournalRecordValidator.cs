using FluentValidation;
using ParkingServiceStores.Data.Models;

namespace ParkingServiceStores.Data.FluentValidators
{
    public class JournalRecordValidator : AbstractValidator<JournalRecord>
    {
        public JournalRecordValidator()
        {
            RuleFor(record => record.EntryTime).LessThan(r => r.LeavingTime).WithMessage("Entry time can not be more than Leaving time!");
            RuleFor(record => record.LeavingTime).GreaterThan(r => r.EntryTime).WithMessage("Leaving time can not be less than Entry time!");
        }
    }
}
