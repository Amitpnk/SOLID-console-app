using System;

namespace DIP.Solution
{
    public class Customer
    {
        private IErrorHandling _errorHandling;
        public Customer(IErrorHandling errorHandling)
        {
            _errorHandling = errorHandling;
        }
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
