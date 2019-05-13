using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Nucleus.Application.Groups.Dto;

using Nucleus.Utilities.Collections;

namespace Nucleus.Application.Groups
{
    public interface IGroupAppService
    {
        Task<IPagedList<GroupListOutput>> GetGroupsAsync(GroupListInput input);

        Task<GetGroupForCreateOrUpdateOutput> GetGroupForCreateOrUpdateAsync(Guid id);

        Task<IdentityResult> AddGroupAsync(CreateOrUpdateGroupInput input);

        Task<IdentityResult> EditGroupAsync(CreateOrUpdateGroupInput input);
        
        Task<IdentityResult> RemoveGroupAsync(Guid id);
    }
}