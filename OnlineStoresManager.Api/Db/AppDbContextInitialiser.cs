using Microsoft.EntityFrameworkCore;
using OnlineStoresManager.Goods.Books;
using OnlineStoresManager.Goods.Clothes;

namespace OnlineStoresManager.API.Db
{
    public static class InitialiserExtensions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var initialiser = scope.ServiceProvider.GetRequiredService<AppDbContextInitialiser>();

            await initialiser.InitialiseAsync();

            await initialiser.SeedAsync();
        }
    }

    public class AppDbContextInitialiser
    {
        private readonly ILogger<AppDbContextInitialiser> _logger;
        private readonly AppDbContext _context;

        public AppDbContextInitialiser(ILogger<AppDbContextInitialiser> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public async Task InitialiseAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            // Default data
            // Seed, if necessary
            if (!_context.Goods.Any())
            {
                _context.Goods.Add(new Shirt
                {
                    Id = Guid.NewGuid(),
                    Name = "shirt test"
                });

                _context.Goods.Add(new ShortStory
                {
                    Id = Guid.NewGuid(),
                    Name = "book test"
                });

                await _context.SaveChangesAsync();
            }
        }
    }

}
