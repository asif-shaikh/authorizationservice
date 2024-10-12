using Microsoft.AspNetCore.Mvc;
using Ocorpus.AuthorizationService.Controllers.Interfaces;
using OCorpus.AuthorizationService.Services.Interfaces;

namespace Ocorpus.AuthorizationService.Controllers;

/// <summary>
/// Organization controller implementating the IOrganizationController interface.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class OrganizationController : ControllerBase, IOrganizationController
{
    private readonly IOrganizationService _service;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrganizationController"/> class.
    /// </summary>
    /// <param name="service"> 
    ///     The Organization service.    
    /// </param>
    public OrganizationController(IOrganizationService service)
    {
        _service = service;
    }

    /// <inheritdoc/>
    /// <summary>
    ///     Creates a new organization.
    /// </summary>
    /// <param name="organizationDto">
    ///     The organization Dto.
    /// </param>
    /// <returns>
    ///     The created organization.
    /// </returns>
    [HttpPost]
    [ProducesResponseType(typeof(OrganizationDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrganizationDto>> CreateOrganizationAsync(OrganizationDto organizationDto)
    {
        var organization = await _service.CreateOrganizationAsync(organizationDto);
        return CreatedAtAction(nameof(CreateOrganizationAsync), new { id = organization.OrganizationId }, organization);
    }

    /// <summary>
    ///     Gets the organization by its id.
    /// </summary>
    /// <param name="id">
    ///     The id of the organization.
    /// </param>
    /// <returns>
    ///     The organization.
    /// </returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(OrganizationDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrganizationDto>> GetOrganizationAsync(int id)
    {
        var organization = await _service.GetOrganizationAsync(id);
        return organization;
    }

    /// <summary>
    ///     Gets the organization by its name.
    /// </summary>
    /// <param name="name">
    ///     The name of the organization.
    /// </param>
    /// <returns>
    ///     The organization.
    /// </returns>
    [HttpGet("{name}")]
    [ProducesResponseType(typeof(OrganizationDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrganizationDto>> GetOrganizationAsync(string name)
    {
        var organization = await _service.GetOrganizationAsync(name);
        return organization;
    }

    /// <summary>
    ///     Gets all organizations.
    /// </summary>
    /// <returns>
    ///     The list of organizations.
    /// </returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<OrganizationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<OrganizationDto>>> GetOrganizationsAsync()
    {
        var organizations = await _service.GetOrganizationsAsync();
        return Ok(organizations);
    }

    /// <summary>
    ///     Sets the active status of an organization.
    /// </summary>
    /// <param name="id">
    ///     The id of the organization.
    /// </param>
    /// <param name="isActive">
    ///     The active status.
    /// </param>
    /// <returns>
    ///     The result of the operation.
    /// </returns>
    [HttpPatch("{id:int}/active")]
    [ProducesResponseType(typeof(OrganizationDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> SetActiveStatus(int id, bool isActive)
    {
        var result = await _service.SetActiveStatus(id, isActive);
        return Ok(result);
    }

    /// <summary>
    ///     Updates an organization.
    /// </summary>
    /// <param name="organizationDto">
    ///     The organization Dto.
    /// </param>
    /// <returns>
    ///     The updated organization.
    /// </returns>
    [HttpPut]
    [ProducesResponseType(typeof(OrganizationDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrganizationDto>> UpdateOrganizationAsync(OrganizationDto organizationDto)
    {
        var organization = await _service.UpdateOrganizationAsync(organizationDto);
        return Ok(organization);
    }
}

