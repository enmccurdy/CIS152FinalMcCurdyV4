/***************************************************************
* Name : DrinkShopV4ConsoleApp Project's Program.cs driver class file
* Author: Elizabeth McCurdy
* Created : 04/30/2024
* Course: CIS 152 - Data Structure
* Version: 4.0
* OS: Windows 11
* IDE: Visual Studio Community 2022
* Copyright : This is my own original work 
* based on specifications issued by our instructor
* Description: CIS152FinalMcCurdyV4 fourth version of final project
*   for Spring 2024 Data Structures class - 
*   DrinkShopV4ConsoleApp - Console App only version of project. 
*   
*   >>Clothing super class - blue print for Clothing super class objects,
*   with constructor(s), getters/setters (mutators/accessors), method(s) and ToString()
*   method to display details regarding the Clothing super class objects to the console.
*            Input: String - size, String - color for each instance of 
*            Clothing super class object
*            Output: ToString() method to display details about the Clothing
*            super class object to the console.
*            wash() & pack() method display details about care of Clothing
*            super class object to the console.
*            BigO: O(n) 0 linear algorithm whose runtime would grow in
*            direct proportion to n (number of objects created for the Clothing
*            super class). <<
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or
* unmodified. I have not given other fellow student(s) access
* to my program.
***************************************************************/

using System.Numerics;

