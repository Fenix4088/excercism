using System.Text;
using Exercism.BethanyShop.Enteties;
using Exercism.BethanyShop.Enteties.Products;

namespace BethanyShop.Utilities;

    public class Utilities
    {
        private static string directory = @"/Users/fenix/Documents/webdev/courses/exercism/exercism/";
        private static string fileName = "employees.txt";
        
        private static List<Product> inventory = new();
        private static List<Order> orders = new();

        internal static void InitializeStock()//Mock implementation
        {
            
            Product p1 = new("Sugar", new Price(10, Currency.Euro), UnitType.PerKg, 100, description: "Very white product!");
            Product p2 = new("Cake decorations", new Price(10, Currency.Euro), UnitType.PerItem, 1000, description: "Blue!");
            Product p3 = new("Strawberry", new Price(10, Currency.Euro), UnitType.PerBox, 100, description: "Red!");
            
            inventory.Add(p1);
            inventory.Add(p2);
            inventory.Add(p3);
        }

        internal static void ShowMainMenu()
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("********************");
            Console.WriteLine("* Select an action *");
            Console.WriteLine("********************");

            Console.WriteLine("1: Inventory management");
            Console.WriteLine("2: Order management");
            Console.WriteLine("3: Settings");
            Console.WriteLine("4: Save all data");
            Console.WriteLine("0: Close application");

            Console.Write("Your selection: ");

            string? userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "1":
                    ShowInventoryManagementMenu();
                    break;
                case "2":
                    ShowOrderManagementMenu();
                    break;
                case "3":
                    ShowSettingsMenu();
                    break;
                case "4":
                    //SaveAllData();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
        }

        private static void ShowInventoryManagementMenu()
        {
            string? userSelection;

            do
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("************************");
                Console.WriteLine("* Inventory management *");
                Console.WriteLine("************************");

                ShowAllProductsOverview();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("What do you want to do?");
                Console.ResetColor();

                Console.WriteLine("1: View details of product");
                Console.WriteLine("2: Add new product");
                Console.WriteLine("3: Clone product");
                Console.WriteLine("4: View products with low stock");
                Console.WriteLine("0: Back to main menu");

                Console.Write("Your selection: ");

                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        ShowDetailsAndUseProduct();
                        break;

                    case "2":
                        //ShowCreateNewProduct();
                        break;

                    case "3":
                        //ShowCloneExistingProduct();
                        break;

                    case "4":
                        ShowProductsLowOnStock();
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
            while (userSelection != "0");
            ShowMainMenu();
        }


        private static void ShowAllProductsOverview()
        {
            foreach (var product in inventory)
            {
                Console.WriteLine(product.DisplayDetailsShort());
                Console.WriteLine();
            }
        }

        private static void ShowDetailsAndUseProduct()
        {
            string? userSelection = string.Empty;

            Console.Write("Enter the ID of product: ");
            string? selectedProductId = Console.ReadLine();

            if (selectedProductId != null)
            {
                Product? selectedProduct = inventory.FirstOrDefault(p => p.Id == selectedProductId);

                if (selectedProduct != null)
                {

                    Console.WriteLine(selectedProduct.DisplayDetailsFull());

                    Console.WriteLine("\nWhat do you want to do?");
                    Console.WriteLine("1: Use product");
                    Console.WriteLine("0: Back to inventory overview");

                    Console.Write("Your selection: ");
                    userSelection = Console.ReadLine();

                    if (userSelection == "1")
                    {
                        Console.WriteLine("How many products do you want to use?");
                        int amount = int.Parse(Console.ReadLine() ?? "0");

                        selectedProduct.UseProduct(amount);

                        Console.ReadLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Non-existing product selected. Please try again.");
            }
        }

        private static void ShowProductsLowOnStock()
        {
            List<Product> lowOnStockProducts = inventory.Where(p => p.IsBelowStockTreshold).ToList();

            if (lowOnStockProducts.Count > 0)
            {
                Console.WriteLine("The following items are low on stock, order more soon!");

                foreach (var product in lowOnStockProducts)
                {
                    Console.WriteLine(product.DisplayDetailsShort());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No items are currently low on stock!");
            }

            Console.ReadLine();
        }

        private static void ShowOrderManagementMenu()
        {
            string? userSelection = string.Empty;

            do
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("********************");
                Console.WriteLine("* Select an action *");
                Console.WriteLine("********************");

                Console.WriteLine("1: Open order overview");
                Console.WriteLine("2: Add new order");
                Console.WriteLine("0: Back to main menu");

                Console.Write("Your selection: ");

                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        ShowOpenOrderOverview();
                        break;
                    case "2":
                        ShowAddNewOrder();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
            while (userSelection != "0");
            ShowMainMenu();
        }

        private static void ShowOpenOrderOverview()
        {
            //check to handle fulfilled orders
            ShowFulfilledOrders();

            if (orders.Count > 0)
            {
                Console.WriteLine("Open orders:");

                foreach (var order in orders)
                {
                    Console.WriteLine(order.ShowOrderDetails());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("There are no open orders");
            }

            Console.ReadLine();
        }

        private static void ShowFulfilledOrders()
        {
            Console.WriteLine("Checking fulfilled orders.");
            foreach (var order in orders)
            {
                if (!order.Fulfilled && order.OrderFulfilmentDate < DateTime.Now) // fulfil the order
                {
                    foreach (var orderItem in order.OrderItems)
                    {
                        Product? selectedProduct = inventory.FirstOrDefault(p => p.Id == orderItem.ProductId);
                        if (selectedProduct != null)
                            selectedProduct.IncreaseStock(orderItem.AmountOrdered);
                    }
                    order.Fulfilled = true;
                }
            }

            orders.RemoveAll(o => o.Fulfilled);

            Console.WriteLine("Fulfilled orders checked");
        }

        private static void ShowAddNewOrder()
        {
            Order newOrder = new Order();
            string? selectedProductId = string.Empty;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Creating new order");
            Console.ResetColor();

            do
            {
                ShowAllProductsOverview();

                Console.WriteLine("Which product do you want to order? (enter 0 to stop adding new products to the order)");

                Console.Write("Enter the ID of product: ");
                selectedProductId = Console.ReadLine();

                if (selectedProductId != "0")
                {
                    Product? selectedProduct = inventory.FirstOrDefault(p => p.Id == selectedProductId);

                    if (selectedProduct != null)
                    {
                        Console.Write("How many do you want to order?: ");
                        int amountOrdered = int.Parse(Console.ReadLine() ?? "0");

                        OrderItem orderItem = new(selectedProduct.Id, selectedProduct.Name, amountOrdered);
                        // {
                        //     ProductId = selectedProduct.Id,
                        //     ProductName = selectedProduct.Name,
                        //     AmountOrdered = amountOrdered
                        // };

                        //OrderItem orderItem = new OrderItem();
                        //orderItem.ProductId = selectedProduct.Id;
                        //orderItem.ProductName = selectedProduct.Name;
                        //orderItem.AmountOrdered = amountOrdered;

                        newOrder.OrderItems.Add(orderItem);
                    }
                }

            } while (selectedProductId != "0");

            Console.WriteLine("Creating order...");

            orders.Add(newOrder);

            Console.WriteLine("Order now created.");
            Console.ReadLine();
        }

        private static void ShowSettingsMenu()
        {
            string? userSelection;

            do
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("************");
                Console.WriteLine("* Settings *");
                Console.WriteLine("************");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("What do you want to do?");
                Console.ResetColor();

                Console.WriteLine("1: Change stock treshold");
                Console.WriteLine("0: Back to main menu");

                Console.Write("Your selection: ");

                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        ShowChangeStockTreshold();
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
            while (userSelection != "0");
            ShowMainMenu();
        }

        private static void ShowChangeStockTreshold()
        {
            Console.WriteLine($"Enter the new stock treshold (current value: {Product.StockTreshold}). This applies to all products!");
            Console.Write("New value: ");
            int newValue = int.Parse(Console.ReadLine() ?? "0");
            Product.StockTreshold = newValue;
            Console.WriteLine($"New stock treshold set to {Product.StockTreshold}");

            foreach (var product in inventory)
            {
                product.UpdateLowStock();
            }

            Console.ReadLine();
        }
        
        
        internal static void RegisterEmployee(List<Employee> employees)
        {
            Console.WriteLine("Creating an employee");

            Console.WriteLine("What type of employee do you want to register?");
            Console.WriteLine("1. Employee\n2. Manager\n3. Store manager\n4. Researcher\n5. Junior researcher");
            Console.Write("Your selection: ");
            string employeeType = Console.ReadLine();

            if (employeeType != "1" && employeeType != "2" && employeeType != "3"
                && employeeType != "4" && employeeType != "5")
            {
                Console.WriteLine("Invalid selection!");
                return;
            }

            Console.Write("Enter the first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter the last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter the email: ");
            string email = Console.ReadLine();

            Console.Write("Enter the birth day: ");
            DateTime birthDay = DateTime.Parse(Console.ReadLine());//ex. 2/16/2008

            Console.Write("Enter the hourly rate: ");
            string hourlyRate = Console.ReadLine();
            double rate = double.Parse(hourlyRate);//we will assume here that input is in the correct format

            Employee employee = null;

            switch (employeeType)
            {
                case "1":
                    employee = new Employee(firstName, lastName, email, birthDay, rate);
                    break;
                case "2":
                    employee = new Manager(firstName, lastName, email, birthDay, rate);
                    break;
                case "3":
                    employee = new StoreManager(firstName, lastName, email, birthDay, rate);
                    break;
                case "4":
                    employee = new Researcher(firstName, lastName, email, birthDay, rate);
                    break;
                case "5":
                    employee = new JuniorResearcher(firstName, lastName, email, birthDay, rate);
                    break;
            }

            employees.Add(employee);

            Console.WriteLine("Employee created!\n\n");
        }

        internal static void LoadEmployeeById(List<Employee> employees)
        {
            try
            {
                Console.Write("Enter the Employee ID you want to visualize: ");

                int selectedId = int.Parse(Console.ReadLine());
                Employee selectedEmployee = employees[selectedId];
                selectedEmployee.DisplayEmployeeDetails();
            }
            catch (FormatException fex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That's not the correct format to enter an ID!\n\n");
                Console.ResetColor();
            }
        }

        internal static void CheckForExistingEmployeeFile()
        {
            string path = $"{directory}{fileName}";

            if (File.Exists(path))
            {
                Console.WriteLine("An existing file with Employee data is found.");
            }
            else
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Directory is ready for saving files.");
                    Console.ResetColor();
                }
            }
        }

        static void ViewAllEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                employees[i].DisplayEmployeeDetails();
            }
        }

        static void LoadEmployees(List<Employee> employees)
        {
            string path = $"{directory}{fileName}";
            try
            {
                if (File.Exists(path))
                {
                    employees.Clear();

                    //now read the file
                    string[] employeesAsString = File.ReadAllLines(path);
                    for (int i = 0; i < employeesAsString.Length; i++)
                    {
                        string[] employeeSplits = employeesAsString[i].Split(';');
                        string firstName = employeeSplits[0].Substring(employeeSplits[0].IndexOf(':') + 1);//firstName:Bethany
                        string lastName = employeeSplits[1].Substring(employeeSplits[1].IndexOf(':') + 1);
                        string email = employeeSplits[2].Substring(employeeSplits[2].IndexOf(':') + 1);
                        DateTime birthDay = DateTime.Parse(employeeSplits[3].Substring(employeeSplits[3].IndexOf(':') + 1));
                        double hourlyRate = double.Parse(employeeSplits[4].Substring(employeeSplits[4].IndexOf(':') + 1));
                        string employeeType = employeeSplits[5].Substring(employeeSplits[5].IndexOf(':') + 1);

                        Employee employee = null;

                        switch (employeeType)
                        {
                            case "1":
                                employee = new Employee(firstName, lastName, email, birthDay, hourlyRate);
                                break;
                            case "2":
                                employee = new Manager(firstName, lastName, email, birthDay, hourlyRate);
                                break;
                            case "3":
                                employee = new StoreManager(firstName, lastName, email, birthDay, hourlyRate);
                                break;
                            case "4":
                                employee = new Researcher(firstName, lastName, email, birthDay, hourlyRate);
                                break;
                            case "5":
                                employee = new JuniorResearcher(firstName, lastName, email, birthDay, hourlyRate);
                                break;
                        }


                        employees.Add(employee);

                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Loaded {employees.Count} employees!\n\n");
                    //Console.ResetColor();
                }
            }
            catch (IndexOutOfRangeException iex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong parsing the file, please check the data!");
                Console.WriteLine(iex.Message);
                //Console.ResetColor();
            }
            catch (FileNotFoundException fnfex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The file couldn't be found!");
                Console.WriteLine(fnfex.Message);
                Console.WriteLine(fnfex.StackTrace);
                //Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong while loading the file!");
                Console.WriteLine(ex.Message);
                //Console.ResetColor();
            }
            finally
            {
                Console.ResetColor();

            }
        }

        internal static void SaveEmployees(List<Employee> employees)
        {
            string path = $"{directory}{fileName}";
            StringBuilder sb = new StringBuilder();
            foreach (Employee employee in employees)
            {
                string type = GetEmployeeType(employee);
                sb.Append($"firstName:{employee.FirstName};");
                sb.Append($"lastName:{employee.LastName};");
                sb.Append($"email:{employee.Email};");
                sb.Append($"birthDay:{employee.BirthDate.ToShortDateString()};");
                sb.Append($"hourlyRate:{employee.HourlyRate};");
                sb.Append($"type:{type};");
                sb.Append(Environment.NewLine);
            }
            File.WriteAllText(path, sb.ToString());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saved employees successfully");
            Console.ResetColor();
        }

        private static string GetEmployeeType(Employee employee)
        {
            if (employee is Manager)
                return "2";
            else if (employee is StoreManager)
                return "3";
            else if (employee is JuniorResearcher)
                return "5";
            else if (employee is Researcher)
                return "4";
            else if (employee is Employee)
                return "1";
            return "0";
        }
    }

