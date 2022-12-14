namespace ManchesterAirportParking.Repository.Domain.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using ManchesterAirportParking.Common.Extensions;
    using ManchesterAirportParking.Repository.Domain.Repository.Domain.Models;
    using NodaTime;
    using NodaTime.Extensions;

    public class ParkingArea : EntityBase
    {
        [NotMapped]
        public IReadOnlyList<Space> CurrentFreeSpaces
        {
            get
            {
                LocalDate now = SystemClock.Instance.InTzdbSystemDefaultZone()
                                           .GetCurrentLocalDateTime()
                                           .Date;

                return this.Spaces?.Where(x => x.Reservations?.Any(y => ((y.From >= now) && (y.To >= now)) || ((y.From <= now) && (y.To <= now))) ?? false)
                           .ToList();
            }
        }

        public string Name { get; set; }

        public ICollection<Space> Spaces { get; set; }

        /// <summary>
        ///     Returns <see cref="Spaces" /> which have some/partial availability between the date provided.
        ///     Meaning the reservation date for the space does not fully cover the requested availibility date.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public IEnumerable<SpaceAvailability> GetAvailabilityBetween(LocalDate from, LocalDate to)
        {
            IList<SpaceAvailability> spaceAvailabilities = new List<SpaceAvailability>();

            foreach (LocalDate date in from.IterateTo(to))
            {
                foreach (Space space in this.Spaces.Where(space => !space.Reservations.Any(y => (y.From <= date) && (y.To >= date))))
                {
                    spaceAvailabilities.Add(new SpaceAvailability
                                            {
                                                Space = space,
                                                From = date
                                            });
                }
            }

            IEnumerable<IGrouping<int, SpaceAvailability>> groupedSpaces = spaceAvailabilities.GroupBy(x => x.Space.Id);

            // Check for contiguous regions of dates and merge them into one availability.
            foreach (IGrouping<int, SpaceAvailability> grouping in groupedSpaces)
            {
                // These may still only contain partial availability between the dates
                IEnumerable<SpaceAvailability> merged = grouping.Merge();

                // Find the availability which fully cover the requested range
                foreach (SpaceAvailability merge in merged.Where(merge => (merge.From <= from) && (merge.To >= to)))
                {
                    yield return merge;
                }
            }
        }
    }
}
