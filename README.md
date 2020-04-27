
# SOLID

SOLID are five basic principles which helps to create good software architecture. 
SOLID is an acronym.

* S - [SRP (Single responsiblity principle)](#single-responsibility-principle)
* O - [OCP (Open closed principle)](#open-closed-principle)
* L - [LSP (Liskov substitution principle)](#liskov-substitution-principle)
* I - [ISP (Interface segragation principle)](#interface-segragation-principle)
* D - [DIP (Dependency inversion principle)](#dependency-inversion-principle)

## Single Responsibility Principle

SRP says that class should have only one responsiblity and not mulitple

### Problem

Customer Add method does mulitple responsiblity, where it will have adding and error handling logic

```c#
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
```

### Solution

Solution is by not violating the single responsibility principle. Now we abstract the logger, so its writing the error logic.

```c#
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
            FileLogger logger = new FileLogger();
            logger.Handle(ex.Message);
        }
    }
}

public class FileLogger
{
    public void Handle(string error)
    {
        File.WriteAllText(@"C:\Error.txt", error);
    }
}
```

## Open closed principle

Open for Extension Closed for Modification

### Problem

Violating Open Closed Principle, because if we need to add another company (like big basket) we need to modify existing code in switch statement

```c#
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
```

### Solution

Creating inheritance and making easy to modification by adding derived class without touching existing class 

```c#
public class Checkout
{
    public virtual double CalculateShippingCost(double orderAmount)
    {
        return orderAmount;
    }
}

class Flipkart : Checkout
{
    public override double CalculateShippingCost(double orderAmount)
    {
        return orderAmount + (orderAmount * 0.10);
    }
}

class Amazon : Checkout
{
    public override double CalculateShippingCost(double orderAmount)
    {
        return orderAmount + (orderAmount * 0.05);
    }
}
```

## Liskov substitution principle

Parent class should be able to refer child objects seamlessly during runtime polymorphism

### Problem

For COD transaction there is no need to check balanace and deduct amount, but still client is using it 

```c#
abstract class Payment
{
    public abstract void CheckBalance();

    public abstract void DeductAmount();

    public abstract void ProcessTransaction();

}

class Paypal : Payment
{
    public override void CheckBalance()
    {
        Console.WriteLine("CheckBalance Method Called");
    }

    public override void DeductAmount()
    {
        Console.WriteLine("DeductAmount Method Called");
    }

    public override void ProcessTransaction()
    {
        Console.WriteLine("ProcessTransaction Method Called");
    }
}

class COD : Payment
{
    public override void CheckBalance()
    {
        throw new NotImplementedException();
    }

    public override void DeductAmount()
    {
        throw new NotImplementedException();
    }

    public override void ProcessTransaction()
    {
        Console.WriteLine("ProcessTransaction Method Called");
    }
}
```

### Solution

As COD transaction is only need to do transaction, no need of check balance and deduct amount, we can use interface and implement based on secarnio 

```c#
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
```

## Interface segragation principle

Show only those methods to client which they need. 

### Problem

If we want to add more functionality, don't add to existing interfaces, segregate them out.

```c#
public interface ICustomer
{
    void Add();
    void Read(); // Adding read method to existing Functionality is BAD
}
```

### Solution

Just create another interface, and extend from it

```c#
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
```

## Dependency inversion principle

High level modules should not depend on low-level modules, but should depend on abstraction

### Problem

We are relying on the customer to say that we are using a File Logger, rather than another type of logger, e.g. EmailLogger.

```C#
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
```

## Solution 

We pass in a Logger interface to the customer so it doesnt know what type of logger it is

```c#
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
```

```c#
static void Main(string[] args)
{

    Solution.Customer customer = new Solution.Customer(new Solution.FileLogger());
    customer.Add();
}
```