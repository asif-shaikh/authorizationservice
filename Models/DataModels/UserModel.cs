using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCorpus.AuthorizationService.Models.DataModels;

[Table("Users", Schema = "auth")]
public partial class UserModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column(TypeName = "uniqueidentifier")]
    public Guid UserId { get; set; }

    [Required]
    [Column(TypeName = "uniqueidentifier")]
    public Guid OrganizationId { get; set; }

    [Required]
    [StringLength(128)]
    public string Username { get; set; } = null!;

    [Required]
    [StringLength(128)]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(128)]
    public string WindowsDomain { get; set; } = null!;

    [Required]
    [StringLength(128)]
    public string? HashedPassword { get; set; } = null;

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    public bool IsDisabled { get; set; } = false;

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(OrganizationId))]
    public virtual OrganizationModel Organization { get; set; } = null!;

    public virtual ICollection<UserGroupModel> UserGroups { get; set; } = [];
    public virtual ICollection<UserRoleModel> UserRoles { get; set; } = [];
    public virtual ICollection<UserClaimModel> UserClaims { get; set; } = [];
}

