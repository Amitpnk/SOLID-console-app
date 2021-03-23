using System;

namespace OCP
{
    class Program
    {
        static void Main(string[] args)
        {
            Problem.Checkout checkoutP = new Problem.Checkout();
            checkoutP.Merchant = "Amazon";
            Console.WriteLine($"Shipping cost : {checkoutP.CalculateShippingCost(10)} ");

            Solution.Checkout checkoutS = new Solution.Amazon();
            Console.WriteLine($"Shipping cost : {checkoutS.CalculateShippingCost(10)} ");

            Console.ReadKey();
        }
    }
}
