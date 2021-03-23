namespace OCP.Solution
{
    public class Checkout
    {
        public virtual double CalculateShippingCost(double orderAmount)
        {
            return orderAmount;
        }
    }

    class Flipkart : Checkout
    {
        public override double CalculateShippingCost(double orderAmount)
        {
            return orderAmount + (orderAmount * 0.10);
        }
    }

    class Amazon : Checkout
    {
        public override double CalculateShippingCost(double orderAmount)
        {
            return orderAmount + (orderAmount * 0.05);
        }
    }
}
