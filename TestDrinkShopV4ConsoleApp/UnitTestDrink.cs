using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrinkShopV4ConsoleApp;

namespace TestDrinkShopV4ConsoleApp
{
    public class UnitTestDrink
    {
        [Fact]
        public void TestGetDrinkById()
        {
            // ARRANGE
            //Order testCustomerEmail = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            //string expected = "WhiteChocolateMocha";
            // expectedId should be 1 since static nextId value initialed to 0, then incremented before assigned
            // to the class object in the constructor?
            //int expectedId = 0;
            int expectedId = 1;
            int expectedId2 = 2;
            int expectedId3 = 3;
            Order testOrder = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            // ACT
            testOrder.AddDrinkToOrder("WhiteChocolateMocha", "small");
            testOrder.AddDrinkToOrder("WhiteChocolateMocha", "large");
            //int testDrinkId = testOrder.DrinkId;
            // GetOrderDrinkById(int drinkId) Order class method does not work per Unit Test
            // returns 'null'. Not sure if this method is actually even needed.
            //Drink testDrink = testOrder.GetOrderDrinkById(1);
            //int testDrinkId = testDrink.DrinkId;
            Drink drink1 = Drink.GetDrinkById(1);
            Drink drink2 = Drink.GetDrinkById(2);
            Drink drink3 = Drink.GetDrinkById(3);
            // ?? actual testDrinkId is 0 per unit test explorer??
            //Drink testDrink = Drink.GetDrinkById(testDrinkId);
            //Drink drink1 = Drink.GetDrinkById(0);
            // ASSERT
            //Assert.Equal(expected, testDrink.DrinkName);
            //Assert.Equal(expectedId, 1);
            //Assert.Equal(expectedId, testDrinkId);
            //Assert.Equal(testDrink, Drink.GetDrinkById(1));
            //Assert.Equal(testDrink, drink1);
            Assert.Equal(expectedId, drink1.DrinkId);
            Assert.Equal(expectedId2, drink2.DrinkId);
            Assert.Equal(expectedId3, drink3.DrinkId);
        }
        [Fact]
        public void TestValidDrinkName()
        {
            // ARRANGE
            //string expected = "White Chocolate Mocha";
            string expected = "WhiteChocolateMocha";
            //int expectedId = 1;
            Order testOrder = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            
            // ACT
            //int testDrinkId = testOrder.DrinkId;
            //Drink testDrink = Drink.GetDrinkById(testDrinkId);
            // ?? above and testOrder.GetOrderDrinkById(1) method fails/returns null?
            //Assert using testDrink rather than drink1 fails d/t System.NullReferenceException: Object reference not
            // set to an instance of an object??
            Drink drink1 = Drink.GetDrinkById(1);
            // ASSERT
            //Assert.Equal(expected, testDrink.DrinkName);
            Assert.Equal(expected, drink1.DrinkName);
            //Assert.Equal(expectedId, 1);
        }
        // Had to scratch the DrinkName ENUM so can't do below?
        /*[Fact]
        public void TestInValidDrinkName()
        {
            // ARRANGE
            //Order testCustomerEmail = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expected = "WhiteChocolateMocha";
            // ACT
            Order testOrder = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "White Chocolate Mocha", "regular");
            //int testDrinkId = testOrder.DrinkId;
            //Drink testDrink = Drink.GetDrinkById(testDrinkId);
            Drink drink1 = Drink.GetDrinkById(1);
            // ASSERT
            //Assert.Equal(expected, testDrink.DrinkName);
            Assert.Equal(expected, drink1.DrinkName);
        }*/

