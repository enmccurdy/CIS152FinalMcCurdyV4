/***************************************************************
* Name : DrinkShopV4ConsoleApp Project's DrinkShopOperations.cs class file
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
*   DrinkShopOperations class - created separate class for various 
*   operations on DrinkShop class objects done by the 
*   manager/barista/customer.
*   
*   Ended up not using this class 
*   
*   blue print for DrinkShopOperations class objects,
*   with constructor(s), getters/setters (mutators/accessors), method(s) 
*   and ToString() method to display details regarding the DrinkShopOperations
*   class objects to the console.
*            Input: Queues and Lists for holding for each instance of Customer,
*            Drink, and Order class objects for the DrinkShopOperations class 
*            object to work with.
*            Output: ToString() method to display details about the 
*            DrinkShopOperations class object to the console.
*            BigO: Varies for Quick sort - generally O(n log n) for unsorted 
*            list/array – quasilinear time for quick sort, merge sort and 
*            heap sort. Big-O: O(n log n) for Quick sort for best and average 
*            case (worse case is O(n^2 quadratic) for Quick sort if array is
*            already sorted).   
*
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or
* unmodified. I have not given other fellow student(s) access
* to my program.
***************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DrinkShopV4ConsoleApp
{
    public class DrinkShopOperations
    {
        // Fields/Attributes
        // Moved below to it own class for various operations on DrinkShop class
        // objects by the manager/barista/customer
        // Create a Queue data structure to hold Orders objects
        private Queue<Order> _ordersQueue;

        // ?? create an attribute to hold all Customer objects?
        // - ?? Or which can then be sorted/searched??
        private List<Customer> _allCustomers;
        //?? create another attribute/property to hold all Customer objects in
        // in sorted order - sorted by lastname - then use this for binary search
        // or other search method - List vs Dictionary?? 
        //private Dictionary<CustomerId, Customer> _sortedCustomers;
        private List<Customer> _sortedCustomersList;

        // Constructor(s)
        // Default no-args Constructor - set default values
        public DrinkShopOperations()
        {
            // Create empty Queue to hold Order class objects 
            OrdersQueue = new Queue<Order>();

            AllCustomers = new List<Customer>();
            // Call method to get a sorted list of all the customers
            SortedCustomersList = CreateSortedCustomersList(AllCustomers);
        }

        // Parameterized Constructor 
        public DrinkShopOperations(Queue<Order> ordersQueue, List<Customer> allCustomers)
        {
            OrdersQueue = ordersQueue;
            AllCustomers = allCustomers;
            //SortedCustomersList = sortedCustomersList;
            // Call method to get a sorted list of all the customers
            SortedCustomersList = CreateSortedCustomersList(AllCustomers);
        }

        public DrinkShopOperations(Queue<Order> ordersQueue, List<Customer> allCustomers, List<Customer> sortedCustomersList)
        {
            OrdersQueue = ordersQueue;
            AllCustomers = allCustomers;
            SortedCustomersList = sortedCustomersList;
        }

        // Properties
        public Queue<Order>? OrdersQueue { get => _ordersQueue; set => _ordersQueue = value; }
        public List<Customer>? AllCustomers { get => _allCustomers; set => _allCustomers = value; }
        public List<Customer>? SortedCustomersList { get => _sortedCustomersList; set => _sortedCustomersList = value; }

        public virtual ICollection<Order>? Orders { get; set; }

        // Methods - 
        // method to add Order object to this OrdersQueue 
        public void AddOrderToQueue(Order newOrder)
        {
            OrdersQueue.Enqueue(newOrder);
        }

        //private Order? GetOrderFromQueue()
        public Order? GetOrderFromQueue()
        {
            return OrdersQueue.Dequeue();
        }

        public static Drink? CompleteDrinkInOrder(Order currentOrder, Drink completedDrink)
        //public Drink? CompleteDrinkInOrder(Drink completedDrink)
        //public void CompleteDrinkInOrder(Drink completedDrink)
        {
            if (currentOrder != null && currentOrder.OrderDrinkList != null && completedDrink != null)
            //if (currentOrder != null) 
            {
                //if (currentOrder.OrderDrinkList != null)
                //{
                foreach (Drink drink in currentOrder.OrderDrinkList)
                {
                    if (drink.Equals(completedDrink) && drink.DrinkMade != true)
                    {
                        // call method to complete drink
                        drink.DrinkCompleted();
                        // break out of loop - so only 1 drink completed and don't
                        // continue to iterate through all the drinks in the
                        // OrderDrinkList if already found drink to mark as 
                        // completed.
                        //break;
                        // vs ?? return drink;
                        return drink;
                    }
                    /*else
                    {
                        // drink not found
                        return null;
                    }*/
                }
                // drink not found
                return null;

            }
            else
            {
                // order empty or OrderDrinkList empty.
                return null;
            }
            
            /*if (OrdersQueue.Count != 0)
            {
                Order currentOrder = OrdersQueue.Dequeue();
                //?? above version vs make private method & call below
                //Order currentOrder = GetOrderFromQueue();
                // ?? vs call method to complete drink
                if (currentOrder != null || currentOrder.OrderDrinkList != null)
                //if (currentOrder != null) 
                {
                    //if (currentOrder.OrderDrinkList != null)
                    //{
                    foreach (Drink drink in currentOrder.OrderDrinkList)
                    {
                        if (drink.Equals(completedDrink) && drink.DrinkMade != true)
                        {
                            // call method to complete drink
                            drink.DrinkCompleted();
                            // break out of loop - so only 1 drink completed and don't
                            // continue to iterate through all the drinks in the
                            // OrderDrinkList if already found drink to mark as 
                            // completed.
                            //break;
                            // vs ?? return drink;
                            return drink;
                        }
                        else
                        {
                            // drink not found
                            return null;
                        }
                    }
                    //}
                    *//*else
                    {
                        // drink not found
                        return null;
                    }*//*

                }
                else
                {
                    // order empty or OrderDrinkList empty.
                    return null;
                }
            }
            else
            {
                // else if OrderQueue is empty.
                return null;
            }*/

        }


        public List<Customer>? CreateSortedCustomersList(List<Customer> allCustomers)
        {
            // Sorting algorithm written by me
            if (allCustomers != null)
            {
                // create an array/list to use to 'heapify' the allCustomers list
                // alphabetically in 'ascending' order
                //throw new NotImplementedException();
                MinHeap heap = new MinHeap();
                heap.HeapSort();
                return heap.HeapifiedCustomers;
            }
            else
            {
                return null;
            }

            //throw new NotImplementedException();

        }

        public string? DisplayCustomerList()
        {
            //return base.ToString();
            string CustomerListOutput = "";
            if (AllCustomers != null)
            {

                CustomerListOutput += $"Customers in List: {AllCustomers.Count}\n Customers: \n";
                foreach (Customer customer in AllCustomers)
                {
                    CustomerListOutput += $"{customer.ToString} \n";
                }
            }
            else
            {
                CustomerListOutput += $"Customer List: empty;";
            }
            return CustomerListOutput;
        }

        public string? DisplaySortedCustomerList()
        {
            //return base.ToString();
            string CustomerListOutput = "";
            if (SortedCustomersList != null)
            {

                CustomerListOutput += $"Customers in List: {SortedCustomersList.Count}\n Customers: \n";
                foreach (Customer customer in SortedCustomersList)
                {
                    CustomerListOutput += $"{customer.ToString} \n";
                }
            }
            else
            {
                CustomerListOutput += $"Customer List: empty;";
            }
            return CustomerListOutput;
        }

        public string? SearchSortedCustomerList(Customer findCustomer)
        {
            //return base.ToString();
            string CustomerOutput = "";
            if (SortedCustomersList != null)
            {

                //CustomerOutput += $"Customers in List: {SortedCustomersList.Count}\n Customers: \n";
                foreach (Customer customer in SortedCustomersList)
                {
                    if (customer.Equals(findCustomer))
                    {
                        CustomerOutput += $"Customer Found: {customer.ToString} \n";
                    }
                }
            }
            else
            {
                CustomerOutput += $"Customer not found;";
            }
            return CustomerOutput;
        }

        public string? DisplayOrderQueue()
        {
            //return base.ToString();
            string OrderQueueOutput = "";
            if (OrdersQueue != null)
            {

                OrderQueueOutput += $"Orders in Queue: {OrdersQueue.Count}\n Orders: \n";
                foreach (Order order in OrdersQueue)
                {
                    OrderQueueOutput += $"{order.ToString} \n";
                }
            }
            else
            {
                OrderQueueOutput += $"Orders in Queue: none;";
            }
            return OrderQueueOutput;
        }

        // ToString() - display method
        /*public override string? ToString()
        {
            return base.ToString();
        }*/
    }
}
