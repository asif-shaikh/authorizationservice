

using AutoMapper;
using OCorpus.AuthorizationService.Models.DataModels;

/// <summary>
/// Mapping profile
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MappingProfile"/> class.
    /// </summary>
    public MappingProfile()
    {
        CreateMap<Organization, OrganizationDto>().ReverseMap();
    }
}