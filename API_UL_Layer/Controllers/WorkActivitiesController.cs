using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Logic_Layer;
using Business_Logic_Layer.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_UL_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkActivitiesController : ControllerBase
    {
        private readonly WorkActivitiesBLL _WorkActivities;

        public WorkActivitiesController()
        {
            _WorkActivities = new WorkActivitiesBLL();

        }

        [HttpPost]
        public async Task<ActionResult<WorkActivitiesModel>> addWorkActivities([FromBody] WorkActivitiesModel workActivities)
        {
            if (workActivities == null)
            {
                return BadRequest();
            }

            WorkActivitiesModel result = await _WorkActivities.AddWorkActivities(workActivities);


            return result;
        }

        [HttpGet("repair/{RepairId:guid}")]
        public async Task<ActionResult<IEnumerable<WorkActivitiesModel>>> GetWorkActivities(Guid RepairId)
        {
            var result = await _WorkActivities.GetWorkActivities(RepairId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("public/{WorkId:guid}")]
        public async Task<ActionResult<WorkActivitiesModel>> GetWorkActivitiesByID(Guid WorkId)
        {
            var result = await _WorkActivities.GetWorkActivitiesByID(WorkId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{WorkId:guid}")]
        public async Task<ActionResult<WorkActivitiesModel>> UpdateWorkActivities(Guid WorkId, WorkActivitiesModel WorkActivities)
        {
     

            var result = await _WorkActivities.UpdateWorkActivities(WorkId, WorkActivities);
            if (result == null)
            {
                return NotFound();
            }

            return WorkActivities;
        }

        [HttpDelete("{WorkId:guid}")]
        public async Task<IActionResult> DeleteWorkActivities(Guid WorkId)
        {
            var result = await _WorkActivities.DeleteWorkActivities(WorkId);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
