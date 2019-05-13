using System;
using System.Collections.Generic;
using Nucleus.Application.Groups.Dto;
using Nucleus.Application.Roles.Dto;

namespace Nucleus.Application.Tags.Dto
{
    public class GetTagForCreateOrUpdateOutput
    {
        public TagDto User { get; set; } = new TagDto();

        public List<RoleDto> AllRoles { get; set; } = new List<RoleDto>();

        public List<Guid> GrantedRoleIds { get; set; } = new List<Guid>();
    }
}