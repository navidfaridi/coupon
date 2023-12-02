using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Noyanet.Coupon.Core.Interfaces;
using Noyanet.Coupon.MsSql;

namespace Noyanet.Coupon.RestApi.Controllers.v1
{
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	[ApiController]
	public class CouponController : ControllerBase
	{
		//private readonly ICoupnService _service;
		CouponDbContext _context;
		public CouponController(
			//ICoupnService service
			CouponDbContext context
			)
		{
			//_service = service;
			_context = context;
		}

		[HttpGet("check/{code}")]
		public async Task<IActionResult> CheckCoupon([FromRoute] string code)
		{
			var data = _context.CouponInfos.FirstOrDefault(x=>x.Code == code);
			//var result = await _service.Check(code);
			return Ok(data);
		}
	}
}
