using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCorpus.AuthorizationService.Models.DataModels;

[Table("RolePermissions", Schema = "auth")]
public partial class RolePermissionModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column(TypeName = "uniqueidentifier")]
    public Guid RolePermissionId { get; set; }

    [Required]
    [Column(TypeName = "uniqueidentifier")]
    public Guid RoleId { get; set; }

    [Required]
    [Column(TypeName = "uniqueidentifier")]
    public Guid PermissionId { get; set; }

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(RoleId))]
    public RoleModel Role { get; set; } = null!;

    [ForeignKey(nameof(PermissionId))]
    public PermissionModel Permission { get; set; } = null!;
}