namespace DrinkShopV4ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //seed data - had to go through Order class to create the Customer and Drink class objects
            // associated with it, to get program to work correctly. 
            // public Order(string firstName, string lastName, string email, string phone, string drinkName, string drinkSize)
            //Order order1, Customer customer1, Drink drink1 = new Order("Alexa", "Carsons", "acarson@fake.edu", "222-444-5555", "WhiteChocolateMocha", "regular");
            Order order1 = new Order("Alexa", "Carsons", "acarson@fake.edu", "222-444-5555", "WhiteChocolateMocha", "regular");
            Order order2 = new Order("Andrea", "Meridian", "ameridian@fake.edu", "IcedTea", "regular");
            Order order3 = new Order("Arturo", "Archibalt", "aarchibalt@fake.edu", "222-555-8855", "VanillaItalianSoda", "regular");
            Order order4 = new Order("BA", "Baracus", "babaracus@fake.edu", "StrawberryItalianSoda", "small");
            Order order5 = new Order("Ying", "Yang", "yyang@fake.edu", "222-333-4455", "Americano", "regular");
            Order order6 = new Order("Justice", "Prevails", "jprevails@fake.edu", "Mocha", "regular");
            Order order7 = new Order("Norman", "Oswald", "greengoblin@fake.org", "222-222-3535", "Latte", "regular");
            Order order8 = new Order("Oliver", "Twist", "otwist@fake.edu", "CherryItalianSoda", "large");
            
            // Any additional Drink objects in the order had to be added separately - again using 
            // Order class methods. 
            /*new Drink { OrderId = 1, DrinkName = "WhiteChocolateMocha", DrinkSize = "regular" },
            new Drink { OrderId = 1, DrinkName = "WhiteChocolateMocha", DrinkSize = "small" },
            new Drink { OrderId = 1, DrinkName = "WhiteChocolateMocha", DrinkSize = "large" },
            new Drink { OrderId = 2, DrinkName = "IcedTea", DrinkSize = "regular" },
            new Drink { OrderId = 2, DrinkName = "GreenTea", DrinkSize = "small" },
            new Drink { OrderId = 2, DrinkName = "ChaiTea", DrinkSize = "large" },
            new Drink { OrderId = 3, DrinkName = "VanillaItalianSoda", DrinkSize = "regular" },
            new Drink { OrderId = 4, DrinkName = "StrawberryItalianSoda", DrinkSize = "small" },
            new Drink { OrderId = 4, DrinkName = "CherryItalianSoda", DrinkSize = "large" },
            new Drink { OrderId = 5, DrinkName = "Americano", DrinkSize = "regular" },
            new Drink { OrderId = 6, DrinkName = "Mocha", DrinkSize = "regular" },
            new Drink { OrderId = 7, DrinkName = "Latte", DrinkSize = "regular" },*/
            order1.AddDrinkToOrder("WhiteChocolateMocha", "small");
            order1.AddDrinkToOrder("WhiteChocolateMocha", "large");
            order2.AddDrinkToOrder("GreenTea", "small");
            order2.AddDrinkToOrder("ChaiTea", "large");
            order4.AddDrinkToOrder("CherryItalianSoda", "large");

            var orders = new List<Order>()
            {
                order1,
                order2,
                order3,
                order4,    
                order5,
                order6,
                order7,
                order8
            /*new Order { CustomerId = 1, new Drink { DrinkName = "WhiteChocolateMocha", DrinkSize = "regular" } },
            new Order { CustomerId = 2, new Drink { DrinkName = "IcedTea", DrinkSize = "regular" } },
            new Order { CustomerId = 3, new Drink { DrinkName = "VanillaItalianSoda", DrinkSize = "regular" } },
            new Order { CustomerId = 4, new Drink { DrinkName = "StrawberryItalianSoda", DrinkSize = "small" } },
            new Order { CustomerId = 5, new Drink { DrinkName = "Americano", DrinkSize = "regular" } },
            new Order { CustomerId = 6, new Drink { DrinkName = "Mocha", DrinkSize = "regular" } },
            new Order { CustomerId = 7, new Drink { DrinkName = "Latte", DrinkSize = "regular" } },*/
            /*new Order { new Customer { FirstName = "Carsons", LastName = "Alexa", Email = "acarson@fake.edu", Phone = "222-444-5555" }, new Drink { DrinkName = "WhiteChocolateMocha", DrinkSize = "regular" } },
            new Order { CustomerId = 2, new Drink { DrinkName = "IcedTea", DrinkSize = "regular" } },
            new Order { CustomerId = 3, new Drink { DrinkName = "VanillaItalianSoda", DrinkSize = "regular" } },
            new Order { CustomerId = 4, new Drink { DrinkName = "StrawberryItalianSoda", DrinkSize = "small" } },
            new Order { CustomerId = 5, new Drink { DrinkName = "Americano", DrinkSize = "regular" } },
            new Order { CustomerId = 6, new Drink { DrinkName = "Mocha", DrinkSize = "regular" } },
            new Order { CustomerId = 7, new Drink { DrinkName = "Latte", DrinkSize = "regular" } },*/
            /*new Order { FirstName = "Carsons", LastName = "Alexa", Email = "acarson@fake.edu", Phone = "222-444-5555" }, new Drink { DrinkName = "WhiteChocolateMocha", DrinkSize = "regular" } },
            new Order { CustomerId = 2, new Drink { DrinkName = "IcedTea", DrinkSize = "regular" } },
            new Order { CustomerId = 3, new Drink { DrinkName = "VanillaItalianSoda", DrinkSize = "regular" } },
            new Order { CustomerId = 4, new Drink { DrinkName = "StrawberryItalianSoda", DrinkSize = "small" } },
            new Order { CustomerId = 5, new Drink { DrinkName = "Americano", DrinkSize = "regular" } },
            new Order { CustomerId = 6, new Drink { DrinkName = "Mocha", DrinkSize = "regular" } },
            new Order { CustomerId = 7, new Drink { DrinkName = "Latte", DrinkSize = "regular" } },*/
            };
            Console.WriteLine("Display all Order class objects created using Order ToString() method: ");
            foreach (Order order in orders)
            {
                Console.WriteLine(order.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Use Drink.GetDrinkById(int drinkId) to display drink1 Drink class object created with first Order class object: ");
            Drink drink1 = Drink.GetDrinkById(1);
            Console.WriteLine(drink1);
            Console.WriteLine();

            Console.WriteLine("Use Customer.GetCustomerById(int customerId) to display customer1 Customer class object created with first Order class object: ");
            Customer customer1 = Customer.GetCustomerById(1);
            Console.WriteLine(customer1);
            Console.WriteLine();

            Console.WriteLine("Use DisplayCustomerOrders() method to display all of customer1 Customer class object's associated Order object(s): (only 1 order currently)");
            Console.WriteLine(customer1.DisplayCustomerOrders());
            Console.WriteLine();

            Console.WriteLine("Use Customer.DisplayAllCustomers() method to Display all Customer class objects created with Order class objects: ");
            Console.WriteLine(Customer.DisplayAllCustomers()); 
            Console.WriteLine();

            Console.WriteLine("Display all Sorted Customer class objects created with Order class objects - using MergeSort() method I wrote: ");
            // MinHeap not sorting customers correctly so create MergeSortCustomersList() method which
            // then calls the MergeSort() recursive method which uses the Merge() helper method to sort an
            // array
            // Call the Customer class's MergeSortCustomersList() method to create the sorted array
            Customer.MergeSortCustomersList();
            // Then call method to display the sorted array.  The MergeSort() worked!
            Console.WriteLine(Customer.DisplayAllSortedCustomers());
            Console.WriteLine();

            /*Console.WriteLine("Display all Customer class objects in MinHeap: ");
            Console.WriteLine(Customer.DisplayCustomersMinHeap());
            Console.WriteLine();*/

            /*Console.WriteLine("Display all Customer class objects in MinHeap Array: ");
            Console.WriteLine(Customer.DisplayCustomersHeapArray());
            Console.WriteLine();*/

            Console.WriteLine("Display all Order class objects created with Order class objects using Order.DisplayAllOrders() method: ");
            Console.WriteLine(Order.DisplayAllOrders());
            Console.WriteLine();

            // Now trial of creating the PriorityQueue of all the Orders, then displaying them
            // by dequeueing each value from the Priority Qeueue. 
            // Call CreateOrdersQueue() method to create the PriorityQueue of Order objects - prioritized
            // by date/time
            Console.WriteLine("Call CreateOrdersQueue() method to create the PriorityQueue of Order objects - prioritized by date/time: ");
            Order.CreateOrdersQueue();
            Console.WriteLine("Then Display all Order class objects by dequeueing each from the PriorityQueue using Order.DisplayOrdersQueue() method: ");
            Console.WriteLine(Order.DisplayOrdersQueue());
            Console.WriteLine();

            // Re-create PriorityQueue of Order objects
            Console.WriteLine("Re-Call CreateOrdersQueue() method to recreate the PriorityQueue of Order objects - prioritized by date/time: ");
            Order.CreateOrdersQueue();
            // now use PeekAtOrder() method to Peek at first order in Queue
            Console.WriteLine("Then use Order.PeekAtOrder() method to peek at first Order object in the PriorityQueue: ");
            Order currentOrder = Order.PeekAtOrder();
            //Console.WriteLine(Order.PeekAtOrder());
            Console.WriteLine();
            // Then use DisplayDrinksInOrder() method to just display the Drinks for that order
            Console.WriteLine("Then use DisplayDrinksInOrder() method to Display this Orders Drink object details by peeking at first Order in the PriorityQueue: ");
            Console.WriteLine(currentOrder.DisplayDrinksInOrder());
            Console.WriteLine();

            // then use CompleteDrinkInOrder(int drinkId), and the CompleteOrder(), DrinksStillToCompleteInOrder()
            // methods to process through and complete all the drinks for that order. 
            Console.WriteLine("Then use CompleteDrinkInOrder(int drinkId) method to complete the passed in Drink object for this order: Drink 1");
            currentOrder.CompleteDrinkInOrder(1);
            //Console.WriteLine(currentOrder.CompleteDrinkInOrder(1));
            Console.WriteLine();

            Console.WriteLine("Then use DrinksStillToCompleteInOrder() method to display which Drinks still need to be made for this order: ");
            Console.WriteLine(currentOrder.DrinksStillToCompleteInOrder());
            Console.WriteLine();

            Console.WriteLine("Then before all drinks completed call CompleteOrder() method to demo triggering call to DrinksStillToCompleteInOrder() method to show can't complete the Order object yet: ");
            Console.WriteLine(currentOrder.CompleteOrder());
            Console.WriteLine();

            Console.WriteLine("Keep using CompleteDrinkInOrder(int drinkId) method to complete all the Drinks in this order: Drink 9 ");
            currentOrder.CompleteDrinkInOrder(9);
            Console.WriteLine();
            
            Console.WriteLine("Recall DrinksStillToCompleteInOrder() method after each CompleteDrinkInOrder(int drinkId) method call to display which Drinks still need to be made for this order: ");
            Console.WriteLine(currentOrder.DrinksStillToCompleteInOrder());
            Console.WriteLine();

            Console.WriteLine("Then before all drinks completed call DequeueOrder() method to demo can't Dequeue order from PriorityQueue until complete the Order object and the order IsOrderComplete & OrderFilled filled conditions are met: ");
            Order demoDequeueOrder = Order.DequeueOrder();
            Console.WriteLine(demoDequeueOrder);
            Console.WriteLine();

            Console.WriteLine("Keep using CompleteDrinkInOrder(int drinkId) method to complete all the Drinks in this order: Drink 10");
            currentOrder.CompleteDrinkInOrder(10);
            Console.WriteLine();

            Console.WriteLine("Recall DrinksStillToCompleteInOrder() method after each CompleteDrinkInOrder(int drinkId) method call to display which Drinks still need to be made for this order: ");
            Console.WriteLine(currentOrder.DrinksStillToCompleteInOrder());
            Console.WriteLine();

            Console.WriteLine("Then once all drinks complete use CompleteOrder() method to complete the Order object: ");
            Console.WriteLine(currentOrder.CompleteOrder());
            Console.WriteLine();

            // Last can only use DequeueOrder() method to get remove/return first order from Queue only if 
            // order IsOrderComplete & OrderFilled filled conditions are met
            Console.WriteLine("Last can now demo can only use DequeueOrder() method to Dequeue order from PriorityQueue now that the Order object is complete and the order IsOrderComplete & OrderFilled filled conditions are met: ");
            Order demoDequeueOrder2 = Order.DequeueOrder();
            Console.WriteLine(demoDequeueOrder2);
            Console.WriteLine();

            // now use PeekAtOrder() method to Peek at next order in Queue
            Console.WriteLine("Then use PeekAtOrder() method to peek at second/next Order object in the PriorityQueue: ");
            Order secondOrder = Order.PeekAtOrder();
            Console.WriteLine();
            // Then use DisplayDrinksInOrder() method to just display the Drinks for that order
            Console.WriteLine("Use DisplayDrinksInOrder() method to Display this Order's Drink object details for the next Order in the PriorityQueue: ");
            Console.WriteLine(secondOrder.DisplayDrinksInOrder());
            Console.WriteLine();

            /*var customers = new List<Customer>()
            {
            new Customer{FirstName="Alexa",LastName="Carsons",Email="acarson@fake.edu", Phone="222-444-5555"},
            new Customer{FirstName="Andrea",LastName="Meridian",Email="ameridian@fake.edu"},
            new Customer{FirstName="Arturo",LastName="Archibalt",Email="aarchibalt@fake.edu", Phone="222-555-8855"},
            new Customer{FirstName="BA",LastName="Baracus",Email="babaracus@fake.edu"},
            new Customer{FirstName="Ying",LastName="Yang",Email="yyang@fake.edu", Phone="222-333-4455"},
            new Customer{FirstName="Justice",LastName="Prevails",Email="jprevails@fake.edu"},
            new Customer{FirstName="Norman",LastName="Oswald",Email="greengoblin@fake.org", Phone="222-222-3535"},
            new Customer{FirstName="Oliver",LastName="Twist",Email="otwist@fake.edu"}
            };*/

            /*foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }*/
            //Console.WriteLine();
            //var drinks = new List<Drink>()
            //{
                // Enum version 
            /*new Drink{DrinkId=101,OrderId=1,DrinkName=DrinkName.WhiteChocolateMocha, DrinkType="coffee", DrinkSize="regular"},
            new Drink{DrinkId=102,OrderId=1,DrinkName=DrinkName.WhiteChocolateMocha, DrinkType="coffee", DrinkSize="small"},
            new Drink{DrinkId=103,OrderId=1,DrinkName=DrinkName.WhiteChocolateMocha, DrinkType="coffee", DrinkSize="large"},
            new Drink{DrinkId=104,OrderId=2,DrinkName=DrinkName.IcedTea, DrinkType="tea", DrinkSize="regular"},
            new Drink{DrinkId=105,OrderId=2,DrinkName=DrinkName.GreenTea, DrinkType="tea", DrinkSize="small"},
            new Drink{DrinkId=106,OrderId=2,DrinkName=DrinkName.ChaiTea, DrinkType="tea", DrinkSize="large"},
            new Drink{DrinkId=107,OrderId=3,DrinkName=DrinkName.VanillaItalianSoda, DrinkType="soda", DrinkSize="regular"},
            new Drink{DrinkId=108,OrderId=4,DrinkName=DrinkName.StrawberryItalianSoda, DrinkType="soda", DrinkSize="small"},
            new Drink{DrinkId=109,OrderId=4,DrinkName=DrinkName.CherryItalianSoda, DrinkType="soda", DrinkSize="large"},
            new Drink{DrinkId=110,OrderId=5,DrinkName=DrinkName.Americano, DrinkType="coffee", DrinkSize="regular"},
            new Drink{DrinkId=111,OrderId=6,DrinkName=DrinkName.Mocha, DrinkType="coffee", DrinkSize="regular"},
            new Drink{DrinkId=112,OrderId=7,DrinkName=DrinkName.Latte, DrinkType="coffee", DrinkSize="regular"},*/
            // string version 
            /*new Drink{DrinkId=101,OrderId=1,DrinkName="WhiteChocolateMocha", DrinkType="coffee", DrinkSize="regular"},
            new Drink{DrinkId=102,OrderId=1,DrinkName="WhiteChocolateMocha", DrinkType="coffee", DrinkSize="small"},
            new Drink{DrinkId=103,OrderId=1,DrinkName="WhiteChocolateMocha", DrinkType="coffee", DrinkSize="large"},
            new Drink{DrinkId=104,OrderId=2,DrinkName="IcedTea", DrinkType="tea", DrinkSize="regular"},
            new Drink{DrinkId=105,OrderId=2,DrinkName="GreenTea", DrinkType="tea", DrinkSize="small"},
            new Drink{DrinkId=106,OrderId=2,DrinkName="ChaiTea", DrinkType="tea", DrinkSize="large"},
            new Drink{DrinkId=107,OrderId=3,DrinkName="VanillaItalianSoda", DrinkType="soda", DrinkSize="regular"},
            new Drink{DrinkId=108,OrderId=4,DrinkName="StrawberryItalianSoda", DrinkType="soda", DrinkSize="small"},
            new Drink{DrinkId=109,OrderId=4,DrinkName="CherryItalianSoda", DrinkType="soda", DrinkSize="large"},
            new Drink{DrinkId=110,OrderId=5,DrinkName="Americano", DrinkType="coffee", DrinkSize="regular"},
            new Drink{DrinkId=111,OrderId=6,DrinkName="Mocha", DrinkType="coffee", DrinkSize="regular"},
            new Drink{DrinkId=112,OrderId=7,DrinkName="Latte", DrinkType="coffee", DrinkSize="regular"},*/
            // string version - DrinkType & DrinkPrice assigned by setter, DrinkId & DrinkMade set by Constructors
            /*new Drink{OrderId=1,DrinkName="WhiteChocolateMocha", DrinkSize="regular"},
            new Drink{OrderId=1,DrinkName="WhiteChocolateMocha", DrinkSize="small"},
            new Drink{OrderId=1,DrinkName="WhiteChocolateMocha", DrinkSize="large"},
            new Drink{OrderId=2,DrinkName="IcedTea", DrinkSize="regular"},
            new Drink{OrderId=2,DrinkName="GreenTea", DrinkSize="small"},
            new Drink{OrderId=2,DrinkName="ChaiTea", DrinkSize="large"},
            new Drink{OrderId=3,DrinkName="VanillaItalianSoda", DrinkSize="regular"},
            new Drink{OrderId=4,DrinkName="StrawberryItalianSoda", DrinkSize="small"},
            new Drink{OrderId=4,DrinkName="CherryItalianSoda", DrinkSize="large"},
            new Drink{OrderId=5,DrinkName="Americano", DrinkSize="regular"},
            new Drink{OrderId=6,DrinkName="Mocha", DrinkSize="regular"},
            new Drink{OrderId=7,DrinkName="Latte", DrinkSize="regular"},
            };*/

            /*foreach (Drink drink in drinks)
            {
                Console.WriteLine(drink.ToString());
            } */
            //Console.WriteLine();
            // None of below variations worked to create Order objects
            /*Order order1 = new Order { CustomerId = 1, new Drink(Drink.OrderId = 1, Drink.DrinkName = "WhiteChocolateMocha", Drink.DrinkSize = "regular") };
            Order order2 = new Order { CustomerId = 2, new Drink(Drink.DrinkName = "IcedTea", DrinkSize = "regular") };
            Order order3 = new Order { CustomerId = 3, new Drink(Drink.DrinkName = "VanillaItalianSoda", DrinkSize = "regular") };
            Order order4 = new Order { CustomerId = 4, new Drink(Drink.DrinkName = "StrawberryItalianSoda", DrinkSize = "small") };
            Order order5 = new Order { CustomerId = 5, new Drink(Drink.DrinkName = "Americano", DrinkSize = "regular") };
            Order order6 = new Order { CustomerId = 6, new Drink(Drink.DrinkName = "Mocha", DrinkSize = "regular") };
            Order order7 = new Order { CustomerId = 7, new Drink(Drink.DrinkName = "Latte", DrinkSize = "regular") };*/

            /*Order order1b = new Order { CustomerId = 1, new Drink { Drink.OrderId = 1, Drink.DrinkName = "WhiteChocolateMocha", Drink.DrinkSize = "regular" } };
            Order order2b = new Order { CustomerId = 2, new Drink { OrderId = 2, DrinkName = "IcedTea", DrinkSize = "regular" } };
            Order order3b = new Order { CustomerId = 3, new Drink { OrderId = 3, DrinkName = "VanillaItalianSoda", DrinkSize = "regular" } };
            Order order4b = new Order { CustomerId = 4, new Drink { OrderId = 4, DrinkName = "StrawberryItalianSoda", DrinkSize = "small" } };
            Order order5b = new Order { CustomerId = 5, new Drink { OrderId = 5, DrinkName = "Americano", DrinkSize = "regular" } };
            Order order6b = new Order { CustomerId = 6, new Drink { OrderId = 6, DrinkName = "Mocha", DrinkSize = "regular" } };
            Order order7b = new Order { CustomerId = 7, new Drink { OrderId = 7, DrinkName = "Latte", DrinkSize = "regular" } };*/

            //var orders = new List<Order>()
            //{
            // ToDo class removed from app
            /*new Order{OrderId=1,OrderDate=seedDate,CustomerId=1,ToDoId=101},
            new Order{OrderId=2,OrderDate=(seedDate),CustomerId=2,ToDoId=101},
            new Order{OrderId=3,OrderDate=(seedDate),CustomerId=3,ToDoId=101},
            new Order{OrderId=4,OrderDate=(seedDate),CustomerId=4,ToDoId=101},
            new Order{OrderId=5,OrderDate=(seedDate),CustomerId=5,ToDoId=101},
            new Order{OrderId=6,OrderDate=(seedDate),CustomerId=6,ToDoId=101},
            new Order{OrderId=7,OrderDate=(seedDate),CustomerId=7,ToDoId=101},*/
            /*new Order { OrderId = 7, OrderDate = DateTime.Parse("2005-04-01"), CustomerId = 7, ToDoId = 101 }*/
            // V4 version - OrderId, OrderDate, OrderFilled & IsOrderComplete set by Constructors
            // Below only version that worked for creating order objects after customer and drink objects made. 
           /* new Order{CustomerId=1,DrinkId=1},
            new Order{CustomerId=2,DrinkId=4},
            new Order{CustomerId=3,DrinkId=7},
            new Order{CustomerId=4,DrinkId=8},
            new Order{CustomerId=5,DrinkId=10},
            new Order{CustomerId=6,DrinkId=11},
            new Order{CustomerId=7,DrinkId=12},*/
            /*new Order{CustomerId=1,new Drink(Drink.DrinkName="WhiteChocolateMocha", drinkSize="regular")},
            new Order{CustomerId=2,DrinkId=4},
            new Order{CustomerId=3,DrinkId=7},
            new Order{CustomerId=4,DrinkId=8},
            new Order{CustomerId=5,DrinkId=10},
            new Order{CustomerId=6,DrinkId=11},
            new Order{CustomerId=7,DrinkId=12},*/
            /*new Order{CustomerId=1,new Drink(DrinkName="WhiteChocolateMocha",DrinkSize="regular")},
            new Order{CustomerId=2,new Drink(DrinkName="IcedTea", DrinkSize="regular")},
            new Order{CustomerId=3,new Drink(DrinkName="VanillaItalianSoda", DrinkSize="regular")},
            new Order{CustomerId=4,new Drink(DrinkName="StrawberryItalianSoda", DrinkSize="small")},
            new Order{CustomerId=5,new Drink(DrinkName="Americano", DrinkSize="regular")},
            new Order{CustomerId=6,new Drink(DrinkName="Mocha", DrinkSize="regular")},
            new Order{CustomerId=7,new Drink(DrinkName="Latte", DrinkSize="regular")},*/
            /*new Order{CustomerId=1,new Drink("WhiteChocolateMocha","regular")},
            new Order{CustomerId=2,new Drink("IcedTea","regular")},
            new Order{CustomerId=3,new Drink"VanillaItalianSoda","regular")},
            new Order{CustomerId=4,new Drink("StrawberryItalianSoda","small")},
            new Order{CustomerId=5,new Drink("Americano","regular")},
            new Order{CustomerId=6,new Drink("Mocha","regular")},
            new Order{CustomerId=7,new Drink("Latte","regular")},*/
            /*new Order{CustomerId=1,new Drink{DrinkName="WhiteChocolateMocha", DrinkSize="regular"}},
            new Order{CustomerId=2,new Drink{DrinkName="IcedTea", DrinkSize="regular"}},
            new Order{CustomerId=3,new Drink{DrinkName="VanillaItalianSoda", DrinkSize="regular"}},
            new Order{CustomerId=4,new Drink{DrinkName="StrawberryItalianSoda", DrinkSize="small"}},
            new Order{CustomerId=5,new Drink{DrinkName="Americano", DrinkSize="regular"}},
            new Order{CustomerId=6,new Drink{DrinkName="Mocha", DrinkSize="regular"}},
            new Order{CustomerId=7,new Drink{DrinkName="Latte", DrinkSize="regular"}},*/
            /*new Order{CustomerId=1,new Drink{Drink.OrderId=1, Drink.DrinkName="WhiteChocolateMocha", Drink.DrinkSize="regular"}},
            new Order{CustomerId=2,new Drink{OrderId=2,DrinkName="IcedTea", DrinkSize="regular"}},
            new Order{CustomerId=3,new Drink{OrderId=3,DrinkName="VanillaItalianSoda", DrinkSize="regular"}},
            new Order{CustomerId=4,new Drink{OrderId=4,DrinkName="StrawberryItalianSoda", DrinkSize="small"}},
            new Order{CustomerId=5,new Drink{OrderId=5,DrinkName="Americano", DrinkSize="regular"}},
            new Order{CustomerId=6,new Drink{OrderId=6,DrinkName="Mocha", DrinkSize="regular"}},
            new Order{CustomerId=7,new Drink{OrderId=7,DrinkName="Latte", DrinkSize="regular"}},*/
            //};

            /*foreach (Order order in orders)
            {
                Console.WriteLine(order.ToString());
            }*/
            //Console.WriteLine();
        }
    }
}
