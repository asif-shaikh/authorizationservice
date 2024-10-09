using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCorpus.AuthorizationService.Models.DataModels; 

[Table("Roles", Schema = "auth")]
public partial class RoleModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column(TypeName = "uniqueidentifier")]
    public Guid RoleId { get; set; }

    [Required]
    [Column(TypeName = "uniqueidentifier")]
    public Guid OrganizationId { get; set; }

    [Required]
    [StringLength(128)]
    public string Name { get; set; } = null!;

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

    public ICollection<UserRoleModel> UserRoles { get; set; } = null!;
    public ICollection<RolePermissionModel> RolePermissions { get; set; } = null!;
}

