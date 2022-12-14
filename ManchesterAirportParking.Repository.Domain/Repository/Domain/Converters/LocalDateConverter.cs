namespace ManchesterAirportParking.Repository.Domain.Converters;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

public class LocalDateConverter : ValueConverter<LocalDate, DateTime>
{
    public LocalDateConverter()
        : base(net => net.ToDateTimeUnspecified(), db => LocalDate.FromDateTime(db))
    {
    }
}
