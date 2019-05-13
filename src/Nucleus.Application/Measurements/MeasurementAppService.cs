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
using Nucleus.Application.Measurements.Dto;

namespace Nucleus.Application.Measurements
{
    public class MeasurementAppService : IMeasurementApnpService
    {
        //  private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly NucleusDbContext _dbContext;

        public MeasurementAppService(IMapper mapper,
            UserManager<User> userManager,
            NucleusDbContext dbContext)
        {
            _mapper = mapper;
            // _userManager = userManager;
            _dbContext = dbContext;
        }

        public Task<IdentityResult> AddMeasurementAsync(CreateOrUpdateMeasurementInput input)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> EditMeasurementAsync(CreateOrUpdateMeasurementInput input)
        {
            throw new NotImplementedException();
        }

        public Task<GetMeasurementForCreateOrUpdateOutput> GetMeasurementForCreateOrUpdateAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<MeasurementListOutput>> GetMeasurementsAsync(MeasurementListOutput input)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetPositionsAsync(MeasurementListOutput input)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> RemoveMeasurementAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
       
}
