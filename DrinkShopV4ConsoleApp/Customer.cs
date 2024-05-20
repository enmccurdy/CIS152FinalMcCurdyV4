/***************************************************************
* Name : DrinkShopV4ConsoleApp Project's Customer.cs class file
* Author: Elizabeth McCurdy
* Created : 04/30/2024
* Course: CIS 152 - Data Structure
* Version: 4.0
* OS: Windows 11
* IDE: Visual Studio Community 2022
* Copyright : This is my own original work 
* based on specifications issued by our instructor
* Description : CIS152FinalMcCurdyV4 fourth version of final project
*   for Spring 2024 Data Structures class - 
*   DrinkShopV4ConsoleApp - Console App only version of project. 
*   Customer class - blue print for Customer class objects,
*   with constructor(s), getters/setters (mutators/accessors), method(s) 
*   and ToString() method to display details regarding the Customer class 
*   objects to the console.
*            Input: String - firstName, String - lastName, 
*            and optional Strings - email and phone for each instance of 
*            Customer class object.
*            Output: ToString() method to display details about the Customer 
*            class object to the console.
*            BigO: Merge Sort - generally O(n log n) for unsorted 
*            list/array – quasilinear time for quick sort, merge sort and 
*            heap sort. Note Big-O for Quick sort can vary from O(n log n) 
*            for Quick sort's best and average case (worst case is 
*            O(n^2 quadratic) for Quick sort if array is
*            already sorted). 
*            
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or
* unmodified. I have not given other fellow student(s) access
* to my program.
***************************************************************/

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DrinkShopV4ConsoleApp
{
    public class Customer
    {
        // ?? No constructors were shown in model classes in the tutorials??
        // ?? No private Fields/attributes show in model classes in the
        // tutorials??
        // ?? Only public properties w/ just { get; set; } show in model
        // classes in the tutorials??
        // ??Not sure if this is one of the reasons why having difficulty
        // gettting programs to work with the database/join tables correctly??
        // First tried this one class w/o the field/attributes - didn't seem
        // to make a difference
        // Fields/attributes
        private int _customerId;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        // ?? consider adding date object
        // to hold date when customer first
        // created to use as 'joined'/'customer since xxxx' data.

        // Moving below to a different class for various operations on DrinkShop class
        // objects by the manager/barista/customer
        // ?? create an attribute to hold all customers objects - in a sorted order? Or which
        // can then be sorted/searched??
        //?? create another attribute/property to hold all Customer objects in database in sorted
        // order - sorted by lastname - then use this for binary search or other search method
        // private Dictionary<CustomerId, Customer> _sortedCustomers;
        //private List<Customer> _sortedCustomersList;

        // Create static counter for Customer class 
        private static int _nextCustomerId = 0;
        // Create static Lists for all the customers which can be sent to MinHeap
        // to create the sorted Customer objects list. 
        private static List<Customer> _allCustomersList = new List<Customer>();
        private static List<Customer> _sortedCustomersList = new List<Customer>();

        // since MinHeap not working correctly to sort list create a static array variable
        // _allCustomersArray to be used in MergeSort() 
        private static Customer[] _allCustomersArray;

        // ?? version ICollection version
        private static ICollection<Customer> _allCustomersCollection = new List<Customer>();

        // virtual Properties/ICollections appeared to be worthless in Console app to 
        // link a Customer class object to its associated Orders so created below attribute/property
        // instead.
        private List<Order> _customerOrders = new List<Order>();

        // Constructor(s)
        // ?? No constructors were shown in model classes in the tutorials??
        // Default constructor
        public Customer()
        {
            // increment _customerId using Customer class's static _nextCustomerId counter. 
            NextCustomerId = NextCustomerId + 1;
            CustomerId = NextCustomerId;
            //CustomerId = customerId;
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            AllCustomersList.Add(this);
            // ?? check ICollection version
            AllCustomersCollection.Add(this);
        }

        // Parameterized Constructor(s)
        public Customer(string firstName, string lastName)
        {
            // increment _customerId using Customer class's static _nextCustomerId counter. 
            NextCustomerId = NextCustomerId + 1;
            CustomerId = NextCustomerId;
            //CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = "";
            Phone = "";
            AllCustomersList.Add(this);
            // ?? check ICollection version
            AllCustomersCollection.Add(this);
        }

        public Customer(string firstName, string lastName, string phone)
        {
            // increment _customerId using Customer class's static _nextCustomerId counter. 
            NextCustomerId = NextCustomerId + 1;
            CustomerId = NextCustomerId;
            //CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            // program wouldn't allow 2 parameterized constructors with 3 strings
            // so had to get creative and make 3rd string input versatile
            //Email = "";
            //Phone = phone;
            string emailRegexPattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            Regex regexEmail = new Regex(emailRegexPattern);
            if (regexEmail.IsMatch(phone))
            {
                _email = phone;
            }
            else
            {
                // if doesn't match set a default value
                _email = "";
            }
            string phoneRegexPattern = @"^\d{3}-\d{3}-\d{4}$";
            Regex regexPhone = new Regex(phoneRegexPattern);
            if (regexPhone.IsMatch(phone))
            {
                _phone = phone;
            }
            else
            {
                // if doesn't match set a default value
                _phone = "000-000-0000";
            }
            AllCustomersList.Add(this);
            // ?? check ICollection version
            AllCustomersCollection.Add(this);
        }

        // program wouldn't allow another parameterized constructor with 3 strings
        /*public Customer(string firstName, string lastName, string email)
        {
            // increment _customerId using Customer class's static _nextCustomerId counter. 
            NextCustomerId = NextCustomerId + 1;
            CustomerId = NextCustomerId;
            //CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = "";
            AllCustomersList.Add(this);
            // ?? check ICollection version
            AllCustomersCollection.Add(this);
        }*/

        public Customer(string firstName, string lastName, string email, string phone)
        {
            // increment _customerId using Customer class's static _nextCustomerId counter. 
            NextCustomerId = NextCustomerId + 1;
            CustomerId = NextCustomerId;
            //CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            //AllCustomersList.Add(this);
            Customer.AllCustomersList.Add(this);
            // ?? check ICollection version
            AllCustomersCollection.Add(this);
        }

        // Properties
        // If using Entity Framework do not need to specify [Key] as 
        // the EF assigns Properties named w/ 'ClassnameId' syntax as the
        // Class's Primary Key automatically. 
        //[Key]
        public int CustomerId { get => _customerId; set => _customerId = value; }
        //public int CustomerId { get; set; }

        // Had to remove most data annotations from Customer class as the
        // Razor pages refused to build 'd/t multiple annotations of the same type' per message. 
        // Data Annotations - for data validation rules ?? place on 
        // attributes/fields or properties better practice??
        //[Required(ErrorMessage = "First name required")]
        //[StringLength(50, ErrorMessage = "Invalid First Name: name cannot be longer than 50 characters.")]
        // Can use a RegularExpression to add validation to make sure characters are only in alphabet
        // no spaces/numbers or special characters.
        // Below version ensures first letter is capitalized and rest are letters of the alphabet.
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        // ?? version if just want alphabetic letters but capitalization doesn't matter??
        //[RegularExpression(@"^[a-zA-Z""'\s-]*$")]
        //public string FirstName { get => _firstName; set => _firstName = value; }
        //public string FirstName { get => _firstName; set => _firstName = value; } = null!;
        //public string FirstName { get; set; } = null!;
        // Switched to below version of FirstName property which uses a RegularExpression for 
        // input validation. 
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                // Unit testing showed that just using the regex pattern IsMatch() to assign
                // either the passed in value or the default value allowed just blank spaces
                // to be assigned for the name if only "" passed as input -
                // to resolve wrapped below in another if condition check to rule out
                // blank space/nothing input by user for name 
                // using || and != null combination condition didn't work
                if (value != "")
                //if (value != null || value != "")
                {
                    // Can use a RegularExpression to add validation to make sure characters are only in alphabet
                    // no spaces/numbers or special characters.
                    // Below version ensures first letter is capitalized and rest are letters of the alphabet.
                    //string firstNameRegexPattern = @"^[A-Z]+[a-zA-Z""'\s-]*$";
                    // ?? version if just want alphabetic letters but capitalization doesn't matter??
                    string firstNameRegexPattern = @"^[a-zA-Z""'\s-]*$";
                    //string firstNameRegexPattern = @"^[a-zA-Z'\s-]*$";
                    Regex regex = new Regex(firstNameRegexPattern);
                    if (regex.IsMatch(value))
                    {
                        _firstName = value;
                    }
                    else
                    {
                        // if doesn't match set a default value
                        _firstName = "invalid first name";
                    }
                }
                else
                {
                    // if blank or null set a default value
                    _firstName = "invalid first name";
                }

            }
        }
        // ?? version if just want alphabetic letters but capitalization doesn't matter??
        //[RegularExpression(@"^[a-zA-Z""'\s-]*$")]
        //[Required(ErrorMessage = "Last name required")]
        //[StringLength(50, ErrorMessage = "Invalid First Name: name cannot be longer than 50 characters.")]
        //public string LastName { get => _lastName; set => _lastName = value; }
        //public string LastName { get; set; } = null!;
        // Switched to below version of FirstName property which uses a RegularExpression for 
        // input validation. 
        public string LastName
        {
            get { return _lastName; }
            set
            {
                // Unit testing showed that just using the regex pattern IsMatch() to assign
                // either the passed in value or the default value allowed just blank spaces
                // to be assigned for the name if only "" passed as input -
                // to resolve wrapped below in another if condition check to rule out
                // blank space/nothing input by user for name 
                // using || and != null combination condition didn't work
                //if (value != null || value != "")
                if (value != "")
                {
                    // Can use a RegularExpression to add validation to make sure characters are only in alphabet
                    // no spaces/numbers or special characters.
                    // Below version ensures first letter is capitalized and rest are letters of the alphabet.
                    //string lastNameRegexPattern = @"^[A-Z]+[a-zA-Z""'\s-]*$";
                    // ?? version if just want alphabetic letters but capitalization doesn't matter??
                    string lastNameRegexPattern = @"^[a-zA-Z""'\s-]*$";
                    Regex regex = new Regex(lastNameRegexPattern);
                    if (regex.IsMatch(value))
                    {
                        _lastName = value;
                    }
                    else
                    {
                        // if doesn't match set a default value
                        _lastName = "invalid last name";
                    }
                }
                else
                {
                    // if blank set a default value
                    _lastName = "invalid last name";
                }


            }
        }
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress(ErrorMessage = "Email address is invalid")]
        //[RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$")]
        //public string? Email { get => _email; set => _email = value; }
        public string? Email 
        {
            get { return _email; }
            set
            {
                string emailRegexPattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
                Regex regex = new Regex(emailRegexPattern);
                if (regex.IsMatch(value))
                {
                    _email = value ;
                }
                else
                {
                    // if doesn't match set a default value
                    _email = "invalidEmail@fake.edu";
                }
            }
        }
        //public string? Email { get; set; }
        //[DataType(DataType.PhoneNumber)]
        // ??[RegularExpression(@"^\d{3}-\d{3}-\d{4}$")] string phone)
        //[RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        //[Phone(ErrorMessage = "Phone number is invalid")]
        //public string? Phone { get => _phone; set => _phone = value; }
        //public string? Phone { get; set; }
        public string? Phone
        {
            get { return _phone; }
            set
            {
                // ?? Decide if want phone to be invalid vs formatting the user's input if no 
                // hypens added/all numbers format vs accepting () / - and all numbers formats
                string phoneRegexPattern = @"^\d{3}-\d{3}-\d{4}$";
                Regex regex = new Regex(phoneRegexPattern);
                if (regex.IsMatch(value))
                {
                    _phone = value;
                }
                else
                {
                    // if doesn't match set a default value
                    _phone = "111-111-1111";
                }
            }
        }

        public static int NextCustomerId { get => _nextCustomerId; set => _nextCustomerId = value; }

        //?? create another attribute/property to hold all Customer objects in database in sorted
        // order - sorted by lastname - then use this for binary search or other search method
        // public Dictionary<CustomerId, Customer> SortedCustomers {get; set;}
        //public List<Customer> SortedCustomersList {get; set;}
        /*public List<Customer> SortedCustomersList 
        {
            get { return _sortedCustomersList; }
            set
            {
                //using DrinkShopContext context = new DrinkShopContext();
                List<Customer> alphabeticalCustomersList = new List<Customer>();
                _sortedCustomersList = alphabeticalCustomersList;
            }
        }*/

        // Navigation property: 
        // Collection of Order objects – navigation property – indicates a customer can have
        // 0 or > orders – creates the one-to-many relationship in the DB to be generated. 
        //public ICollection<Order> Orders { get; set; } = null!;
        //public virtual ICollection<Order> Orders { get; set; } = null!;
        // ?? below instead to allow nulls as a customer can exist w/o an order??
        //public virtual ICollection<Order>? Orders { get; set; }
        // above not set to new List<Order>() caused null reference issues.
        public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();
        // virtual Properties/ICollections appeared to be worthless in Console app to 
        // link a Customer class object to its associated Orders so created below attribute/property
        // instead.
        public List<Order> CustomerOrders { get => _customerOrders; set => _customerOrders = value; }

        //public virtual ICollection<Customer>? Customers { get; set; }

        //public static ICollection<Customer>? AllCustomersList { get; set; }
        //public static ICollection<Customer>? AllCustomersCollection { get; set; }
        public static ICollection<Customer>? AllCustomersCollection { get => _allCustomersCollection; set => _allCustomersCollection = value; }

        // ?? virtual properties appear to be worthless in Console apps ?? ICollection's too???
        // ??The virtual Customers/Orders would NOT allow a Customer/Order objects to be assigned to
        // it by the class constructors, nor would it link to the Customer/Order object through the
        // CustomerId property - in the Order/Drink classes!! Trying static version of ICollection
        // and Lists to hold all Customer objects created. 

        // Created static Lists for all the Customers which can be sent to MinHeap
        // to create the sorted Customer objects list. ?? unsure if better than using the ICollection
        // version. 
        public static List<Customer>? AllCustomersList { get => _allCustomersList; set => _allCustomersList = value; }
        public static List<Customer>? SortedCustomersList { get => _sortedCustomersList; set => _sortedCustomersList = value; }
        // since MinHeap not working correctly to sort list create a static array variable
        // _allCustomersArray to be used in MergeSort() 
        public static Customer[] AllCustomersArray { get => _allCustomersArray; set => _allCustomersArray = value; }



        // Methods
        public static Customer? GetCustomerById(int customerId)
        {
            //List<Customer> customerList =
            //ICollection<Customer> Customers;
            if (AllCustomersList != null)
            //if (Customers != null)
            {
                foreach (Customer customer in AllCustomersList)
                //foreach (Customer customer in Customers)
                {
                    if (customer.CustomerId == customerId)
                    {
                        return customer;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }
        // The MinHeap was not sorting correctly - last two names in list were out of order.
        // So created MergeSortCustomersList() method which created an array from the
        // AllCustomersList, then calls the MergeSort() recursive method to sort the
        // array version of the AllCustomerList into a AllCustomersArray - the array of
        // all the customers sorted alphabetically by last name.
        //  The MergeSort() worked!
        public static void MergeSortCustomersList()
        {
            // Before trying to sort the list make
            // sure it is not null/empty
            if (AllCustomersList != null)
            {
                // Take AllCustomersList List and create array to call 
                // recursive MergeSort() method with.
                //var allCustomersArray = AllCustomersList.ToArray();
                //MergeSort(allCustomersArray);
                AllCustomersArray = AllCustomersList.ToArray();
                MergeSort(AllCustomersArray);
            }
        }
        // The MinHeap was not sorting correctly last two names in list were out of order.
        // So created a MergeSort() recursive method so sort the AllCustomerList into a 
        // SortedCustomersList - the list of customers sorted alphabetically by last name.
        // ?? change below to private?? rather than public??
        private static void MergeSort(Customer[] sortArray)
        //public static void MergeSort(Customer[] sortArray)
        {
            // variable to hold length of list/array
            int length = sortArray.Length;

            // base case for the recursive method - to know when to stop recursion.
            // Base case is whent split list/array down to a length of one - don't
            // need to divide it any further. 
            if (length <= 1)
            {
                return;
            }
            // variable to hold middle position of the list/array
            int middle = length / 2;
            // create 2 new subarrays/lists
            Customer[] leftCustomersArray = new Customer[middle];
            Customer[] rightCustomersArray = new Customer[length - middle];
            // 2 indices variables needed when copying the elements of the original
            // array/list into the subarrays.
            int i = 0; // index for left array/list
            int j = 0; // index for right array/.ist

            // for loop - iterate through each element of array/list start at 0 to copy it to
            // the subarray/list - since declared above don't need to do again in the for loop
            // condition. 
            //for (int i = 0; i < length; i++)
            for (; i < length; i++)
            {
                // if statement condition to determine if need to copy element from original
                // array/.ist to the left or right subarray/list
                if (i < middle)
                {
                    //leftCustomersArray[i] = AllCustomersList[i];
                    leftCustomersArray[i] = sortArray[i];
                }
                // else copy the element to the right subarray/list
                else
                {
                    //rightCustomersArray[j] = AllCustomersList[i];
                    rightCustomersArray[j] = sortArray[i];
                    // increment j by 1
                    j++;
                }
            }
            // outside of for loop make recursive call to subdivide the left array/list
            MergeSort(leftCustomersArray);
            // outside of for loop make recusrive call to subdivide the right array/list
            MergeSort(rightCustomersArray);
            // outside of for loop make call to helper fxn/method to Merge() the subarrays/lists
            // passing in the left and right arrays and the original array they came from. 
            Merge(leftCustomersArray, rightCustomersArray, sortArray);
        }
        // Merge() Helper method for MergeSort() recursive method.
        private static void Merge(Customer[] leftArray, Customer[] rightArray, Customer[] sortArray)
        {
            // declare local variables to hold length of the left and right subarrays
            int leftLength = sortArray.Length / 2;
            int rightLength = sortArray.Length - leftLength;

            // declare 3 indices variables - 1 for each of the arrays
            int i = 0; // index for original array
            int l = 0; // index for leftArray
            int r = 0; // index for rightArray

            // Check conditions for merging: 
            // Use while loop - condition - while there are still elements in the left and right arrays
            // continue to add elements back into the original array
            while (l < leftLength && r < rightLength)
            {
                // if condition to check which element is smaller (alphabetically comes 1st)
                // if element in leftArray comes before element in rightArray
                if (leftArray[l].LastName.CompareTo(rightArray[r].LastName) < 0)
                {
                    // copy element from leftArray at index 'l' into orginal array at index 'i'
                    sortArray[i] = leftArray[l];
                    // then increment 'l' & 'i'
                    i++;
                    l++;
                }
                // else if element in rightArray comes before element in leftArray
                else
                {
                    // copy element from rightArray at index 'r' into original array at index 'i'
                    sortArray[i] = rightArray[r];
                    // then increment 'r' & 'i'
                    i++;
                    r++;
                }
            }
            // Use while loop for condition where only 1 element remaining in the leftArray (so 
            // none available for comparison). 
            while (l < leftLength)
            {
                // copy element in leftArray at index 'l' into original array at index 'i'
                sortArray[i] = leftArray[l];
                // then increment 'l' & 'i'
                i++;
                l++;
            }
            // Next use another while loop for condition where only 1 element remaining in the rightArray
            // (so none available for comparison). 
            while (r < rightLength)
            {
                // copy element in rightArray at index 'r' into original array at index 'i'
                sortArray[i] = rightArray[r];
                // then increment 'r' & 'i'
                i++;
                r++;
            }
        }

        // ??Make this a static method
        //public string? DisplayAllCustomers()
        public static string? DisplayAllCustomers()
        {
            //return base.ToString();
            string allCustomersOutput = "";
            if (AllCustomersList != null)
            {

                allCustomersOutput += $"Customers in AllCustomersList: {AllCustomersList.Count}\nCustomers:\n";
                foreach (Customer customer in AllCustomersList)
                {
                    //allCustomersOutput += $"{customer.ToString}\n";
                    allCustomersOutput += $"{customer.ToString()}\n";
                }
            }
            else
            {
                allCustomersOutput += $"Customers in AllCustomersList: none;";
            }
            return allCustomersOutput;
        }
        // ??Make this a static method
        public static string? DisplayAllSortedCustomers()
        //public string? DisplayAllSortedCustomers()
        {
            //return base.ToString();
            string allSortedCustomersOutput = "";
            // MinHeap was not working correctly so create MergeSort() method 
            if (AllCustomersList != null)
            {
                // Check AllCustomersArray is not null
                if (AllCustomersArray != null)
                {
                    // Output AllCustomersArray to show sorted order
                    allSortedCustomersOutput += $"Customers in AllCustomersArray: {AllCustomersArray.Length}\nCustomers:\n";
                    foreach (Customer customer in AllCustomersArray)
                    {
                        //allSortedCustomersOutput += $"{customer.ToString}\n";
                        allSortedCustomersOutput += $"{customer.ToString()}\n";
                    }
                }
                else
                {
                    allSortedCustomersOutput += $"Customers in AllCustomersArray: none;";
                }
            }
            else
            {
                allSortedCustomersOutput += $"Customers in AllCustomersList: none;";
            }
            return allSortedCustomersOutput;
            // MinHeap wasn't working
            /*if (AllCustomersList != null)
            {
                allSortedCustomersOutput += $"Customers in AllCustomersList: {AllCustomersList.Count}\nCustomers:\n";
                // Create MinHeap of AllCustomersList and then display output:
                // Create MinHeap class object and pass in AllCustomersList
                MinHeap minHeap = new MinHeap(AllCustomersList);
                if (minHeap.UnsortedCustomers != null)
                {
                    allSortedCustomersOutput += $"Customers in minHeap.UnsortedCustomers List: {minHeap.UnsortedCustomers.Count}\nCustomers:\n";
                    allSortedCustomersOutput += $"{minHeap.DisplayUnsortedList()}";
                }
                else
                {
                    allSortedCustomersOutput += $"Customers in minHeap.UnsortedCustomers List: none;";
                }
                minHeap.HeapSort();
                SortedCustomersList = minHeap.HeapifiedCustomers;

                if (SortedCustomersList != null)
                {
                    // SortedCustomersList
                    allSortedCustomersOutput += $"Customers in SortedCustomersList: {SortedCustomersList.Count}\nCustomers:\n";
                    foreach (Customer customer in SortedCustomersList)
                    {
                        //allSortedCustomersOutput += $"{customer.ToString}\n";
                        allSortedCustomersOutput += $"{customer.ToString()}\n";
                    }
                }
                else
                {
                    allSortedCustomersOutput += $"Customers in SortedCustomersList: none;";
                }
            }
            else
            {
                allSortedCustomersOutput += $"Customers in AllCustomersList: none;";
            }
            return allSortedCustomersOutput;*/
        }
        // ??Make this a static method
        public static string? DisplayCustomersMinHeap()
        //public string? DisplayCustomersMinHeap()
        {
            //return base.ToString();
            string allSortedCustomersOutput = "";
            if (AllCustomersList != null)
            {
                allSortedCustomersOutput += $"Customers in AllCustomersList: {AllCustomersList.Count}\nCustomers:\n";
                // Create MinHeap of AllCustomersList and then display output:
                // Create MinHeap class object and pass in AllCustomersList
                MinHeap minHeap = new MinHeap(AllCustomersList);
                if (minHeap.UnsortedCustomers != null)
                {
                    allSortedCustomersOutput += $"Customers in minHeap.UnsortedCustomers List: {minHeap.UnsortedCustomers.Count}\nCustomers:\n";
                    allSortedCustomersOutput += $"{minHeap.DisplayUnsortedList()}";
                }
                else
                {
                    allSortedCustomersOutput += $"Customers in minHeap.UnsortedCustomers List: none;";
                }
                minHeap.HeapSort();
                //SortedCustomersList = minHeap.HeapifiedCustomers;
                if (minHeap.HeapifiedCustomers != null)
                {
                    allSortedCustomersOutput += $"Customers in minHeap.HeapifiedCustomers List: {minHeap.HeapifiedCustomers.Count}\nCustomers:\n";
                    //List<Customer> customers = minHeap.HeapifiedCustomers;
                    //List<Customer> heapfiedCustomersList = new List<Customer> (minHeap.HeapifiedCustomers);
                    //allSortedCustomersOutput += $"{minHeap.HeapifiedCustomers.DisplayHeapifiedList()}";
                    //heapfiedCustomersList.DisplayHeapfiedList();
                    allSortedCustomersOutput += $"{minHeap.DisplayHeapifiedList()}";
                }
                else
                {
                    allSortedCustomersOutput += $"Customers in minHeap.HeapifiedCustomers List: none;";
                }
            }
            else
            {
                allSortedCustomersOutput += $"Customers in AllCustomersList: none;";
            }
            return allSortedCustomersOutput;
        }
        // ??Make this a static method
        public static string? DisplayCustomersHeapArray()
        //public string? DisplayCustomersHeapArray()
        {
            //return base.ToString();
            string allSortedCustomersOutput = "";
            if (AllCustomersList != null)
            {
                allSortedCustomersOutput += $"Customers in AllCustomersList: {AllCustomersList.Count}\nCustomers:\n";
                // Create MinHeap of AllCustomersList and then display output:
                // Create MinHeap class object and pass in AllCustomersList
                MinHeap minHeap = new MinHeap(AllCustomersList);
                if (minHeap.UnsortedCustomers != null)
                {
                    allSortedCustomersOutput += $"Customers in minHeap.UnsortedCustomers List: {minHeap.UnsortedCustomers.Count}\nCustomers\n";
                    allSortedCustomersOutput += $"{minHeap.DisplayUnsortedList()}";
                }
                else
                {
                    allSortedCustomersOutput += $"Customers in minHeap.UnsortedCustomers List: none;";
                }

                minHeap.HeapSort();
                //SortedCustomersList = minHeap.HeapifiedCustomers;
                if (minHeap.HeapifiedCustomersArray != null)
                {
                    allSortedCustomersOutput += $"Customers in minHeap.HeapifiedCustomersArray: {minHeap.HeapifiedCustomersArray.Length}\nCustomers:\n";
                    allSortedCustomersOutput += $"{minHeap.DisplayHeapifiedArray()}";
                }
                else
                {
                    allSortedCustomersOutput += $"Customers in minHeap.HeapifiedCustomersArray: none;";
                }
            }
            else
            {
                allSortedCustomersOutput += $"Customers in AllCustomersList: none;";
            }
            return allSortedCustomersOutput;
        }

        // Write methods to sort/search SortedCustomers (dict) vs SortedCustomersList (List)
        public string? DisplayCustomerOrders()
        {
            string OrderOutput = "";
            // ? use static Order class's AllOrdersList
            if (Order.AllOrdersList != null)
            {
                foreach(Order order in Order.AllOrdersList)
                {
                    if (order.CustomerId == CustomerId)
                    {
                        // Use CustomerOrders property rather than virtual ICollection
                        CustomerOrders.Add(order);
                        //Orders.Add(order);
                    }
                }
            }
            // Use CustomerOrders property rather than virtual ICollection
            if (CustomerOrders != null) 
            //if (Orders != null)
            {
                OrderOutput += $"Customer Orders Count: {CustomerOrders.Count}\nOrders:\n";
                //OrderOutput += $"Customer Orders: {Orders.Count}\n Orders: \n";
                foreach(Order order in CustomerOrders)
                //foreach (Order order in Orders)
                {
                    //OrderOutput += $"{order.ToString} \n";
                    OrderOutput += $"{order.ToString()}\n";
                }
            }
            else
            {
                OrderOutput += $"Customer Orders in List: none;";
            }
            return OrderOutput;
        }


        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            //return base.ToString();
            return $"Customer Id: {CustomerId}; Customer Name: {FirstName} {LastName}; Email: {Email}; Phone: {Phone}";
        }

    }
}