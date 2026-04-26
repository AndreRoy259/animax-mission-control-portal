using AnimaxMissionControlPortal.Data;
using AnimaxMissionControlPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimaxMissionControlPortal.Services;

public sealed class DivisionService(AnimaxDbContext dbContext)
{
    public Task<List<Division>> GetAllAsync(CancellationToken cancellationToken = default) =>
        dbContext.Divisions
            .AsNoTracking()
            .Include(x => x.Missions)
            .OrderBy(x => x.Code)
            .ToListAsync(cancellationToken);

    public Task<Division?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        dbContext.Divisions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
}
