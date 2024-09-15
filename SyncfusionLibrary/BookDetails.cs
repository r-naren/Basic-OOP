using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLibrary
{
    // Class
    /// <summary>
    /// Class BookDetails used to create instance for Books in library <see cref="BookDetails" />
    /// </summary>
    public class BookDetails
    {
        /*
        1.	BookID (Auto Increment - BID1000)
        2.	BookName
        3.	AuthorName
        4.	BookCount
        */
        //static field
        private static int s_bookID = 1000;
        //Properties
        /// <summary>
        /// BookID has the count for assigning Book ID to each book which is Read-only property of instance of <see cref="BookDetails" />
        /// </summary>
        public string BookID { get; } // Read-Only property
        /// <summary>
        /// BookName has the value of the book name of instance of <see cref="BookDetails" />
        /// </summary> 
        /// <value>string type (Ex: C#)</value>
        public string BookName { get; set; }
        /// <summary>
        /// AuthorName has the value of the author name of instance of <see cref="BookDetails" />
        /// </summary> 
        /// <value>string type (Ex: Author Name)</value>
        public string AuthorName { get; set; }
        /// <summary>
        /// BookCount has the value of the book count of instance of <see cref="BookDetails" />
        /// </summary> 
        /// <value>Integer type, Range(1,20000000)</value>
        public int BookCount { get; set; }
        //Constructor
        /// <summary>
        /// This parameterized constructor used to create Book object for instance of <see cref="BookDetails" />
        /// </summary>
        /// <param name="bookName">bookName parameter used to assign its value to associated property</param>
        /// <param name="authorName">authorName parameter used to assign its value to associated property</param>
        /// <param name="bookCount">bookCount parameter used to assign its value to associated property</param>
        public BookDetails(string bookName, string authorName, int bookCount)
        {
            BookID = "BID" + ++s_bookID;
            BookName = bookName;
            AuthorName = authorName;
            BookCount = bookCount;
        }
    }
}