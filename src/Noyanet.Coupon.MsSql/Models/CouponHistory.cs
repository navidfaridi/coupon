namespace Noyanet.Coupon.MsSql.Models;

public partial class CouponHistory
{
    public long Id { get; set; }

    public string CouponCode { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string ServiceOrgin { get; set; } = null!;

    public DateTime Created { get; set; }

    public virtual CouponInfo CouponCodeNavigation { get; set; } = null!;
}
