namespace Noyanet.Coupon.Core.Model
{
    public class UseCouponResponse
    {
        public bool Result { get; set; }
        public CouponModel CouponInfo { get; set; }
        public string ErrorCode { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}