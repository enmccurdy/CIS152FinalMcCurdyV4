/***************************************************************
* Name : DrinkShopV4ConsoleApp Project's Order.cs class file
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
*   Order class - blue print for Order class objects,
*   with constructor(s), getters/setters (mutators/accessors), method(s) 
*   and ToString() method to display details regarding the Order class 
*   objects to the console.
*            Input: String - firstName, String - lastName, 
*            and optional Strings - email and phone to pass to Customer
*            class to created instance of Customer class object associated
*            with this instance of Order class object. String - DrinkName, 
*            String - DrinkSize for each instance of Drink class object 
*            associated with an instance of Order class object.
*            Output: ToString() method to display details about the Order 
*            class object to the console.
*            BigO: Merge Sort - generally O(n log n) for unsorted 
*            list/array – quasilinear time for quick sort, merge sort and 
*            heap sort. Note Big-O for Quick sort can vary from O(n log n) 
*            for Quick sort's best and average case (worst case is 
*            O(n^2 quadratic) for Quick sort if array is
*            already sorted). 
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or
* unmodified. I have not given other fellow student(s) access
* to my program.
***************************************************************/

using System;
using System.Collections;
using System.Security.Principal;

namespace DrinkShopV4ConsoleApp
{
    // ?? add IComparer<Order> for custom priority comparer?? for orders priorty queue
    // to Order class vs doing this in a separate OrdersQueueComparer class
    // versus IComparable<Order>
    //public class Order : IComparer<Order>
    public class Order
    {
        // ?? No constructors were shown in model classes in the tutorials??
        // ?? No private Fields/attributes show in model classes in the
        // tutorials??
        // ?? Only public properties w/ just { get; set; } show in model
        // classes in the tutorials??
        // ??Not sure if this is one of the reasons why having difficulty
        // gettting programs to work with the database/join tables correctly??
        // Trying one class w/o the field/attributes
        // Fields/attributes
        // Primary key - OrderId
        private int _orderId;
        // ?? consider seperating out Date and Time into two separate attributes??
        // Timestamp for when order created and when completed.
        private DateTime _orderDate;
        // ?? need to create something to increment the OrderDate each time order 
        // created since seed data created essentially at the same time. So 
        // hard to determine if OrdersQueueComparer is working.
        //private static _addSeconds = OrderDate.Add(TimeSpan.FromSeconds(22));
        //private static DateTime _addSeconds;
        //private static TimeSpan _addSeconds = TimeSpan.FromSeconds(22);
        private static TimeSpan _addSeconds = TimeSpan.FromSeconds(01);
        //private static TimeSpan _addSeconds = 0;

        private DateTime _orderFilled;
        private bool _isOrderComplete;

        private decimal _orderTotal;
        
        // ?attribute to hold associated foreign key for CustomerID
        // ?? rather than _customer??
        private int _customerId;
        // ?? add Customer class object to hold Customer object associated
        // with this Order object - instead of _customerId above
        // Use foreign key CustomerId to associate specific customer w/ this Order 
        // object/entity rather than using below attribute/property combo. 
        private Customer _customer;
        // Since the virtual Customer property doesn't appear to work/link
        // to the Customer object via CustomerId as reportedly supposed to
        // created specific attribute/Property to hold the Customer object
        // associated w/ this instance of the Order class object. 

        // create a list of Drink objects for this Order class object.
        private List<Drink> _orderDrinkList;

        // Create static counter for Order class 
        private static int _nextOrderId = 0;
        // Create static list to hold all Orders created. 
        private static List<Order> _allOrdersList = new List<Order>();

        // ?attribute to hold associated foreign key for DrinkID
        //private int _drinkId;
        // Since the Order entity/object can have many associated Drink objects
        // which are linked to using the DrinkId foreign key ?? Have ICollection
        // virtual list of the DrinkIds for this Order entity/object vs
        // the Drinks List above??

        // ?? all of below Lists and ICollections not created inside Order
        // class for plain console app version.
        // Use the one-to-many collection of Drink objects/entities for this
        // Order entity/object - couldn't get to work using private attributes/fields
        // with a public Property - had to create List of Drink objects using 
        // the virtual ICollection<Drink> navigation property below (see Navigation
        // properties sections). 
        //private List<Drink> _drinks;
        //private virtual List<Drink> _drinks;
        //private ICollection<Drink> _drinks;
        //private List<Order> _orders;
        //private List<Order> _ordersList;
        //private List<Order> _ordersTableList;
        //private ICollection<Order> _orders;
        //private ICollection<Order> _ordersList;

        // ?? eliminated the ToDo model and moved the Orders queue data structure
        // into the Order model. ??
        //private Queue<Order> _ordersQueue;
        // ?? change this to a static class object created when Order class
        // first initialized - then can add to it??
        // ?? changed this from creating in a separate ToDo class to instead
        // using a static class attribute/property created when Order class
        // first initialized - then can add to it as Order classw objects are
        // created/use as needed?? - initialize to empty Queue when initially
        // created this Order class attribute/Property. 
        private static Queue<Order> _ordersQueue = new Queue<Order>();
        // Rather than regular Queue create a PriorityQueue
        private static PriorityQueue<Order, Order> _priortyOrdersQueue;


