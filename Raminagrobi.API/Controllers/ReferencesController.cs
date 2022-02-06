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

namespace Raminagrobis.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferencesController : ControllerBase
    {
        private readonly ILogger<ReferencesController> _logger;
        private readonly References _db;

        public ReferencesController(ILogger<ReferencesController> logger)
        {
            _logger = logger;
            _db = new References();
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<ReferencesResponse>> GetAll()
        {
            var res = _db.GetAll();

            if (res == null || res.Count <= 0)
                return NotFound();

            return Ok(res.Select(x => x.ToResponse()));
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult<ReferencesResponse> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var res = _db.GetByID(id);

            if (res == null)
                return NotFound();

            return Ok(res.ToResponse());
        }

        [HttpPost]
        [Route("AddReferences")]
        public ActionResult AddReferences(ReferencesRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        [Route("UpdateReferences")]
        public ActionResult UpdateReferences(ReferencesRequest request, int id)
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
        [Route("DeleteReferences")]
        public ActionResult DeleteReferences(int id)
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
