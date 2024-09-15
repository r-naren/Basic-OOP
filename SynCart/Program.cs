using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
namespace SynCart;
class Program
{
    //object creation for classes
    public static List<CustomerDetails> customerDetails = new List<CustomerDetails>();
    public static List<OrderDetails> orderDetails = new List<OrderDetails>();
    public static List<ProductDetails> productDetails = new List<ProductDetails>();
    const string wrongInput = "!!!! ";
    public static void Main(string[] args)
    {
        //Assigning default values to the lists
        DefaultValuesAssigning();
        bool temp;
        int choice = 0;
        Console.WriteLine("---------------------------SynCart---------------------------");
        do
        {
            Console.WriteLine("-------------------------MAIN MENU--------------------------");
            Console.WriteLine("1.Customer Registration\n2.Login\n3.Exit");
            Console.Write("Enter any of the above mentioned choices : ");
            temp = int.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 1:
                    {
                        CustomerRegistration();
                        break;
                    }
                case 2:
                    {
                        Login();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Exiting Application .....");
                        break;
                    }
                default:
                    {
                        Console.WriteLine(wrongInput + " Enter a valid choice ");
                        break;
                    }
            }
            if (!temp)
            {
                Console.WriteLine($"Enter valid choice");

            }
        } while (choice != 3);
        Console.WriteLine();
    }
    public static void DefaultValuesAssigning()
    {
        ProductDetails product1 = new ProductDetails("Mobile (Samsung)", 10, 10000, 3);
        ProductDetails product2 = new ProductDetails("Tablet (Lenovo)", 5, 15000, 2);
        ProductDetails product3 = new ProductDetails("Camara (Sony)", 3, 20000, 4);
        ProductDetails product4 = new ProductDetails("iPhone", 5, 50000, 6);
        ProductDetails product5 = new ProductDetails("Laptop (Lenovo I3)", 3, 40000, 3);
        ProductDetails product6 = new ProductDetails("HeadPhone (Boat)", 5, 1000, 2);
        ProductDetails product7 = new ProductDetails("Speakers (Boat)", 4, 500, 2);
        productDetails.Add(product1);
        productDetails.Add(product2);
        productDetails.Add(product3);
        productDetails.Add(product4);
        productDetails.Add(product5);
        productDetails.Add(product6);
        productDetails.Add(product7);
        CustomerDetails customer1 = new CustomerDetails("Ravi", "Chennai", "9885858588", "ravi@mail.com", 50000);
        CustomerDetails customer2 = new CustomerDetails("Baskaran", "Chennai", "9888475757", "baskaran@mail.com", 60000);
        customerDetails.Add(customer1);
        customerDetails.Add(customer2);
        OrderDetails order1 = new OrderDetails("CID1001", "PID101", 20000, DateTime.Now, 2, OrderStatus.Ordered);
        OrderDetails order2 = new OrderDetails("CID1002", "PID103", 40000, DateTime.Now, 2, OrderStatus.Ordered);
        orderDetails.Add(order1);
        orderDetails.Add(order2);
    }
    public static void CustomerRegistration()
    {
        //Declaring registration details variables
        bool temp;
        string customerName, city, phoneNumber, mailID;
        double walletBalance;
        //Customer's name
        Console.Write("Enter Customer's Name : ");
        customerName = Console.ReadLine();
        if (string.IsNullOrEmpty(customerName))
        {
            Console.WriteLine("Customer's name can't be empty " + wrongInput);
            return;
        }
        //City name
        Console.Write("Enter City Name : ");
        city = Console.ReadLine();
        if (string.IsNullOrEmpty(city))
        {
            Console.WriteLine("City name can't be empty " + wrongInput);
            return;
        }

        //Phone Number

        Console.Write("Enter Phone number : ");
        phoneNumber = Console.ReadLine();
        const string phonePattern = "[6-9]{1}[0-9]{9}";
        if (!string.IsNullOrEmpty(phoneNumber))
        {

            System.Text.RegularExpressions.Regex phoneCheck = new System.Text.RegularExpressions.Regex(phonePattern);
            if (!phoneCheck.IsMatch(phoneNumber))
            {
                Console.WriteLine("Enter valid mobile number " + wrongInput);
                return;
            }
        }
        else
        {
            Console.WriteLine("Phone number can't be empty");
            return;
        }

        //Mail ID

        Console.Write("Enter Mail Id : ");
        mailID = Console.ReadLine();
        const string mailPattern = @"^[A-Za-z0-9._-]+@[A-Za-z0-9.]+\.[A-Za-z]{2,5}$";
        if (!string.IsNullOrEmpty(mailID))
        {
            temp = false;
            System.Text.RegularExpressions.Regex mailCheck = new System.Text.RegularExpressions.Regex(mailPattern);
            if (!mailCheck.IsMatch(mailID))
            {
                Console.WriteLine("Enter valid mail Id " + wrongInput);
                return;
            }
        }
        else
        {
            Console.WriteLine("Email ID can't be empty");
            return;
        }

        //Enter wallet balance

        Console.Write("Enter Wallet balance : ");
        temp = double.TryParse(Console.ReadLine(), out walletBalance);
        if (!temp || walletBalance == 0)
        {
            Console.WriteLine("Enter valid balance amount " + wrongInput);
            return;
        }
        if (walletBalance < 0)
        {
            Console.WriteLine("Balance should not be negative " + wrongInput);
            return;
        }

        CustomerDetails customer = new CustomerDetails(customerName, city, phoneNumber, mailID, walletBalance);
        customerDetails.Add(customer);
        Console.WriteLine($"Customer Registered Successfully and CustomerID is  {customer.CustomerID}. Kindly note it and press enter.");
        Console.ReadKey();
    }
    public static void Login()
    {
        //Checking if student id is present or not
        string customerID;
        CustomerDetails temp;
        Console.Write("Enter Customer Id for login: ");
        customerID = Console.ReadLine().ToUpper();
        //lambda expression
        temp = customerDetails.Find(c => c.CustomerID == customerID);
        if (temp == null)
        {
            Console.WriteLine("Invalid Customer ID " + wrongInput);
            return;
        }
        LoginOperation(temp);
    }
    public static void LoginOperation(CustomerDetails customer)
    {
        Console.WriteLine($"Welcome {customer.CustomerName} ......");
        int choice = 0;
        do
        {
            Console.WriteLine("------------------------SUB MENU------------------------");
            Console.WriteLine("1.Purchase\n2.Order History\n3.Cancel order\n4.Wallet balance\n5.Wallet recharge\n6.Exit");
            Console.Write("Enter any of the above mentioned choices : ");
            int.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 1:
                    {
                        Purchase(customer);
                        break;
                    }
                case 2:
                    {
                        OrderHistory(customer);
                        break;
                    }
                case 3:
                    {
                        CancelOrder(customer);
                        break;
                    }
                case 4:
                    {
                        CustomerDetails.WalletBalanceCheck(customer);
                        break;
                    }
                case 5:
                    {
                        WalletRecharge(customer);
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine($"Logging out from {customer.CustomerID}. Entering Main Menu ");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Enter a valid choice" + wrongInput);
                        break;
                    }
            }
        } while (choice != 6);
    }

    public static void Purchase(CustomerDetails customer)
    {
        bool flag = false;
        foreach (ProductDetails temp in productDetails)
        {
            if (temp.Stock > 0)
            {
                flag = true;
            }
        }
        if (flag)
        {
            Console.WriteLine($"Product ID\t|  Product Name\t\t | Availabe stocks\t| Price Per Quantity\t| Shipping duration ");
            foreach (ProductDetails temp in productDetails)
            {
                if (temp.Stock > 0)
                {
                    Console.WriteLine($"{temp.ProductID}\t\t| {temp.ProductName}   \t\t | \t{temp.Stock}\t\t| \t{temp.Price}\t\t|\t   {temp.Duration}");
                }
                else
                {
                    Console.WriteLine($"{temp.ProductID}\t\t| {temp.ProductName}   \t | \t{temp.Stock}\t\t| \t{temp.Price} \t\t|\t   {temp.Duration}");
                }
            }
        }
        else
        {
            Console.WriteLine($"There is no products to display");
        }
        string productId;
        int quantity;
        double totalPrice;
        int i;

        Console.Write("Enter Product ID you wish to purchase : ");
        productId = Console.ReadLine().ToUpper();
        if (string.IsNullOrEmpty(productId))
        {
            Console.WriteLine("Product ID can't be empty " + wrongInput);
        }
        else
        {
            for (i = 0; i < productDetails.Count; i++)
            {
                if (productDetails[i].ProductID == productId)
                {
                    Console.Write("Enter count you wish to purchase : ");
                    flag = int.TryParse(Console.ReadLine(), out quantity);
                    if (productDetails[i].Stock >= quantity && quantity > 0)
                    {
                        totalPrice = (quantity * productDetails[i].Price) + 50;
                        if (totalPrice <= customer.WalletBalance)
                        {
                            customer.WalletBalance -= totalPrice;
                            productDetails[i].Stock -= quantity;
                            OrderDetails order = new OrderDetails(customer.CustomerID, productDetails[i].ProductID, totalPrice, DateTime.Now, quantity, OrderStatus.Ordered);
                            orderDetails.Add(order);
                            Console.WriteLine($"Order placed successfully. Order ID: {order.OrderID}");
                            DateTime delivery = DateTime.Now;
                            delivery = delivery.AddDays(productDetails[i].Duration);
                            Console.WriteLine($"Your order will be delivered on {delivery.ToString("dd/MM/yyyy")}.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do purchase again.");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Required count not available. Current availability is {productDetails[i].Stock}");
                        break;
                    }
                }
            }
            if (i == productDetails.Count)
            {
                Console.WriteLine("Invalid Product ID " + wrongInput);
            }
        }

    }
    public static void OrderHistory(CustomerDetails customer)
    {
        OrderDetails temp = orderDetails.Find(o => o.CustomerID == customer.CustomerID);
        if (temp != null)
        {
            Console.WriteLine("Order Id\t| Customer ID\t| Product ID\t| Total Price\t| Purchase Date\t| Quantity\t| Order Status");
            foreach (OrderDetails order in orderDetails)
            {
                if (order.CustomerID == customer.CustomerID)
                {
                    Console.WriteLine($"{order.OrderID}\t\t|   {order.CustomerID}\t|   {order.ProductID}\t|   {order.TotalPrice}\t|  {order.PurchaseDate.ToString("dd/MM/yyyy")}\t|    {order.Quantity}\t\t|   {order.OrderStatus}");
                }
            }
        }
        else
        {
            Console.WriteLine($"There is no order History.");
        }
    }
    public static void CancelOrder(CustomerDetails customer)
    {
        string orderID;
        bool temp = false;
        OrderDetails order1 = orderDetails.Find(o => o.CustomerID == customer.CustomerID);
        if (order1 != null)
        {
            Console.WriteLine("Order Id\t| Customer ID\t| Product ID\t| Total Price\t| Purchase Date\t| Quantity\t| Order Status");

            foreach (OrderDetails order in orderDetails)
            {
                if (order.CustomerID == customer.CustomerID && order.OrderStatus == OrderStatus.Ordered)
                {
                    Console.WriteLine($"{order.OrderID}\t\t|   {order.CustomerID}\t|   {order.ProductID}\t|   {order.TotalPrice}\t|  {order.PurchaseDate.ToString("dd/MM/yyyy")}\t|    {order.Quantity}\t\t|   {order.OrderStatus}");
                }
            }

            Console.Write("Enter Order ID you wish to cancel : ");
            orderID = Console.ReadLine().ToUpper();
            if (string.IsNullOrEmpty(orderID))
            {
                Console.WriteLine("Order ID can't be empty " + wrongInput);
            }
            else
            {
                foreach (OrderDetails order in orderDetails)
                {
                    if (order.CustomerID == customer.CustomerID && order.OrderID == orderID && order.OrderStatus == OrderStatus.Ordered)
                    {
                        foreach (ProductDetails product in productDetails)
                        {
                            if (product.ProductID == order.ProductID)
                            {
                                product.Stock += order.Quantity;
                            }
                        }
                        customer.WalletBalance += order.TotalPrice;
                        order.OrderStatus = OrderStatus.Cancelled;
                        Console.WriteLine($"Order : {order.OrderID} cancelled successfully");
                        temp = true;
                        break;
                    }
                }
                if (!temp)
                {
                    Console.WriteLine($"Invalid OrderID");
                }
            }

        }
        else
        {
            Console.WriteLine($"There is no order History to cancel.");
        }
    }
    public static void WalletRecharge(CustomerDetails customer)
    {
        string option;
        do
        {
            Console.Write("Do you want to recharge wallet yes / no : ");
            option = Console.ReadLine().ToLower();
            if (string.IsNullOrEmpty(option))
            {
                Console.WriteLine("Option can't be empty !!!!");
            }
        } while (string.IsNullOrEmpty(option));
        switch (option)
        {
            case "yes":
                {
                    CustomerDetails.WalletRecharge(customer);
                    break;
                }
            case "no":
                {
                    break;
                }
            default:
                {
                    Console.WriteLine($"Enter valid option " + wrongInput);
                    break;
                }
        }
    }
}
