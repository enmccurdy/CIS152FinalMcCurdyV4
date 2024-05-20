/***************************************************************
* Name : DrinkShopV4ConsoleApp Project's MinHeap.cs class file
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
*   MinHeap class - class used by DrinkShopOperations class
*   to sort all the Customer class objects in alphabetical
*   order by last name the sorted list then can be used for various 
*   operations on DrinkShop class objects done by the 
*   manager/barista/customer.
*   
*   Ended up not using this class 
*   
*   blue print for MinHeap class objects,
*   with constructor(s), getters/setters (mutators/accessors), method(s) 
*   and ToString() method to display details regarding the MinHeap class 
*   objects to the console.
*            Input: Lists & Arrays for holding for each instance of Customer,
*            class objects for the MinHeap class object to work with to sort
*            customers by last name.
*            Output: ToString() method to display details about the MinHeap 
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkShopV4ConsoleApp
{
    public class MinHeap
    {
        // Fields/Attributes
        private List<Customer> _unsortedCustomers;
        private List<Customer> _heapifiedCustomers;
        private Customer[] _heapifiedCustomersArray;
        // ?? may not need below List since have above
        private List<Customer> _ascendingCustomers;
        private int _size;
        // ?? don't need since using a List rather than an array??
        private int _maxSize;

        // Constructor(s)
        // Default Constructor - not likely to be used in this program
        public MinHeap()
        {
            // create empty List to hold Customer class objects
            UnsortedCustomers = new List<Customer>();
            //HeapifiedCustomers = heapifiedCustomers;
            //HeapifiedCustomers = new List<Customer>();
            //HeapSort(HeapifiedCustomers);
            //HeapifiedCustomers = UnsortedCustomers.ToList();
            // ?? copy to array in constructor vs wait to do until
            // call sort fxn
            //UnsortedCustomers.CopyTo(HeapifiedCustomersArray);
            //AscendingCustomers = ascendingCustomers;
            // Below should initialize Size to 0.
            Size = UnsortedCustomers.Count;
            MaxSize = Size + 10;
            HeapifiedCustomersArray = new Customer[MaxSize];
        }

        // Parameterized Constructor(s)
        public MinHeap(List<Customer> unsortedCustomers)
        {
            UnsortedCustomers = unsortedCustomers;
            //HeapifiedCustomers = heapifiedCustomers;
            //HeapifiedCustomers = unsortedCustomers;
            HeapifiedCustomers = new List<Customer>();
            //UnsortedCustomers.CopyTo(HeapifiedCustomers.ToList());
            foreach(Customer customer in UnsortedCustomers)
            {
                HeapifiedCustomers.Add(customer);
            }
            //HeapifiedCustomers = unsortedCustomers.ToList();
            // ?? copy to array in constructor vs wait to do until
            // call sort fxn
            //UnsortedCustomers.CopyTo(HeapifiedCustomersArray);
            //AscendingCustomers = ascendingCustomers;
            Size = UnsortedCustomers.Count;
            MaxSize = Size + 10;
            HeapifiedCustomersArray = new Customer[MaxSize];
            UnsortedCustomers.CopyTo(HeapifiedCustomersArray);
            // ?? Call HeapSort() method from constructor???
            //HeapSort(HeapifiedCustomers); // changed method so don't
            // have to pass a parameter to it.
            //HeapSort();
        }

        /*public MinHeap(List<Customer> unsortedCustomers, int maxSize)
        {
            UnsortedCustomers = unsortedCustomers;
            HeapifiedCustomers = heapifiedCustomers;
            HeapifiedCustomers = new List<Customer>();
            //UnsortedCustomers.CopyTo(HeapifiedCustomers.ToList());
            foreach(Customer customer in UnsortedCustomers)
            {
                HeapifiedCustomers.Add(customer);
            }
            // ?? copy to array in constructor vs wait to do until
            // call sort fxn
            UnsortedCustomers.CopyTo(HeapifiedCustomersArray);
            HeapifiedCustomers.CopyTo(HeapifiedCustomersArray);
            //AscendingCustomers = ascendingCustomers;
            Size = UnsortedCustomers.Count;
            //MaxSize = maxSize;
            //?? MaxSize = Size + 10;
            // ?? Call HeapSort() method from constructor???
            //HeapSort(HeapifiedCustomers); // changed method so don't
            // have to pass a parameter to it.
            //HeapSort();
        }*/

        public MinHeap(List<Customer> unsortedCustomers, int size)
        //public MinHeap(List<Customer> unsortedCustomers, int size, int maxSize)
        {
            UnsortedCustomers = unsortedCustomers;
            //HeapifiedCustomers = heapifiedCustomers;
            //HeapifiedCustomers = unsortedCustomers;
            //HeapifiedCustomers = unsortedCustomers.ToList();
            // ?? copy to array in constructor vs wait to do until
            // call sort fxn
            HeapifiedCustomers = new List<Customer>();
            //UnsortedCustomers.CopyTo(HeapifiedCustomers.ToList());
            foreach (Customer customer in UnsortedCustomers)
            {
                HeapifiedCustomers.Add(customer);
            }
            //UnsortedCustomers.CopyTo(HeapifiedCustomersArray);
            //HeapifiedCustomers.CopyTo(HeapifiedCustomersArray);
            //AscendingCustomers = ascendingCustomers;
            Size = size;
            //MaxSize = maxSize;
            MaxSize = Size + 10;
            HeapifiedCustomersArray = new Customer[MaxSize];
            UnsortedCustomers.CopyTo(HeapifiedCustomersArray);
            // ?? Call HeapSort() method from constructor???
            //HeapSort(HeapifiedCustomers); // changed method so don't
            // have to pass a parameter to it.
            //HeapSort();
        }

        public MinHeap(List<Customer> unsortedCustomers, List<Customer> heapifiedCustomers, List<Customer> ascendingCustomers, int size)
        //public MinHeap(List<Customer> unsortedCustomers, List<Customer> heapifiedCustomers, List<Customer> ascendingCustomers, int size, int maxSize)
        {
            UnsortedCustomers = unsortedCustomers;
            HeapifiedCustomers = heapifiedCustomers;
            //HeapifiedCustomers = unsortedCustomers;
            //HeapifiedCustomers = unsortedCustomers.ToList();
            AscendingCustomers = ascendingCustomers;
            Size = size;
            //MaxSize = maxSize;
            MaxSize = Size + 10;
            // ?? copy to array in constructor vs wait to do until
            // call sort fxn
            //UnsortedCustomers.CopyTo(HeapifiedCustomersArray);
            // Just doing above doesn't work - ??
            // 1st have to initialize the array before copying
            // to it for it to work??
            HeapifiedCustomersArray = new Customer[MaxSize];
            UnsortedCustomers.CopyTo(HeapifiedCustomersArray);
            // ?? Call HeapSort() method from constructor???
            //HeapSort(HeapifiedCustomers); // changed method so don't
            // have to pass a parameter to it.
            //HeapSort();
        }

        // Properties
        public List<Customer> UnsortedCustomers { get => _unsortedCustomers; set => _unsortedCustomers = value; }
        // ?? within set call HeapSort(HeapifiedCustomers); 
        public List<Customer> HeapifiedCustomers { get => _heapifiedCustomers; set => _heapifiedCustomers = value; }
        // ?? within set call HeapifiedCustomers.CopyTo(HeapifiedCustomersArray);
        public Customer[]? HeapifiedCustomersArray { get => _heapifiedCustomersArray; set => _heapifiedCustomersArray = value; }
        public List<Customer> AscendingCustomers { get => _ascendingCustomers; set => _ascendingCustomers = value; }
        public int Size { get => _size; set => _size = value; }
        public int MaxSize { get => _maxSize; set => _maxSize = value; }

        // Methods
        // Helper methods to get indexes for parent node & left & right child nodes
        private int LeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }
        private int RightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }
        private int ParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        // Helper methods to determine if node has a parent node, & if has left &/or right children
        private bool LeftChildExists(int index)
        {
            return LeftChildIndex(index) < Size;
        }
        private bool RightChildExists(int index)
        {
            return RightChildIndex(index) < Size;
        }
        private bool ParentExists(int index)
        {
            return ParentIndex(index) >= 0;
        }

        // Helper methods to get values of the parent node and left and right child nodes
        private Customer LeftChildValue(int index)
        {
            //return UnsortedCustomers[LeftChildIndex(index)];
            // Heapified List version -
            return HeapifiedCustomers[LeftChildIndex(index)];
            // Array version
            //return HeapifiedCustomersArray[LeftChildIndex(index)];
        }
        private Customer RightChildValue(int index)
        {
            //return UnsortedCustomers[RightChildIndex(index)];
            // Heapified List version -
            return HeapifiedCustomers[RightChildIndex(index)];
            // Array version
            //return HeapifiedCustomersArray[RightChildIndex(index)];
        }
        private Customer ParentValue(int index)
        {
            //return UnsortedCustomers[ParentIndex(index)];
            // Heapified List version -
            return HeapifiedCustomers[ParentIndex(index)];
            // Array version
            //return HeapifiedCustomersArray[ParentIndex(index)];
        }

        // Method to swap the two values in the List at indexA & indexB
        private void Swap(int indexA, int indexB)
        {
            // Unsorted List version - 
            //int temp = UnsortedCustomers[indexA];
            /*Customer tempCustomer = UnsortedCustomers[indexA];
            UnsortedCustomers[indexA] = UnsortedCustomers[indexB];
            //UnsortedCustomers[indexB] = temp;
            UnsortedCustomers[indexB] = tempCustomer;*/
            
            // Heapified List version - 
            Customer tempHeapCustomer = HeapifiedCustomers[indexA];
            HeapifiedCustomers[indexA] = HeapifiedCustomers[indexB];
            HeapifiedCustomers[indexB] = tempHeapCustomer;
            
            // Array version
            Customer tempArrayCustomer = HeapifiedCustomersArray[indexA];
            HeapifiedCustomersArray[indexA] = HeapifiedCustomersArray[indexB];
            HeapifiedCustomersArray[indexB] = tempArrayCustomer;
        }

        // Method to enlarge/increase the MaxSize of the array if needed
        // ?? if need fxn since using List rather than array??
        private void IncreaseArraySize()
        {
            if (Size == MaxSize)
            {
                // Double the MaxSize if array capacity has been reached
                int newSize = MaxSize * 2;
                // initialize a new array of increase size
                Customer[] largerArray = new Customer[newSize];
                Array.Copy(HeapifiedCustomersArray, largerArray, HeapifiedCustomersArray.Length);
                // Reset MaxSize value and HeapifiedCustomersArray values
                MaxSize = newSize;
                HeapifiedCustomersArray = largerArray;
            }
        }
        
        // Heap Data Structure operations methods: 
        // IsEmpty() checks if Heap is empty - return true if is and false if 
        // there are elements/values in Heap
        public bool IsEmpty()
        {
            return Size == 0;
        }

        // Peek() method - aka GetMin() for MinHeap - gets the root element/value
        // which is the smallest value in a MinHeap data structure, if the
        // Heap is NOT empty, else it returns null. Does not remove the root element
        // from the Heap/array. 
        public Customer? Peek()
        {
            // Can call IsEmpty() or check if Size != 0
            if (!IsEmpty())
            {
                // Unsorted List version - 
                //return UnsortedCustomers.First<Customer>();
                //return UnsortedCustomers.First();
                //return UnsortedCustomers[0];
                // Heapified List version - 
                return HeapifiedCustomers[0];
                // Array version 
                //return HeapifiedCustomersArray[0];
            }
            else
            {
                return null;
            }
        }

        // Delete() or RemoveMin() for MinHeap - gets the root element/value
        // which is the smallest value in a MinHeap data structure, if the
        // Heap is NOT empty, else it returns null. Does remove the root element
        // from the Heap. 
        public Customer? RemoveMin()
        {
            if (!IsEmpty())
            {
                /*//Customer customer = UnsortedCustomers.RemoveAt(0);
                Customer customer = UnsortedCustomers[0];
                UnsortedCustomers.RemoveAt(0);
                // Decrement size by 1
                //Size--;
                // vs
                Size = UnsortedCustomers.Count;
                return customer;*/
                // Heapified List version - 
                //Customer customer = HeapifiedCustomers.RemoveAt(0);
                Customer customer = HeapifiedCustomers[0];
                HeapifiedCustomers.RemoveAt(0);
                // For array if remove 1st value from array, then 
                // need to take last value in array and replace
                // root element's value at index 0's w/ the size-1 value and then
                // decrease size of array essentially cutting off
                // duplicate value that is at size-1 index
                HeapifiedCustomersArray[0] = HeapifiedCustomersArray[Size - 1];
                // Decrement size by 1
                //Size--;
                // vs
                Size = HeapifiedCustomers.Count;
                // Then should call recursive method to re-heapify the Heap/Tree
                // passing in root index value of 0 as the 'subtree' root
                HeapifyDownRecursive(0);
                // Return value that was previously the root of the MinHeap (ie.
                // the smallest value). 
                return customer;
            }
            else
            {
                return null;
            }
        }

        // ?? Method in progress - finish after write Equals/GetHashCode overrides in
        // Customer class using IEquatable<Customer> if needed ???
        // Use IndexOf() List method instead of FindIndex. 
        // ??If want to return the Customer object removed from Heap/List/Array if found
        // can do below rather than 'void' - may help w/ double check whether 'null'
        // versus Customer returned from call so could use to trigger an alert to 
        // user. ??
        // public Customer? DeleteCustomer(Customer removeCustomer)
        public void DeleteCustomer(Customer removeCustomer)
        {
            if (!IsEmpty())
            {
                // Search List/Array to see if there is a matching Customer
                // For HeapifiedCustomers Heap and HeapifiedCustomersArray Array
                // need to find index location of first matching Customer object
                // if it is found.

                // Heapified List version - 
                //int customerHeapIndex = HeapifiedCustomers.FindIndex(0, removeCustomer);
                int customerHeapIndex = HeapifiedCustomers.IndexOf(removeCustomer);
                Customer tempHeapCustomer;
                if (customerHeapIndex != -1)
                //if (HeapifiedCustomers.FindIndex(0, removeCustomer) != -1)
                {
                    //int customerHeapIndex = HeapifiedCustomers.FindIndex(0, removeCustomer);
                    // If searched for Customer object exists
                    if (customerHeapIndex != Size - 1)
                    {
                        // if searched for Customer is not the last element then need to 
                        // switch its location w/ the last element
                        //Customer tempHeapCustomer = HeapifiedCustomers[customerHeapIndex];
                        tempHeapCustomer = HeapifiedCustomers[customerHeapIndex];
                        HeapifiedCustomers[customerHeapIndex] = HeapifiedCustomers[Size - 1];
                        HeapifiedCustomers[Size - 1] = tempHeapCustomer;
                    }
                    // Now can remove last element in Heap/List & decrement Size
                    // If searched for Customer was already the last element in List/Heap
                    // don't need to do the Swap, can just decrease size of Heap/List by removing it.
                    // Then re-Heapify the HeapifiedCustomers List/Heap
                    HeapifiedCustomers.Remove(removeCustomer);
                    // Wait to decrement until did same process to the Heap array
                    //Size -= 1;
                }

                // Heapified Array version - 
                // Search through array for matching customer. 
                int customerArrayIndex = -1;
                for (int i = 0; i < Size; i++)
                {
                    if (HeapifiedCustomersArray[i] == removeCustomer)
                    {
                        customerArrayIndex = i;
                    }
                }
                
                if (customerArrayIndex != -1)
                {
                    // If searched for Customer object exists
                    if (customerArrayIndex != Size - 1)
                    {
                        // if searched for Customer is not the last element then need to 
                        // switch its location w/ the last element
                        Customer tempArrayCustomer = HeapifiedCustomersArray[customerArrayIndex];
                        HeapifiedCustomersArray[customerArrayIndex] = HeapifiedCustomersArray[Size - 1];
                        HeapifiedCustomersArray[Size - 1] = tempArrayCustomer;
                    }
                    // Now can remove last element in Heap Array & decrement Size
                    // If searched for Customer was already the last element in Heap Array
                    // don't need to do the Swap, can just decrease size of Heap Array/removing it
                    // by decrementing 'Size'/the array.
                    // Then re-Heapify the HeapifiedCustomersArray 
                }


                // For UnsortedCustomers list can just remove the Customer object w/o re-Heapifying
                UnsortedCustomers.Remove(removeCustomer);

                // Decrement size by 1
                //Size--;
                // vs
                Size = HeapifiedCustomers.Count;
                // Then should call recursive method to re-heapify the Heap/Tree
                // passing in root index value of 0 as the 'subtree' root
                HeapifyDownRecursive(0);
                // Could return removed Customer value 
                //return tempHeapCustomer;
            }
            /*else
            {
                return null;
            }*/
        }

        // HeapifyDown() method to restructure the Heap/Tree from the root down
        // if needed to maintain the 'Heap Property' rules.
        // Below doesn't work correctly!! - Recursive version better. 
        private void HeapifyDown()
        {
            // Start with the root node/element's index - 0
            int index = 0;
            // while current node/element has children continue walking down 
            // Heap checking if 'Heap Property' rules are maintained.
            // Only checking if LeftChildExists d/t way the Heap (Complete
            // Binary Tree) structure is created - the tree always fills in 
            // the left child before the right child, therefore if no left
            // child then know there will be no right child.
            while (LeftChildExists(index))
            {
                // determine which of the children has the smaller index number.
                // First set min value to index of left child
                int minChildIndex = LeftChildIndex(index);
                // Then use if condition to check for situation where a right child
                // node exists to reset the minChildIndex value if the right child's
                // index value is smaller than the current minChildIndex value.
                if (RightChildExists(index) && RightChildIndex(index) < LeftChildIndex(index))
                {
                    minChildIndex = RightChildIndex(index);
                }
                // Once determined which of the children is smaller, then use the
                // if condition to determine if current node/element's vlaue is
                // smaller than the smaller child node/element's value, then if
                // in correct spot on the Heap, and don't need to continue 
                // checking further down the Heap/Tree.
                //if (UnsortedCustomers[index] < UnsortedCustomers[minChildIndex])
                if (HeapifiedCustomers[index].LastName.CompareTo(HeapifiedCustomers[minChildIndex].LastName) < 0)
                //if (UnsortedCustomers[index].LastName.CompareTo(UnsortedCustomers[minChildIndex].LastName) < 0)
                {
                    // < 0 - string A precedes string B in alphabetical order
                    break;
                }
                else
                {
                    // Else if current node/element is NOT in correct position in the
                    // Heap/Tree, then call the Swap() method to swap the current node/element's value
                    // w/ its smaller child, then move further down the Heap/tree to the smaller
                    // child's index location. 
                    Swap(index, minChildIndex);
                }
                index = minChildIndex;
            }
        }

        // HeapifyDownRecursive(int index) method to restructure the Heap/Tree from the root down
        // if needed to maintain the 'Heap Property' rules. It will 're-Heapify' a subtree -
        // where root node of subtree is at passed in index location.  Method recursively calls
        // itself.
        private void HeapifyDownRecursive(int index)
        {
            // for MinHeap - initialize minIndex to passed in index - the subtree's root
            // node/element's index
            int minIndex = index;
            // get current minIndex node's left & right child indexes.
            int leftChildIndex = LeftChildIndex(index);
            int rightChildIndex = RightChildIndex(index);

            //?? - one tutorial used below for indexes of left/right child indexes rather
            // than above - and improved results of sorted order only when done in Heapify()
            // method, but worsended when tried this version of indexes in HeapifyDownRecursive()
            // method
            //int leftChildIndex = 2 * index;
            //int rightChildIndex = 2 * index + 1;

            // use if condition to check if left child node's value is < root/current node's value
            // HeapifiedCustomers List version 
            if (leftChildIndex < Size && HeapifiedCustomers[leftChildIndex].LastName.CompareTo(HeapifiedCustomers[minIndex].LastName) < 0)
            //if (leftChildIndex < Size && UnsortedCustomers[leftChildIndex].LastName.CompareTo(UnsortedCustomers[minIndex].LastName) < 0)
            {
                // if left child node's value is smaller (comes alphabetically before) then
                // current root node's value, then reassign new minIndex
                minIndex = leftChildIndex;
            }
            // Next use if condition to check if right child node's value is < current minIndex node's
            // value. 
            // HeapifiedCustomers List version 
            if (rightChildIndex < Size && HeapifiedCustomers[rightChildIndex].LastName.CompareTo(HeapifiedCustomers[minIndex].LastName) < 0)
            //if (rightChildIndex < Size && UnsortedCustomers[rightChildIndex].LastName.CompareTo(UnsortedCustomers[minIndex].LastName) < 0)
            {
                // if right child node's value is smaller (comes alphabetically before) then
                // current root node's value, then reassign new minIndex
                minIndex = rightChildIndex;
            }
            // Then use if condition to check if current minIndex is the current subtree's root
            // node, if NOT then swap the subtree root value w/ the minIndex value
            if (minIndex != index)
            {
                // Else if current node/element is NOT in correct position in the
                // Heap/Tree, then call the Swap() method to swap the current node/element's value
                // w/ its smaller child, then move further down the Heap/tree to the smaller
                // child's index location. 
                Swap(index, minIndex);
                // Recursively call HeapifyDownRecursive() recursive method w/ new subtree root
                // index value
                HeapifyDownRecursive(minIndex);
            }
        }

        // Insert() - Adds new node/element to the Heap/Tree - It will call the HeapifyUp() method
        // to restructure the Heap/Tree if needed so it maintains the 'Heap Property' rules.
        public void Insert(Customer customer)
        {
            // if using the array will need to create/call IncreaseArraySize() helper method
            // to check if need to increase the array size before can add new Customer to the
            // end of the array
            IncreaseArraySize();
            // Add new element/Customer to bottom/end of the Heap/Tree and UnsortedCustomers List
            //UnsortedCustomers[Size] = customer;
            UnsortedCustomers.Add(customer);
            // HeapifiedCustomers List version 
            //HeapifiedCustomers[Size] = customer;
            HeapifiedCustomers.Add(customer);
            // Array version -
            HeapifiedCustomersArray[Size] = customer;
            // Increment Size by 1
            Size++;
            // ?? or 
            //Size = UnsortedCustomers.Count;
            // Call HeapifyUp() helper method to 'bubble up' swapping elements restructuring the 
            // Heap/Tree upward from the bottom up if needed to maintain the 'Heap Property'
            // rules.
            HeapifyUp();
            // Or could re-Heapify using for loop like below and calling Heapify(i);
            // or HeapifyDownRecursive(i); each run through for loop
            // for (int i = n / 2 - 1; i >= 0; i--) { Heapify(i);} 
            // for (int i = n / 2 - 1; i >= 0; i--) { HeapifyDownRecursive(i);} 
        }

        // HeapifyUp() method to 'bubble up' swapping elements restructuring the Heap/Tree upward
        // from the bottom up if needed to maintain the 'Heap Property' rules after adding new
        // element/Customer to bottom/end of Heap/Tree. 
        private void HeapifyUp()
        {
            // HeapifyUp() method starts at the last element (Size - 1)
            int index = Size - 1;
            // While node/element has a parent node && the parent is larger than the current node/
            // element's value - (i.e. it comes alphabetically after the element) - swap the current
            // node/element w/ its parent node's index.
            // HeapifiedCustomers List version 
            while (ParentExists(index) && ParentValue(index).LastName.CompareTo(HeapifiedCustomers[index].LastName) > 0)
            //while (ParentExists(index) && ParentValue(index).LastName.CompareTo(UnsortedCustomers[index].LastName) > 0)
            {
                // Call the Swap() method to swap the current node/element's value at index w/ its parent
                // node's value (index), and continue checking 'bubbling up' the Heap/Tree.
                Swap(ParentIndex(index), index);
                // ?? switching which are swapped didn't fix or make worse issues w/ HeapSort() last two out of order
                //Swap(index, ParentIndex(index));
                // reset 'index' variable to the current node/element's current parent node's index
                index = ParentIndex(index);
            }
        }

        // HeapSort() method takes the passed in unsorted array/list which is then iterated over starting 
        // around the midpoint of the array/list, and calling the Heapify() recursive method, each pass
        // decrementing the iterator value, to sort the passed in unsorted array into ascending order
        // (for MinHeap). 
        // The HeapSort() method 1st calls the Heapify() recursive method to build a MinHeap version of
        // the original unsorted list/array, then the Heapified array/list is processed through the Heap
        // Sort algorithm which will swap values in the array by calling the HeapifyDownRecursive()
        // recursive method passing in 0 for the index of the root of the Heap/Tree. 
        public void HeapSort()
        //public void HeapSort(List<Customer> listToHeapSort)
        {
            // assign value of array.Length/Size/list.Count to 'n' - the number of nodes/elements in the
            // Heap/Tree/Array/List.
            //int n = listToHeapSort.Count;
            int n = HeapifiedCustomers.Count;
            // verify Size of list/array to sort is > 1 before trying to sort. 
            if (n > 1)
            {


                // HeapifiedCustomers List and HeapifiedCustomersArray will hold sorted customers when 
                // HeapSort is done. 

                // To build the MinHeap/Heapify the passed in unsorted list/array - repeatedly call the 
                // HeapifyDownRecursive() recursive method/Heapify() method
                // ?? for MaxHeap starting at around the midpoint index of array/list 'i' & decrementing
                // down to 1 with each call.
                // For MinHeap starting at root index 0 and incrementing up until reached length of list/array.
                // Neither version of for loop supposedly for MaxHeap or MinHeap made a difference
                // Neither using Heapify() or HeapifyDownRecursive() method changed order of Heapified list/array
                // only partially sorted. Same f used Heapify() in first for loop and HeapifyDownRecursive()
                // in 2nd for loop or vice versa.  
                // Order remained consistently: Customer ID: 3 (Archibalt), 4 (Baracus), 7 (Oswald), 1 (Carsons),
                // 2 (Meridian), 6 (Prevails), 5 (Yang), 8 (Twist)
                // When changed method of index assignment for left/right index in Heapify() method order changed
                // slightly - improved - to (M still out of place) (if call HeapifyDownRecursive in 1st for loop
                // and Heapify() method in 2nd for loop: 
                // Order became: Customer ID: 3 (Archibalt), 4 (Baracus), 1 (Carsons), 7 (Oswald),
                // 2 (Meridian), 6 (Prevails), 8 (Twist), 5 (Yang)
                // slightly - improved - to (M still out of place) (if called Heapify() method in both for loops: 
                // Order became: Customer ID: 3 (Archibalt), 4 (Baracus), 2 (Meridian), 1 (Carsons), 5 (Yang), 
                // 7 (Oswald), 6 (Prevails), 8 (Twist)
                // if call Heapify() method in 1st for loop and HeapifyDownRecursive() method in 2nd for loop: 
                // Order became: Customer ID: 3 (Archibalt), 4 (Baracus), 1 (Carsons), 2 (Meridian), 7 (Oswald),
                // 6 (Prevails), 5 (Yang), 8 (Twist)
                for (int i = n / 2 - 1; i >= 0; i--) // for MaxHeap?? this gives the MinHeap order - ish
                //for (int i = 0; i < n; i++) // for MinHeap ?? this does NOT give the MinHeap
                {
                    // call Heapify() method to build the MinHeap - which places the smallest element at the 
                    // root position of the Heap/Tree
                    Heapify(i);
                    //HeapifyDownRecursive(i);
                }

                // Temp debugging statement: 
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Index: {j} : Value: {HeapifiedCustomers[j].LastName}\n");
                }

                // Below is Heap sort of partially Heapified Heap/Tree/List/Array
                // In 2nd for loop Each 'root' node removed, then placed into the sorted list/array, then the temp
                // array/list is re-Heapfied from top down since the previously 'last' value
                // in the temp array is placed into the now empty 0 index location of array/list
                // as the 'new' root node & the size of the temp array is decremented by 1
                //for (int i = n - 1; i > 0; i--) - Nope
                for (int i = n - 1; i >= 0; i--)
                {
                    /*Customer tempCustomer = HeapifiedCustomers[0];
                    Customer tempArrayCustomer = HeapifiedCustomersArray[0];
                    HeapifiedCustomers[0] = HeapifiedCustomers[i];
                    HeapifiedCustomersArray[0] = HeapifiedCustomersArray[i];
                    HeapifiedCustomers[i] = tempCustomer;
                    HeapifiedCustomersArray[i] = tempArrayCustomer;*/
                    // Swap element at zero index location w/ last element
                    // decrementing size (n) of 'i' as process through sort. 
                    Swap(0, i);

                    // ?? - one tutorial added this - no difference.
                    //n--;

                    // call Heapify() method - passing index 0 for the new root node index
                    //Heapify(0);
                    HeapifyDownRecursive(0);
                    // Trial to see if calling HeapifyUp() would improve sored results - NOPE
                    //HeapifyUp();
                    // Tried calling HeapifyDown() method instead which automatically starts at 0
                    // but only worked to get 'Yang' in last spot rest all out of order. -NOPE
                    //HeapifyDown();
                }
                // Make one final call to HeapifyDownRecursive method passing in root node to see
                // if would resolve issue of Twist always being last in sorted list rather than Yang.
                // - NOPE
                //HeapifyDownRecursive(0);
                // Trial to see if calling HeapifyUp() instead would resolve last two Customers remaining 
                // out of order issues. - NOPE
                //HeapifyUp();
                // Tried calling HeapifyDown() method at very end which automatically starts at 0
                // but now 'Yang' in 2nd to last spot again but rest are in order. -NOPE
                //HeapifyDown();
            }
        }

        // Heapify() method same as HeapifyDownRecursive() method other than assignment of
        // left/right child indexes. 
        private void Heapify(int index)
        {
            // for MinHeap - initialize minIndex to passed in 'root' node index - subtree
            int minIndex = index;
            // get current minIndex root node's left & right child indexes
            //int leftChildIndex = LeftChildIndex(index);
            //int rightChildIndex = RightChildIndex(index);
            //?? - one tutorial used below for indexes of left/right child indexes rather
            // than above - and improved results of sorted order, but not resolved
            int leftChildIndex = 2 * index;
            int rightChildIndex = 2 * index + 1;
            // first version of getting child indexes and below were shown more frequently
            // in tutorials and was correct way to identify the index of passed in subtree root.
            // ?? unsure why 
            //int leftChildIndex = 2 * index + 1;
            //int rightChildIndex = 2 * index + 2;
            // ?? use helper method that gets value at that index instead??
            //Customer leftChildCustomer = LeftChildValue(leftChildIndex);
            //Customer rightChildCustomer = RightChildValue(rightChildIndex);
            //Customer minIndexCustomer = ParentValue(minIndex);
            // Use if condition to check left child node's value is < root/current node's value
            //if (leftChildIndex < HeapifiedCustomers.Count && leftChildCustomer.LastName.CompareTo(minIndexCustomer.LastName) < 0)
            //if (leftChildIndex < Size && HeapifiedCustomers[leftChildIndex].LastName.CompareTo(HeapifiedCustomers[minIndex].LastName) < 0)
            // Above and below versions using Size vs HeapifiedCustomers.Count worked the same. 
            if (leftChildIndex < HeapifiedCustomers.Count && HeapifiedCustomers[leftChildIndex].LastName.CompareTo(HeapifiedCustomers[minIndex].LastName) < 0)
            {
                // If left child node's value is smaller, re-assign new minIndex
                minIndex = leftChildIndex;
                //minIndexCustomer = leftChildCustomer;
            }
            // Use if condition to check right child node's value is < root/current node's value
            //if (rightChildIndex < HeapifiedCustomers.Count && rightChildCustomer.LastName.CompareTo(minIndexCustomer.LastName) < 0)
            //if (rightChildIndex < Size && HeapifiedCustomers[rightChildIndex].LastName.CompareTo(HeapifiedCustomers[minIndex].LastName) < 0)
            if (rightChildIndex < HeapifiedCustomers.Count && HeapifiedCustomers[rightChildIndex].LastName.CompareTo(HeapifiedCustomers[minIndex].LastName) < 0)
            {
                // If right child node's value is smaller, re-assign new minIndex
                minIndex = rightChildIndex;
            }
            // Use if condition to check if current minIndex is the current subtree tree, if not
            // then swap the subtree root value w/ the minIndex value
            if (minIndex != index)
            {
                // Call Swap() method to swap values at these indexes.
                Swap(index, minIndex);
                // Recursively call the Heapify() method passing in the new subtree root node's minIndex 
                Heapify(minIndex);
            }
        }

        // Display methods
        public string? DisplayUnsortedList()
        {
            string output = "";
            if (UnsortedCustomers != null)
            {
                output += $"UnsortedCustomers List size: {Size}; MaxSize: {MaxSize}; Count: {UnsortedCustomers.Count}\n";
                // ?? create counter and increment w/in the foreach loop to show List index for each
                // value in UnsortedCustomers List
                int i = 0;
                foreach (Customer customer in UnsortedCustomers)
                {
                    //output += $"{customer.ToString}\n";
                    //output += $"Index: {i}: Customer: {customer.ToString}\n";
                    output += $"Index: {i}: Customer: {customer.ToString()}\n";
                    i++;
                }
            }
            else
            {
                output += "UnsortedCustomers List is empty.\n";
            }
            return output;
        }


        public string? DisplayHeapifiedList()
        {
            string output = "";
            if (HeapifiedCustomers != null)
            {
                output += $"HeapifiedCustomers List size: {Size}; Count: {HeapifiedCustomers.Count}\n";
                // ?? create counter and increment w/in the foreach loop to show List index for each
                // value in HeapifiedCustomers List
                int i = 0;
                foreach (Customer customer in HeapifiedCustomers)
                {
                    //output += $"{customer.ToString}\n";
                    //output += $"Index: {i}: Customer: {customer.ToString}\n";
                    output += $"Index: {i}: Customer: {customer.ToString()}\n";
                    i++;
                }
            }
            else
            {
                output += "HeapifiedCustomers List is empty.\n";
            }
            return output;
        }

        public string? DisplayHeapifiedArray()
        {
            string output = "";
            if (HeapifiedCustomersArray != null)
            {
                output += $"HeapifiedCustomers Array size: {Size}; MaxSiz: {MaxSize}; Length: {HeapifiedCustomersArray.Length}\n";
                for (int i = 0; i < Size; i++)
                //for (int i = 0; i < HeapifiedCustomersArray.Length; i++)
                {
                    output += $"Index: {i}: Customer: {HeapifiedCustomersArray[i]}\n";
                }
                /*foreach (Customer customer in HeapifiedCustomersArray)
                {
                    output += $"{customer.ToString}\n";
                }*/
            }
            else
            {
                output += "HeapifiedCustomers Array is empty.\n";
            }
            return output;
        }

    }
}
