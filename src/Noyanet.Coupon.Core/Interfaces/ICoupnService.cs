using System.Threading.Tasks;
using Noyanet.Coupon.Core.Model;

namespace Noyanet.Coupon.Core.Interfaces
{
    public interface ICoupnService
	{
		Task<CheckCouponResponse> Check(string code);

		Task<UseCouponResponse> UseCoupon(string code, string userId);
	}
}