        // Constructor(s) ?? None of the tutorials actually appeared to show 
        // Model class constructors?? or private attributes/fields
        // Default constructor
        public Order()
        {
            // increment _orderId using Order class's static _nextOrderId counter. 
            NextOrderId = NextOrderId + 1;
            OrderId = NextOrderId;
            //OrderId = orderId;
            // Set OrderDate to today's date.
            //OrderDate = new DateTime();
            OrderDate = DateTime.Now;
            OrderDate = OrderDate.Add(AddSeconds);
            // Incrementing Add Seconds
            //AddSeconds = AddSeconds + AddSeconds;
            AddSeconds = AddSeconds + TimeSpan.FromSeconds(05);

            OrderFilled = null;
            IsOrderComplete = false;
            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            //Customer = null;
            // Call Customer class to create default Customer object
            Customer customer = new Customer();
            Customer = customer;
            CustomerId = customer.CustomerId;
            // Create an empty List of Drink objects. 
            //Drinks = new List<Drink>();
            // create an empty list of Drink objects when Order object first 
            // created. 
            OrderDrinkList = new List<Drink>();
            //??OrderDetails = OrderDetails;

            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();

            //OrdersQueue.Enqueue(this.Order);
            //_ordersQueue.Enqueue(this.Order);
            AllOrdersList.Add(this);
        }
        // Parameterized Constructor(s)
        /*public Order(int customerId)
        //public Order(Customer customer)
        {
            // increment _orderId using Order class's static _nextOrderId counter. 
            NextOrderId = NextOrderId + 1;
            OrderId = NextOrderId;
            //OrderId = orderId;
            // Set OrderDate to today's date.
            //OrderDate = new DateTime();
            OrderDate = DateTime.Now;
            OrderDate = OrderDate.Add(AddSeconds);
            // Incrementing Add Seconds
            //AddSeconds = AddSeconds + AddSeconds;
            AddSeconds = AddSeconds + TimeSpan.FromSeconds(05);
            OrderFilled = null;
            IsOrderComplete = false;

            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            Customer = customer;
            //CustomerId = customerId;
            // Call Customer class to create default Customer object
            //Customer customer = new Customer();
            CustomerId = customer.CustomerId;

            // Create an empty List of Drink objects. 
            //Drinks = new List<Drink>();
            // create an empty list of Drink objects when Order object first 
            // created. 
            OrderDrinkList = new List<Drink>();
            //??OrderDetails = OrderDetails;

            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();
            AllOrdersList.Add(this);
        }*/
        public Order(Customer customer)
        {
            // increment _orderId using Order class's static _nextOrderId counter. 
            NextOrderId = NextOrderId + 1;
            OrderId = NextOrderId;
            //OrderId = orderId;
            // Set OrderDate to today's date.
            //OrderDate = new DateTime();
            OrderDate = DateTime.Now;
            OrderDate = OrderDate.Add(AddSeconds);
            // Incrementing Add Seconds
            //AddSeconds = AddSeconds + AddSeconds;
            AddSeconds = AddSeconds + TimeSpan.FromSeconds(05);
            OrderFilled = null;
            IsOrderComplete = false;

            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            Customer = customer;
            //CustomerId = customerId;
            // Call Customer class's parameterized customer to create Customer object
            //Customer customer = new Customer(firstName, lastName);
            CustomerId = customer.CustomerId;

            // Create an empty List of Drink objects. 
            //Drinks = new List<Drink>();
            // create an empty list of Drink objects when Order object first 
            // created. 
            OrderDrinkList = new List<Drink>();
            //OrderDrinkList = drinks;
            //Drinks = drinks;
            //??OrderDetails = OrderDetails;

            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();
            AllOrdersList.Add(this);
        }

        public Order(Customer customer, Drink drink)
        {
            // increment _orderId using Order class's static _nextOrderId counter. 
            NextOrderId = NextOrderId + 1;
            OrderId = NextOrderId;
            //OrderId = orderId;
            // Set OrderDate to today's date.
            //OrderDate = new DateTime();
            OrderDate = DateTime.Now;
            OrderDate = OrderDate.Add(AddSeconds);
            // Incrementing Add Seconds
            //AddSeconds = AddSeconds + AddSeconds;
            AddSeconds = AddSeconds + TimeSpan.FromSeconds(05);
            OrderFilled = null;
            IsOrderComplete = false;

            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            Customer = customer;
            //CustomerId = customerId;
            // Call Customer class's parameterized customer to create Customer object
            //Customer customer = new Customer(firstName, lastName);
            CustomerId = customer.CustomerId;

            // Create an empty List of Drink objects. 
            //Drinks = new List<Drink>();
            // create an empty list of Drink objects when Order object first 
            // created. 
            //OrderDrinkList = new List<Drink>();
            //OrderDrinkList.Add(drink);
            //AddDrinkToOrder(drink);
            OrderDrinkList = new List<Drink>() { drink };
            //OrderDrinkList = drinks;
            //Drinks = drinks;
            Drinks.Add(drink);
            //??OrderDetails = OrderDetails;

            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();
            AllOrdersList.Add(this);
        }

        public Order(int customerId, Drink drink)
        {
            // increment _orderId using Order class's static _nextOrderId counter. 
            NextOrderId = NextOrderId + 1;
            OrderId = NextOrderId;
            //OrderId = orderId;
            // Set OrderDate to today's date.
            //OrderDate = new DateTime();
            OrderDate = DateTime.Now;
            OrderDate = OrderDate.Add(AddSeconds);
            // Incrementing Add Seconds
            //AddSeconds = AddSeconds + AddSeconds;
            AddSeconds = AddSeconds + TimeSpan.FromSeconds(05);
            OrderFilled = null;
            IsOrderComplete = false;

            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            //Customer = customer;
            CustomerId = customerId;
            //Customer = Customer.GetCustomerById(customerId);
            if (Customer.GetCustomerById(customerId) != null)
            {
                Customer = Customer.GetCustomerById(customerId);
            }
            /*if (Order.Customer.GetCustomerById(customerId) != null)
            {
                Customer = Order.Customer.GetCustomerById(customerId);
            }*/
            // Call Customer class's parameterized customer to create Customer object
            //Customer customer = new Customer(firstName, lastName);
            //CustomerId = customer.CustomerId;

            // Create an empty List of Drink objects. 
            //Drinks = new List<Drink>();
            // create an empty list of Drink objects when Order object first 
            // created. 
            OrderDrinkList = new List<Drink>() { drink };
            //OrderDrinkList.Add(drink);
            //AddDrinkToOrder(drink);
            //OrderDrinkList = drinks;
            //Drinks = drinks;
            Drinks.Add(drink);
            // Every Drink created add to Drink.AllDrinks static List
            //?? in Order class or see if can get this working inside
            // the Drink class
            //Drink.AllDrinks.Add(drink);
            
            //??OrderDetails = OrderDetails;

            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();
            AllOrdersList.Add(this);
        }

        public Order(int customerId, int drinkId)
        {
            // increment _orderId using Order class's static _nextOrderId counter. 
            NextOrderId = NextOrderId + 1;
            OrderId = NextOrderId;
            //OrderId = orderId;
            // Set OrderDate to today's date.
            //OrderDate = new DateTime();
            OrderDate = DateTime.Now;
            OrderDate = OrderDate.Add(AddSeconds);
            // Incrementing Add Seconds
            //AddSeconds = AddSeconds + AddSeconds;
            AddSeconds = AddSeconds + TimeSpan.FromSeconds(05);
            OrderFilled = null;
            IsOrderComplete = false;

            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            //Customer = customer;
            CustomerId = customerId;
            //Customer = Customer.GetCustomerById(customerId);
            if (Customer.GetCustomerById(customerId) != null)
            {
                Customer = Customer.GetCustomerById(customerId);
            }
            /*if (Order.Customer.GetCustomerById(customerId) != null)
            {
                Customer = Order.Customer.GetCustomerById(customerId);
            }
            Customer = Order.Customer;*/
            // Call Customer class's parameterized customer to create Customer object
            //Customer customer = new Customer(firstName, lastName);
            //CustomerId = customer.CustomerId;

            // Create an empty List of Drink objects. 
            //Drinks = new List<Drink>();
            // create an empty list of Drink objects when Order object first 
            // created. 
            OrderDrinkList = new List<Drink>();
            //OrderDrinkList.Add(drink);
            //AddDrinkToOrder(drink);
            /*if (Drink.GetDrinkById(drinkId) != null)
            {
                var drink = Drink.GetDrinkById(drinkId);
                AddDrinkToOrder(drink);
            }*/
            /*if (Drinks.GetDrinkById(drinkId) != null)
            {
                var drink = Drinks.GetDrinkById(drinkId);
                AddDrinkToOrder(drink);
            }*/
            //foreach (Drink drink in Drinks)
            //{
                /*if (drink.GetDrinkById(drinkId) != null)
                {
                    var addDrink = drink.GetDrinkById(drinkId);
                    AddDrinkToOrder(drink);
                    Drinks.Add((Drink)addDrink);
                }*/
                //if (drink.DrinkId.Equals(drinkId) && drink.OrderId.Equals(OrderId))
                /*if (drink.DrinkId.Equals(drinkId))
                {
                    AddDrinkToOrder(drink);
                }
            }*/

            foreach (Drink drink in Drink.AllDrinks)
            {
                if (drink.DrinkId.Equals(drinkId) && drink.OrderId.Equals(OrderId))
                //if (drink.DrinkId.Equals(drinkId))
                {
                    //AddDrinkToOrder(drink);
                    OrderDrinkList.Add(drink);
                    Drinks.Add(drink);
                }
            }

            //OrderDrinkList = drinks;
            //Drinks = drinks;
            //??OrderDetails = OrderDetails;

            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();
            AllOrdersList.Add(this);
        }

