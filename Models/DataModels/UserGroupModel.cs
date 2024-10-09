using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCorpus.AuthorizationService.Models.DataModels;

[Table("UserGroups", Schema = "auth")]
public partial class UserGroupModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column(TypeName = "uniqueidentifier")]
    public Guid UserGroupId { get; set; }

    [Required]
    [Column(TypeName = "uniqueidentifier")]
    public Guid OrganizationId { get; set; }

    [Required]
    [Column(TypeName = "uniqueidentifier")]
    public Guid UserId { get; set; }

    [Required]
    [Column(TypeName = "uniqueidentifier")]
    public Guid GroupId { get; set; }

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

    [ForeignKey(nameof(UserId))]
    public UserModel User { get; set; } = null!;

    [ForeignKey(nameof(GroupId))]
    public GroupModel Group { get; set; } = null!;
}