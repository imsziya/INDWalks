using INDWalks.Models.DTO;

namespace INDWalks.Repositories;

public interface IRegionRepository
{
    Task<IEnumerable<Region>> GetAllAsync();
    Task<Region?> GetAsync(int id);
    Task AddAsync(List<Region> regions);
    Task<int> DeleteAsync(int id);
    Task<int> UpdateAsync(Region region);
}
