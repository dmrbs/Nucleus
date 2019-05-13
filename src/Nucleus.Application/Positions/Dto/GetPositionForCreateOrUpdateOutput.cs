using System;
using System.Collections.Generic;
using Nucleus.Application.Roles.Dto;

namespace Nucleus.Application.Positions.Dto
{
    public class GetPositionForCreateOrUpdateOutput
    {
        public PositionDto User { get; set; } = new PositionDto();

        public List<RoleDto> AllRoles { get; set; } = new List<RoleDto>();

        public List<Guid> GrantedRoleIds { get; set; } = new List<Guid>();
    }
}