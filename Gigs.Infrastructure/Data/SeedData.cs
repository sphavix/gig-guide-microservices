using Gigs.Domain.Entities;

namespace Gigs.Infrastructure.Data
{
    public class SeedData
    {
        public static async Task Seed(ApplicationDbContext context)
        {
            if (context.Gigs.Any()) return;
            
            var activities = new List<Gig>
            {
                new Gig
                {
                    Title = "Past Gig 1",
                    Date = DateTime.UtcNow.AddMonths(-2),
                    Description = "Gig 2 months ago",
                    Category = "drinks",
                    City = "London",
                    Venue = "Pub",
                },
                new Gig
                {
                    Title = "Past Gig 2",
                    Date = DateTime.UtcNow.AddMonths(-1),
                    Description = "Gig 1 month ago",
                    Category = "culture",
                    City = "Paris",
                    Venue = "Louvre",
                },
                new Gig
                {
                    Title = "Future Gig 1",
                    Date = DateTime.UtcNow.AddMonths(1),
                    Description = "Gig 1 month in future",
                    Category = "culture",
                    City = "London",
                    Venue = "Natural History Museum",
                },
                new Gig
                {
                    Title = "Future Gig 2",
                    Date = DateTime.UtcNow.AddMonths(2),
                    Description = "Gig 2 months in future",
                    Category = "music",
                    City = "London",
                    Venue = "O2 Arena",
                },
                new Gig
                {
                    Title = "Future Gig 3",
                    Date = DateTime.UtcNow.AddMonths(3),
                    Description = "Gig 3 months in future",
                    Category = "drinks",
                    City = "London",
                    Venue = "Another pub",
                },
                new Gig
                {
                    Title = "Future Gig 4",
                    Date = DateTime.UtcNow.AddMonths(4),
                    Description = "Gig 4 months in future",
                    Category = "drinks",
                    City = "London",
                    Venue = "Yet another pub",
                },
                new Gig
                {
                    Title = "Future Gig 5",
                    Date = DateTime.UtcNow.AddMonths(5),
                    Description = "Gig 5 months in future",
                    Category = "drinks",
                    City = "London",
                    Venue = "Just another pub",
                },
                new Gig
                {
                    Title = "Future Gig 6",
                    Date = DateTime.UtcNow.AddMonths(6),
                    Description = "Gig 6 months in future",
                    Category = "music",
                    City = "London",
                    Venue = "Roundhouse Camden",
                },
                new Gig
                {
                    Title = "Future Gig 7",
                    Date = DateTime.UtcNow.AddMonths(7),
                    Description = "Gig 2 months ago",
                    Category = "travel",
                    City = "London",
                    Venue = "Somewhere on the Thames",
                },
                new Gig
                {
                    Title = "Future Gig 8",
                    Date = DateTime.UtcNow.AddMonths(8),
                    Description = "Gig 8 months in future",
                    Category = "film",
                    City = "London",
                    Venue = "Cinema",
                }
            };

            await context.Gigs.AddRangeAsync(activities);
            await context.SaveChangesAsync();
        }

    }
}