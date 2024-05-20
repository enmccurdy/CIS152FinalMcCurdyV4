using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrinkShopV4ConsoleApp;

namespace TestDrinkShopV4ConsoleApp
{
    public class UnitTestOrder
    {
        // Test GetOrderById(int orderId) static Order class method
        [Fact]
        public void TestGetOrderById()
        {
            // ARRANGE
            // 1st expectedId should be 1 since static nextId value initialed to 0, then incremented before assigned
            // to the class object in the constructor(s)
            int expectedId1 = 1;
            int expectedId2 = 2;
            Order testOrder1 = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            Order testOrder2 = new Order("John", "doe", "johndoe@fake.edu", "IcedTea", "regular");
            // ACT
            testOrder1.AddDrinkToOrder("WhiteChocolateMocha", "small");
            testOrder1.AddDrinkToOrder("WhiteChocolateMocha", "large");
            testOrder2.AddDrinkToOrder("GreenTea", "small");
            testOrder2.AddDrinkToOrder("ChaiTea", "large");

            Order order1 = Order.GetOrderById(1);
            Order order2 = Order.GetOrderById(2);

            // ASSERT
            Assert.Equal(expectedId1, order1.OrderId);
            Assert.Equal(expectedId2, order2.OrderId);
        }

        // Test AddDrinkToOrder(string drinkName, string drinkSize) method
        // Below unit test is also testing GetOrderDrinkById(int drinkId) Order class method which 
        // return a Drink object. 
        [Fact]
        public void TestAddDrinkToOrder()
        {
            // ARRANGE
            // 1st expectedId should be 1 since static nextId value initialed to 0, then incremented before assigned
            // to the class object in the constructor(s)
            int expectedId1 = 1;
            int expectedId2 = 2;
            int expectedId3 = 3;
            int expectedId4 = 4;
            int expectedId5 = 5;
            int expectedId6 = 6;
            Order testOrder1 = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            Order testOrder2 = new Order("John", "doe", "johndoe@fake.edu", "IcedTea", "regular");
            // ACT
            testOrder1.AddDrinkToOrder("WhiteChocolateMocha", "small");
            testOrder1.AddDrinkToOrder("WhiteChocolateMocha", "large");
            testOrder2.AddDrinkToOrder("GreenTea", "small");
            testOrder2.AddDrinkToOrder("ChaiTea", "large");
            
            Drink drink1 = Drink.GetDrinkById(1);
            Drink drink2 = Drink.GetDrinkById(2);
            Drink drink3 = Drink.GetDrinkById(3);
            Drink drink4 = Drink.GetDrinkById(4);
            Drink drink5 = Drink.GetDrinkById(5);
            Drink drink6 = Drink.GetDrinkById(6);
            // Use GetOrderDrinkById(int drinkId) to see if can get the matching drink from Order object
            Drink testDrink1 = testOrder1.GetOrderDrinkById(1);
            Drink testDrink2 = testOrder2.GetOrderDrinkById(2);
            Drink testDrink3 = testOrder1.GetOrderDrinkById(3);
            Drink testDrink4 = testOrder1.GetOrderDrinkById(4);
            Drink testDrink5 = testOrder2.GetOrderDrinkById(5);
            Drink testDrink6 = testOrder2.GetOrderDrinkById(6);

            // ASSERT
            //Assert.Equal(testDrink, Drink.GetDrinkById(1));
            //Assert.Equal(testDrink, drink1);
            Assert.Equal(drink1, testDrink1);
            Assert.Equal(drink2, testDrink2);
            Assert.Equal(drink3, testDrink3);
            Assert.Equal(drink4, testDrink4);
            Assert.Equal(drink5, testDrink5);
            Assert.Equal(drink6, testDrink6);
            // below used to cause error so could check which Drink object from which Order object was being
            // assigned to drink2 and testDrink3 variables. 
            //Assert.Equal(drink2, testDrink3);
            Assert.Equal(expectedId1, drink1.DrinkId);
            Assert.Equal(expectedId2, drink2.DrinkId);
            Assert.Equal(expectedId3, drink3.DrinkId);
            Assert.Equal(expectedId4, drink4.DrinkId);
            Assert.Equal(expectedId5, drink5.DrinkId);
            Assert.Equal(expectedId6, drink6.DrinkId);
        }

        // Test CalcTotal() method
        [Fact]
        public void TestOrderCalcTotal()
        {
            // ARRANGE
            decimal expectedTotal1 = 11.97m;
            decimal expectedTotal2 = 7.77m;
            decimal expectedTotal3 = 3.99m;
            decimal expectedTotal4 = 10.50m;

            Order testOrder1 = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            Order testOrder2 = new Order("John", "doe", "johndoe@fake.edu", "IcedTea", "regular");
            Order testOrder3 = new Order("Rumpel", "Stiltskin", "rstiltskin@fake.edu", "WhiteChocolateMocha", "regular");
            Order testOrder4 = new Order("Diana", "Price", "wwrus@fake.edu", "222-848-8484", "VanillaItalianSoda", "regular");
            testOrder1.AddDrinkToOrder("WhiteChocolateMocha", "small");
            testOrder1.AddDrinkToOrder("WhiteChocolateMocha", "large");
            testOrder2.AddDrinkToOrder("GreenTea", "small");
            testOrder2.AddDrinkToOrder("ChaiTea", "large");
            testOrder4.AddDrinkToOrder("StrawberryItalianSoda", "small");
            testOrder4.AddDrinkToOrder("CherryItalianSoda", "large");

            // ACT
            decimal actualTotal1 = (decimal)testOrder1.OrderTotal;
            decimal actualTotal2 = (decimal)testOrder2.OrderTotal;
            decimal actualTotal3 = (decimal)testOrder3.OrderTotal;
            decimal actualTotal4 = (decimal)testOrder4.OrderTotal;

            // ASSERT
            Assert.Equal(expectedTotal1, actualTotal1);
            Assert.Equal(expectedTotal2, actualTotal2);
            Assert.Equal(expectedTotal3, actualTotal3);
            Assert.Equal(expectedTotal4, actualTotal4);

        }
    }
}
