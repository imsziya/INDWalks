using AutoMapper;
using INDWalks.DbContexts;
using INDWalks.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace INDWalks.Repositories;

public class RegionRepository(IndWalksDbContext walksDbContext, IMapper mapper) : IRegionRepository
{
    public async Task AddAsync(List<Region> regions)
    {
        var dbRegions = mapper.Map<List<Models.Domain.Region>>(regions);
        await walksDbContext.Regions.AddRangeAsync(dbRegions);
        await walksDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var region = walksDbContext.Regions.FirstOrDefault(r => r.Id == id);
        if (region != null)
        {
            walksDbContext.Regions.Remove(region);
            return await walksDbContext.SaveChangesAsync();
        }
        return 0;
    }

    public async Task<IEnumerable<Region>> GetAllAsync()
    {
        var dbRegions = await walksDbContext.Regions.ToListAsync();
        return mapper.Map<IEnumerable<Region>>(dbRegions);
    }
    public async Task<Region?> GetAsync(int id)
    {
        var region = await walksDbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
        if (region is null) return null;
        return mapper.Map<Region>(region);
    }

    public async Task<int> UpdateAsync(Region region)
    {
        var existingRegion = walksDbContext.Regions.FirstOrDefault(r => r.Id == region.Id);
        if (existingRegion != null)
        {
            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;
            walksDbContext.Regions.Update(existingRegion);
            return await walksDbContext.SaveChangesAsync();
        }
        return 0;
    }
}
