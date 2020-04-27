using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
