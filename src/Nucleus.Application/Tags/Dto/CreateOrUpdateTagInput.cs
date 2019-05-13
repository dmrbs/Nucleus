using System;
using System.Collections.Generic;

namespace Nucleus.Application.Tags.Dto
{
    public class CreateOrUpdateTagInput
    {
        public TagDto User { get; set; } = new TagDto();

        public List<Guid> GrantedRoleIds { get; set; } = new List<Guid>();
    }
}
