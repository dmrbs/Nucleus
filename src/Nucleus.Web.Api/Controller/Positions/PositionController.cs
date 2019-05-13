using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nucleus.Application.Dto;
using Nucleus.Application.Groups;
using Nucleus.Application.Groups.Dto;
using Nucleus.Application.Positions;
using Nucleus.Application.Positions.Dto;
using Nucleus.Application.Users;
using Nucleus.Application.Users.Dto;
using Nucleus.Core.Permissions;
using Nucleus.Utilities.Collections;
using Nucleus.Web.Core.Controllers;

namespace Nucleus.Web.Api.Controller.Positions
{
    public class PositionController : AdminController
    {
        private readonly IPositionAppService _positionAppService;

        public PositionController(IPositionAppService positionAppService)
        {
            _positionAppService = positionAppService;
        }

        [HttpGet("[action]")]
        [Authorize(Policy = DefaultPermissions.PermissionNameForPositionRead)]
        public async Task<ActionResult<IPagedList<PositionListOutput>>> GetPositions(PositionListOutput input)
        {
            return Ok(await _positionAppService.GetPositionsAsync(input));
        }

    }
}