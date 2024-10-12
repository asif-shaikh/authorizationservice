public class OrganizationDto
{
    public int OrganizationId { get; set; }

    public string Name { get; set; } = null!;

    public string Domain { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}