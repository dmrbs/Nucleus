using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nucleus.Application.Dto;
using Nucleus.Application.Groups;
using Nucleus.Application.Groups.Dto;
using Nucleus.Application.Users;
using Nucleus.Application.Users.Dto;
using Nucleus.Core.Permissions;
using Nucleus.Utilities.Collections;
using Nucleus.Web.Core.Controllers;

namespace Nucleus.Web.Api.Controller.Groups
{
    public class GroupController : AdminController
    {
        private readonly IGroupAppService _groupAppService;

        public GroupController(IGroupAppService groupAppService)
        {
            _groupAppService = groupAppService;
        }

        [HttpGet("[action]")]
        [Authorize(Policy = DefaultPermissions.PermissionNameForGroupRead)]
        public async Task<ActionResult<IPagedList<GroupListOutput>>> GetGroups(GroupListInput input)
        {
            return Ok(await _groupAppService.GetGroupsAsync(input));
        }

    }
}