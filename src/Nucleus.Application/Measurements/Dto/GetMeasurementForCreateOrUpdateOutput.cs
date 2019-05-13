using System;
using System.Collections.Generic;
using Nucleus.Application.Roles.Dto;

namespace Nucleus.Application.Measurements.Dto
{
    public class GetMeasurementForCreateOrUpdateOutput
    {
        public MeasurementDto User { get; set; } = new MeasurementDto();

        public List<RoleDto> AllRoles { get; set; } = new List<RoleDto>();

        public List<Guid> GrantedRoleIds { get; set; } = new List<Guid>();
    }
}