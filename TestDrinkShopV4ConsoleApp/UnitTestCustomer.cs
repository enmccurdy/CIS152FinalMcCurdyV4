using DrinkShopV4ConsoleApp;
using System.Numerics;

namespace TestDrinkShopV4ConsoleApp
{
    public class UnitTestCustomer
    {
        [Fact]
        public void TestValidEmail()
        {
            // ARRANGE
            //Order testCustomerEmail = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedEmail = "jdoe@fake.edu";
            // ACT
            Order testCustomerEmail = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedEmail, testCustomerEmail.Customer.Email);
        }
        // Testing email assigned even if it has numbers
        [Fact]
        public void TestValidNumericalEmail()
        {
            // ARRANGE
            //Order testCustomerEmail = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedEmail = "jdoe349@fake.edu";
            // ACT
            Order testCustomerEmail = new Order("Jane", "Doe", "jdoe349@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedEmail, testCustomerEmail.Customer.Email);
        }
        // Testing Default value assigned if no email passed
        [Fact]
        public void TestEmailBlank()
        {
            // ARRANGE
            //Order testCustomerEmail = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedEmail = "invalidEmail@fake.edu";
            // ACT
            Order testCustomerEmail = new Order("Jane", "Doe", "", "222-191-1919", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedEmail, testCustomerEmail.Customer.Email);
        }
        // Testing Default value assigned if invalid email passed
        [Fact]
        public void TestInvalidEmail()
        {
            // ARRANGE
            //Order testCustomerEmail = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedEmail = "invalidEmail@fake.edu";
            // ACT
            Order testCustomerEmail = new Order("Jane", "Doe", "jdoefakeedu", "222-191-1919", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedEmail, testCustomerEmail.Customer.Email);
        }

        [Fact]
        public void TestValidPhone()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedPhone = "222-191-1919";
            // ACT
            Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedPhone, testCustomerPhone.Customer.Phone);
        }
        // Testing Default value assigned if no phone number passed
        [Fact]
        public void TestPhoneBlank()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedPhone = "111-111-1111";
            // ACT
            Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedPhone, testCustomerPhone.Customer.Phone);
        }
        // Testing Default value assigned if invalid phone number passed
        [Fact]
        public void TestInvalidPhone()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedPhone = "111-111-1111";
            // ACT
            Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "191-1919", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedPhone, testCustomerPhone.Customer.Phone);
        }
        // ?? Decide if want this to cause it to be invalid vs formatting the user's input if no 
        // hypens added vs accepting () / - and all numbers formats
        // Testing Default value assigned if ??invalid phone number passed with no hypens
        [Fact]
        public void TestInvalidHyphenlessPhone()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedPhone = "111-111-1111";
            // ACT
            Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "2221911919", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedPhone, testCustomerPhone.Customer.Phone);
        }
        // Testing Default value assigned if invalid phone number with letters passed
        [Fact]
        public void TestAlphaPhone()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedPhone = "111-111-1111";
            // ACT
            Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "x22-191-1919", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedPhone, testCustomerPhone.Customer.Phone);
        }

        [Fact]
        public void TestValidFirstName()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedFirstName = "Jane";
            // ACT
            Order testCustomerFirstName = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedFirstName, testCustomerFirstName.Customer.FirstName);
        }
        // Testing passed value assigned if FirstName has a space
        [Fact]
        public void TestValidFirstNameWithSpace()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedFirstName = "Jo Ann";
            // ACT
            Order testCustomerFirstName = new Order("Jo Ann", "Doe", "jdoe@fake.edu", "", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedFirstName, testCustomerFirstName.Customer.FirstName);
        }
        // Testing passed value assigned if FirstName has a hyphen
        [Fact]
        public void TestValidFirstNameWithHypen()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedFirstName = "Abdul-Kareem";
            // ACT
            Order testCustomerFirstName = new Order("Abdul-Kareem", "Doe", "jdoe@fake.edu", "", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedFirstName, testCustomerFirstName.Customer.FirstName);
        }
        // Testing passed value assigned if FirstName has an apostrophe
        [Fact]
        public void TestValidFirstNameWithApos()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedFirstName = "de'Angles";
            // ACT
            Order testCustomerFirstName = new Order("de'Angles", "Doe", "jdoe@fake.edu", "", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedFirstName, testCustomerFirstName.Customer.FirstName);
        }
        // Testing Default value assigned if no FirstName passed
        [Fact]
        public void TestFirstNameBlank()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedFirstName = "invalid first name";
            // ACT
            Order testCustomerFirstName = new Order("", "Doe", "jdoe@fake.edu", "", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedFirstName, testCustomerFirstName.Customer.FirstName);
        }
        
        // Testing Default value assigned if invalid FirstName passed with special characters in it
        [Fact]
        public void TestInvalidFirstName()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedFirstName = "invalid first name";
            // ACT
            Order testCustomerFirstName = new Order("J@ne", "Doe", "jdoe@fake.edu", "191-1919", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedFirstName, testCustomerFirstName.Customer.FirstName);
        }
        // Testing Default value assigned if invalid FirstName with numbers passed
        [Fact]
        public void TestNumericFirstName()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedFirstName = "invalid first name";
            // ACT
            Order testCustomerFirstName = new Order("J4n3", "Doe", "jdoe@fake.edu", "x22-191-1919", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedFirstName, testCustomerFirstName.Customer.FirstName);
        }

        [Fact]
        public void TestValidLastName()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedLastName = "Doe";
            // ACT
            Order testCustomerLastName = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedLastName, testCustomerLastName.Customer.LastName);
        }
        // Testing passed value assigned if LastName has a space
        [Fact]
        public void TestValidLastNameWithSpace()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedLastName = "da Vinci";
            // ACT
            Order testCustomerLastName = new Order("Jo Ann", "da Vinci", "jdoe@fake.edu", "", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedLastName, testCustomerLastName.Customer.LastName);
        }
        // Testing passed value assigned if FirstName has a hyphen
        [Fact]
        public void TestValidLastNameWithHypen()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedLastName = "Jones-Smith";
            // ACT
            Order testCustomerLastName = new Order("Jane", "Jones-Smith", "jdoe@fake.edu", "", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedLastName, testCustomerLastName.Customer.LastName);
        }
        // Testing passed value assigned if LastName has an apostrophe
        [Fact]
        public void TestValidLastNameWithApos()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedLastName = "O'Neal";
            // ACT
            Order testCustomerLastName = new Order("Jane", "O'Neal", "jdoe@fake.edu", "", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedLastName, testCustomerLastName.Customer.LastName);
        }
        // Testing Default value assigned if no LastName passed
        [Fact]
        public void TestLastNameBlank()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedLastName = "invalid last name";
            // ACT
            Order testCustomerLastName = new Order("Jane", "", "jdoe@fake.edu", "", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedLastName, testCustomerLastName.Customer.LastName);
        }

        // Testing Default value assigned if invalid LastName passed with special characters in it
        [Fact]
        public void TestInvalidLastName()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedLastName = "invalid last name";
            // ACT
            Order testCustomerLastName = new Order("Jane", "D@e", "jdoe@fake.edu", "191-1919", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedLastName, testCustomerLastName.Customer.LastName);
        }
        // Testing Default value assigned if invalid LastName with numbers passed
        [Fact]
        public void TestNumericLastName()
        {
            // ARRANGE
            //Order testCustomerPhone = new Order("Jane", "Doe", "jdoe@fake.edu", "222-191-1919", "WhiteChocolateMocha", "regular");
            string expectedLastName = "invalid last name";
            // ACT
            Order testCustomerLastName = new Order("Jane", "Do3", "jdoe@fake.edu", "x22-191-1919", "WhiteChocolateMocha", "regular");
            // ASSERT
            Assert.Equal(expectedLastName, testCustomerLastName.Customer.LastName);
        }
    }
}