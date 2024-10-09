using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OCorpus.AuthorizationService.Models.DataModels;

namespace OCorpus.AuthorizationService.Contexts;

public partial class OcorpusDbContext : DbContext
{
    public OcorpusDbContext(DbContextOptions<OcorpusDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserClaim> UserClaims { get; set; }

    public virtual DbSet<UserGroup> UserGroups { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK_GroupModel_GroupId");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.OrganizationId).HasName("PK_OrganizationModel_OrganizationId");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK_PermissionModel_PermissionId");

            entity.HasOne(d => d.Organization).WithMany(p => p.Permissions).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK_RoleModel_RoleId");

            entity.HasOne(d => d.Organization).WithMany(p => p.Roles).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.RolePermissionId).HasName("PK_RolePermissionModel_RolePermissionId");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_UserModel_UserId");

            entity.HasOne(d => d.Organization).WithMany(p => p.Users).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<UserClaim>(entity =>
        {
            entity.HasKey(e => e.UserClaimId).HasName("PK_UserClaimModel_UserClaimId");

            entity.HasOne(d => d.User).WithMany(p => p.UserClaims).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<UserGroup>(entity =>
        {
            entity.HasKey(e => e.UserGroupId).HasName("PK_UserGroupModel_UserGroupId");

            entity.HasOne(d => d.Group).WithMany(p => p.UserGroups).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Organization).WithMany(p => p.UserGroups).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.UserGroups).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK_UserRoleModel_UserRoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles).OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
