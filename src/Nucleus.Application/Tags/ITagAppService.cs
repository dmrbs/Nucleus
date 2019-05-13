using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Nucleus.Application.Groups.Dto;
using Nucleus.Application.Tags.Dto;
using Nucleus.Utilities.Collections;

namespace Nucleus.Application.Tags
{
    public interface ITagAppService
    {
        Task<IPagedList<TagListOutput>> GetTagsAsync(TagListInput input);

        Task<GetTagForCreateOrUpdateOutput> GetTagForCreateOrUpdateAsync(Guid id);

        Task<IdentityResult> AddTagAsync(CreateOrUpdateTagInput input);

        Task<IdentityResult> EditTagAsync(CreateOrUpdateTagInput input);
        
        Task<IdentityResult> RemoveTagAsync(Guid id);
    }
}