        /*public Order(int customerId, List<Drink> drinks)
        //public Order(Customer customer, List<Drink> drinks)
        {
            // increment _orderId using Order class's static _nextOrderId counter. 
            NextOrderId = NextOrderId + 1;
            OrderId = NextOrderId;
            //OrderId = orderId;
            // Set OrderDate to today's date.
            OrderDate = new DateTime();
            OrderDate = DateTime.Now;
            OrderDate = OrderDate.Add(AddSeconds);
            // Incrementing Add Seconds
            //AddSeconds = AddSeconds + AddSeconds;
            AddSeconds = AddSeconds + TimeSpan.FromSeconds(05);
            OrderFilled = null;
            IsOrderComplete = false;
            
            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            Customer = customer;
            //CustomerId = customerId;
            // Call Customer class to create default Customer object
            //Customer customer = new Customer();
            CustomerId = customer.CustomerId;

            // Create an empty List of Drink objects. 
            //Drinks = new List<Drink>();
            // create an empty list of Drink objects when Order object first 
            // created. 
            //OrderDrinkList = new List<Drink>();
            OrderDrinkList = drinks;
            //Drinks = drinks;
            //??OrderDetails = OrderDetails;
            
            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();
            AllOrdersList.Add(this);
        }*/

        public Order(string firstName, string lastName)
        {
            // increment _orderId using Order class's static _nextOrderId counter. 
            NextOrderId = NextOrderId + 1;
            OrderId = NextOrderId;
            //OrderId = orderId;
            // Set OrderDate to today's date.
            //OrderDate = new DateTime();
            OrderDate = DateTime.Now;
            OrderDate = OrderDate.Add(AddSeconds);
            // Incrementing Add Seconds
            //AddSeconds = AddSeconds + AddSeconds;
            AddSeconds = AddSeconds + TimeSpan.FromSeconds(05);
            OrderFilled = null;
            IsOrderComplete = false;
            
            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            //Customer = customer;
            //CustomerId = customerId;
            // Call Customer class's parameterized customer to create Customer object
            Customer customer = new Customer(firstName, lastName);
            Customer = customer;
            CustomerId = customer.CustomerId;

            // Create an empty List of Drink objects. 
            //Drinks = new List<Drink>();
            // create an empty list of Drink objects when Order object first 
            // created. 
            OrderDrinkList = new List<Drink>();
            //OrderDrinkList = drinks;
            //Drinks = drinks;
            //??OrderDetails = OrderDetails;
            
            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();
            AllOrdersList.Add(this);
        }

        public Order(string firstName, string lastName, string email)
        {
            // increment _orderId using Order class's static _nextOrderId counter. 
            NextOrderId = NextOrderId + 1;
            OrderId = NextOrderId;
            //OrderId = orderId;
            // Set OrderDate to today's date.
            //OrderDate = new DateTime();
            OrderDate = DateTime.Now;
            OrderDate = OrderDate.Add(AddSeconds);
            // Incrementing Add Seconds
            //AddSeconds = AddSeconds + AddSeconds;
            AddSeconds = AddSeconds + TimeSpan.FromSeconds(05);
            OrderFilled = null;
            IsOrderComplete = false;

            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            //Customer = customer;
            //CustomerId = customerId;
            // Call Customer class's parameterized customer to create Customer object
            Customer customer = new Customer(firstName, lastName, email);
            Customer = customer;
            CustomerId = customer.CustomerId;

            // Create an empty List of Drink objects. 
            //Drinks = new List<Drink>();
            // create an empty list of Drink objects when Order object first 
            // created. 
            OrderDrinkList = new List<Drink>();
            //OrderDrinkList = drinks;
            //Drinks = drinks;
            //??OrderDetails = OrderDetails;

            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();
            AllOrdersList.Add(this);
        }

        public Order(string firstName, string lastName, string email, string phone)
        {
            // increment _orderId using Order class's static _nextOrderId counter. 
            NextOrderId = NextOrderId + 1;
            OrderId = NextOrderId;
            //OrderId = orderId;
            // Set OrderDate to today's date.
            //OrderDate = new DateTime();
            OrderDate = DateTime.Now;
            OrderDate = OrderDate.Add(AddSeconds);
            // Incrementing Add Seconds
            //AddSeconds = AddSeconds + AddSeconds;
            AddSeconds = AddSeconds + TimeSpan.FromSeconds(05);
            OrderFilled = null;
            IsOrderComplete = false;

            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            //Customer = customer;
            //CustomerId = customerId;
            // Call Customer class's parameterized customer to create Customer object
            Customer customer = new Customer(firstName, lastName, email, phone);
            Customer = customer;
            CustomerId = customer.CustomerId;

            // Create an empty List of Drink objects. 
            //Drinks = new List<Drink>();
            // create an empty list of Drink objects when Order object first 
            // created. 
            OrderDrinkList = new List<Drink>();
            //OrderDrinkList = drinks;
            //Drinks = drinks;
            //??OrderDetails = OrderDetails;

            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();
            AllOrdersList.Add(this);

        }

        public Order(string firstName, string lastName, string email, string drinkName, string drinkSize)
        {
            // increment _orderId using Order class's static _nextOrderId counter. 
            NextOrderId = NextOrderId + 1;
            OrderId = NextOrderId;
            //OrderId = orderId;
            // Set OrderDate to today's date.
            //OrderDate = new DateTime();
            OrderDate = DateTime.Now;
            OrderDate = OrderDate.Add(AddSeconds);
            // Incrementing Add Seconds
            //AddSeconds = AddSeconds + AddSeconds;
            AddSeconds = AddSeconds + TimeSpan.FromSeconds(05);
            OrderFilled = null;
            IsOrderComplete = false;

            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            //Customer = customer;
            //CustomerId = customerId;
            // Call Customer class's parameterized customer to create Customer object
            Customer customer = new Customer(firstName, lastName, email);
            Customer = customer;
            CustomerId = customer.CustomerId;

            // Create an empty List of Drink objects. 
            //Drinks = new List<Drink>();
            // create an empty list of Drink objects when Order object first 
            // created. 
            OrderDrinkList = new List<Drink>();
            //OrderDrinkList = drinks;
            //Drinks = drinks;
            //??OrderDetails = OrderDetails;
            
            // Call Drink class parameterized constructor to create a Drink class object
            //Drink drink = new Drink(drinkName, drinkSize);
            // call constructor that takes OrderId value 
            Drink drink = new Drink(OrderId, drinkName, drinkSize);
            // add drink to OrderDrinkList
            OrderDrinkList.Add(drink);
            Drinks.Add(drink);
            // ?? Every Drink created add to Drink.AllDrinks static List
            // ?? in Order class or see if can get this working inside
            // the Drink class
            // Drink.AllDrinks.Add(drink);
            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();
            AllOrdersList.Add(this);
        }


