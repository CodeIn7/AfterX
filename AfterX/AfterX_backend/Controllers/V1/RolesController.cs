using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AfterX;
using AfterX.Contracts.V1;
using AfterX.Services;
using AfterX.Contracts.V1.Responses;
using AfterX.Contracts.V1.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace AfterX.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RolesController : Controller
    {
        private IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet(ApiRoutes.Roles.GetAll)]
        public async Task<IActionResult> Index()
        {
            return Ok(await _roleService.GetRolesAsync());
        }

        [HttpGet(ApiRoutes.Roles.Get)]
        public async Task<IActionResult> Details([FromRoute] int roleId)
        {

            var role = await _roleService.GetRoleByIdAsync(roleId);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpPost(ApiRoutes.Roles.Create)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] PostRoleRequest request)
        {
            var role = new Role { Name = request.Name };

            var created = await _roleService.CreateRoleAsync(role);

            if (!created)
            {
                return NoContent();
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Roles.Get.Replace("{roleId}", role.Id.ToString());

            var response = new PostRoleResponse
            {
                Id = role.Id,
                Name = role.Name
            };

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoutes.Roles.Update)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromRoute] int roleId, [FromBody] UpdateRoleRequest request)
        {
            var role = new Role { Id = roleId, Name = request.Name };

            var updated = await _roleService.UpdateRoleAsync(role);

            if (!updated)
                return NotFound();

            var response = new PostRoleResponse
            {
                Id = role.Id,
                Name = role.Name
            };
            return Ok(response);
        }

        [HttpDelete(ApiRoutes.Roles.Delete)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromRoute] int roleId)
        {
            var deleted = await _roleService.DeleteRoleAsync(roleId);

            if (!deleted)
                return NotFound();

            return NoContent();

        }
    }
}
