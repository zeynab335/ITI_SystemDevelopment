using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using static D10.ListGenerators;
using static System.Net.Mime.MediaTypeNames;

namespace D10

{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ - Restriction Operators 1

            //1.1 Find all products that are out of stock.
            var Result = ProductList.Where(P => P.UnitsInStock == 0);

            //1.2 Find all products that are in stock and cost more than 3.00 per unit.
            Result = ProductList.Where(P => P.UnitsInStock > 0 && P.UnitPrice > 3);

            // 1.3. Returns digits whose name is shorter than their value.

            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var shortDigits = from pair in Arr.Select((value, index) => new { value, index })
                              where pair.value.Length < pair.index
                              select pair.value;

            //foreach (var Unit in shortDigits) Console.WriteLine(Unit);
            

            #endregion

            #region LINQ-Element Operators

            // 2.1 Get first Product out of Stock 
            var element = ProductList.FirstOrDefault(P => P.UnitsInStock == 0);

            // 2.2   Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            element = ProductList.FirstOrDefault(P => P.UnitPrice > 1000);

            // 2.3. Retrieve the second number greater than 5 
            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            Array.Sort(Arr2);

            var data = (from x in Arr2
                        where x > 5
                        select x
                        ).Skip(1).FirstOrDefault();
            //Console.WriteLine(data);


            #endregion


            #region LINQ - Set Operators

            // 1. Find the unique Category names from Product List
            // return array of categories
            var Categories = ProductList.Select(p=>p.Category).ToList().Distinct();

            // ***********************************************

            // 2.Produce a Sequence containing the unique first letter
            // from both product and customer names.

            var product_names = ProductList.Select(p => p.ProductName);
            var unique_product_names = product_names.DistinctBy(p => p[0]).ToList();
            //Console.WriteLine(product_names.Count()); // 77 
            //Console.WriteLine(unique_product_names.Count()); // 22

            //foreach (var item in product_names)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("*************************************");
            //foreach (var item in unique_product_names)
            //{
            //    Console.WriteLine(item);
            //}

            //****************************************************

            // 3. Create one sequence that contains the common first letter from both product and customer names.
            var product_names2 = ProductList.Select(p => p.ProductName.ToCharArray().FirstOrDefault());
            var customerNames2 = CustomerList.Select(c => c.CompanyName.ToCharArray().FirstOrDefault());

            var Res_union = customerNames2.Intersect(product_names2);

            //foreach (var res in Res_union)
            //    Console.WriteLine(res);


            // 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.
            var except_result = product_names2.Except(customerNames2) ;
            //foreach (var res in except_result)
            //    Console.WriteLine(res);

            //* 5. Create one sequence that contains the last Three Characters in each names of all customers and products, including any duplicates
            var ProductNamesList = ProductList.Select(p => p.ProductName.Substring(p.ProductName.Length - 3,3) );;
            var CustomerNamesList = CustomerList.Select(c => c.CompanyName.Substring(c.CompanyName.Length - 3,3) );;
                
            var unino_res = ProductNamesList.Concat(CustomerNamesList);

            //Console.WriteLine(unino_res.Count());
            // using Contact => 168
            // using union => 129

            //foreach (var item in unino_res)
            //    Console.Write(item);

            #endregion



            #region LINQ - Aggregate Operators
            // 1. Uses Count to get the number of odd numbers in the array
            int[] OddNumbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var count_OddNumbers = OddNumbers.Count(num => num % 2 != 0);
            //Console.WriteLine(count_OddNumbers);

            //*************************************************************


            // 2. Return a list of customers and how many orders each has.
            var CustomerOrders = CustomerList.Select(c => new { Id  = c.CustomerID ,customerName = c.CompanyName, CustermerOrders = c.Orders.Count() });

            //foreach (var item in CustomerOrders) Console.WriteLine(item);
            


            //*************************************************************

            // 3. Return a list of categories and how many products each has
            // retur <string,Product>
            var CategoriesOfProducts = ProductList.GroupBy(p => p.Category);
                                      
            //Console.WriteLine("********************************");
            //foreach (var products in CategoriesOfProducts)
            //{
            //    Console.WriteLine("Category => " + products.Key + " : " + products.Count());