        public Order(string firstName, string lastName, string email, string phone, string drinkName, string drinkSize)
        {
            // increment _orderId using Order class's static _nextOrderId counter. 
            NextOrderId = NextOrderId + 1;
            OrderId = NextOrderId;
            //OrderId = orderId;
            // Set OrderDate to today's date.
            //OrderDate = new DateTime();
            OrderDate = DateTime.Now;
            OrderDate = OrderDate.Add(AddSeconds);
            // Incrementing Add Seconds
            //AddSeconds = AddSeconds + AddSeconds;
            AddSeconds = AddSeconds + TimeSpan.FromSeconds(05);
            OrderFilled = null;
            IsOrderComplete = false;

            // ?? need to use/assign a default CustomerId value??
            // rather than below??
            //Customer = customer;
            //CustomerId = customerId;
            // Call Customer class's parameterized customer to create Customer object
            Customer customer = new Customer(firstName, lastName, email, phone);
            Customer = customer;
            CustomerId = customer.CustomerId;

            // Create an empty List of Drink objects. 
            //Drinks = new List<Drink>();
            // create an empty list of Drink objects when Order object first 
            // created. 
            OrderDrinkList = new List<Drink>();
            //OrderDrinkList = drinks;
            //Drinks = drinks;
            //??OrderDetails = OrderDetails;
            // Call Drink class parameterized constructor to create a Drink class object
            //Drink drink = new Drink(drinkName, drinkSize);
            // call constructor that takes OrderId value 
            Drink drink = new Drink(OrderId, drinkName, drinkSize);
            // add drink to OrderDrinkList
            OrderDrinkList.Add(drink);
            Drinks.Add(drink);
            // ??Every Drink created add to Drink.AllDrinks static List
            // ?? in Order class or see if can get this working inside
            // the Drink class
            //Drink.AllDrinks.Add(drink);
            // Call a method to calculate the orderTotal
            OrderTotal = CalcTotal();
            AllOrdersList.Add(this);
        }


        // Properties:
        // If using Entity Framework do not need to specify [Key] as 
        // the EF assigns Properties named w/ 'ClassnameId' syntax as the
        // Class's Primary Key automatically. 
        //[Key]
        public int OrderId { get => _orderId; set => _orderId = value; }
        // DataType attribute for formatting DateTime object
        //[DataType(DataType.DateTime, ErrorMessage = "OrderDate DateTime is invalid.")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy - hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get => _orderDate; set => _orderDate = value; }
        /*public DateTime OrderDate 
        {
            get {  return _orderDate; }
            set { 
                //value = new DateTime();
                //_orderDate = value;
                _orderDate = new DateTime();
            }
        }*/

        //public static DateTime AddSeconds { get => AddSeconds1; set => AddSeconds1 = value; }
        public static TimeSpan AddSeconds { get => _addSeconds; set => _addSeconds = value; }

        //[DataType(DataType.DateTime, ErrorMessage = "OrderFilled DateTime is invalid.")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy - hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        //public DateTime? OrderFilled { get => _orderFilled; set => _orderFilled = (DateTime)value.Value; }
        //public DateTime? OrderFilled { get => _orderFilled; set => _orderFilled = value.Value; }
        public DateTime? OrderFilled { get; set; }
        public bool IsOrderComplete { get => _isOrderComplete; set => _isOrderComplete = value; }
        
        //[ForeignKey(nameof(CustomerId))]
        //[ForeignKey("Customer")]
        public int CustomerId { get => _customerId; set => _customerId = value; }
        //public int CustomerId { get; set; }
        public Customer? Customer { get => _customer; set => _customer = value; }
        //public Customer? Customer { get; set; }
        //public Customer Customer { get; set; } = null!;
        //internal Customer Customer { get => _customer; set => _customer = value; }

        //public int DrinkId { get => _drinkId; set => _drinkId = value; }
        public int DrinkId { get; set; }
        public List<Drink> OrderDrinkList { get => _orderDrinkList; set => _orderDrinkList = value; }
        //public List<Drink>? OrderDrinkList { get; set; }
        //public List<Drink> Drinks { get => _drinks; set => _drinks = value; }

        //public List<Order> Orders { get; set; }
        //public List<Order>? AllOrdersList { get; set; }
        //public List<Order>? AllOrdersList { get; set; } = [];
        //public List<Order>? OrdersTableList { get; set; }
        /*public List<Order>? OrdersTableList
        {
            get { return _ordersTableList; }
            set
            {
                //using DrinkShopContext context = new DrinkShopContext();
                //List<Order> allOrdersList = new List<Order>();
                //List<Order> allOrdersList = ICollection<Order> Orders.ToList();
                //List<Order> allOrdersList = Collection<Order> Orders.ToList();
                //List<Order> allOrdersList = select * from context.Orders.ToList();
                //_ordersTableList = db.Orders.ToList();
                _ordersTableList = Orders.ToList();
            }
        }*/
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
        //[DataType(DataType.Currency, ErrorMessage = "Order invalid, must be a positive value.")]
        //[DisplayFormat(DataFormatString = "{C2, CultureInfo.CurrentCulture}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "(C2, CultureInfo.CurrentCulture)", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{D2}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "(D2)", ApplyFormatInEditMode = true)]
        //[Column(TypeName = "decimal(18, 2)")]
        //public decimal OrderTotal { get => _orderTotal; set => _orderTotal = value; }
        public decimal? OrderTotal
        {
            get { return _orderTotal; }
            set
            {
                _orderTotal = CalcTotal();
            }
        }
        
