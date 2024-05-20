/***************************************************************
* Name : DrinkShopV4ConsoleApp Project's Drink.cs class file
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
*   Drink class - blue print for Drink class objects,
*   with constructor(s), getters/setters (mutators/accessors), method(s) 
*   and ToString() method to display details regarding the Drink class 
*   objects to the console.
*            Input: String - DrinkName, String - DrinkSize for each instance 
*            of Drink class object. And depending on which constructor is
*            used - int orderId for associated Order object this Drink object
*            is associated with.
*            Output: ToString() method to display details about the Drink
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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkShopV4ConsoleApp
{
    // moved enum DrinkName from Data > Enum folder to inside model/class file
    public enum DrinkName
    {
        WhiteChocolateMocha,
        Mocha,
        MochaLatte,
        Latte,
        Americano,
        IcedTea,
        GreenTea,
        ChaiTea,
        VanillaItalianSoda,
        StrawberryItalianSoda,
        CherryItalianSoda
    }

    public class Drink
    {
        // ?? No constructors were shown in model classes in the tutorials??
        // ?? No private Fields/attributes show in model classes in the
        // tutorials??
        // ?? Only public properties w/ just { get; set; } show in model
        // classes in the tutorials??
        // ??Not sure if this is one of the reasons why having difficulty
        // gettting programs to work with the database/join tables correctly??
        // Fields/attributes
        // Primary key - DrinkId
        private int _drinkId;
        private string _drinkName;
        // Switch to using enum for DrinkName options??
        //private DrinkName _drinkName;
        // consider creating enums for DrinkType and DrinkSize
        private string _drinkType;
        private string _drinkSize;
        //private string _drinkDescription;
        //private string _drinkImageUrl;
        private decimal _drinkPrice;
        // create a bool to hold true/false whether this Drink object
        // had been made or not.
        private bool _drinkMade;

        // ?attribute to hold associated foreign key for OrderID
        // ?? not even needed given this data is held many to many
        // relationship data is held in OrderDetail relational table??
        private int _orderId;
        //private int _orderDetailId;
        private Order _order;
        // ?? is OrderId/Order properties/attributes even really needed in Drink class object??

        // ??or does this just need a Property?? along w/ virtual Property
        // to attach to associated Order entity/object??

        // create static counter for Drink class 
        private static int _nextDrinkId = 0;
        private static List<Drink> _allDrinks = new List<Drink>();

        // Constructor(s)
        // ?? No constructors were shown in model classes in the tutorials??
        // Default constructor
        public Drink()
        {
            // increment _drinkId using Drink class's static _nextDrinkId counter. 
            NextDrinkId = NextDrinkId + 1;
            DrinkId = NextDrinkId;
            //DrinkId = drinkId;
            DrinkName = "";
            //DrinkName = DrinkName.WhiteChocolateMocha;
            //DrinkType = "";
            DrinkSize = "";
            //DrinkImageUrl = drinkImageUrl;
            DrinkType = DrinkType;
            //DrinkPrice = -1m;
            DrinkPrice = DrinkPrice;
            DrinkMade = false;
            //OrderId = this.OrderId;
            //AllDrinks.Add(this.Drink);
            AllDrinks.Add(this);
            //Drink.AllDrinks.Add(this);
        }
        // Parameterized Constructor(s)
        public Drink(string drinkName, string drinkSize)
        {
            // increment _drinkId using Drink class's static _nextDrinkId counter. 
            NextDrinkId = NextDrinkId + 1;
            DrinkId = NextDrinkId;
            //DrinkId = this.DrinkId;
            DrinkName = drinkName;
            DrinkSize = drinkSize;
            DrinkType = this.DrinkType;
            DrinkPrice = this.DrinkPrice;
            //OrderId = this.OrderId;
            DrinkMade = false;
            // Every Drink created add to Drink.AllDrinks static List
            Drink.AllDrinks.Add(this);
        }
        public Drink(int orderId, string drinkName, string drinkSize)
        {
            // increment _drinkId using Drink class's static _nextDrinkId counter. 
            NextDrinkId = NextDrinkId + 1;
            DrinkId = NextDrinkId;
            //DrinkId = this.DrinkId;
            DrinkName = drinkName;
            DrinkSize = drinkSize;
            DrinkType = this.DrinkType;
            DrinkPrice = this.DrinkPrice;
            OrderId = orderId;
            //Order = Order.GetOrderById(orderId);
            if (Order.GetOrderById(orderId) != null)
            {
                Order = Order.GetOrderById(orderId);
            }
            DrinkMade = false;
            //AllDrinks.Add(this);
            // Every Drink created add to Drink.AllDrinks static List
            Drink.AllDrinks.Add(this);
        }
        /*public Drink(DrinkName drinkName, string drinkType, string drinkSize)
        //public Drink(string drinkName, string drinkType, string drinkSize)
        {
            // increment _drinkId using Drink class's static _nextDrinkId counter. 
            _nextDrinkId = _nextDrinkId + 1;
            DrinkId = _nextDrinkId;
            //DrinkId = drinkId;
            DrinkName = drinkName;
            //DrinkType = drinkType;
            DrinkType = this.DrinkType;
            DrinkSize = drinkSize;
            //DrinkImageUrl = drinkImageUrl;
            // Use below for now until switch to DrinkPrice w/ specific setter version 
            //DrinkPrice = 1.49m;
            DrinkPrice = this.DrinkPrice;
            DrinkMade = false;
            //AllDrinks.Add(this);
            // Every Drink created add to Drink.AllDrinks static List
            Drink.AllDrinks.Add(this);
        }*/
        /*public Drink(DrinkName drinkName, string drinkType, string drinkSize, decimal price)
        //public Drink(string drinkName, string drinkType, string drinkSize, decimal price)
        {
            // increment _drinkId using Drink class's static _nextDrinkId counter. 
            _nextDrinkId = _nextDrinkId + 1;
            DrinkId = _nextDrinkId;
            //DrinkId = drinkId;
            DrinkName = drinkName;
            DrinkType = drinkType;
            DrinkSize = drinkSize;
            //DrinkImageUrl = drinkImageUrl;
            DrinkPrice = price;
            // Every Drink created add to Drink.AllDrinks static List
            Drink.AllDrinks.Add(this);
            //AllDrinks.Add(this);
        }*/

        // Properties:
        // If using Entity Framework do not need to specify [Key] as 
        // the EF assigns Properties named w/ 'ClassnameId' syntax as the
        // Class's Primary Key automatically. 
        //[Key]
        public int DrinkId { get => _drinkId; set => _drinkId = value; }
        // If need to use a nullable reference type in the model/class, but
        // do NOT want null stored in database use 'string?' with the
        // [Required] attibute.
        //[Required(ErrorMessage = "DrinkName is required")]
        //public string? DrinkName { get => _drinkName; set => _drinkName = value; }
        // Create input validation in DrinkName set so only the specified values
        // are allowed to be assigned. 
        public string? DrinkName
        {
            get { return _drinkName; }
            set
            {
                if (string.Equals(value, "WhiteChocolateMocha", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "Mocha", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "MochaLatte", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "Latte", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "Americano", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "IcedTea", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "GreenTea", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "ChaiTea", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "VanillaItalianSoda", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "StrawberryItalianSoda", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "CherryItalianSoda", StringComparison.InvariantCultureIgnoreCase))
                {
                    _drinkName = value;
                }
                else
                {
                    // set default value??
                    _drinkName = "";
                }
            }
        }
        // Tutorial showed using initializer set to 'null!' to explicitly set the
        // property as null - rather than using '?' nullable reference with the [Required]
        // attibute
        //public string DrinkName { get; set; } = null!;
        // enum version
        //public DrinkName DrinkName { get => _drinkName; set => _drinkName = value; }
        //[Required(ErrorMessage = "DrinkType is required")]
        //public string? DrinkType { get => _drinkType; set => _drinkType = value; }
        public string? DrinkType
        {
            get { return _drinkType; }
            /*set
            {
                if (string.Equals(value, "coffee", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "tea", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "soda", StringComparison.InvariantCultureIgnoreCase))
                {
                    _drinkType = value;
                }
                else
                {
                    // set default of 'coffee' if input doesn't match one of the three drink types
                    _drinkType = "coffee";
                }
            }*/
            // change above from checking if 'coffee' 'tea' or 'soda' entered to setting
            // DrinkType automatically for user depending on DrinkName value
            set
            {
                //string drinkNameString = DrinkName.ToString();
                //string drinkNameString = this.DrinkName;
                if (string.Equals(DrinkName, "WhiteChocolateMocha", StringComparison.InvariantCultureIgnoreCase) || string.Equals(DrinkName, "Mocha", StringComparison.InvariantCultureIgnoreCase) || string.Equals(DrinkName, "MochaLatte", StringComparison.InvariantCultureIgnoreCase) || string.Equals(DrinkName, "Latte", StringComparison.InvariantCultureIgnoreCase) || string.Equals(DrinkName, "Americano", StringComparison.InvariantCultureIgnoreCase))
                /*if (string.Equals(drinkNameString, "WhiteChocolateMocha", StringComparison.InvariantCultureIgnoreCase) || string.Equals(drinkNameString, "Mocha", StringComparison.InvariantCultureIgnoreCase) || string.Equals(drinkNameString, "MochaLatte", StringComparison.InvariantCultureIgnoreCase) || string.Equals(drinkNameString, "Latte", StringComparison.InvariantCultureIgnoreCase) || string.Equals(drinkNameString, "Americano", StringComparison.InvariantCultureIgnoreCase))*//*(DrinkName.Equals("WhiteChocolateMocha") || DrinkName.Equals("Mocha") || DrinkName.Equals("MochaLatte") || DrinkName.Equals("Latte") || DrinkName.Equals("Americano"))*/
                /*(Drink.DrinkName.Equals(Drink.DrinkName, "WhiteChocolateMocha", StringComparison.InvariantCultureIgnoreCase) || string.Equals(DrinkName, "Mocha", StringComparison.InvariantCultureIgnoreCase) || string.Equals(DrinkName, "MochaLatte", StringComparison.InvariantCultureIgnoreCase) || string.Equals(DrinkName, "Latte", StringComparison.InvariantCultureIgnoreCase) || string.Equals(DrinkName, "Americano", StringComparison.InvariantCultureIgnoreCase))*/
                {
                    _drinkType = "coffee";
                }
                else if (string.Equals(DrinkName, "IcedTea", StringComparison.InvariantCultureIgnoreCase) || string.Equals(DrinkName, "GreenTea", StringComparison.InvariantCultureIgnoreCase) || string.Equals(DrinkName, "ChaiTea", StringComparison.InvariantCultureIgnoreCase))
                /*else if (string.Equals(drinkNameString, "IcedTea", StringComparison.InvariantCultureIgnoreCase) || string.Equals(drinkNameString, "GreenTea", StringComparison.InvariantCultureIgnoreCase) || string.Equals(drinkNameString, "ChaiTea", StringComparison.InvariantCultureIgnoreCase))*//*(DrinkName.Equals("IcedTea") || DrinkName.Equals("GreenTea") || DrinkName.Equals("ChaiTea"))*/
                {
                    _drinkType = "tea";
                }
                else if (string.Equals(DrinkName, "VanillaItalianSoda", StringComparison.InvariantCultureIgnoreCase) || string.Equals(DrinkName, "StrawberryItalianSoda", StringComparison.InvariantCultureIgnoreCase) || string.Equals(DrinkName, "CherryItalianSoda", StringComparison.InvariantCultureIgnoreCase))
                /*else if (string.Equals(drinkNameString, "VanillaItalianSoda", StringComparison.InvariantCultureIgnoreCase) || string.Equals(drinkNameString, "StrawberryItalianSoda", StringComparison.InvariantCultureIgnoreCase) || string.Equals(drinkNameString, "CherryItalianSoda", StringComparison.InvariantCultureIgnoreCase))*/ /*(DrinkName.Equals("VanillaItalianSoda") || DrinkName.Equals("StrawberryItalianSoda") || DrinkName.Equals("CherryItalianSoda"))*/
                {
                    _drinkType = "soda";
                }
                else
                {
                    // set default of 'coffee' if input doesn't match one of the three drink types
                    _drinkType = "coffee";
                }
            }
        }

        // Add '?' to datatype for DrinkSize to make it 'nullable'
        //[Required(ErrorMessage = "DrinkSize is required")]
        //public string? DrinkSize { get => _drinkSize; set => _drinkSize = value; }
        public string? DrinkSize
        {
            get { return _drinkSize; }
            set
            {
                if (string.Equals(value, "small", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "regular", StringComparison.InvariantCultureIgnoreCase) || string.Equals(value, "large", StringComparison.InvariantCultureIgnoreCase))
                {
                    _drinkSize = value;
                }
                else
                {
                    // set default DrinkSize of 'regular' if input doesn't match one fo the three sizes
                    _drinkSize = "regular";
                }
            }
        }
        // Per learn.microsoft.com tutorial - decimal, int, float, DateTime
        // values types are 'inherently' required therefore do NOT need the
        // 'Required' attribute. 
        //[DisplayFormat(DataFormatString = "{C2, CultureInfo.CurrentCulture}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "(C2, CultureInfo.CurrentCulture)", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{D2}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "(D2)", ApplyFormatInEditMode = true)]
        //[Column(TypeName = "decimal(18, 2)")]
        //[DataType(DataType.Currency, ErrorMessage = "Drink Price invalid, must be a positive value.")]
        //public decimal DrinkPrice { get => _drinkPrice; set => _drinkPrice = value; }
        public decimal DrinkPrice
        {
            get { return _drinkPrice; }
            set
            {
                // Setting DrinkPrice based on DrinkType and DrinkSize
                //string drinkTypeString = DrinkType.ToString();
                //decimal price = 0.0m;
                if (string.Equals(DrinkType, "coffee", StringComparison.InvariantCultureIgnoreCase))
                {
                    //if (string.Equals(DrinkType, "coffee", StringComparison.InvariantCultureIgnoreCase) && string.Equals(DrinkSize, "small", StringComparison.InvariantCultureIgnoreCase))
                    if (string.Equals(DrinkSize, "small", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 2.99m;
                        //price = 2.99m;
                    }
                    //else if (string.Equals(DrinkType, "coffee", StringComparison.InvariantCultureIgnoreCase) && string.Equals(DrinkSize, "regular", StringComparison.InvariantCultureIgnoreCase))
                    else if (string.Equals(DrinkSize, "regular", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 3.99m;
                        //price = 3.99m;
                    }
                    //else if (string.Equals(DrinkType, "coffee", StringComparison.InvariantCultureIgnoreCase) && string.Equals(DrinkSize, "large", StringComparison.InvariantCultureIgnoreCase))
                    else if (string.Equals(DrinkSize, "large", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 4.99m;
                        //price = 4.99m;
                    }
                }
                else if (string.Equals(DrinkType, "tea", StringComparison.InvariantCultureIgnoreCase))
                {
                    //if (string.Equals(DrinkType, "tea", StringComparison.InvariantCultureIgnoreCase) && string.Equals(DrinkSize, "small", StringComparison.InvariantCultureIgnoreCase))
                    if (string.Equals(DrinkSize, "small", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 1.59m;
                        //price = 1.59m;
                    }
                    //else if (string.Equals(DrinkType, "tea", StringComparison.InvariantCultureIgnoreCase) && string.Equals(DrinkSize, "regular", StringComparison.InvariantCultureIgnoreCase))
                    else if (string.Equals(DrinkSize, "regular", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 2.59m;
                        //price = 2.59m;
                    }
                    //else if (string.Equals(DrinkType, "tea", StringComparison.InvariantCultureIgnoreCase) && string.Equals(DrinkSize, "large", StringComparison.InvariantCultureIgnoreCase))
                    else if (string.Equals(DrinkSize, "large", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 3.59m;
                        //price = 3.59m;
                    }
                }
                else if (string.Equals(DrinkType, "soda", StringComparison.InvariantCultureIgnoreCase))
                {
                    //if (string.Equals(DrinkType, "soda", StringComparison.InvariantCultureIgnoreCase) && string.Equals(DrinkSize, "small", StringComparison.InvariantCultureIgnoreCase))
                    if (string.Equals(DrinkSize, "small", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 2.50m;
                        //price = 2.50m;
                    }
                    //else if (string.Equals(DrinkType, "soda", StringComparison.InvariantCultureIgnoreCase) && string.Equals(DrinkSize, "regular", StringComparison.InvariantCultureIgnoreCase))
                    else if (string.Equals(DrinkSize, "regular", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 3.50m;
                        //price = 3.50m;
                    }
                    //else if (string.Equals(DrinkType, "soda", StringComparison.InvariantCultureIgnoreCase) && string.Equals(DrinkSize, "large", StringComparison.InvariantCultureIgnoreCase))
                    else if (string.Equals(DrinkSize, "large", StringComparison.InvariantCultureIgnoreCase))
                    {
                        value = 4.50m;
                        //price = 4.50m;
                    }
                }
                _drinkPrice = value;
                //_drinkPrice = price;
            }
        }
        public bool DrinkMade { get => _drinkMade; set => _drinkMade = value; }

        // ?? below not needed d/t OrderDetail table is used to hold this many-to-many
        // relational data between Drink object and Order object??
        // ?attribute? too?? Property to hold associated foreign key for OrderID
        //[ForeignKey("Order")]
        //[ForeignKey(nameof(Order))]
        public int OrderId { get => _orderId; set => _orderId = value; }
        // ??or does this just need the above Property?? along w/ virtual Property
        // to attach to associated Order entity/object??
        //public int OrderDetailId { get => _orderDetailId; set => _orderDetailId = value; }

        // Navigation Property
        // Actually 1 Drink can only be associated w/ 1 Order object so not a collection
        // of Order/OrderDetail objects. 

        // ?? virtual properties appear to be worthless in Console apps ?? ICollection's too???
        // Below virtual Order would NOT allow a Order object to be assigned to it by the
        // constructors, nor would it link to the Order object through the OrderId property!!
        //public virtual Order Order { get; set; }
        // ?? Instead used below Property
        public Order Order { get => _order; set => _order = value; }
        // ?? is OrderId/Order properties/attributes even really needed in Drink class object??

        public static int NextDrinkId { get => _nextDrinkId; set => _nextDrinkId = value; }
        public static List<Drink>? AllDrinks { get => _allDrinks; set => _allDrinks = value; }

        //public virtual Order Order { get; set; } = null!;
        //public virtual OrderDetail OrderDetail { get; set; } = null!;



        // Adding below caused error and wouldn't update-database command in Web app
        // version. 
        // Navigation property for a collection of OrderDetails - shown in 
        // microsoft.learn tutorials for more complex models, but caused error to have
        // it in web app??
        //public virtual ICollection<OrderDetail>? OrderDetails { get; set; } = null!;
        //public virtual ICollection<Drink>? Drinks { get; set; }

        // Methods
        // Method to switch DrinkMade bool from default 'false' to 'true'
        public void DrinkCompleted()
        {
            DrinkMade = true;
        }

        /*public Drink? GetDrinkById(int drinkId)
        {
            if (Order.Drinks != null)
            {
                foreach (Drink drink in Order.Drinks)
                {
                    if (drink.DrinkId == drinkId)
                    {
                        return drink;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }*/

        public static Drink? GetDrinkById(int drinkId)
        {
            // Use static AllDrinks List instead
            if (AllDrinks != null)
            //if (Order.Drinks != null)
            {
                foreach (Drink drink in AllDrinks)
                //foreach (Drink drink in Order.Drinks)
                {
                    if (drink.DrinkId == drinkId)
                    {
                        return drink;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        // ToString() override print method 
        public override string? ToString()
        {
            //return base.ToString();
            string drinkOutput = "";
            // Decide on DrinkPrice formatting if want '$' - and specify 2 decimal place output is C2
            // if just want 2 decimal places w/o '$' sign use D2. 
            //string drinkOutput = $"Drink Id: {DrinkId}; Drink Type: {DrinkType}; Drink Name: {DrinkName}; Size: {DrinkSize}; Price: $ {DrinkPrice:D2};";
            //string drinkOutput = $"Drink Id: {DrinkId}; Drink Type: {DrinkType}; Drink Name: {DrinkName}; Size: {DrinkSize}; Price: $ {DrinkPrice:D2}; Order Id: {OrderId}";
            //string drinkOutput = $"Drink Id: {DrinkId}; Drink Type: {DrinkType}; Drink Name: {DrinkName}; Size: {DrinkSize}; Price: $ {DrinkPrice:D2}; Order Id: {Order.OrderId}";
            //return string drinkOutput = $"Drink Id: {DrinkId}; Drink Type: {DrinkType}; Drink Name: {DrinkName}; Size: {DrinkSize}; Price: $ {DrinkPrice:D2}; Order Id: {OrderId}; Drink Made: {DrinkMade}\n";
            //string drinkOutput = $"Drink Id: {DrinkId}; Drink Type: {DrinkType}; Drink Name: {DrinkName}; Size: {DrinkSize}; Price: $ {DrinkPrice:D2}; Order Id: {OrderId}; Drink Made: {DrinkMade}\n";
            drinkOutput += $" Drink Id: {DrinkId};\n  Drink Type: {DrinkType}; Drink Name: {DrinkName}; Size: {DrinkSize}; Price: $ {this.DrinkPrice};\n  Order Id: {OrderId}; Drink Made: {DrinkMade}";
            // ?? is OrderId/Order properties/attributes even really needed in Drink class object??
            //drinkOutput += $" Drink Id: {DrinkId};\n  Drink Type: {DrinkType}; Drink Name: {DrinkName}; Size: {DrinkSize}; Price: $ {this.DrinkPrice};\n  Drink Made: {DrinkMade}";
            return drinkOutput;
        }
    }
}
