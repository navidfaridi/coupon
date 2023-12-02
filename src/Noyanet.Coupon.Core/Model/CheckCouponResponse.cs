namespace Noyanet.Coupon.Core.Model
{
    public class CheckCouponResponse
    {
        public bool IsExist { get; set; }
        public bool IsAvailable { get; set; }
        public CouponModel Coupon { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}