            //    foreach(var product in products)
            //    {
            //        Console.WriteLine("  Product Name :" + product.ProductName + "Category = " + product.Category + "\n" );
            //    }

            //}

            //*****************************************************

            //4. Get the total of the numbers in an array.
            int[] TotalOfArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //Console.WriteLine( TotalOfArr.Sum());

            //*****************************************************


            //* 5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            string[] dictionary_english;

            if (File.Exists("dictionary_english.txt"))
            {
                 dictionary_english = File.ReadAllLines("dictionary_english.txt");

                //Console.WriteLine( dictionary_english.Sum(x => x.Length));

            }

            //*************************************************

            //* 6. Get the total units in stock for each product category.

            var TotalUnits = ProductList.GroupBy(p => p.Category);
            //foreach (var products in TotalUnits)
            //{
            //    Console.WriteLine("Category => " + products.Key + " : " + products.Count());

            //    Console.WriteLine("total units in Stock For " + products.Key + " == " + products.Sum(p => p.UnitsInStock));

            //    Console.WriteLine("****************************");

            //}


            //******************************************************

            // 7. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            if (File.Exists("dictionary_english.txt"))
            {
                dictionary_english = File.ReadAllLines("dictionary_english.txt");

                //var Result1 = dictionary_english.MinBy(p => p.Length);
                //Console.WriteLine(Result1);

            }


            //8. Get the cheapest price among each category's products
            var cheapestPrice  = ProductList.GroupBy(p => p.Category)
                                            .Select( p=> new { product_Category = p.Key, maxPrice = p.Max(p=>p.UnitPrice) });


            //foreach (var c in cheapestPrice)
            //{
            //    Console.WriteLine(c.ToString());
            //}

            //*******************************************************************

            //9.Get the products with the cheapest price in each category(Use Let)
            var CheapestResult = from p in ProductList
                                 group p by p.Category into AllProducts
                                 let minPrice = AllProducts.Min(p => p.UnitPrice)
                                 select new { product_Category = AllProducts.Key , minPrice = minPrice};

            //foreach (var c in CheapestResult)
            //{
            //    Console.WriteLine(c.ToString());
            //}

            //*******************************************************************


            // 10. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            if (File.Exists("dictionary_english.txt"))
            {
                dictionary_english = File.ReadAllLines("dictionary_english.txt");

                //var Result2 = dictionary_english.MaxBy(p => p.Length);
                //Console.WriteLine(Result2);
            }

            //*******************************************************************

            //11
            var ExpensivePrice = from p in ProductList
                                 group p by p.Category into AllProducts
                                 let maxPrice = AllProducts.Max(p => p.UnitPrice)
                                 select new { product_Category = AllProducts.Key, maxPrice = maxPrice };

            //foreach (var c in ExpensivePrice)
            //{
            //    Console.WriteLine(c.ToString());
            //}

            //***************************************************
            // 12
            var TheMostExpensivePrice = ExpensivePrice.ToList();
                
            //foreach (var c in TheMostExpensivePrice) Console.WriteLine(c.ToString());
            
            //Console.WriteLine(TheMostExpensivePrice.Max(p => p.maxPrice));

            //****************************************************
            // 13. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            if (File.Exists("dictionary_english.txt"))
            {
                dictionary_english = File.ReadAllLines("dictionary_english.txt");
                
                Console.WriteLine(dictionary_english.Average(st => st.Length));
            }


            //14. Get the average price of each category's products.
            var AvgPrice = from p in ProductList
                           group p by p.Category into ProductCategories
                           let avg = ProductCategories.Average(p => p.UnitPrice)
                           select new { Category = ProductCategories.Key, Avg = avg };


            //foreach (var item in AvgPrice)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion


            #region Ordering Operators

            //1. Sort a list of products by name
            var SortProduct = ProductList.OrderBy(p=>p.ProductName);
            //foreach (var item in SortProduct)
            //{
            //    Console.WriteLine(item);
            //}