        // Test DrinkType assigned correctly
        [Fact]
        public void TestValidDrinkTypeAssigned()
        {
            // ARRANGE
            string expected = "coffee";
            string expectedTea = "tea";
            string expectedSoda = "soda";
            Order testOrder = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");

            // ACT
            // coffees
            testOrder.AddDrinkToOrder("Mocha", "small");
            testOrder.AddDrinkToOrder("MochaLatte", "large");
            testOrder.AddDrinkToOrder("Latte", "small");
            testOrder.AddDrinkToOrder("American", "large");
            // teas
            testOrder.AddDrinkToOrder("IcedTea", "small");
            testOrder.AddDrinkToOrder("GreenTea", "regular");
            testOrder.AddDrinkToOrder("ChaiTea", "large");
            // sodas
            testOrder.AddDrinkToOrder("VanillaItalianSoda", "small");
            testOrder.AddDrinkToOrder("StrawberryItalianSoda", "regular");
            testOrder.AddDrinkToOrder("CherryItalianSoda", "large");
            // default 'coffee' assigned if no match found
            testOrder.AddDrinkToOrder("Macchiato", "large");

            //int testDrinkId = testOrder.DrinkId;
            //Drink testDrink = Drink.GetDrinkById(testDrinkId);
            // ?? above and testOrder.GetOrderDrinkById(1) method fails/returns null?
            //Assert using testDrink rather than drink1 fails d/t System.NullReferenceException: Object reference not
            // set to an instance of an object??
            Drink drink1 = Drink.GetDrinkById(1);
            Drink drink2 = Drink.GetDrinkById(2);
            Drink drink3 = Drink.GetDrinkById(3);
            Drink drink4 = Drink.GetDrinkById(4);
            Drink drink5 = Drink.GetDrinkById(5);

            Drink drink6 = Drink.GetDrinkById(6);
            Drink drink7 = Drink.GetDrinkById(7);
            Drink drink8 = Drink.GetDrinkById(8);
            
            Drink drink9 = Drink.GetDrinkById(9);
            Drink drink10 = Drink.GetDrinkById(10);
            Drink drink11 = Drink.GetDrinkById(11);

            Drink drink12 = Drink.GetDrinkById(12);

            // ASSERT
            //Assert.Equal(expected, testDrink.DrinkName);
            Assert.Equal(expected, drink1.DrinkType);
            Assert.Equal(expected, drink2.DrinkType);
            Assert.Equal(expected, drink3.DrinkType);
            Assert.Equal(expected, drink4.DrinkType);
            Assert.Equal(expected, drink5.DrinkType);

            Assert.Equal(expectedTea, drink6.DrinkType);
            Assert.Equal(expectedTea, drink7.DrinkType);
            Assert.Equal(expectedTea, drink8.DrinkType);

            Assert.Equal(expectedSoda, drink9.DrinkType);
            Assert.Equal(expectedSoda, drink10.DrinkType);
            Assert.Equal(expectedSoda, drink11.DrinkType);

            Assert.Equal(expected, drink12.DrinkType);
        }
        // Test DrinkSize assigned correctly
        [Fact]
        public void TestValidDrinkSizeAssigned()
        {
            // ARRANGE
            string expectedSmall = "small";
            string expectedReg = "regular";
            string expectedLarge = "large";
            Order testOrder = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            // ACT
            // coffees
            testOrder.AddDrinkToOrder("Mocha", "small");
            testOrder.AddDrinkToOrder("MochaLatte", "large");
            testOrder.AddDrinkToOrder("Latte", "small");
            testOrder.AddDrinkToOrder("American", "large");
            // teas
            testOrder.AddDrinkToOrder("IcedTea", "small");
            testOrder.AddDrinkToOrder("GreenTea", "regular");
            testOrder.AddDrinkToOrder("ChaiTea", "large");
            // sodas
            testOrder.AddDrinkToOrder("VanillaItalianSoda", "small");
            testOrder.AddDrinkToOrder("StrawberryItalianSoda", "regular");
            testOrder.AddDrinkToOrder("CherryItalianSoda", "large");
            // default 'coffee' assigned if no match found
            testOrder.AddDrinkToOrder("Macchiato", "large");
            // default 'regular' assigned if no match found
            //testOrder.AddDrinkToOrder("American", "medium");
            testOrder.AddDrinkToOrder("WhiteChocolateMocha", "medium");
            //testOrder.AddDrinkToOrder("WhiteChocolateMocha", "grande");

            //int testDrinkId = testOrder.DrinkId;
            //Drink testDrink = Drink.GetDrinkById(testDrinkId);
            // ?? above and testOrder.GetOrderDrinkById(1) method fails/returns null?
            //Assert using testDrink rather than drink1 fails d/t System.NullReferenceException: Object reference not
            // set to an instance of an object??
            Drink drink1 = Drink.GetDrinkById(1);
            Drink drink2 = Drink.GetDrinkById(2);
            Drink drink3 = Drink.GetDrinkById(3);
            Drink drink4 = Drink.GetDrinkById(4);
            Drink drink5 = Drink.GetDrinkById(5);

            Drink drink6 = Drink.GetDrinkById(6);
            Drink drink7 = Drink.GetDrinkById(7);
            Drink drink8 = Drink.GetDrinkById(8);

            Drink drink9 = Drink.GetDrinkById(9);
            Drink drink10 = Drink.GetDrinkById(10);
            Drink drink11 = Drink.GetDrinkById(11);

            Drink drink12 = Drink.GetDrinkById(12);
            Drink drink13 = Drink.GetDrinkById(13);

            // ASSERT
            // coffees
            //Assert.Equal(expected, testDrink.DrinkName);
            Assert.Equal(expectedReg, drink1.DrinkSize);
            Assert.Equal(expectedSmall, drink2.DrinkSize);
            Assert.Equal(expectedLarge, drink3.DrinkSize);
            // Default to 'regular' if no match found to 'small', 'regular', or 'large'
            // ?? passed in 'medium' should assign 'regular' but Unit test showing 'small'
            // is assigned?? 
            // Had to revert to passing in same Drink objects to testOrder or 
            // of Unit Test won't pass d/t drink id's correlated w/ first
            // version of testOrder passed, even if tried changing name
            // of Order and Drink variables used in each Unit Test method. 
            // This resolved above issue and allowed Unit Tests to pass. 
            Assert.Equal(expectedSmall, drink4.DrinkSize);
            Assert.Equal(expectedLarge, drink5.DrinkSize);
            // teas
            Assert.Equal(expectedSmall, drink6.DrinkSize);
            Assert.Equal(expectedReg, drink7.DrinkSize);
            Assert.Equal(expectedLarge, drink8.DrinkSize);
            // sodas
            Assert.Equal(expectedSmall, drink9.DrinkSize);
            Assert.Equal(expectedReg, drink10.DrinkSize);
            Assert.Equal(expectedLarge, drink11.DrinkSize);
            // default tests
            Assert.Equal(expectedLarge, drink12.DrinkSize);
            Assert.Equal(expectedReg, drink13.DrinkSize);
        }

