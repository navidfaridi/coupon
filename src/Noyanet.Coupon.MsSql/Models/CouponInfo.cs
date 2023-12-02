namespace Noyanet.Coupon.MsSql.Models;

public partial class CouponInfo
{
    public CouponInfo()
    {
        CouponHistories = new List<CouponHistory>();
    }
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public byte CouponType { get; set; }

    public int CouponValue { get; set; }

    public DateTime Created { get; set; }

    public short MaxUsage { get; set; }

    public short? UsageCount { get; set; }

    public DateTime? ExpireDate { get; set; }

    public Guid UniqueId { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<CouponHistory> CouponHistories { get; set; } = new List<CouponHistory>();
}
