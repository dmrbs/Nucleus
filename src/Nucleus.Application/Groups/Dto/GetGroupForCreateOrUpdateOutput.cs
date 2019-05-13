using System;
using System.Collections.Generic;
using Nucleus.Application.Groups.Dto;
using Nucleus.Application.Roles.Dto;

namespace Nucleus.Application.Positions.Dto
{
    public class GetGroupForCreateOrUpdateOutput
    {
        public GroupDto User { get; set; } = new GroupDto();

        public List<RoleDto> AllRoles { get; set; } = new List<RoleDto>();

        public List<Guid> GrantedRoleIds { get; set; } = new List<Guid>();
    }
}