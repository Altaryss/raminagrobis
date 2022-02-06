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
    public class MtmPrController : ControllerBase
    {
        private readonly ILogger<MtmPrController> _logger;
        private readonly MtmPr _db;

        public MtmPrController(ILogger<MtmPrController> logger)
        {
            _logger = logger;
            _db = new MtmPr();
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<MtmPrResponse>> GetAll()
        {
            var res = _db.GetAll();

            if (res == null || res.Count <= 0)
                return NotFound();

            return Ok(res.Select(x => x.ToResponse()));
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult<MtmPrResponse> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var res = _db.GetByID(id);

            if (res == null)
                return NotFound();

            return Ok(res.ToResponse());
        }

        [HttpPost]
        [Route("AddMtmPr")]
        public ActionResult AddMtmPr(MtmPrRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        [Route("UpdateMtmPr")]
        public ActionResult UpdateMtmPr(MtmPrRequest request, int id)
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
        [Route("DeleteMtmPr")]
        public ActionResult DeleteMtmPr(int id)
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
