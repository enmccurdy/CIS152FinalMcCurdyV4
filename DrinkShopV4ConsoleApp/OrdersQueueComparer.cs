/***************************************************************
* Name : DrinkShopV4ConsoleApp Project's OrdersQueueComparer.cs 
*   class file
* Author: Elizabeth McCurdy
***************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkShopV4ConsoleApp
{
    // ?? add IComparer<Order> for custom priority comparer?? for orders priorty queue
    // to in a separate OrdersQueueComparer class - rather than in Order class
    public class OrdersQueueComparer : IComparer<Order>
    {
        public int Compare(Order? x, Order? y)
        {
            //throw new NotImplementedException();
            // goal is to give oldest/older date/time higher priority
            // so those orders are filled first.
            if (x.OrderDate == y.OrderDate)
            {
                // if same date/time
                return 0;
            }
            // below caused most recent order to be at front of the queue
            //else if (x.OrderDate > y.OrderDate)
            else if (x.OrderDate < y.OrderDate)
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
        }
    }
}
