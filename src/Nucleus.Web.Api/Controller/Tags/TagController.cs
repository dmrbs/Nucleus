using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nucleus.Application.Dto;
using Nucleus.Application.Groups;
using Nucleus.Application.Groups.Dto;
using Nucleus.Application.Tags;
using Nucleus.Application.Tags.Dto;
using Nucleus.Application.Users;
using Nucleus.Application.Users.Dto;
using Nucleus.Core.Permissions;
using Nucleus.Utilities.Collections;
using Nucleus.Web.Core.Controllers;

namespace Nucleus.Web.Api.Controller.Tags
{
    public class TagController : AdminController
    {
        private readonly ITagAppService _groupAppService;

        public TagController(ITagAppService TagAppService)
        {
            _groupAppService = TagAppService;
        }

        [HttpGet("[action]")]
        [Authorize(Policy = DefaultPermissions.PermissionNameForGroupRead)]
        public async Task<ActionResult<IPagedList<TagListOutput>>> GetTags(TagListInput input)
        {
            return Ok(await _tagAppService.GetTagsAsync(input));
        }

        private ActionResult<IPagedList<TagListOutput>> Ok(object p)
        {
            throw new NotImplementedException();
        }
    }
}