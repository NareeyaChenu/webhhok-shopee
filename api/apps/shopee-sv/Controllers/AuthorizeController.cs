using Microsoft.AspNetCore.Mvc;
using shopee_sv.Interfaces;
using ShopeeLib.DTOs;


namespace shopee_sv.Controllers
{
    [ApiController]
    [Route("api/shopee/v1")]

    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthorizeService _service;

        public AuthorizeController(IAuthorizeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("authorize-url")]
        public ActionResult GetSignKey([FromQuery] AuthorizationModel model)
        {

            var data = _service.GetAthorizeKey(model);
            return Ok(data);
        }

        [HttpPost("get-token")]
        public async Task<IActionResult> GetAccessToken([FromBody] ShopeeTokenRequest req)
        {
             var data = await _service.GetAccessTokenAsync(req);
            return Ok(data);
        }
    }
}