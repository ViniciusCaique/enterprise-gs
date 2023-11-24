namespace BreatheApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(BreatheContext context)
        {
            context.Database.EnsureCreated();

            if (context.Doencas.Any())
            {
                return;
            }
        }
    }
}