        // ?? changed this from creating in a separate ToDo class to instead
        // using a static class attribute/property created when Order class
        // first initialized - then can add to it as Order classw objects are
        // created/use as needed??
        public static Queue<Order>? OrdersQueue { get => _ordersQueue; set => _ordersQueue = value; }
        /*public static Queue<Order>? OrdersQueue
        {
            get { return _ordersQueue; }
            //set => _ordersQueue.Enqueue(this.Order);
            set => _ordersQueue.Enqueue(Order);
            //set {
                //Order.OrdersQueue.Enqueue(Order);
                //Order.OrdersQueue.Enqueue(item: Order);
                //_ordersQueue.Enqueue(this.Order);
            //}
        }*/
        /*public Queue<Order>? OrdersQueue
        {
            get { return _ordersQueue; }
            set
            {
                // versus if created a static object for entire Order class
                // to enqueue each Order object to once it is created. 
                //OrdersQueue.Enqueue(this.Order);
                OrdersQueue = new Queue<Order>();
                if (OrdersTableList != null)
                {
                    //List<Order> ordersList = Orders.ToList();
                    List<Order> ordersList = OrdersTableList;
                    //List<Order> ordersList = new ICollection<Order> Orders;
                    //Orders.Sort();
                    //Orders.ToImmutableSortedDictionary();
                    // Sort all Order object by OrderDate in ascending order then add/enqueue
                    // to OrderQueueu
                    ordersList.Sort();
                    foreach (Order order in ordersList)
                    {
                        OrdersQueue.Enqueue(order);
                    }
                }
            }
        }*/

        // Navigation Properties: 
        // MS learn tutorial on EF MVC used below to hold multiple rows of data associated
        // w/ this class entity's primary key value - i.e. Drinks property of an Order entity
        // would hold all the 'Drink' entities/objects related this this Order entity -
        // so if this Order entity has multiple related Drink rows (Drink rows w/ this Order
        // entity's/object's primary key in the Drink rows OrderId foreign key column).
        // Uses keyword 'virtual' so 'Navigation Properties' can take advantage of EF functionality
        // - necessary d/t need a List (such as ICollection) to be able to do CRUD operations
        // on a navigation property which holds multiple entities (such as w/ many-to-many &
        // one-to-many type relationships). 
        // Since the Order entity/object can have many associated Drink objects
        // which are linked to using the DrinkId foreign key ?? Have ICollection
        // virtual list of the DrinkIds for this Order entity/object vs
        // the Drinks List above - public List<Drink> Drinks;??
        //public List<Drink> DrinksInOrderList { get => _drinksInOrderList; set => _drinksInOrderList = value; }

        //??public virtual Drink Drink { get; set; }
        //public virtual ICollection<Order> Orders { get; set; } = null!;

        // Navigation Properties: 
        // CustomerId property is a foreign key w/ the corresponding 'navigation property' of Customer.
        // This Order entity/object can only be associated w/ one Customer entity/object. 
        // Below defines one Customer entity per order – the CustomerId property is used to represent
        // the Foreign key relationship to the Customer table (if omit the CustomerId property EF Core
        // will create it anyway, as a ‘shadow property’.
        //public Customer Customer { get; set; }
        //public Customer Customer { get; set; } = null!;
        //public virtual Customer Customer { get; set; } = null!;

        // ?? virtual properties appear to be worthless in Console apps ?? ICollection's too???
        // Below virtual Customer would NOT allow a Customer object to be assigned to it by the
        // constructors, nor would it link to the Customer object through the CustomerId property!!
        //public virtual Customer? Customer { get; set; }
        //public virtual Customer Customer { get => customer; set => customer = value; }


        // DrinkId property is a foreign key w/ the corresponding 'navigation property' of Order.Drinks.
        // This Order entity/object 'Drinks' List/collection can hold many associated Drink entities/objects.
        //public virtual ICollection<Drink> Drinks { get; set; }
        //public virtual ICollection<Drink> Drinks { get; set; } = null!;

        // ?? virtual properties appear to be worthless in Console apps ?? ICollection's too???
        public virtual ICollection<Drink> Drinks { get; set; } = new List<Drink>();
        // ??Navigation property for a collection of OrderDetails - rather than using 
        // the ICollection<Drink> Drinks property
        //public virtual ICollection<OrderDetail> OrderDetails { get; set; } = null!;

        public static int NextOrderId { get => _nextOrderId; set => _nextOrderId = value; }
        // ??Create a static variable to hold all the Order class objects. 
        //public static List<Order>? AllOrdersList { get; set; }
        public static List<Order>? AllOrdersList { get => _allOrdersList; set => _allOrdersList = value; }
        // Rather than regular Queue create a PriorityQueue
        public static PriorityQueue<Order, Order>? PriortyOrdersQueue { get => _priortyOrdersQueue; set => _priortyOrdersQueue = value; }
        

        // Use above version of Property instead and initialized to a new List in the static field/attribute 
        // rather than using below.
        //?? public static List<Order>? AllOrdersList { get; set; } = new List<Order>();

        // ??changed create OrderDetail class rather than ToDo class when tried join table for data base version.

        // Methods
        public decimal CalcTotal()
        {
            decimal total = 0m;
            //if (OrderDetails != null)
            // ?? Use OrderDrinkList List rather than Drinks ICollection ??
            if (OrderDrinkList != null)
            //if (Drinks != null)
            {
                //foreach (OrderDetail drink in OrderDetails)
                foreach (Drink drink in OrderDrinkList)
                //foreach (Drink drink in Drinks)
                {
                    //total += drink.Drink.DrinkPrice;
                    //total += drink.DrinkPrice;
                    total = total + drink.DrinkPrice;
                }
            }
            return total;
        }

        // method to add another Drink object to this Order object
        public void AddDrinkToOrder(string drinkName, string drinkSize)
        {
            //Drink drink = new Drink(drinkName, drinkSize);
            // call constructor that takes OrderId value 
            Drink drink = new Drink(OrderId, drinkName, drinkSize);
            OrderDrinkList.Add(drink);
            Drinks.Add(drink);
            // Every Drink created add to Drink.AllDrinks static List
            Drink.AllDrinks.Add(drink);
            // ?? should CalcTotal() be called after every new Drink added
            // to OrderDrinkList ??
            // Call a method to calculate the new OrderTotal
            OrderTotal = CalcTotal();
        }

        public void AddDrinkToOrder(Drink drink)
        {
            //Drink drink = new Drink(drinkName, drinkSize);
            OrderDrinkList.Add(drink);
            Drinks.Add(drink);
            // Every Drink created add to Drink.AllDrinks static List
            Drink.AllDrinks.Add(drink);
            // ?? should CalcTotal() be called after every new Drink added
            // to OrderDrinkList ??
            // Call a method to calculate the new OrderTotal
            OrderTotal = CalcTotal();
        }

        /*public void AddDrinkToOrder(int drinkId)
        {
            //Drink drink = new Drink(drinkName, drinkSize);
            OrderDrinkList.Add(drinkId);
            // ?? should CalcTotal() be called after every new Drink added
            // to OrderDrinkList ??
        }*/

        // This method was not working - Unit Test showed it kept returning 'null'
        // Not sure if really need this method. 
        /*public Drink? GetOrderDrinkById(int drinkId)
        {
            Drink drink = Drink.GetDrinkById(drinkId);
            //if (OrderDrinkList.Count != 0 && drink != null)
            if (OrderDrinkList != null && drink != null)
            //if (OrderDrinkList.Count != 0 && OrderDrinkList.Contains(drink))
            //if (OrderDrinkList != null || OrderDrinkList.Count != 0)
            {
                //return drink;
                if (OrderDrinkList.Contains(drink))
                //if (OrderDrinkList.Contains(Drink.GetDrinkById(drinkId)))
                {
                    //Drink drink = Drink.GetDrinkById(drinkId);
                    return drink;
                }
                *//*foreach(Drink drink in OrderDrinkList)
                {
                    if (drink.DrinkId == drinkId)
                    {
                        return drink;
                    }
                }*//*
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }*/

