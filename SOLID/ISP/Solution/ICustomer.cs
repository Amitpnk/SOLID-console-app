using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.Solution
{
    public interface ICustomer
    {
        void Add();
    }

    public interface ICustomerRead : ICustomer
    {
        void Read();
    }

    class Client : ICustomer, ICustomerRead
    {
        public void Add()
        {
            Console.WriteLine("Add functionality");
        }

        public void Read()
        {
            Console.WriteLine("Read functionality");
        }
    }
}
