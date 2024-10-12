using OCorpus.AuthorizationService.Contexts;
using OCorpus.AuthorizationService.Models.DataModels;
using OCorpus.AuthorizationService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace OCorpus.AuthorizationService.Repositories;

/// <summary>
/// Organization repository implementating the IOrganizationRepository interface.
/// </summary>
public class OrganizationRepository : IOrganizationRepository
{
    private readonly OCorpusDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrganizationRepository"/> class.
    /// </summary>
    /// <param name="context"> The OCorpus db context.</param>
    public OrganizationRepository(OCorpusDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<Organization> Create(Organization organization)
    {
        _context.Organizations.Add(organization);
        await _context.SaveChangesAsync();
        return organization;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Organization>> GetAll()
    {
        return await _context.Organizations.ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<Organization?> GetById(int id)
    {
        var organization = await _context.Organizations.FindAsync(id);

        if (organization == null)
        {
            throw new KeyNotFoundException($"Organization with id {id} not found.");
        }

        return organization;
    }

    /// <inheritdoc/>
    public async Task<Organization?> GetByName(string name)
    {
        var organization = await _context.Organizations
            .FirstOrDefaultAsync(o => o.Name == name);

        if (organization == null)
        {
            throw new KeyNotFoundException($"Organization with name {name} not found.");
        }

        return organization;
    }

    /// <inheritdoc/>
    public async Task<bool> SetActiveStatus(int id, bool isActive)
    {
        var organization = await GetById(id);

        organization!.IsActive = isActive;
        _context.Entry(organization).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return true;
    }

    /// <inheritdoc/>
    public async Task<Organization> Update(Organization organization)
    {
        var existingOrganization = await GetById(organization.OrganizationId);

        existingOrganization!.Name = organization.Name;
        existingOrganization.IsActive = organization.IsActive;

        _context.Entry(existingOrganization).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return existingOrganization!;
    }
}