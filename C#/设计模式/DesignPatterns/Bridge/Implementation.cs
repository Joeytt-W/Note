namespace Bridge
{
    /// <summary>
    /// Abstraction
    /// </summary>
    public abstract class Menu
    {
        public readonly ICoupon _coupon = null;

        public Menu(ICoupon coupon)
        {
            _coupon = coupon;
        }

        public abstract int CalculatePrice();
    }

    /// <summary>
    /// Implementor
    /// </summary>
    public interface ICoupon
    {
        public int CouponValue { get; }
    }

    public class NoCoupon : ICoupon
    {
        public int CouponValue => 0;
    }

    public class OneEuroCoupon : ICoupon
    {
        public int CouponValue => 1;
    }

    public class TwoEuroCoupon : ICoupon
    {
        public int CouponValue => 2;
    }


    public class VegetarianMenu : Menu
    {
        public VegetarianMenu(ICoupon coupon):base(coupon)
        {

        }

        public override int CalculatePrice()
        {
            return 20 - _coupon.CouponValue;
        }
    }

    public class MeatBasedMenu : Menu
    {
        public MeatBasedMenu(ICoupon coupon) : base(coupon)
        {

        }

        public override int CalculatePrice()
        {
            return 30 - _coupon.CouponValue;
        }
    }
}