            //**********************************************
            //* 2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
            string[] Cstm_compare_Arr = { "bRaNcH" , "aPPLE", "AbAcUs", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var res1 = Cstm_compare_Arr.OrderBy(p=>p,new CustomComparer());
            //foreach (var item in res1)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("/*****************");

            //**********************************************

            //*3. Sort a list of products by units in stock from highest to lowest.
            var DescUnitStock = ProductList.OrderByDescending(p => p.UnitsInStock);
            //foreach (var item in DescUnitStock)
            //{
            //    Console.WriteLine(item);
            //}

            //**********************************************


            //* 4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            var SortByProductName = Arr.Select((value) => new { value = value}).OrderBy(p => p.value.Length).ThenBy(p=>p.value);
            //foreach (var item in SortByProductName)
            //{
            //    Console.WriteLine(item);
            //}

            //* 5. Sort first by word length and then by a case-insensitive sort of the words in an array.
            var rees = Cstm_compare_Arr.OrderBy(p=>p.Length).ThenBy(p => p, new CustomComparer());
            //foreach (var item in rees)
            //{
            //    Console.WriteLine(item);
            //}


            //**********************************************

            //6. Sort a list of products, first by category, and then by unit price, from highest to lowest.
            var SortProuctsByUnit = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

            //**********************************************

            //7. Sort first by word length and then by a case-insensitive descending sort of the words in an array.
            var rees2 = Cstm_compare_Arr.OrderBy(p => p.Length).ThenByDescending(p => p, new CustomComparer());

            //**********************************************

            //*8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            Regex rg = new Regex(@"[a-z]i");
            var ele = Arr.Where(value => value.ToCharArray()[1] == 'i' );
            foreach (var c in ele) Console.WriteLine(c.ToString());


            #endregion


            #region Partitioning

            // 1. Get the first 3 orders from customers in Washington
            var customer_order3 = CustomerList.Where(c => c.Country == "Washington").Select(c => new{cutomerName = c.CompanyName , order = c.Orders.Length }).Take(3);
            //foreach(var c in customer_order3) Console.WriteLine(c.ToString());


            //*****************************************************************

            // 2. Get all but the first 2 orders from customers in Washington.
            var customer_order2 = CustomerList.Where(c => c.Country == "Washington").Select(c => new { cutomerName = c.CompanyName, order = c.Orders.Length }).Take(2);
            //foreach (var c in customer_order2) Console.WriteLine(c.ToString());

            //*****************************************************************


            // 3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var r = numbers.TakeWhile((value, index) => value >= index);
            //foreach (var c in r) Console.WriteLine(c.ToString());

            //*****************************************************************

            // 4.. Get the elements of the array starting from the first element divisible by 3.
            var SkipElement = numbers.SkipWhile((value) => value % 3 != 0);
            //foreach (var c in SkipElement) Console.WriteLine(c.ToString());

            //*****************************************************************

            //*5. Get the elements of the array starting from the first element less than its position.
            var TakeLess = numbers.SkipWhile((value, index) => value > index);
            //foreach (var c in TakeLess) Console.WriteLine(c.ToString());



            #endregion


            #region LINQ - Projection Operators

            // 1. Return a sequence of just the names of a list of products.
            var listOFProducts = ProductList.Select(p => new { ProductName = p.ProductName });
            //foreach (var c in listOFProducts) Console.WriteLine(c.ToString());

            //********************************************************************

            //2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var WordsVersions = words.Select(w => new { UpperCase = w.ToUpper() , LowerCase = w.ToLower() });

            //foreach (var c in WordsVersions) Console.WriteLine(c.ToString());
            //********************************************************************


            // 3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
            
            var listUnitProducts = ProductList.Select(p => new { ProductName = p.ProductName , Price = p.UnitPrice });
            //foreach (var c in listUnitProducts) Console.WriteLine(c.ToString());

            //********************************************************************

            //4. Determine if the value of ints in an array match their position in the array.
            var CheckNumInPlace = numbers.Select((value,index)=> new { Number = value , InPlace = (value==index)});
            //foreach (var c in CheckNumInPlace) Console.WriteLine(c.Number + " : " + c.InPlace);


            //********************************************************************

            //*5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var comparsionBetweenNumbers = from a in numbersA
                                           from b in numbersB
                                           where a < b
                                           select new {a = a , b = b};
            //foreach (var c in comparsionBetweenNumbers) Console.WriteLine(c.a + " is less than " + c.b);


            //*****************************************************************
            // 6. Select all orders where the order total is less than 500.00.
            var OrderList = CustomerList.Where(c => (c.Orders.Sum(c => c.Total)) > 50000).Select(c => new { CustomerID = c.CustomerID, TotalOrders = c.Orders.Sum(c => c.Total) });
            //foreach (var c in OrderList) Console.WriteLine(c.ToString());

            //******************************************************

            //7. Select all orders where the order was made in 1998 or later.   int orderID, DateTime orderDate, decimal total
            var OrderListByDate = CustomerList.Select(c => new { Name = c.CompanyName, Orders = c.Orders.Where(o => o.OrderDate.Year >= 1998) });
            //foreach (var c in OrderListByDate)
            //{
            //    Console.WriteLine(c.Name.ToString());

            //    foreach (var order in c.Orders)
            //    {
            //        Console.WriteLine(order.OrderDate);
            //    }
            //}


            #endregion



            #region LINQ - Quantifiers

            // 1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            if (File.Exists("dictionary_english.txt"))
            {
                dictionary_english = File.ReadAllLines("dictionary_english.txt");
                var concate = dictionary_english.Any(dic => dic.Contains("ei"));

                //Console.WriteLine(concate);

            }


            //****************************************************************
            //2. Return a grouped a list of products only for categories that have at least one product that is out of stock.
            var LstProducts = ProductList.GroupBy(p => p.Category).Where(p => p.Any(p => p.UnitsInStock > 0));
            //foreach(var AllProducts in LstProducts)
            //{

            //    Console.WriteLine("Category" + " = " + AllProducts.Key);
            //    foreach (var product in AllProducts)
            //    {
            //        Console.WriteLine(product);
            //    }

            //}


            //****************************************************************
            // 3. Return a grouped a list of products only for categories that have all of their products in stock.
            var LstAllProducts = ProductList.GroupBy(p => p.Category).Where(p => p.All(p => p.UnitsInStock > 0));
            //foreach (var AllProducts in LstAllProducts)
            //{

            //    Console.WriteLine("Category" + " = " + AllProducts.Key);
            //    foreach (var product in AllProducts)
            //    {
            //        Console.WriteLine(product);
            //    }

            //}



            #endregion



            #region  LINQ - Grouping Operators

            //1. Use group by to partition a list of numbers by their remainder when divided by 5
            var LstNumbers = Enumerable.Range(0, 15).GroupBy(n=>n % 5);
            foreach (var range in LstNumbers)
            {
                foreach (var r1 in range)
                {
                    Console.WriteLine(r1.ToString());
                }
                Console.Write("****************\n");

            }


            // Uses group by to partition a list of words by their first letter. Use dictionary_english.txt for Input
            if (File.Exists("dictionary_english.txt"))
            {
                dictionary_english = File.ReadAllLines("dictionary_english.txt");
                var concate = dictionary_english.GroupBy(dic => dic.ToCharArray()[0]);

                //Console.WriteLine(concate);
                //foreach (var range in concate)
                //{
                //    Console.WriteLine(range.Key.ToString());
                //    Console.Write("***************************************************\n");

                //    foreach (var r1 in range)
                //    {
                //        Console.WriteLine(r1.ToString());
                //    }

                //}

            }

            //*Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            string[] Arr5 = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

            var s2 = Arr5.GroupBy(w => w.Trim(), new StringComparaer() );
            foreach (var item in s2)
            {

                foreach(var i in item)
                {
                    Console.WriteLine(i);
                }

            }

            #endregion

        }



    }

    

    class StringComparaer : IEqualityComparer<string>
    {
       

        public bool Equals(string? x, string? y)
        {
            int sizeX = (int)x?.Count();
            int sizeY = (int)y?.Count();

            int match = 0;

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (x[i] == y[j]) match++;
                }
            }

            return (match > 2) ? true : false;
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return 0;
        }
    }
}