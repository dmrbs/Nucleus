using System;
using System.Collections.Generic;

namespace Nucleus.Application.Measurements.Dto
{
    public class CreateOrUpdateMeasurementInput
    {
        public MeasurementDto User { get; set; } = new MeasurementDto();

        public List<Guid> GrantedRoleIds { get; set; } = new List<Guid>();
    }
}
