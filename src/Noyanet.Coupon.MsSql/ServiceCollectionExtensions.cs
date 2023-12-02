using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Noyanet.Coupon.Core.Interfaces;
using Noyanet.Coupon.MsSql.Repository;

namespace Noyanet.Coupon.MsSql;
public static class ServiceCollectionExtensions
{
	public static void AddMsSqlDb(this IServiceCollection services, IConfiguration configuration)
	{
		var cnn = configuration.GetConnectionString("Default");
		services.AddDbContext<CouponDbContext>(options =>
		{
			options.UseSqlServer(cnn);
		});
		services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
	}
}