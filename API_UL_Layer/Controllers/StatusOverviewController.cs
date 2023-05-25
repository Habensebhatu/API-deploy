using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Logic_Layer;
using Business_Logic_Layer.ViewModel;
using Data_Access_Layer.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_UL_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class statusOverviewController : ControllerBase
    {
        private readonly StatusOverviewBLL _statusOverviewBLL;

        public statusOverviewController()
        {
            _statusOverviewBLL = new StatusOverviewBLL();
        }

        [HttpPost]
        public async Task<ActionResult<StatusOverviewModel>> AddStatusOverview(StatusOverviewModel statusOverview)
        {
            if (statusOverview == null)
            {
                return BadRequest();
            }

            StatusOverviewModel result = await _statusOverviewBLL.AddStatusOverView(statusOverview);
            return result;
        }

        [HttpGet("{RepairId:guid}")]
        public async Task<ActionResult<StatusOverviewModel>> GetStatusOverviewById(Guid RepairId)
        {


            var StatusOverview = await _statusOverviewBLL.GetStatusOverviewById(RepairId);
            if (StatusOverview == null)
            {
                return NotFound();
            }
            return Ok(StatusOverview);


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StatusOverviewModel>> DeleteStatusOverviewById(Guid id)
        {
            bool StatusOverview = await _statusOverviewBLL.DeleteStatusOverviewById(id);
            if (!StatusOverview)
            {
                return NotFound();
            }
            return Ok(StatusOverview);
        }



    }
}
