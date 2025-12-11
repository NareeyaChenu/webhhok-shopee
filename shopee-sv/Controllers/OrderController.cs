
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shopee_sv.Interfaces;

namespace shopee_sv.Controllers
{
    [ApiController]
    [Route("webhook/shopee/v1")]
    public class OrderController : ControllerBase
    {

        private readonly IForwardRequest _req;

        public OrderController(IForwardRequest req)
        {
            _req = req;
        }


        [HttpPost]
        [Route("order")]

        public async Task<ActionResult> OrderReceiver([FromBody] object body)
        {

            if(body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            var json = body.ToString();


            if(json == null)
            {
                throw new Exception("Error Convert object to string");
            }

            var bookingSnPattern = "\"booking_sn\"\\s*:\\s*\"(.*?)\"";
            var shopIdPattern = "\"shop_id\"\\s*:\\s*\"(.*?)\"";

            var bookingSn = Regex.Match(json, bookingSnPattern).Groups[1].Value;
            var shopId = Regex.Match(json, shopIdPattern).Groups[1].Value;


            await _req.GetDetailAsync(bookingSn , shopId);

            return Ok(new
            {
                booking_sn = bookingSn,
                shop_id = shopId
            });
        }
    }
}