
using OCorpus.AuthorizationService.Models.DataModels;

namespace OCorpus.AuthorizationService.Repositories.Interfaces;

/// <summary>
/// Interface for an organization repository.
/// </summary>
public interface IOrganizationRepository
{
    /// <summary>
    /// Gets all organizations.
    /// </summary>
    /// <returns> 
    /// An <see cref="IEnumerable{Organization}"/> containing all organizations. 
    /// </returns>
    Task<IEnumerable<Organization>> GetAll();

    /// <summary>
    /// Gets an organization by name.
    /// </summary>
    /// <param name="name"> The name of the organization. </param>
    /// <returns> An <see cref="Organization"/> containing the organization. </returns>
    Task<Organization?> GetByName(string name);

    /// <summary>
    /// Gets an organization by id.
    /// </summary>
    /// <param name="id"> The id of the organization. </param>
    /// <returns> An <see cref="Organization"/> containing the organization. </returns>
    Task<Organization?> GetById(int id);

    /// <summary>
    /// Creates an organization.
    /// </summary>
    /// <param name="organization"> The organization to create. </param>
    /// <returns> An <see cref="Organization"/> containing the created organization. </returns>
    Task<Organization> Create(Organization organization);

    /// <summary>
    /// Updates an organization.
    /// </summary>
    /// <param name="id"> The id of the organization. </param>
    /// <param name="organization"> The organization to update. </param>
    /// <returns> An <see cref="Organization"/> containing the updated organization. </returns>
    Task<Organization> Update(Organization organization);

    /// <summary>
    /// Set organization status to active/inactive.
    /// </summary>
    /// <param name="id"> The id of the organization. </param>
    /// <param name="isActive"> The status to set the organization to. </param>
    /// <returns> An <see cref="bool"/> indicating if the operation was successful. </returns>
    Task<bool> SetActiveStatus(int id, bool isActive);
}