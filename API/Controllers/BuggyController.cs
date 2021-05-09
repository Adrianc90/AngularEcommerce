using System;
using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("not-found")]
        public ActionResult GetNotFound()
        {
            return NotFound(new ApiResponse(404));
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            int res = 0;

            int lol = 2;
            res = 1 / (2 - lol);

            return Ok(res);
            //throw new Exception("This is a server error");
        }

        [HttpGet("unauthorised")]
        public ActionResult GetUnauthorised()
        {
            return Unauthorized();
        }
    }
}