        // changed above method to below to see if will work to get Drink object - 
        // This version worked to return the specified drink object
        public Drink? GetOrderDrinkById(int drinkId)
        //public void GetOrderDrinkById(int drinkId)
        {
            Drink currentDrink = Drink.GetDrinkById(drinkId);
            if (currentDrink != null)
            //if (Drink.GetDrinkById(drinkId) != null)
            {
                if (OrderDrinkList != null)
                {
                    if (OrderDrinkList.Contains(currentDrink))
                    {
                        return currentDrink;
                    }
                    else
                    {
                        return null;
                    }
                    /*foreach (Drink drink in OrderDrinkList)
                    {
                        if (drink.Equals(currentDrink))
                        //if (currentDrink.Equals(drink))
                        {
                            return drink;
                        }
                    }*/

                }
                else
                {
                    return null;
                }

            } else
            {
                return null;
            }
        }

        public string? DisplayOrderDrinkList()
        {
            //return base.ToString();
            string ToDoOutput = "";
            //string ToDoOutput = $"ToDo Id: {ToDoId}; ToDo Date: {ToDoDate}; ";
            if (OrderDrinkList != null)
            {

                ToDoOutput += $"Drinks in Order: {OrderDrinkList.Count}\n Drinks: \n";
                foreach (Drink drink in OrderDrinkList)
                {
                    ToDoOutput += $"{drink.ToString} \n";
                }
            }
            else
            {
                ToDoOutput += $"Drinks in Order: none;";
            }
            return ToDoOutput;
        }

        // Method to switch IsOrderComplete bool from default 'false' to 'true' & set time order
        // was finished
        public void OrderCompleted()
        {
            //OrderFilled = new DateTime();
            OrderFilled = DateTime.Now;
            IsOrderComplete = true;
        }

