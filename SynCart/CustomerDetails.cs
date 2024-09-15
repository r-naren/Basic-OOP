using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public class CustomerDetails
    {
        private static int s_customerID = 1000;
        public string CustomerID { get; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string MobileNumber { get; set; }
        public double WalletBalance { get; set; }
        public string EmailID { get; set; }
        public CustomerDetails(string customerName, string city, string mobileNumber, string emailID, double walletBalance)
        {
            CustomerID = "CID" + ++s_customerID;
            CustomerName = customerName;
            City = city;
            MobileNumber = mobileNumber;
            WalletBalance = walletBalance;
            EmailID = emailID;
        }
        public static void WalletBalanceCheck(CustomerDetails customer)
        {
            Console.WriteLine($"Available Total Wallet balance : {customer.WalletBalance}");
        }
        public static void WalletRecharge(CustomerDetails customer)
        {
            bool temp;
            double amountToRecharge;
            do
            {
                Console.Write("Enter amount to recharge : ");
                temp = double.TryParse(Console.ReadLine(), out amountToRecharge);
                if (!temp || amountToRecharge == 0)
                {
                    Console.WriteLine("Enter valid amount to recharge !!!!");
                }
                if (amountToRecharge < 0)
                {
                    Console.WriteLine("Amount should not be negative !!!!");
                }
            } while (amountToRecharge <= 0 || !temp);
            customer.WalletBalance+=amountToRecharge;
            Console.WriteLine($"Update wallet balance : {customer.WalletBalance}");
        }
    }
}