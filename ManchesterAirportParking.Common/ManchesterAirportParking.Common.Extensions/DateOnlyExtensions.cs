namespace ManchesterAirportParking.Common.Extensions
{
    using NodaTime;

    public static class DateOnlyExtensions
    {
        public static IEnumerable<LocalDate> IterateTo(this LocalDate from, LocalDate to)
        {
            for (LocalDate day = from; day <= to; day = day.PlusDays(1))
            {
                yield return day;
            }
        }
    }
}
