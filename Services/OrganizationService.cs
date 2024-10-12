using AutoMapper;
using OCorpus.AuthorizationService.Models.DataModels;
using OCorpus.AuthorizationService.Repositories.Interfaces;
using OCorpus.AuthorizationService.Services.Interfaces;

namespace OCorpus.AuthorizationService.Services;

/// <summary>
///     Organization service implementating the IOrganizationService interface.
/// </summary>
public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _repository;
    private readonly IMapper _mapper;

    /// <summary>
    ///     Initializes a new instance of the <see cref="OrganizationService"/> class.
    /// </summary>
    /// <param name="repository"> The organization repository.</param>
    /// <param name="mapper"> The mapper.</param>
    public OrganizationService(IOrganizationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<OrganizationDto>> GetOrganizationsAsync()
    {
        var organizations = await _repository.GetAll();
        return _mapper.Map<IEnumerable<OrganizationDto>>(organizations);
    }

    /// <inheritdoc/>
    public async Task<OrganizationDto> GetOrganizationAsync(int id)
    {
        var organization = await _repository.GetById(id);
        return _mapper.Map<OrganizationDto>(organization!);
    }

    /// <inheritdoc/>
    public async Task<OrganizationDto> GetOrganizationAsync(string name)
    {
        var organization = await _repository.GetByName(name);
        return _mapper.Map<OrganizationDto>(organization!);
    }

    /// <inheritdoc/>
    public async Task<OrganizationDto> CreateOrganizationAsync(OrganizationDto organizationDto)
    {
        var organization = _mapper.Map<Organization>(organizationDto);
        var createdOrganization = await _repository.Create(organization);
        return _mapper.Map<OrganizationDto>(createdOrganization);
    }

    /// <inheritdoc/>
    public async Task<OrganizationDto> UpdateOrganizationAsync(OrganizationDto organizationDto)
    {
        var organization = _mapper.Map<Organization>(organizationDto);
        var updatedOrganization = await _repository.Update(organization);
        return _mapper.Map<OrganizationDto>(updatedOrganization);
    }

    /// <inheritdoc/>
    public async Task<bool> SetActiveStatus(int id, bool isActive)
    {
        return await _repository.SetActiveStatus(id, isActive);
    }
}
