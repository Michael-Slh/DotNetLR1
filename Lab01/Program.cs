using Data;

namespace Lab01
{
    internal class Program
    {
        static void Main()
        {
            var data = DataSeeding.GetData();
            var queries = new Queries(data);
            Options(queries);
        }

        static void PrintMenu()
        {
            Console.WriteLine("Choose from 1 to 15 or 0 to quit.");
            Console.WriteLine("1. Get first stop and quantity of buses driving from this point.");
            Console.WriteLine("2. Get number of buses that run on routes with more than three buses.");
            Console.WriteLine("3. Get companies with the biggest amount of routes.");
            Console.WriteLine("4. Get first and last three buses.");
            Console.WriteLine("5. Get routes with it\'s companies.");
            Console.WriteLine("6. Get common routes between first and second buses.");
            Console.WriteLine("7. Get list of the same amount of routes for buses.");
            Console.WriteLine("8. Get car city codes with their amount.");
            Console.WriteLine("9. Get all start and end points.");
            Console.WriteLine("10. Get routes with the same amount of buses.");
            Console.WriteLine("11. Get avarage amount of buses among routes.");
            Console.WriteLine("12. Get all buses except buses on first and last route.");
            Console.WriteLine("13. Get amount of symbols in routes.");
            Console.WriteLine("14. Get all routes of companies.");
            Console.WriteLine("15. Get all ordered bus numbers.");
            Console.WriteLine("0. Quit.");
        }

        static void Options(Queries queries)
        {
            var finished = false;
            while (!finished)
            {
                PrintMenu();
                string? opt = Console.ReadLine();
                if (opt is null || !int.TryParse(opt, out int result) || result < 0 || result > 15)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong option. Try again.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
                switch (result)
                {
                    case 0:
                        Console.WriteLine("Program finished.");
                        finished = true;
                        break;
                    case 1:
                        {
                            var res = queries.GetByFirstStopAndCount();
                            foreach (var item in res)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    case 2:
                        {
                            var res = queries.GetThreeOrMoreBusses(3);
                            foreach (var item in res)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    case 3:
                        {
                            var res = queries.GetTopRoutesCompanies();
                            foreach (var item in res)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    case 4:
                        {
                            var res = queries.GetFirstAndLastBusses();
                            foreach (var item in res)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    case 5:
                        {
                            var res = queries.GetRouteCompany();
                            foreach (var item in res)
                            {
                                Console.WriteLine(item.Name1 + " " + item.Name2);
                            }
                            break;
                        }
                    case 6:
                        {
                            var res = queries.GetCommonRoutes();
                            foreach (var item in res)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    case 7:
                        {
                            var res = queries.GetSameRoutes();
                            foreach (var item in res)
                            {
                                Console.WriteLine("Amount: " + item.Name1 + ", buses: " + item.Name2);
                            }
                            break;
                        }
                    case 8:
                        {
                            var res = queries.GetNameplates();
                            foreach (var item in res)
                            {
                                Console.WriteLine(item.Name1 + " - " + item.Name2);
                            }
                            break;
                        }
                    case 9:
                        {
                            var res = queries.GetRouteStartAndFinish();
                            foreach (var item in res)
                            {
                                Console.WriteLine(item.Name);
                            }
                            break;
                        }
                    case 10:
                        {
                            var res = queries.GetRoutesByBusAmount();
                            foreach (var item in res)
                            {
                                Console.WriteLine("Courses: " + item.Name2 + " with " + item.Name1);
                            }
                            break;
                        }
                    case 11:
                        {
                            var res = queries.GetAvgBussAmount();
                            Console.WriteLine("Avarage amount: " + res);
                            break;
                        }
                    case 12:
                        {
                            var res = queries.GetAllBussesButLastAndFirstRoute();
                            foreach (var item in res)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    case 13:
                        {
                            var res = queries.GetRoutesBySymbols();
                            foreach (var item in res)
                            {
                                Console.WriteLine("Number of symbols: " + item.Name1 + ", routes: " + item.Name2);
                            }
                            break;
                        }
                    case 14:
                        {
                            var res = queries.GetRoutesByCompany();
                            foreach (var item in res)
                            {
                                Console.WriteLine("Company \"" + item.Name1 + "\" has routes: " + item.Name2);
                            }
                            break;
                        }
                    case 15:
                        {
                            var res = queries.GetAllBusNumbers();
                            foreach (var item in res)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                }

                Console.Write("Press any button to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}