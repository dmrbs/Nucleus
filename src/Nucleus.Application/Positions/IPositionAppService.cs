using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Nucleus.Application.Positions.Dto;
using Nucleus.Utilities.Collections;


namespace Nucleus.Application.Positions
{
    public interface IPositionAppService
    {
        Task<IPagedList<PositionListOutput>> GetPositionsAsync(PositionListOutput input);

        Task<GetPositionForCreateOrUpdateOutput> GetPositionForCreateOrUpdateAsync(Guid id);

        Task<IdentityResult> AddPositionAsync(CreateOrUpdatePositionInput input);

        Task<IdentityResult> EditPositionAsync(CreateOrUpdatePositionInput input);
        
        Task<IdentityResult> RemovePositionAsync(Guid id);
    }
}