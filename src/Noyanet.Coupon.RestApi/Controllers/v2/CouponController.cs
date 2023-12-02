using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Noyanet.Coupon.RestApi.Controllers.v2
{
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("2.0")]
	[ApiController]
	public class CouponController : ControllerBase
	{

		[HttpGet]
		public async Task<IActionResult> get()
		{
			return Ok();
		}
	}
}
