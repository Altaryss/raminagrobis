using Depot.DAL.Depot;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raminagrobi.Api.Contracts.Requests;
using Raminagrobi.Api.Contracts.Responses;
using Raminagrobi.Api.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raminagrobi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly ILogger<MemberController> _logger;
        private readonly Member_DAL_Depot _db;

        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
            _db = new Member_DAL_Depot();
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

            if (_db.Insert(request.ToDto()) == null)
                return Problem("Insert into database failed", statusCode: StatusCodes.Status500InternalServerError);

            return Ok();
        }

        [HttpPut]
        [Route("UpdateMember")]
        public ActionResult UpdateMember(MemberRequest request, int id)
        {
            if (id <= 0)
                return BadRequest();

            var res = _db.GetByID(id);

            if (res == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            if (_db.Update(request.ToDto()) == null)
                return Problem("Update into database failed", statusCode: StatusCodes.Status500InternalServerError);

            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(int id)
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
