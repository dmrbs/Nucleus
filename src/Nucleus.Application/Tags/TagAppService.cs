using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Identity;
using Nucleus.Application.Groups.Dto;
using Nucleus.Core.Users;
using Nucleus.EntityFramework;
using Nucleus.Utilities.Collections;
using Nucleus.Utilities.Extensions.Collections;
using Nucleus.Utilities.Extensions.PrimitiveTypes;
using Nucleus.Application.Tags.Dto;

namespace Nucleus.Application.Tags
{
    public class TagAppService : ITagAppService
    {
        //  private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly NucleusDbContext _dbContext;

        public TagAppService(IMapper mapper,
            UserManager<User> userManager,
            NucleusDbContext dbContext)
        {
            _mapper = mapper;
            // _userManager = userManager;
            _dbContext = dbContext;
        }

        public Task<IdentityResult> AddTagAsync(CreateOrUpdateTagInput input)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> EditTagAsync(CreateOrUpdateTagInput input)
        {
            throw new NotImplementedException();
        }

        public async Task<IPagedList<TagListOutput>> GetTagsAsync(TagListInput input)
        {
            var query = _dbContext.Tags
                .OrderBy(input.SortBy);

            var qroupsCount = await query.CountAsync();
            var tags = query.PagedBy(input.PageIndex, input.PageSize).ToList();
            var tagsListOutput = _mapper.Map<List<TagListOutput>>(tags);

            return tagsListOutput.ToPagedList(qroupsCount);
        }

        public Task<GetTagForCreateOrUpdateOutput> GetTagForCreateOrUpdateAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> RemoveTagAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
       
}
