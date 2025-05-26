using INDWalks.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace INDWalks.DbContexts;

public class IndWalksDbContext(DbContextOptions<IndWalksDbContext> options) : DbContext(options)
{
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }
    public DbSet<WalkDifficulty> WalkDifficulties { get; set; }
}
