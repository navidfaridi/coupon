using Microsoft.Extensions.DependencyInjection;

namespace Noyanet.Coupon.RestApi.Client
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddCouponApiClient(this IServiceCollection services)
		{
			return services;
		}
	}
}
