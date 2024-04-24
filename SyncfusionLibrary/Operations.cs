using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SyncfusionLibrary
{
    public static class Operations
    {
        static UserDetails currentLoggedInUser;
        //Static list
        static List<UserDetails> usersList = new List<UserDetails>();
        static List<BookDetails> booksList = new List<BookDetails>();
        static List<BorrowDetails> borrowList = new List<BorrowDetails>();
        public static void AddDefaultData()
        {
            // Adding default data 
            UserDetails user1 = new UserDetails("Ravichandran", Gender.Male, "EEE", "9938388333", "ravi@gmail.com", 100);
            UserDetails user2 = new UserDetails("Priyadharshini", Gender.Female, "CSE", "9944444455", "priya@gmail.com", 150);
            usersList.Add(user1);
            usersList.Add(user2);
            BookDetails book1 = new BookDetails("C#", "Author1", 3);
            BookDetails book2 = new BookDetails("HTML", "Author2", 5);
            BookDetails book3 = new BookDetails("CSS", "Author1", 3);
            BookDetails book4 = new BookDetails("JS", "Author1", 3);
            BookDetails book5 = new BookDetails("TS", "Author2", 2);
            booksList.Add(book1);
            booksList.Add(book2);
            booksList.Add(book3);
            booksList.Add(book4);
            booksList.Add(book5);
            BorrowDetails borrow1 = new BorrowDetails("BID1001", "SF3001", new DateTime(2023, 09, 10), 2, Status.Borrowed, 0);
            BorrowDetails borrow2 = new BorrowDetails("BID1003", "SF3001", new DateTime(2023, 09, 12), 1, Status.Borrowed, 0);
            BorrowDetails borrow3 = new BorrowDetails("BID1004", "SF3001", new DateTime(2023, 09, 14), 1, Status.Returned, 16);
            BorrowDetails borrow4 = new BorrowDetails("BID1002", "SF3002", new DateTime(2023, 09, 11), 2, Status.Borrowed, 0);
            BorrowDetails borrow5 = new BorrowDetails("BID1005", "SF3002", new DateTime(2023, 09, 09), 1, Status.Returned, 20);
            borrowList.Add(borrow1);
            borrowList.Add(borrow2);
            borrowList.Add(borrow3);
            borrowList.Add(borrow4);
            borrowList.Add(borrow5);
        } // Add default data ends
        public static void MainMenu()
        {
            Console.WriteLine($"***************Welcome to Syncfusion Library***************");
            int choice = 0;
            bool flag;
            do
            {
                // Iterate until user gives exit
                Console.WriteLine($"----------Main Menu----------");
                Console.WriteLine($"1. User Registration\n2. User Login\n3. Exit");
                Console.Write("Select any one of the options above : ");
                flag = int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine($"*********User Registration********");
                            UserRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"*********User Login********");
                            UserLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine($"Exiting the application");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine($"Enter valid option.");
                            break;
                        }
                }
            } while (choice != 3);
        }// Mainmenu ends
        public static void UserRegistration()
        {
            bool flag = false;
            Gender gender;
            string department, mobileNumber, mailID;
            int walletBalance;
            //Need to get data from user
            Console.Write($"Enter User Name : ");
            string userName = Console.ReadLine();
            if (!string.IsNullOrEmpty(userName))
            {
                Console.Write("Enter Gender (Male/Female/Transgender) : ");
                flag = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);
                if (flag)
                {
                    Console.Write($"Enter Department : ");
                    department = Console.ReadLine();
                    if (!string.IsNullOrEmpty(department))
                    {
                        Console.Write("Enter mobile Number : ");
                        mobileNumber = Console.ReadLine();
                        System.Text.RegularExpressions.Regex phoneCheck = new System.Text.RegularExpressions.Regex(@"[6-9]{1}[0-9]{9}$");
                        if (phoneCheck.IsMatch(mobileNumber) && mobileNumber.Length == 10)
                        {
                            Console.Write($"Enter Mail ID: ");
                            mailID = Console.ReadLine();
                            System.Text.RegularExpressions.Regex mailCheck = new System.Text.RegularExpressions.Regex(@"^[A-Za-z0-9._-]+@[A-Za-z0-9.]+[A-Za-z]{2,5}$");

                            if (mailCheck.IsMatch(mailID))
                            {
                                Console.Write($"Enter wallet balance : ");
                                flag = int.TryParse(Console.ReadLine(), out walletBalance);
                                if (flag && walletBalance > 0)
                                {
                                    // Create  object and add them
                                    UserDetails user1 = new UserDetails(userName, gender, department, mobileNumber, mailID, walletBalance);
                                    usersList.Add(user1);
                                    Console.WriteLine($"User Registered successfully and User ID is {user1.UserID}.");
                                }
                                else
                                {
                                    Console.WriteLine($"Enter valid wallet balance");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Enter Valid mail ID");

                            }
                        }
                        else
                        {
                            Console.WriteLine($"Enter valid Mobile Number");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Enter valid department");
                    }
                }
                else
                {
                    Console.WriteLine($"Enter valid Gender");
                }
            }
            else
            {
                Console.WriteLine($"Enter valid userName.");
            }
        }// User registration ends
        public static void UserLogin()
        {
            string userID;
            bool flag = false;
            Console.Write($"Enter User ID for login : ");
            userID = Console.ReadLine().ToUpper();
            foreach (UserDetails user in usersList)
            {
                if (user.UserID.Equals(userID))
                {
                    flag = true;
                    currentLoggedInUser = user;
                    Console.WriteLine($"Logged in Successfully");
                    SubMenu();
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine($"Enter valid User ID or User ID is not present.");
            }
        }//userLogin ends
        public static void SubMenu()
        {
            int choice = 0;
            bool flag;
            do
            {
                // Iterate until user gives exit option
                Console.WriteLine($"----------Sub Menu----------");
                Console.WriteLine($"1. Borrow Book\n2. Show Borrowed History\n3. Return Books\n4. Wallet Recharge\n5. Exit");
                Console.Write("Select any one of the options above : ");
                flag = int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine($"*********Borrow book********");
                            BorrowBook();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"*********Show Borrowed History********");
                            ShowBorrowedHistory();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine($"*********Return Books********");
                            ReturnBooks();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine($"*********Wallet Recharge********");
                            WalletRecharge();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine($"Logout Successful. Exiting to Main Menu.");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine($"Enter valid option.");
                            break;
                        }
                }
            } while (choice != 5);
        } // SubMenu ends
        public static void BorrowBook()
        {
            bool flag = true, isValid;
            string bookID;
            // Checking whether book os present or not
            foreach (BookDetails book in booksList)
            {
                if (book.BookCount > 0)
                {
                    flag = false;
                    break;
                }
            }
            if (!flag)
            {
                string line = "------------------------------------------------------";
                Console.WriteLine(line);
                Console.WriteLine($"| {"Book ID",-8}|   {"Book Name",-12}|  {"Author Name",-13}|{"Book count",-10}|");
                Console.WriteLine(line);
                foreach (BookDetails book in booksList)
                {
                    Console.WriteLine($"| {book.BookID,-8}|     {book.BookName,-10}|    {book.AuthorName,-11}|    {book.BookCount,-6}|");
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine($"There are no books available.");
            }
            flag = false;
            Console.Write($"Enter Book ID to borrow : ");
            bookID = Console.ReadLine().ToUpper();
            int count = 0, bookCount;
            foreach (BookDetails book in booksList)
            {
                if (book.BookCount >= 0 && book.BookID.Equals(bookID))
                {
                    flag = true;
                    Console.Write($"Enter count of the book you wish to purchase : ");
                    isValid = int.TryParse(Console.ReadLine(), out bookCount);
                    if (isValid)
                    {
                        if (book.BookCount >= bookCount)
                        {
                            //whether borrowed any books
                            foreach (BorrowDetails borrow in borrowList)
                            {
                                if (borrow.UserID.Equals(currentLoggedInUser.UserID) && borrow.Status.Equals(Status.Borrowed))
                                {
                                    count += borrow.BorrowBookCount;
                                }
                            }
                            if (count > 3)
                            {
                                Console.WriteLine($"You have borrowed 3 books already");
                                break;
                            }
                            else
                            {
                                if (count + bookCount > 3)
                                {
                                    Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {count} and requested count is {count + bookCount}, which exceeds 3 ");
                                    break;
                                }
                                else
                                {
                                    BorrowDetails borrow = new BorrowDetails(book.BookID, currentLoggedInUser.UserID, DateTime.Now, bookCount, Status.Borrowed, 0);
                                    borrowList.Add(borrow);
                                    book.BookCount -= bookCount;
                                    Console.WriteLine($"Book borrowed successfully and ID is {borrow.BorrowID}");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            //if book count not available in library
                            Console.WriteLine($"Books are not available for the selected count. Only {book.BookCount} is available.");
                            foreach (BorrowDetails borrow in borrowList)
                            {
                                if (borrow.BookID.Equals(book.BookID) && borrow.Status.Equals(Status.Borrowed))
                                {
                                    Console.WriteLine($"The book will be available on {borrow.BorrowedDate.AddDays(15).ToString("dd/MM/yyyy")}");
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Enter valid book count to borrow.");
                        break;
                    }
                }
            }
            if (!flag)
            {
                Console.WriteLine($"Enter valid Book ID or Book ID is not present.");
            }
        } //Borrow book ends 
        public static void ShowBorrowedHistory()
        {
            bool flag = true;
            foreach (BorrowDetails borrow in borrowList)
            {
                if (borrow.UserID.Equals(currentLoggedInUser.UserID))
                {
                    flag = false;
                    break;
                }
            }
            if (!flag)
            {
                string line = "---------------------------------------------------------------------------------------------";
                Console.WriteLine(line);
                Console.WriteLine($"|{"Borrow ID",-9}| {"Book ID",-8}| {"User ID",-8}| {"Borrowed Date",-14}|{"Borrow Book Count",-17}|  {"Status",-8}|{"Paid Fine Amount",-15}|");
                Console.WriteLine(line);
                foreach (BorrowDetails borrow in borrowList)
                {
                    if (borrow.UserID.Equals(currentLoggedInUser.UserID))
                    {
                        Console.WriteLine($"|  {borrow.BorrowID,-7}| {borrow.BookID,-8}| {borrow.UserID,-8}|  {borrow.BorrowedDate.ToString("dd/MM/yyyy"),-13}|        {borrow.BorrowBookCount,-9}| {borrow.Status,-9}|       {borrow.PaidFineAmount,-9}|");
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine($"User didn't borrowed any books yet");
            }

        } // show borrowed histroy ends
        public static void ReturnBooks()
        {
            bool flag = true;
            foreach (BorrowDetails borrow in borrowList)
            {
                if (borrow.UserID.Equals(currentLoggedInUser.UserID))
                {
                    flag = false;
                    break;
                }
            }
            if (!flag)
            {
                string line = "-----------------------------------------------------------------------------------------------------------------------";
                Console.WriteLine(line);
                Console.WriteLine($"|{"Borrow ID",-9}| {"Book ID",-8}| {"User ID",-8}| {"Borrowed Date",-14}|{"Borrow Book Count",-17}|  {"Status",-8}|{"Paid Fine Amount",-15}| {"Return Date",-12}|{"Fine Amount",-11}|");
                Console.WriteLine(line);
                int fine = 0;
                // Display borrowed history only
                foreach (BorrowDetails borrow in borrowList)
                {
                    if (borrow.UserID.Equals(currentLoggedInUser.UserID) && borrow.Status.Equals(Status.Borrowed))
                    {
                        TimeSpan span = DateTime.Now - borrow.BorrowedDate;
                        if ((int)span.TotalDays <= 15)
                        {
                            fine = 0;
                        }
                        else
                        {
                            fine = (int)span.TotalDays - 15;
                        }
                        Console.WriteLine($"|  {borrow.BorrowID,-7}| {borrow.BookID,-8}| {borrow.UserID,-8}|  {borrow.BorrowedDate.ToString("dd/MM/yyyy"),-13}|        {borrow.BorrowBookCount,-9}| {borrow.Status,-9}|       {borrow.PaidFineAmount,-9}| {borrow.BorrowedDate.AddDays(15).ToString("dd/MM/yyyy"),-12}|    {fine,-7}|");
                        Console.WriteLine(line);
                    }
                }
                flag = false;
                Console.Write($"Enter Borrow ID you wish to cancel : ");
                string borrowedID = Console.ReadLine().ToUpper();
                foreach (BorrowDetails borrow in borrowList)
                {
                    //fine needed or not
                    if (borrow.UserID.Equals(currentLoggedInUser.UserID) && borrow.Status.Equals(Status.Borrowed) && borrow.BorrowID.Equals(borrowedID))
                    {
                        flag = true;
                        TimeSpan span = DateTime.Now - borrow.BorrowedDate;
                        if ((int)span.TotalDays <= 15)
                        {
                            fine = 0;
                        }
                        else
                        {
                            fine = (int)span.TotalDays - 15;
                        }
                        // whether have enough balance to pay fine
                        if (currentLoggedInUser.WalletBalance >= fine)
                        {
                            currentLoggedInUser.DeductWalletBalance(fine);
                            borrow.Status = Status.Returned;
                            borrow.PaidFineAmount = fine;
                            foreach (BookDetails book in booksList)
                            {
                                if (book.BookID.Equals(borrow.BookID))
                                {
                                    book.BookCount += borrow.BorrowBookCount;
                                    break;
                                }
                            }
                            Console.WriteLine($"Book returned successfully");
                        }
                        else
                        {
                            Console.WriteLine($"Insufficient balance. Please rechange and proceed");

                        }
                    }
                }
                if (!flag)
                {
                    Console.WriteLine($"Enter valid borrowed ID");
                }
            }
            else
            {
                Console.WriteLine($"User didn't borrowed any books to return");
            }
        } // Return books ends
        public static void WalletRecharge()
        {
            string choice;
            int amount;
            bool flag;
            Console.Write($"You have Rs.{currentLoggedInUser.WalletBalance}. Do you wish to recharge your wallet (yes/no) : ");
            choice = Console.ReadLine().ToLower();
            if (choice.Equals("yes"))
            {
                Console.Write($"Enter Amount you wish to recharge : ");
                flag = int.TryParse(Console.ReadLine(), out amount);
                if (flag && amount > 0)
                {
                    currentLoggedInUser.UpdateWalletBalance(amount);
                }
                else
                {
                    Console.WriteLine($"Enter valid amount to recharge");
                }
            }
            else
            {
                Console.WriteLine($"Enter valid option");
            }
        } // wallet recharge ends
    }
}