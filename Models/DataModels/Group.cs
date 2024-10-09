using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OCorpus.AuthorizationService.Models.DataModels;

[Table("Groups", Schema = "auth")]
public partial class Group
{
    [Key]
    public int GroupId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(200)]
    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    [InverseProperty("Group")]
    public virtual ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
}
