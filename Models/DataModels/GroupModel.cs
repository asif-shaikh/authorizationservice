using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCorpus.AuthorizationService.Models.DataModels;

[Table("Groups", Schema = "auth")]
public partial class GroupModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column(TypeName = "uniqueidentifier")]
    public Guid GroupId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(200)")]
    public string Description { get; set; } = null!;

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

