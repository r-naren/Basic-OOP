using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLibrary
{
    /// <summary>
    /// DataType Gender used to select a instance of <see cref="UserDetails" /> Gender Information 
    /// </summary>
    public enum Gender { Select, Male, Female, Transgender }
    // Class
    /// <summary>
    /// Class UserDetails used to create instance for Library User <see cref="UserDetails" />
    /// </summary>
    public class UserDetails
    {
        /*
        a.	UserID (Auto Increment – SF3000)
        b.	UserName
        c.	Gender
        d.	Department – (Enum – ECE, EEE, CSE)
        e.	MobileNumber
        f.	MailID
        g.	WalletBalance
        */
        //static field
        private static int s_userID = 3000;
        //Properties
        /// <summary>
        /// UserID has the count for assigning User ID which is Read-only property of instance of <see cref="UserDetails" />
        /// </summary>
        public string UserID { get; } // Read-Only property
        /// <summary>
        /// UserName has the value of the username of instance of <see cref="UserDetails" />
        /// </summary> 
        /// <value>string type (Ex: Ravi)</value>
        public string UserName { get; set; }
        /// <summary>
        /// Gender has the value of the Gender from enum Gender of instance of <see cref="UserDetails" />
        /// </summary> 
        /// <value>Gender type (Male, Female, Transgender)</value>
        public Gender Gender { get; set; }
        /// <summary>
        /// Department has the value of the department of instance of <see cref="UserDetails" />
        /// </summary> 
        /// <value>string type (Ex. EEE)</value>
        public string Department { get; set; }
        /// <summary>
        /// MobileNumber has the value of the mobile number of instance of <see cref="UserDetails" />
        /// </summary> 
        /// <value>string type applicable for Indian number 10 digits (Ex: 9876543210)</value>
        public string MobileNumber { get; set; }
        /// <summary>
        /// MailID has the value of the mail ID of instance of <see cref="UserDetails" />
        /// </summary> 
        /// <value>string type for valid email ID(Ex: Ravi@gmail.com)</value>
        public string MailID { get; set; }
        /// <summary>
        /// WalletBalance has the value of the wallet balance of instance of <see cref="UserDetails" />
        /// </summary> 
        /// <value>Integer type, Range :(1, 2000000000)</value>
        public int WalletBalance { get; set; }
        //Constructor
        /// <summary>
        /// This parameterized constructor used to create user object for instance of <see cref="UserDetails" />
        /// </summary>
        /// <param name="userName">userName parameter used to assign its value to associated property</param> 
        /// <param name="gender">gender parameter used to assign its value to associated property</param>
        /// <param name="department">department parameter used to assign its value to associated property</param>
        /// <param name="mobileNumber">mobileNumber parameter used to assign its value to associated property</param>
        /// <param name="mailID">mailID parameter used to assign its value to associated property</param>
        /// <param name="walletBalance">walletBalance parameter used to assign its value to associated property</param>
        public UserDetails(string userName, Gender gender, string department, string mobileNumber, string mailID, int walletBalance)
        {
            UserID = "SF" + ++s_userID;
            UserName = userName;
            Gender = gender;
            Department = department;
            MobileNumber = mobileNumber;
            MailID = mailID;
            WalletBalance = walletBalance;
        }
        /// <summary>
        /// Method UpdateWalletBalance used to add money to their wallet instance of <see cref="UserDetails" />
        /// </summary>
        /// <param name="amount">This amount is used to update to wallet</param>
        public void UpdateWalletBalance(int amount)
        {
            WalletBalance += amount;
            Console.WriteLine($"Updated wallet balance is Rs.{WalletBalance}");
        }
        /// <summary>
        /// Method DeductWalletBalance used to detect money from their wallet instance of <see cref="UserDetails" />
        /// </summary>
        /// <param name="amount">This amount is used to detect from wallet</param>
        public void DeductWalletBalance(int amount)
        {
            WalletBalance -= amount;
            Console.WriteLine($"After deduction wallet balance is Rs.{WalletBalance}");
        }

    }
}