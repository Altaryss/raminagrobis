using Depot.DAL.Depot;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;
        private readonly Cart_DAL_Depot _db;

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
            _db = new Cart_DAL_Depot();
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<CartResponse>> GetAll()
        {
            var toto = _db.GetAll();

            if (toto == null || toto.Count <= 0)
                return NotFound();

            return Ok(toto.Select(x => x.ToResponse()));
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult<CartResponse> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var toto = _db.GetByID(id);

            if (toto == null)
                return NotFound();

            return Ok(toto.ToResponse());
        }
    }
}
