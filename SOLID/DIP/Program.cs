namespace DIP
{
    class Program
    {
        static void Main(string[] args)
        {

            Solution.Customer customer = new Solution.Customer(new Solution.FileLogger());
            customer.Add();
        }
    }
}
