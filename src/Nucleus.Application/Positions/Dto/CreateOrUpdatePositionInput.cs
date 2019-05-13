using System;
using System.Collections.Generic;

namespace Nucleus.Application.Positions.Dto
{
    public class CreateOrUpdatePositionInput
    {
        public PositionDto User { get; set; } = new PositionDto();

        public List<Guid> GrantedRoleIds { get; set; } = new List<Guid>();
    }
}
