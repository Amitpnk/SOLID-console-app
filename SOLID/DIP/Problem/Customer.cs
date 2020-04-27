using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.Problem
{
    public class Customer
    {
        private IErrorHandling _errorHandling = new FileLogger(); // BAD
      
        public void Add()
        {
            try
            {
                // Adding logic
            }
            catch (Exception ex)
            {
                _errorHandling.Handle(ex.Message);
            }
        }
    }

    public interface IErrorHandling
    {
        void Handle(string error);
    }
    public class FileLogger : IErrorHandling
    {
        public void Handle(string error)
        {
            Console.WriteLine("file log");
        }
    }

    public class DBLogger : IErrorHandling
    {
        public void Handle(string error)
        {
            Console.WriteLine("inserting to db");
        }
    }
}
