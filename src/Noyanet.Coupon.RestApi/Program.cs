using Noyanet.Core.ApiVersioning;
//using Noyanet.Core.SerilogIntegration;
using Noyanet.Coupon.MsSql;
using Noyanet.Coupon.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMsSqlDb(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerService();

//builder.Services.AddSerilog(builder.Configuration);
//builder.Host.UseSerilog("coupon-api", "coupon-api");

builder.Services.AddCouponServices();


var app = builder.Build();

app.UseSwaggerVersioned();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
