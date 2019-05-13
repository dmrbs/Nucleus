using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Nucleus.Application.Measurements.Dto;
using Nucleus.Application.Positions.Dto;
using Nucleus.Utilities.Collections;


namespace Nucleus.Application.Measurements
{
    public interface IMeasurementApnpService
    {
        Task<IPagedList<MeasurementListOutput>> GetMeasurementsAsync(MeasurementListOutput input);

        Task<GetMeasurementForCreateOrUpdateOutput> GetMeasurementForCreateOrUpdateAsync(Guid id);

        Task<IdentityResult> AddMeasurementAsync(CreateOrUpdateMeasurementInput input);

        Task<IdentityResult> EditMeasurementAsync(CreateOrUpdateMeasurementInput input);
        
        Task<IdentityResult> RemoveMeasurementAsync(Guid id);

    }
}