using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OCorpus.AuthorizationService.Models.DataModels;

[Table("UserClaims", Schema = "auth")]
[Index("UserId", Name = "IX_UserClaims_UserId")]
public partial class UserClaim
{
    [Key]
    public int UserClaimId { get; set; }

    public int UserId { get; set; }

    [StringLength(128)]
    public string ClaimType { get; set; } = null!;

    [StringLength(128)]
    public string ClaimValue { get; set; } = null!;

    public DateTime IssuedAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserClaims")]
    public virtual User User { get; set; } = null!;
}
