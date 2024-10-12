namespace OCorpus.AuthorizationService.Services.Interfaces;

/// <summary>
///     Interface for an organization service.
/// </summary>
public interface IOrganizationService
{
    /// <summary>
    ///     Gets a list of organizations.
    /// </summary>
    /// <returns> 
    /// An <see cref="IEnumerable{T}"/> containing a list of <see cref="OrganizationDto"/>. 
    /// </returns>
    Task<IEnumerable<OrganizationDto>> GetOrganizationsAsync();

    /// <summary>
    ///     Gets an organization.
    /// </summary>
    /// <param name="id"> The identifier of the organization.</param>
    /// <returns> An <see cref="OrganizationDto"/>. </returns>
    Task<OrganizationDto> GetOrganizationAsync(int id);
    
    /// <summary>
    ///     Gets an organization.
    /// </summary>
    /// <param name="name"> The name of the organization.</param>
    /// <returns> An <see cref="OrganizationDto"/>. </returns>
    Task<OrganizationDto> GetOrganizationAsync(string name);

    /// <summary>
    ///     Creates a new organization.
    /// </summary>
    /// <param name="organization"> The organization to be created.</param>
    /// <returns> An <see cref="OrganizationDto"/> containing the created organization. </returns>
    Task<OrganizationDto> CreateOrganizationAsync(OrganizationDto organization);

    /// <summary>
    ///     Updates an organization.
    /// </summary>
    /// <param name="organization"> The organization to be updated.</param>
    /// <returns> An <see cref="OrganizationDto"/> containing the updated organization. </returns>
    Task<OrganizationDto> UpdateOrganizationAsync(OrganizationDto organization);

    /// <summary>
    ///     Activates/deactivates an organization.
    /// </summary>
    /// <param name="id"> The identifier of the organization.</param>
    /// <param name="isActive"> <see langword="true"/> if the organization should be activated; otherwise, <see langword="false"/>.</param>
    /// <returns> <see langword="true"/> if the organization was activated/deactivated; otherwise, <see langword="false"/>.</returns>
    Task<bool> SetActiveStatus(int id, bool isActive);
}