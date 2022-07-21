using Colossus.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Colossus.Infrastructure.Data.Seed;
public static class DatabaseInitializer
{
    private static readonly string _seedBasePath = @"Infrastructure" + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "Seed" + Path.DirectorySeparatorChar;
    public static async Task InitializeAsync(IDbContext dbContext)
    {
        if (dbContext is DbContext db)
        {
            db.Database.Migrate();
            if (!await db.Set<SparePart>().AnyAsync())
            {
                var spareParts = JsonSerializer.Deserialize<List<sparePart>>(File.ReadAllText(_seedBasePath + "spare-parts-mock.json"))
                    .Select(x => new SparePart()
                    {
                        Description = x.description,
                        Id = x.id,
                    });

                dbContext.Set<SparePart>().AddRange(spareParts);

                await dbContext.SaveChangesAsync();
            }
        }
        else
        {
            throw new ArgumentNullException(nameof(db));
        }
    }
    public readonly record struct sparePart(string description, long id, string externalId);
}
