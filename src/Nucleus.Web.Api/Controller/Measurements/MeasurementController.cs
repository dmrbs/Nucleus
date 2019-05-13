using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nucleus.Application.Dto;
using Nucleus.Application.Groups;
using Nucleus.Application.Groups.Dto;
using Nucleus.Application.Measurements;
using Nucleus.Application.Measurements.Dto;
using Nucleus.Application.Positions;
using Nucleus.Application.Positions.Dto;
using Nucleus.Application.Users;
using Nucleus.Application.Users.Dto;
using Nucleus.Core.Permissions;
using Nucleus.Utilities.Collections;
using Nucleus.Web.Core.Controllers;

namespace Nucleus.Web.Api.Controller.Measurements
{
    public class MeasurementController : AdminController
    {
        private readonly IMeasurementApnpService _measurementAppService;
        private IMeasurementApnpService measurementAppService;

        public MeasurementController(IMeasurementApnpService measurementsAppService)
        {
            _measurementAppService = measurementAppService;
        }

        [HttpGet("[action]")]
        [Authorize(Policy = DefaultPermissions.PermissionNameForPositionRead)]
        public async Task<ActionResult<IPagedList<MeasurementListOutput>>> GetMeasurements(MeasurementListOutput input)
        {
            return Ok(await _measurementAppService.GetMeasurementsAsync(input));
        }

    }
}