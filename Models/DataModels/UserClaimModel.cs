using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCorpus.AuthorizationService.Models.DataModels;

[Table("UserClaims", Schema = "auth")]
public partial class UserClaimModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column(TypeName = "uniqueidentifier")]
    public Guid UserClaimId { get; set; }

    [Required]
    [Column(TypeName = "uniqueidentifier")]
    public Guid UserId { get; set; }

    [Required]
    [StringLength(128)]
    public string ClaimType { get; set; } = null!;

    [Required]
    [StringLength(128)]
    public string ClaimValue { get; set; } = null!;

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime IssuedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(UserId))]
    public UserModel User { get; set; } = null!;
}


