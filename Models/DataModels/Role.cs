using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OCorpus.AuthorizationService.Models.DataModels;

[Table("Roles", Schema = "auth")]
[Index("OrganizationId", Name = "IX_Roles_OrganizationId")]
public partial class Role
{
    [Key]
    public int RoleId { get; set; }

    public int OrganizationId { get; set; }

    [StringLength(128)]
    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    [ForeignKey("OrganizationId")]
    [InverseProperty("Roles")]
    public virtual Organization Organization { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    [InverseProperty("Role")]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
