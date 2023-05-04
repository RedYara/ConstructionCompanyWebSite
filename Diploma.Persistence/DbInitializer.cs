namespace Diploma.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(DiplomaDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }
    }
}
