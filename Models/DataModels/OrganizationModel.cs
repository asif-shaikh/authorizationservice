using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCorpus.AuthorizationService.Models.DataModels;

[Table("Organizations", Schema = "auth")]
public partial class OrganizationModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "uniqueidentifier")]
    public Guid OrganizationId { get; set; }

    [Required]
    [StringLength(128)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(128)]
    public string Domain { get; set; } = null!;

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [InverseProperty(nameof(UserModel.Organization))]
    public virtual ICollection<UserModel> Users { get; set; } = [];

    [InverseProperty(nameof(RoleModel.Organization))]
    public virtual ICollection<RoleModel> Roles { get; set; } = [];
}

