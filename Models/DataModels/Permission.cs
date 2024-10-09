using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OCorpus.AuthorizationService.Models.DataModels;

[Table("Permissions", Schema = "auth")]
[Index("OrganizationId", Name = "IX_Permissions_OrganizationId")]
public partial class Permission
{
    [Key]
    public int PermissionId { get; set; }

    public int OrganizationId { get; set; }

    [StringLength(128)]
    public string Name { get; set; } = null!;

    [StringLength(128)]
    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    [ForeignKey("OrganizationId")]
    [InverseProperty("Permissions")]
    public virtual Organization Organization { get; set; } = null!;

    [InverseProperty("Permission")]
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
