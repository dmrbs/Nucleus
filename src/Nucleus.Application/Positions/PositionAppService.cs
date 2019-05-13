using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Identity;
using Nucleus.Application.Roles.Dto;
using Nucleus.Core.Users;
using Nucleus.EntityFramework;
using Nucleus.Utilities.Collections;
using Nucleus.Utilities.Extensions.Collections;
using Nucleus.Utilities.Extensions.PrimitiveTypes;
using Nucleus.Application.Positions.Dto;

namespace Nucleus.Application.Positions
{
    public class PositionAppService : IPositionAppService
    {
        //  private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly NucleusDbContext _dbContext;

        public PositionAppService(IMapper mapper,
            UserManager<User> userManager,
            NucleusDbContext dbContext)
        {
            _mapper = mapper;
            // _userManager = userManager;
            _dbContext = dbContext;
        }

        public Task<IdentityResult> AddPositionAsync(CreateOrUpdatePositionInput input)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> EditPositionAsync(CreateOrUpdatePositionInput input)
        {
            throw new NotImplementedException();
        }

        Task<IPagedList<PositionListOutput>> IPositionAppService.GetPositionsAsync(PositionListOutput input)
        {
            throw new NotImplementedException();
        }

        Task<GetPositionForCreateOrUpdateOutput> IPositionAppService.GetPositionForCreateOrUpdateAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<IdentityResult> IPositionAppService.RemovePositionAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
       
}
