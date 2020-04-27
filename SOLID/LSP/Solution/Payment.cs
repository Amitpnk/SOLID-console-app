using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP.Solution
{
    interface IPaymentTransaction
    {
          void ProcessTransaction();

    }

    interface IPaymentCheckBalance
    {
        void CheckBalance();
        void DeductAmount();
    }

    class Paypal : IPaymentTransaction, IPaymentCheckBalance
    {
        public void CheckBalance()
        {
            Console.WriteLine("CheckBalance Method Called");
        }

        public void DeductAmount()
        {
            Console.WriteLine("DeductAmount Method Called");
        }

        public   void ProcessTransaction()
        {
            Console.WriteLine("ProcessTransaction Method Called");
        }
    }

    class COD : IPaymentTransaction
    {
        public   void ProcessTransaction()
        {
            Console.WriteLine("ProcessTransaction Method Called");
        }
    }
}
