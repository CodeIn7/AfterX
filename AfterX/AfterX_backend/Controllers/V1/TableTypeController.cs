using AfterX.Contracts.V1;
using AfterX_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Controllers.V1
{
    public class TableTypeController : Controller
    {
        private ITableTypeService _tableTypeService;
        public TableTypeController(ITableTypeService tableTypeService)
        {
            _tableTypeService = tableTypeService;
        }

        [HttpGet(ApiRoutes.TableTypes.GetAll)]
        public async Task<IActionResult> Index()
        {
            return Ok(await _tableTypeService.GetTableTypesAsync());
        }

        //[HttpGet(ApiRoutes.TableTypes.Get)]
        //public async Task<IActionResult> Details([FromRoute] int tableTypeId)
        //{

        //    var tableType = await _tableTypeService.GetTableTypeByIdAsync(tableTypeId);
        //    if (tableType == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(tableType);
        //}

        //[HttpPost(ApiRoutes.TableTypes.Create)]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([FromBody] PostTableTypeRequest request)
        //{
        //    var tableType = new TableType { Name = request.Name };

        //    var created = await _tableTypeService.CreateTableTypeAsync(tableType);

        //    if (!created)
        //    {
        //        return NoContent();
        //    }

        //    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        //    var locationUri = baseUrl + "/" + ApiRoutes.TableTypes.Get.Replace("{tableTypeId}", tableType.Id.ToString());

        //    var response = new PostTableTypeResponse
        //    {
        //        Id = tableType.Id,
        //        Name = tableType.Name
        //    };

        //    return Created(locationUri, response);
        //}

        //[HttpPut(ApiRoutes.TableTypes.Update)]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update([FromRoute] int tableTypeId, [FromBody] UpdateTableTypeRequest request)
        //{
        //    var tableType = new TableType { Id = tableTypeId, Name = request.Name, NormalizedName = request.Name.ToUpper() };

        //    var updated = await _tableTypeService.UpdateTableTypeAsync(tableType);

        //    if (!updated)
        //        return NotFound();

        //    var response = new PostTableTypeResponse
        //    {
        //        Id = tableType.Id,
        //        Name = tableType.Name
        //    };
        //    return Ok(response);
        //}

        //[HttpDelete(ApiRoutes.TableTypes.Delete)]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed([FromRoute] int tableTypeId)
        //{
        //    var deleted = await _tableTypeService.DeleteTableTypeAsync(tableTypeId);

        //    if (!deleted)
        //        return NotFound();

        //    return NoContent();

        //}
    }
}
