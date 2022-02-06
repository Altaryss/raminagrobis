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
    public class CartDetailsController : ControllerBase
    {
        private readonly ILogger<CartDetailsController> _logger;
        private readonly CartDetails _db;

        public CartDetailsController(ILogger<CartDetailsController> logger)
        {
            _logger = logger;
            _db = new CartDetails();
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<MemberResponse>> GetAll()
        {
            var res = _db.GetAll();

            if (res == null || res.Count <= 0)
                return NotFound();

            return Ok(res.Select(x => x.ToResponse()));
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult<MemberResponse> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var res = _db.GetByID(id);

            if (res == null)
                return NotFound();

            return Ok(res.ToResponse());
        }

        [HttpPost]
        [Route("AddMember")]
        public ActionResult AddMember(MemberRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        [Route("UpdateMember")]
        public ActionResult UpdateMember(MemberRequest request, int id)
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
        [Route("Delete")]
        public ActionResult DeleteMember(int id)
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
