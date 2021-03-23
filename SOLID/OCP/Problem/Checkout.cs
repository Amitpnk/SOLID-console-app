namespace OCP.Problem
{
    public class Checkout
    {
        public string Merchant { get; set; }

        public double CalculateShippingCost(double orderAmount)
        {
            double shippingCost = 0;
            switch (Merchant)
            {
                case "Flipkart":
                    shippingCost = orderAmount + (orderAmount * 0.10);
                    break;
                case "Amazon":
                    shippingCost = orderAmount + (orderAmount * 0.05);
                    break;
                default:
                    break;
            }
            return shippingCost;
        }

    }
}
