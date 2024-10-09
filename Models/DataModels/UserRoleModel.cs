using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCorpus.AuthorizationService.Models.DataModels;

[Table("UserRoles", Schema = "auth")]
public partial class UserRoleModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column(TypeName = "uniqueidentifier")]
    public Guid UserRoleId { get; set; }

    [Required]
    [Column(TypeName = "uniqueidentifier")]
    public Guid UserId { get; set; }

    [Required]
    [Column(TypeName = "uniqueidentifier")]
    public Guid RoleId { get; set; }

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(UserId))]
    public UserModel User { get; set; } = null!;

    [ForeignKey(nameof(RoleId))]
    public RoleModel Role { get; set; } = null!;
}

