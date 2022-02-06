using Raminagrobis.Metier.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raminagrobis.Api.Contracts.Requests;
using Raminagrobis.Api.Contracts.Responses;
using Raminagrobis.Api.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raminagrobi.Metier.Services;

namespace Raminagrobis.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GlobalCartDetailsController : ControllerBase
    {
        private readonly ILogger<GlobalCartDetailsController> _logger;
        private readonly GlobalCartDetails _db;

        public GlobalCartDetailsController(ILogger<GlobalCartDetailsController> logger)
        {
            _logger = logger;
            _db = new GlobalCartDetails();
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<GlobalCartDetailsResponse>> GetAll()
        {
            var res = _db.GetAll();

            if (res == null || res.Count <= 0)
                return NotFound();

            return Ok(res.Select(x => x.ToResponse()));
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult<GlobalCartDetailsResponse> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var res = _db.GetByID(id);

            if (res == null)
                return NotFound();

            return Ok(res.ToResponse());
        }

        [HttpPost]
        [Route("AddGlobalCartDetails")]
        public ActionResult AddGlobalCartDetails(GlobalCartDetailsRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        [Route("UpdateGlobalCartDetails")]
        public ActionResult UpdateGlobalCartDetails(GlobalCartDetailsRequest request, int id)
        {
            if (id <= 0)
                return BadRequest();

            var res = _db.GetByID(id);
            request.ID = id;

            if (res == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteGlobalCartDetails")]
        public ActionResult DeleteGlobalCartDetails(int id)
        {
            if (id <= 0)
                return BadRequest();

            var res = _db.GetByID(id);

            if (res == null)
                return NotFound();

            return Ok();
        }
    }
}
