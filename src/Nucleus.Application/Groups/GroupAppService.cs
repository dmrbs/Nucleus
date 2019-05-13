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


namespace Nucleus.Application.Groups
{
    public class GroupAppService : IGroupAppService
    {
        //  private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly NucleusDbContext _dbContext;

        public GroupAppService(IMapper mapper,
            UserManager<User> userManager,
            NucleusDbContext dbContext)
        {
            _mapper = mapper;
            // _userManager = userManager;
            _dbContext = dbContext;
        }

        public Task<IdentityResult> AddGroupAsync(CreateOrUpdateGroupInput input)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> EditGroupAsync(CreateOrUpdateGroupInput input)
        {
            throw new NotImplementedException();
        }

        public async Task<IPagedList<GroupListOutput>> GetGroupsAsync(GroupListInput input)
        {
            var query = _dbContext.Groups
                .OrderBy(input.SortBy);

            var qroupsCount = await query.CountAsync();
            var groups = query.PagedBy(input.PageIndex, input.PageSize).ToList();
            var groupsListOutput = _mapper.Map<List<GroupListOutput>>(groups);

            return groupsListOutput.ToPagedList(qroupsCount);
        }

        public Task<GetGroupForCreateOrUpdateOutput> GetGroupForCreateOrUpdateAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> RemoveGroupAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
       
}
