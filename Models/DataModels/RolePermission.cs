using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OCorpus.AuthorizationService.Models.DataModels;

[Table("RolePermissions", Schema = "auth")]
[Index("PermissionId", Name = "IX_RolePermissions_PermissionId")]
[Index("RoleId", Name = "IX_RolePermissions_RoleId")]
public partial class RolePermission
{
    [Key]
    public int RolePermissionId { get; set; }

    public int RoleId { get; set; }

    public int PermissionId { get; set; }

    public DateTime AssignedAt { get; set; }

    [ForeignKey("PermissionId")]
    [InverseProperty("RolePermissions")]
    public virtual Permission Permission { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("RolePermissions")]
    public virtual Role Role { get; set; } = null!;
}
