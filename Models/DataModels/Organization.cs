using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OCorpus.AuthorizationService.Models.DataModels;

[Table("Organizations", Schema = "auth")]
public partial class Organization
{
    [Key]
    public int OrganizationId { get; set; }

    [StringLength(128)]
    public string Name { get; set; } = null!;

    [StringLength(128)]
    public string Domain { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    [InverseProperty("Organization")]
    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    [InverseProperty("Organization")]
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    [InverseProperty("Organization")]
    public virtual ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();

    [InverseProperty("Organization")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
