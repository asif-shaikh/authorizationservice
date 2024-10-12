using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OCorpus.AuthorizationService.Models.DataModels;

[Table("Users", Schema = "auth")]
[Index("OrganizationId", Name = "IX_Users_OrganizationId")]
public partial class User
{
    [Key]
    public int UserId { get; set; }

    public int OrganizationId { get; set; }

    [StringLength(128)]
    public string Username { get; set; } = null!;

    [StringLength(128)]
    public string Email { get; set; } = null!;

    [StringLength(128)]
    public string WindowsDomain { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDisabled { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    [ForeignKey("OrganizationId")]
    [InverseProperty("Users")]
    public virtual Organization Organization { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<UserClaim> UserClaims { get; set; } = new List<UserClaim>();

    [InverseProperty("User")]
    public virtual ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();

    [InverseProperty("User")]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
