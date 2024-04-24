using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLibrary
{
    /// <summary>
    /// DataType Status used to select a instance of <see cref="BorrowDetails" /> Book order status
    /// </summary>
    public enum Status { Default, Borrowed, Returned }
    // Class
    /// <summary>
    /// Class BorrowDetails used to create instance for Borrow details of  User <see cref="BorrowDetails" />
    /// </summary>
    public class BorrowDetails
    {
        /*
        •	BorrowID (Auto Increment – LB2000)
        •	BookID 
        •	UserID
        •	BorrowedDate – ( Current Date and Time )
        •	BorrowBookCount 
        •	Status –  ( Enum - Default, Borrowed, Returned )
        •	PaidFineAmount
        */

        //static field
        private static int s_borrowID = 2000;
        //Properties
        /// <summary>
        /// BorrowID has the count for assigning Borrowed ID which is Read-only property of instance of <see cref="BorrowDetails" />
        /// </summary>
        public string BorrowID { get; } // Read-Only property
        /// <summary>
        /// BookID has the count for assigning Book ID of instance of <see cref="BorrowDetails" />
        /// </summary>
        /// <value>String type (Ex: BID1001)</value>
        public string BookID { get; set; }
        /// <summary>
        /// UserID has the count for assigning User ID to each of instance of <see cref="BorrowDetails" />
        /// </summary>
        ///<value>String type (Ex: SF3001)</value>
        public string UserID { get; set; }
        /// <summary>
        /// BorrowedDate has the value of the username of instance of <see cref="BorrowDetails" />
        /// </summary> 
        /// <value>Date Time format (dd/MM/yyyy) </value> 
        public DateTime BorrowedDate { get; set; }
        /// <summary>
        /// BorrowBookCount has the value of the borrowed book count of instance of <see cref="BorrowDetails" />
        /// </summary> 
        /// <value>Integer type, Range :(1, 2000000000)</value>
        public int BorrowBookCount { get; set; }
        /// <summary>
        /// Staus has the value of the borrowed status from enum Status of instance of <see cref="BorrowDetails" />
        /// </summary> 
        /// <value>Status type (Borrowed, Returned)</value>
        public Status Status { get; set; }
        /// <summary>
        /// PaidFineAmount has the value of the paid fine amount of instance of <see cref="BorrowDetails" />
        /// </summary> 
        /// <value>Integer type, Range :(1, 2000000000)</value>
        public int PaidFineAmount { get; set; }
        //Constructor
        /// <summary>
        /// This parameterized constructor used to create Borrow details object for instance of <see cref="BorrowDetails" />
        /// </summary>
        /// <param name="bookID">bookID parameter used to assign its value to associated property</param>
        /// <param name="userID">userID parameter used to assign its value to associated property</param>
        /// <param name="borrowedDate">borrowedDate parameter used to assign its value to associated property</param>
        /// <param name="borrowBookCount">borrowBookCount parameter used to assign its value to associated property</param>
        /// <param name="status">status parameter used to assign its value to associated property</param>
        /// <param name="paidFineAmount">paidFineAmount parameter used to assign its value to associated property</param>
        public BorrowDetails(string bookID, string userID, DateTime borrowedDate, int borrowBookCount, Status status, int paidFineAmount)
        {
            BorrowID = "LB" + ++s_borrowID;
            BookID = bookID;
            UserID = userID;
            BorrowedDate = borrowedDate;
            BorrowBookCount = borrowBookCount;
            Status = status;
            PaidFineAmount = paidFineAmount;
        }
    }
}