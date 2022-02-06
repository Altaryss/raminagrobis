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
    public class GlobalCartController : ControllerBase
    {
        private readonly ILogger<GlobalCartController> _logger;
        private readonly GlobalCart _db;

        public GlobalCartController(ILogger<GlobalCartController> logger)
        {
            _logger = logger;
            _db = new GlobalCart();
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<GlobalCartResponse>> GetAll()
        {
            var res = _db.GetAll();

            if (res == null || res.Count <= 0)
                return NotFound();

            return Ok(res.Select(x => x.ToResponse()));
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult<GlobalCartResponse> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var res = _db.GetByID(id);

            if (res == null)
                return NotFound();

            return Ok(res.ToResponse());
        }

        [HttpPost]
        [Route("AddGlobalCart")]
        public ActionResult AddGlobalCart(GlobalCartRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        [Route("UpdateGlobalCart")]
        public ActionResult UpdateGlobalCart(GlobalCartRequest request, int id)
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
        [Route("DeleteGlobalCart")]
        public ActionResult DeleteGlobalCart(int id)
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
