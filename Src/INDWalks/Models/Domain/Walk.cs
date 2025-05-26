namespace INDWalks.Models.Domain;

public class Walk
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Length { get; set; } 
    public int RegionId { get; set; }
    public int WalkDifficultyId { get; set; }
    public Region?  Region { get; set; }
    public WalkDifficulty? WalkDifficulty { get; set; }
}
