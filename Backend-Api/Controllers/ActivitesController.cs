using Application.Services.Interfaces;
using Domian.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Api.Controllers
{
    public class ActivitesController : BaseController
    {
        #region Constructor

        private readonly IActivitesService _activitesService;

        public ActivitesController(IActivitesService activitesService)
        {
            _activitesService = activitesService;
        }

        #endregion

        #region Api

        [HttpGet("GetAllActivitiesAsync")]
        public async Task<IActionResult> GetAllActivitiesAsync()
        {
            var result = await _activitesService.GetAllActivitiesAsync();

            return new JsonResult(new
            {
                code = 100,
                message = "Activities retrieved successfully.",
                data = result
            });
        }

        [HttpGet("GetActivityAsync/{id}")]
        public async Task<IActionResult> GetActivityAsync([FromRoute] Guid id)
        {
            var result = await _activitesService.GetActivityByIdAsync(id);

            if (result == null)
                return NotFound();


            return new JsonResult(result);
        }

        [HttpPost("CreateActivityAsync")]
        public async Task<IActionResult> CreateActivityAsync([FromBody] Activity activity)
        {

            if(!ModelState.IsValid)
            {
                return new JsonResult(new
                {
                    code = 101,
                    message = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            if (activity == null)
            {
                return BadRequest();
            }

            var created = await _activitesService.CreateActivityAsync(activity);

            if (!created)
            {
                return new JsonResult(new
                {
                    code = 102,
                    message = "An error occurred while creating the activity. Please try again."
                });
            }

            return new JsonResult(new
            {
                code = 100,
                message = "Activity has been created successfully."
            });
        }

        [HttpPut("UpdateActivityAsync")]
        public async Task<IActionResult> UpdateActivityAsync([FromQuery] Guid id, [FromBody] Activity activity)
        {
            if(id != activity.Id)
            {
                return new JsonResult(new
                {
                    code = 102,
                    message = "Activity ID mismatch."
                });
            }

            if(!ModelState.IsValid)
            {
                return new JsonResult(new
                {
                    code = 101,
                    message = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            var updated = await _activitesService.UpdateActivityAsync(activity);

            if (!updated)
            {
                return new JsonResult(new
                {
                    code = 102,
                    message = "An error occurred while updating the activity. Please try again."
                });
            }

            return new JsonResult(new
            {
                code = 100,
                message = "Activity has been updated successfully."
            });
        }


        [HttpDelete("DeleteActivityAsync/{id}")]
        public async Task<IActionResult> DeleteActivityAsync([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var activity = await _activitesService.GetActivityByIdAsync(id);

            if(activity == null)
            {
                return NotFound();
            }

            var deleted = await _activitesService.DeleteActivityAsync(activity.Id);

            if (!deleted)
            {
                return new JsonResult(new
                {
                    code = 102,
                    message = "An error occurred while deleting the activity. Please try again."
                });
            }

            return new JsonResult(new
            {
                code = 100,
                message = "Activity has been deleted successfully."
            });
        }


        #endregion
    }
}
