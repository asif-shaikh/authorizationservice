using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OCorpus.AuthorizationService.Models.DataModels;

[Table("UserGroups", Schema = "auth")]
[Index("GroupId", Name = "IX_UserGroups_GroupId")]
[Index("OrganizationId", Name = "IX_UserGroups_OrganizationId")]
[Index("UserId", Name = "IX_UserGroups_UserId")]
public partial class UserGroup
{
    [Key]
    public int UserGroupId { get; set; }

    public int OrganizationId { get; set; }

    public int UserId { get; set; }

    public int GroupId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    [ForeignKey("GroupId")]
    [InverseProperty("UserGroups")]
    public virtual Group Group { get; set; } = null!;

    [ForeignKey("OrganizationId")]
    [InverseProperty("UserGroups")]
    public virtual Organization Organization { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserGroups")]
    public virtual User User { get; set; } = null!;
}
