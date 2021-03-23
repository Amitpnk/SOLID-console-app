using System;
using System.IO;

namespace SRP.Problem
{
    public class Customer
    {
        void Add()
        {
            try
            {
                // Adding logic
            }
            catch (Exception ex)
            {
                File.WriteAllText(@"C:\Error.txt", ex.ToString());
            }
        }
    }
}
