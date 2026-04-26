using AnimaxMissionControlPortal.Data;
using AnimaxMissionControlPortal.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace AnimaxMissionControlPortal.Tests;

public static class TestDb
{
    public static async Task<(AnimaxDbContext Context, SqliteConnection Connection)> CreateSeededAsync()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();
        var context = CreateContext(connection);
        await context.Database.EnsureCreatedAsync();
        await new SeedService(context).EnsureSeededAsync();
        return (context, connection);
    }

    public static AnimaxDbContext CreateContext(SqliteConnection connection)
    {
        var options = new DbContextOptionsBuilder<AnimaxDbContext>()
            .UseSqlite(connection)
            .Options;

        return new AnimaxDbContext(options);
    }
}
