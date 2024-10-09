using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCorpus.AuthorizationService.Models.DataModels;

[Table("Permissions", Schema = "auth")]
public partial class PermissionModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "uniqueidentifier")]
    public Guid PermissionId { get; set; }

    [Required]
    [Column(TypeName = "uniqueidentifier")]
    public Guid OrganizationId { get; set; }

    [Required]
    [StringLength(128)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(128)]
    public string Description { get; set; } = null!;

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(OrganizationId))]
    public OrganizationModel Organization { get; set; } = null!;

    public ICollection<RolePermissionModel> RolePermissions { get; set; } = null!;
}

