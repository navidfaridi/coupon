using Noyanet.Coupon.Core.Interfaces;
using Noyanet.Coupon.Core.Model;
using Noyanet.Coupon.MsSql;
using Noyanet.Coupon.MsSql.Models;

namespace Noyanet.Coupon.Services
{
	public class CouponService : ICoupnService
	{
		private readonly IAsyncRepository<CouponInfo> _repository;
		public CouponService(IAsyncRepository<CouponInfo> repository)
		{
			_repository = repository;
		}
		public async Task<CheckCouponResponse> Check(string code)
		{
			var data =await _repository.GetByAsync(u=>u.Code == code);
			if (data == null)
				return new CheckCouponResponse
				{
					IsAvailable = false,
					IsExist = false,
					Message = "Coupon code not found!"
				};

			return new CheckCouponResponse
			{
				IsExist = true,
				IsAvailable = data.UsageCount.HasValue ? data.UsageCount < data.MaxUsage : true,
				Coupon = new CouponModel
				{
					UsageCount = data.UsageCount,
					Code = code,
					ExpireDate = data.ExpireDate,
					MaxUsageCount = data.MaxUsage,
					Type = (CouponType)data.CouponType,
					Value = data.CouponValue

				}
			};

		}

		public Task<UseCouponResponse> UseCoupon(string code, string userId)
		{
			throw new NotImplementedException();
		}
	}
}
