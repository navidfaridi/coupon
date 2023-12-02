using Microsoft.Extensions.DependencyInjection;
using Noyanet.Coupon.Core.Interfaces;

namespace Noyanet.Coupon.Services
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddCouponServices(this IServiceCollection services)
		{
			services.AddScoped<ICoupnService, CouponService>();
			return services;
		}
	}
}
