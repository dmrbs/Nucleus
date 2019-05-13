using System;
using System.Collections.Generic;

namespace Nucleus.Application.Groups.Dto
{
    public class CreateOrUpdateGroupInput
    {
        public GroupDto User { get; set; } = new GroupDto();

        public List<Guid> GrantedRoleIds { get; set; } = new List<Guid>();
    }
}
