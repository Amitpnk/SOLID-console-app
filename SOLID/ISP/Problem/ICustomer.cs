using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.Problem
{
    public interface ICustomer
    {
        void Add();
        void Read(); // Adding read method to existing Functionality is BAD
    }

    class Client : ICustomer
    {
        public void Add()
        {
            Console.WriteLine("Add functionality");
        }

        // Adding read method to existing Functionality is BAD
        public void Read()
        {
            Console.WriteLine("Read functionality");
        }
    }

}
