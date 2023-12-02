using System;

namespace Noyanet.Coupon.Core.Model
{
    public class CouponModel
    {
        public string Code { get; set; } = null!;
        public CouponType Type { get; set; } 
        public int Value { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int MaxUsageCount { get; set; }
        public int? UsageCount { get; set; }
    }
}