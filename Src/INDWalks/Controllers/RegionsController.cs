using INDWalks.Models.DTO;
using INDWalks.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace INDWalks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegionsController(IRegionRepository regionRepository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRegions(List<Region> regions)
    {
        await regionRepository.AddAsync(regions);
        return Accepted();
    }
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Region>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRegions()
    {
        var regions = await regionRepository.GetAllAsync();
        if (regions.Any()) return Ok(regions);
        return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Region), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRegions(int id)
    {
        var region = await regionRepository.GetAsync(id);
        if (region is not null) return Ok(region);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRegion(Region region)
    {
        var updated = await regionRepository.UpdateAsync(region);
        if (updated is 1) return Accepted();
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRegions(int id)
    {
        var region = await regionRepository.DeleteAsync(id);
        if (region is 1) return Accepted();
        return BadRequest();
    }
}