        public static Order? GetOrderById(int orderId)
        //public Order? GetOrderById(int orderId)
        {
            //DrinkShopOperations operations = new DrinkShopOperations();
            //ICollection<Order> allOrders = operations.Orders;
            // ?? use static Property - AllOrdersList instead??
            if (AllOrdersList != null)
            //if (allOrders != null)
            {
                foreach (Order order in AllOrdersList)
                //foreach (Order order in allOrders)
                {
                    if (order.OrderId == orderId)
                    {
                        return order;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public static string? DisplayAllOrders()
        {
            //return base.ToString();
            string allOrderOutput = "";
            if (AllOrdersList != null)
            {

                allOrderOutput += $"Orders in AllOrdersList: {AllOrdersList.Count}\n Orders: \n";
                foreach (Order order in AllOrdersList)
                {
                    //allOrderOutput += $"{order.ToString} \n";
                    // above output: System.Func`1[System.String]
                    allOrderOutput += $"{order.ToString()} \n";
                }
            }
            else
            {
                allOrderOutput += $"Orders in AllOrdersList: none;";
            }
            return allOrderOutput;
        }

        // Created/Implemented a Custom Priority Comparer using separate OrdersQueueComparer
        // class that implements the IComparer<Order> interface
        public static void CreateOrdersQueue()
        {
            //var priortyOrdersQueue = new PriorityQueue<Order, int>(AllOrdersList);
            //var priortyOrdersQueue = new PriorityQueue<Order, int>((IEnumerable<(Order Element, int Priority)>)AllOrdersList);
            // Using Compare() method below & IComparer<Order> interface
            //var priortyOrdersQueue = new PriorityQueue<Order, Order>(AllOrdersList.ForEach(o => priortyOrdersQueue.Enqueue(o, o)));
            //AllOrdersList.ForEach(o => priortyOrdersQueue.Enqueue(o, o));
            // 1st separate out only the still pending orders from the AllOrdersList
            List<Order> pendingOrders = new List<Order>();
            foreach (Order order in AllOrdersList)
            {
                if (!order.IsOrderComplete)
                {
                    //List<Order> pendingOrders = new List<Order>();
                    pendingOrders.Add(order);
                    //priortyOrdersQueue.Enqueue(o, o);
                    //AllOrdersList.ForEach(o => priortyOrdersQueue.Enqueue(o, o));
                }
            }
            //Then use the pendingOrders List to populate the priorityOrdersQueue - give the priority queue 
            // an instance of the OrderQueueComparer class to use to implement the custom priority comparer
            //var priortyOrdersQueue = new PriorityQueue<Order, Order>(new OrdersQueueComparer());
            //pendingOrders.ForEach(o => priortyOrdersQueue.Enqueue(o, o));
            // Since opted to rather than regular Queue create a PriorityQueue static Property/attribute
            // for the order class
            PriortyOrdersQueue = new PriorityQueue<Order, Order>(new OrdersQueueComparer());
            pendingOrders.ForEach(o => PriortyOrdersQueue.Enqueue(o, o));

        }

        public static string? DisplayOrdersQueue()
        {
            //return base.ToString();
            string ToDoOutput = "";
            //string ToDoOutput = $"ToDo Id: {ToDoId}; ToDo Date: {ToDoDate}; ";
            // Since opted to rather than regular Queue create a PriorityQueue static Property/attribute
            // for the order class
            //if (OrdersQueue != null)
            if (PriortyOrdersQueue != null)
            {

                //ToDoOutput += $"Orders in Queue: {OrdersQueue.Count}\n Orders: \n";
                ToDoOutput += $"Orders in PriortyOrdersQueue: {PriortyOrdersQueue.Count}\n Orders: \n";
                //foreach (Order order in OrdersQueue)
                // Can use foreach w/ PriorityQeueue since no GetEnumerator 
                //foreach (Order order in PriortyOrdersQueue)
                // have to use a while loop to dequeue() each value in the queue instead
                // create index
                int i = 1;
                while (PriortyOrdersQueue.Count > 0)
                {
                    //ToDoOutput += $"{order.ToString} \n";
                    //ToDoOutput += $"#{i}: {PriortyOrdersQueue.Dequeue().ToString} \n";
                    // above output: System.Func`1[System.String]
                    ToDoOutput += $"#{i}: {PriortyOrdersQueue.Dequeue().ToString()} \n";
                    // increment i
                    i++;
                }

            }
            else
            {
                //ToDoOutput += $"Orders in Queue: none;";
                ToDoOutput += $"Orders in PriortyOrdersQueue: none;";
            }
            return ToDoOutput;
        }

        public static Order? DequeueOrder()
        {
            if (PriortyOrdersQueue != null)
            {
                // ?? 1st Peek() at the first order in queue & only Dequeue()
                // after verifying OrderFilled has a DateTime value & IsOrderComplete = true;
                Order currentOrder = PriortyOrdersQueue.Peek();
                if (currentOrder.IsOrderComplete == true && currentOrder.OrderFilled != null)
                {
                    currentOrder = PriortyOrdersQueue.Dequeue();
                    return currentOrder;
                }
                //Order currentOrder = PriortyOrdersQueue.Dequeue();
                //return currentOrder;
                else
                {
                    // Temp debug print statement
                    Console.WriteLine("DequeueOrder() method - order IsOrderComplete & OrderFilled filled conditions not met");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static Order? PeekAtOrder()
        {
            if (PriortyOrdersQueue != null)
            {
                Order currentOrder = PriortyOrdersQueue.Peek();
                return currentOrder;
            }
            else
            {
                return null;
            }
        }

        public string? DisplayDrinksInOrder()
        //public string? DisplayDrinksInOrder(Order order)
        {
            //string orderfilledString =  ($"{OrderFilled}" != null || $"{OrderFilled}" != "" || $"{OrderFilled}" != "undefined" ? $"{OrderFilled}" : "in progress");
            string orderfilledString = OrderFilled != null ? $"{OrderFilled}" : "in progress";
            //string orderfilledString = OrderFilled != null || OrderFilled != "" || OrderFilled != "undefined" ? $"{OrderFilled};" : "in progress; ";
            //string orderfilledString = OrderFilled is not null or not "" or not (DateTime)"undefined" ? $"{OrderFilled};" : "in progress; ";
            // temp debugging print statement
            //Console.WriteLine(orderfilledString);
            string orderOutput = $"Order Id: {OrderId};\n Order Date/Time: {OrderDate}; Date/Time Order Completed: {orderfilledString}; Order Completed: {IsOrderComplete};\n";
            //string orderOutput = $"Order Id: {OrderId};\n Order Date/Time: {OrderDate}; Date/Time Order Completed: {($"{OrderFilled}" != null || $"{OrderFilled}" != "" || $"{OrderFilled}" != "undefined" ? $"{OrderFilled};" : "in progress; ")} Order Completed: {IsOrderComplete};\n";
            orderOutput += $"Drinks: \n";
            //if (OrderDetails != null)
            if (OrderDrinkList != null)
            {
                foreach (Drink drink in OrderDrinkList)
                {
                    orderOutput += $"{drink} \n";
                }
            }
            else
            {
                //orderOutput += "Drinks: No drinks in this order. \n";
                orderOutput += "No drinks in this order. \n";
            }
            // Decide on OrderTotal formatting if want '$' - and specify 2 decimal place outputis C2
            // if just want 2 decimal places w/o '$' sign use D2. 
            //orderOutput += $"Order Total: $ {OrderTotal:D2}";
            orderOutput += $"Order Total: $ {OrderTotal}\n";
            return orderOutput;
        }

        // ?? change method return type from void to Drink? so can give feedback to user
        // in situation where Drink not found in list. vs returning string message to user. 
        // public Drink? CompleteDrinkInOrder(int drinkId)
        public void CompleteDrinkInOrder(int drinkId)
        {
            Drink currentDrink = Drink.GetDrinkById(drinkId);
            if (currentDrink != null)
            //if (Drink.GetDrinkById(drinkId) != null)
            {
                if (OrderDrinkList != null)
                {
                    if (OrderDrinkList.Contains(currentDrink))
                    {
                        // call Drink class DrinkCompleted() method
                        // to change DrinkMade property value to true;
                        currentDrink.DrinkCompleted();
                    }
                    /*foreach (Drink drink in OrderDrinkList)
                    {
                        if (drink.Equals(currentDrink))
                        //if (currentDrink.Equals(drink))
                        {
                            
                        }
                    }*/
                }
                
            }
        }

        public string? DrinksStillToCompleteInOrder()
        {
            //string orderfilledString =  ($"{OrderFilled}" != null || $"{OrderFilled}" != "" || $"{OrderFilled}" != "undefined" ? $"{OrderFilled}" : "in progress");
            string orderfilledString = OrderFilled != null ? $"{OrderFilled}" : "in progress";
            //string orderfilledString = OrderFilled != null || OrderFilled != "" || OrderFilled != "undefined" ? $"{OrderFilled};" : "in progress; ";
            //string orderfilledString = OrderFilled is not null or not "" or not (DateTime)"undefined" ? $"{OrderFilled};" : "in progress; ";
            // temp debugging print statement
            //Console.WriteLine(orderfilledString);
            string orderOutput = $"Order Id: {OrderId};\n Order Date/Time: {OrderDate}; Date/Time Order Completed: {orderfilledString}; Order Completed: {IsOrderComplete};\n";
            //string orderOutput = $"Order Id: {OrderId};\n Order Date/Time: {OrderDate}; Date/Time Order Completed: {orderfilledString}; Order Completed: {IsOrderComplete};\n";
            //string orderOutput = $"Order Id: {OrderId};\n Order Date/Time: {OrderDate}; Date/Time Order Completed: {($"{OrderFilled}" != null || $"{OrderFilled}" != "" || $"{OrderFilled}" != "undefined" ? $"{OrderFilled};" : "in progress; ")} Order Completed: {IsOrderComplete};\n";
            orderOutput += $"Drinks: \n";
            //if (OrderDetails != null)
            if (OrderDrinkList != null)
            {
                string pendingDrinks = "";
                string completedDrinks = "";
                foreach (Drink drink in OrderDrinkList)
                {
                    if (drink.DrinkMade != true)
                    {
                        //orderOutput += $"{drink} \n";
                        pendingDrinks += $"{drink} \n";
                    }
                    else
                    {
                        completedDrinks += $"{drink} \n";
                    }
                    
                }
                //orderOutput += $"Drinks: \n";
                orderOutput += $"Still to complete: \n";
                orderOutput += $"{pendingDrinks} \n";
                orderOutput += $"Completed: \n";
                orderOutput += $"{completedDrinks} \n";
            }
            else
            {
                //orderOutput += "Drinks: No drinks in this order. \n";
                orderOutput += "No drinks in this order. \n";
            }
            // Decide on OrderTotal formatting if want '$' - and specify 2 decimal place outputis C2
            // if just want 2 decimal places w/o '$' sign use D2. 
            //orderOutput += $"Order Total: $ {OrderTotal:D2}";
            orderOutput += $"Order Total: $ {OrderTotal}\n";
            return orderOutput;
        }

        // ?? change method return type from void to string? so can give feedback to user??
        // in situation where all Drinks in Order are not completed.
        public string? CompleteOrder()
        //public void CompleteOrder()
        {
            string output = "";
            if (OrderDrinkList != null)
            //if (OrderDrinkList != null && IsOrderComplete != true)
            {
                foreach (Drink drink in OrderDrinkList)
                {
                    if ( drink.DrinkMade != true)
                    {
                        output += DrinksStillToCompleteInOrder();
                        return output;
                        //break;
                    }
                    // Move from here to outside foreach - if placed here it triggers this to
                    // run multiple times once for each drink in order.
                    /*// if all drinks in OrderDrinkList have been made then
                    OrderFilled = new DateTime();
                    IsOrderComplete = true;
                    output += $"Date/Time Order Completed: {OrderFilled}; Order Completed: {IsOrderComplete};\n";
                    // ?? Dequeue Order from Priority Queue was it has been completed??
                    // By calling DequeueOrder() method or PriortyOrdersQueue.Dequeue();*/
                }
                // 
                // if all drinks in OrderDrinkList have been made then
                //OrderFilled = new DateTime();
                OrderFilled = DateTime.Now;
                IsOrderComplete = true;
                output += $"Date/Time Order Completed: {OrderFilled}; Order Completed: {IsOrderComplete};\n";
                // ?? Dequeue Order from Priority Queue was it has been completed??
                // By calling DequeueOrder() method or PriortyOrdersQueue.Dequeue();
            }
            else
            {
                output += "No drinks in this order. \n";
            }
            return output;
        }


        public override bool Equals(object? obj)
        {
            //return base.Equals(obj);
            if (obj == null) return false;
            Order objAsDate = obj as Order;
            if (objAsDate == null) return false;
            else return Equals(objAsDate);
        }

        public int SortByDateAscending(DateTime date1, DateTime date2)
        {
            return date1.CompareTo(date2);
        }

        // Moved below to separate OrdersQueueComparer class
        /*public int Compare(Order? x, Order? y)
        {
            //throw new NotImplementedException();
            // goal is to give oldest/older date/time higher priority
            // so those orders are filled first.
            if (x.OrderDate == y.OrderDate)
            {
                // if same date/time
                return 0;
            }
            else if (x.OrderDate > y.OrderDate)
            {
                // the lower the priory value, the higher the priority
                // if Order x is older than Order y
                return -1;
            }
            else
            {
                // the lower the priory value, the higher the priority
                // if Order y is older than Order x (aka Order x is 'younger'
                // than Order y).
                return 1;
            }
        }*/

        // Default comparer for Order by OrderDate
        public int CompareTo(Order compareOrder)
        {
            if (compareOrder == null)
            {
                return 1;
            }
            else
            {
                return this.OrderDate.CompareTo(compareOrder.OrderDate);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /*public override DateTime GetHashCode()
        {
            //return base.GetHashCode();
            return OrderDate;
        }*/

        public bool Equals(Order other)
        //public override bool Equals(object? obj)
        {
            //return base.Equals(obj);
            if (other == null) return false;
            return (this.OrderDate.Equals(other.OrderDate));
        }


        public override string? ToString()
        {
            //return base.ToString();
            //string orderfilledString =  ($"{OrderFilled}" != null || $"{OrderFilled}" != "" || $"{OrderFilled}" != "undefined" ? $"{OrderFilled}" : "in progress");
            //string orderfilledString = OrderFilled != null ? $"{OrderFilled}" : "in progress";
            //string orderfilledString = OrderFilled != null || OrderFilled != "" || OrderFilled != "undefined" ? $"{OrderFilled};" : "in progress; ";
            //string orderfilledString = OrderFilled is not null or not "" or not (DateTime)"undefined" ? $"{OrderFilled};" : "in progress; ";
            // temp debugging print statement
            //Console.WriteLine(orderfilledString);
            //string orderOutput = $"Order Id: {OrderId};\n Order Date/Time: {OrderDate}; Date/Time Order Completed: {orderfilledString}; Order Completed: {IsOrderComplete};\n";
            //return $"Order Id: {OrderId}; Order Date: {OrderDate}; Customer Id: {Customer.CustomerId}; Customer Name: {Customer.FirstName} {Customer.LastName}; ";
            //var filledOutput = ({ OrderFilled} != null) ? $"{OrderFilled};" : $"in progress;");
            //var filledOutput = ({ OrderFilled} != null) ? {OrderFilled} : "in progress;");
            string orderOutput = $"Order Id: {OrderId};\n Order Date/Time: {OrderDate}; Date/Time Order Completed: {($"{ OrderFilled}" != null || $"{OrderFilled}" != "" || $"{OrderFilled}" != "undefined" ? $"{OrderFilled};" : "in progress; ")} Order Completed: {IsOrderComplete};\n";
            //string orderOutput = $"Order Id: {OrderId}; Order Date/Time: {OrderDate}; Date/Time Order Completed: {OrderFilled}; Order Completed: {IsOrderComplete};\n";
            //orderOutput += $"Customer Id: {CustomerId}: {Customer};\n";
            //orderOutput += $"Customer Id: {CustomerId}: {Order.Customer};\n";
            //orderOutput += $"Customer Id: {CustomerId} {Customer.ToString};\n";
            //orderOutput += $"Customer Id: {CustomerId} {Customer.LastName};\n";
            //orderOutput += $"Customer Id: {Customer.CustomerId}; Customer Name: {Customer.FirstName} {Customer.LastName}; \n";
            orderOutput += $"Customer Id: {Customer.CustomerId};\n Customer Name: {Customer.FirstName} {Customer.LastName}; Phone: {Customer.Phone}; Email: {Customer.Email}\n";
            //string orderOutput = $"Order Id: {OrderId}; Order Date/Time: {OrderDate}; Date/Time Order Completed: {OrderFilled}; Order Completed: {IsOrderComplete}; /nCustomer Id: {Customer.CustomerId}; Customer Name: {Customer.FirstName} {Customer.LastName}; \n";
            //string orderOutput = $"Order Id: {OrderId}; Order Date/Time: {OrderDate}; Date/Time Order Completed: {OrderFilled}; Order Completed: {IsOrderComplete}; /nCustomer Id: {Order.Customer.CustomerId}; Customer Name: {Order.Customer.FirstName} {Order.Customer.LastName}; /n";
            //string orderOutput = $"Order Id: {OrderId}; Order Date/Time: {OrderDate}; Date/Time Order Completed: {OrderFilled}; Order Completed: {IsOrderComplete}; /nCustomer: {Customer.ToString};/n";

            orderOutput += $"Drinks: \n";
            //if (OrderDetails != null)
            if (OrderDrinkList != null)
            //if (Drinks != null)
            {
                //orderOutput += $"Drinks: /n";
                //foreach (OrderDetail drink in OrderDetails)
                //foreach (Drink drink in Drinks)
                foreach (Drink drink in OrderDrinkList)
                {
                    //orderOutput += $"{Drink.drink.ToString} \n";
                    //orderOutput += $"{drink.Drink.ToString} \n";
                    //orderOutput += $"{drink.ToString}\n";
                    //orderOutput += $"{drink.ToString()}\n";
                    orderOutput += $"{drink} \n";
                }
            }
            else
            {
                //orderOutput += "Drinks: No drinks in this order. \n";
                orderOutput += "No drinks in this order. \n";
            }
            // Decide on OrderTotal formatting if want '$' - and specify 2 decimal place outputis C2
            // if just want 2 decimal places w/o '$' sign use D2. 
            //orderOutput += $"Order Total: $ {OrderTotal:D2}";
            orderOutput += $"Order Total: $ {OrderTotal}\n";
            return orderOutput;
        }

        
    }
}