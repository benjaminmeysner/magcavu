namespace ManchesterAirportParking.Repository.Domain.Repository.Domain.Models
{
    using ManchesterAirportParking.Repository.Domain.Models;
    using NodaTime;

    public class SpaceAvailability
    {
        public LocalDate From { get; set; }

        public Space Space { get; set; }

        public LocalDate To { get; set; }
    }

    public static class SpaceAvailabilityExtensions
    {
        public static IEnumerable<SpaceAvailability> Merge(this IEnumerable<SpaceAvailability> source)
        {
            IList<SpaceAvailability> spaceAvailabilities = source?.ToList();

            if (spaceAvailabilities is not { Count: > 1 })
            {
                yield break;
            }

            foreach (SpaceAvailability availability in spaceAvailabilities.ToList())
            {
                SpaceAvailability merged = new SpaceAvailability
                                           {
                                               Space = availability.Space,
                                               From = availability.From,
                                               To = availability.From,
                                           };

                SpaceAvailability availableFollowingDay = spaceAvailabilities.FirstOrDefault(x => merged.From.PlusDays(1) == x.From);

                while (availableFollowingDay != null)
                {
                    merged.To = availableFollowingDay.From;

                    spaceAvailabilities.Remove(availableFollowingDay);

                    availableFollowingDay = spaceAvailabilities.FirstOrDefault(x => availableFollowingDay.From.PlusDays(1) == x.From);
                }

                yield return merged;
            }
        }
    }
}