        // Test DrinkPrice assigned correctly
        [Fact]
        public void TestValidDrinkPriceAssigned()
        {
            // ARRANGE
            //string expected = "coffee";
            decimal smallCoffee = 2.99m;
            decimal regCoffee = 3.99m;
            decimal largeCoffee = 4.99m;
            //string expectedTea = "tea";
            decimal smallTea = 1.59m;
            decimal regTea = 2.59m;
            decimal largeTea = 3.59m;
            //string expectedSoda = "soda";
            decimal smallSoda = 2.50m;
            decimal regSoda = 3.50m;
            decimal largeSoda = 4.50m;
            Order testOrder = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            
            // ACT
            // coffees
            testOrder.AddDrinkToOrder("Mocha", "small");
            testOrder.AddDrinkToOrder("MochaLatte", "large");
            testOrder.AddDrinkToOrder("Latte", "small");
            testOrder.AddDrinkToOrder("American", "large");
            // teas
            testOrder.AddDrinkToOrder("IcedTea", "small");
            testOrder.AddDrinkToOrder("GreenTea", "regular");
            testOrder.AddDrinkToOrder("ChaiTea", "large");
            // sodas
            testOrder.AddDrinkToOrder("VanillaItalianSoda", "small");
            testOrder.AddDrinkToOrder("StrawberryItalianSoda", "regular");
            testOrder.AddDrinkToOrder("CherryItalianSoda", "large");
            // default 'coffee' assigned if no match found
            testOrder.AddDrinkToOrder("Macchiato", "large");
            // default 'regular' assigned if no match found
            //testOrder.AddDrinkToOrder("American", "medium");
            testOrder.AddDrinkToOrder("WhiteChocolateMocha", "medium");
            //testOrder.AddDrinkToOrder("WhiteChocolateMocha", "grande");

            // Had to revert to passing in same Drink objects to testOrder or 
            // of Unit Test won't pass d/t drink id's correlated w/ first
            // version of testOrder passed, even if tried changing name
            // of Order and Drink variables used in each Unit Test method. 

            // teas
            /*testOrderPrice.AddDrinkToOrder("IcedTea", "small");
            //testOrderPrice.AddDrinkToOrder("GreenTea", "regular");
            //testOrderPrice.AddDrinkToOrder("ChaiTea", "large");
            testOrderPrice.AddDrinkToOrder("IcedTea", "regular");
            testOrderPrice.AddDrinkToOrder("IcedTea", "large");
            // sodas
            testOrderPrice.AddDrinkToOrder("VanillaItalianSoda", "small");
            //testOrderPrice.AddDrinkToOrder("StrawberryItalianSoda", "regular");
            //testOrderPrice.AddDrinkToOrder("CherryItalianSoda", "large");
            testOrderPrice.AddDrinkToOrder("VanillaItalianSoda", "regular");
            testOrderPrice.AddDrinkToOrder("VanillaItalianSoda", "large");*/
            // default 'coffee' assigned if no match found
            //testOrder.AddDrinkToOrder("Macchiato", "large");

            //int testDrinkId = testOrder.DrinkId;
            //Drink testDrink = Drink.GetDrinkById(testDrinkId);
            // ?? above and testOrder.GetOrderDrinkById(1) method fails/returns null?
            //Assert using testDrink rather than drink1 fails d/t System.NullReferenceException: Object reference not
            // set to an instance of an object??
            /*Drink drinkPrice1 = Drink.GetDrinkById(1);
            Drink drinkPrice2 = Drink.GetDrinkById(2);
            Drink drinkPrice3 = Drink.GetDrinkById(3);
            
            Drink drinkPrice4 = Drink.GetDrinkById(4);
            Drink drinkPrice5 = Drink.GetDrinkById(5);
            Drink drinkPrice6 = Drink.GetDrinkById(6);
           
            Drink drinkPrice7 = Drink.GetDrinkById(7);
            Drink drinkPrice8 = Drink.GetDrinkById(8);
            Drink drinkPrice9 = Drink.GetDrinkById(9);*/
            Drink drink1 = Drink.GetDrinkById(1);
            Drink drink2 = Drink.GetDrinkById(2);
            Drink drink3 = Drink.GetDrinkById(3);
            Drink drink4 = Drink.GetDrinkById(4);
            Drink drink5 = Drink.GetDrinkById(5);

            Drink drink6 = Drink.GetDrinkById(6);
            Drink drink7 = Drink.GetDrinkById(7);
            Drink drink8 = Drink.GetDrinkById(8);

            Drink drink9 = Drink.GetDrinkById(9);
            Drink drink10 = Drink.GetDrinkById(10);
            Drink drink11 = Drink.GetDrinkById(11);

            Drink drink12 = Drink.GetDrinkById(12);
            Drink drink13 = Drink.GetDrinkById(13);

            // ASSERT
            // drink1 is WhiteChocolateMocha - regular 
            // drink2 is Mocha - small
            // drink3 is MochaLatte - large
            //Assert.Equal(drinkPrice2, drinkPrice1);
            //Assert.Equal(drinkPrice3, drinkPrice2);
            //Assert.Equal(regCoffee, drinkPrice1.DrinkPrice);
            //Assert.Equal(smallCoffee, drinkPrice2.DrinkPrice);
            //Assert.Equal(largeCoffee, drinkPrice3.DrinkPrice);
            Assert.Equal(regCoffee, drink1.DrinkPrice);
            Assert.Equal(smallCoffee, drink2.DrinkPrice);
            Assert.Equal(largeCoffee, drink3.DrinkPrice);
            Assert.Equal(smallCoffee, drink4.DrinkPrice);
            Assert.Equal(largeCoffee, drink5.DrinkPrice);
            // teas
            Assert.Equal(smallTea, drink6.DrinkPrice);
            Assert.Equal(regTea, drink7.DrinkPrice);
            Assert.Equal(largeTea, drink8.DrinkPrice);
            // sodas
            Assert.Equal(smallSoda, drink9.DrinkPrice);
            Assert.Equal(regSoda, drink10.DrinkPrice);
            Assert.Equal(largeSoda, drink11.DrinkPrice);
            // default tests
            Assert.Equal(largeCoffee, drink12.DrinkPrice);
            Assert.Equal(regCoffee, drink13.DrinkPrice);
            // Temp statement to check Drink object details
            // ?? drink4 is Latte small ?? rather than IcedTea small
            // ?? drink5 is "" large rather than IcedTea regular
            // ?? drink6 is IcedTea - small, 1.59 rather than IcedTea large
            // ?? drink7 is GreenTea - large, 3.59 rather than VanillaItalianSoda small
            // ?? drink8 is ChaiTea - small, 1.59 rather than VanillaItalianSoda regular
            // ?? drink9 is VanillaItalianSoda - small, 2.50 rather than VanillaItalianSoda large
            //Assert.Equal(drinkPrice4, drinkPrice5);
            //Assert.Equal(drinkPrice6, drinkPrice7);
            //Assert.Equal(drinkPrice8, drinkPrice9);
            // Unit test showing 2.99 assigned when should be 1.59 for small tea
            //Assert.Equal(smallTea, drinkPrice4.DrinkPrice);
            // Unit test showing 4.99 assigned when should be 2.59 for regular tea
            //Assert.Equal(regTea, drinkPrice5.DrinkPrice);
            // Unit test showing 1.59 assigned when should be 3.59 for large tea
            //Assert.Equal(largeTea, drinkPrice6.DrinkPrice);

            // Unit test showing 3.59 assigned when should be 2.50 for small soda
            //Assert.Equal(smallSoda, drinkPrice7.DrinkPrice);
            // Unit test showing 1.59 assigned when should be 3.50 for regular soda
            //Assert.Equal(regSoda, drinkPrice8.DrinkPrice);
            // Unit test showing 2.50 assigned when should be 4.50 for large soda
            //Assert.Equal(largeSoda, drinkPrice9.DrinkPrice);

            //Assert.Equal(expectedSoda, drinkPrice10.DrinkType);
            //Assert.Equal(expectedSoda, drinkPrice11.DrinkType);
            //Assert.Equal(expected, drinkPrice12.DrinkType);
        }
    }
}
