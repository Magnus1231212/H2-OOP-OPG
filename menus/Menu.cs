namespace H2_OOP_OPG
{
    /// <summary>
    /// Provides functionality for building and managing console menus with pagination.
    /// </summary>
    internal class Menu
    {
        /// <summary>
        /// The title of the project displayed in the console window title bar.
        /// </summary>
        private static string ProjectTitle = "";

        /// <summary>
        /// The maximum number of options displayed per page in the main menu.
        /// </summary>
        private static int MaxOptions;

        /// <summary>
        /// The maximum number of options displayed per page in the sub menu.
        /// </summary>
        private static int MaxSubOptions;

        /// <summary>
        /// Tracks the current page of the menu.
        /// </summary>
        private static int Page = 1;

        /// <summary>
        /// Indicates whether the menu should loop back to the first page when the last page is exceeded.
        /// </summary>
        private static bool LoopToFirstPage = false;

        /// <summary>
        /// Initializes the menu builder with configuration settings.
        /// </summary>
        /// <param name="title">The project title to display in the console title bar.</param>
        /// <param name="_LoopToFirstPage">Determines whether pagination loops back to the first page.</param>
        /// <param name="_MaxOptions">The maximum number of options displayed per page in the main menu (default: 7).</param>
        /// <param name="_MaxSubOptions">The maximum number of options displayed per page in the sub menu (default: 7).</param>
        public static void Initialize(string title, bool _LoopToFirstPage, int _MaxOptions = 7, int _MaxSubOptions = 7)
        {
            ProjectTitle = title;
            MaxOptions = _MaxOptions;
            MaxSubOptions = _MaxSubOptions;
            LoopToFirstPage = _LoopToFirstPage;
        }

        /// <summary>
        /// Builds and displays the main menu with pagination and user choice handling.
        /// </summary>
        /// <param name="Options">An array of menu options to display.</param>
        /// <param name="Cases">An array of actions corresponding to each menu option.</param>
        /// <param name="Title">The title of the menu to display in the console title bar.</param>
        public static void buildMain(string[] Options, Action[] Cases, string Title)
        {
            int choice = -1;
            do
            {
                Console.Title = $"{ProjectTitle} - {Title}";

                Console.Clear();
                Console.WriteLine("Please select an option: \n");

                int index = 0;
                foreach (string Option in GetPage(Options, Page, 0))
                {
                    index++;
                    Console.WriteLine($"\t{index}. {Option}");
                }

                if (Options.Length > MaxOptions)
                {
                    Console.WriteLine($"\n\t{MaxOptions + 1}. Next Page");
                }

                if (Page > 1)
                {
                    Console.WriteLine($"\t{MaxOptions + 2}. Previous Page");
                }

                Console.WriteLine("\n\t0. Exit");
                Console.Write("\nChoice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    choice = -1;
                }

                if (choice >= 1 && choice <= MaxOptions && choice <= Options.Length)
                {
                    try
                    {
                        ResetPage();
                        Cases[choice - 1]();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    break;
                }
                else if (choice == (MaxOptions + 1))
                {
                    if (Options.Length > MaxOptions * Page)
                    {
                        Page++;
                    }
                    else if (LoopToFirstPage)
                    {
                        ResetPage();
                    }
                }
                else if (choice == (MaxOptions + 2))
                {
                    if (Page > 1)
                    {
                        Page--;
                    }
                }
                else if (choice == 0)
                {
                    Program.Exit = true;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid number!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }

            } while (choice != 0);
        }

        /// <summary>
        /// Builds and displays a submenu with pagination and user choice handling.
        /// </summary>
        /// <param name="Title">The title of the submenu to display in the console title bar.</param>
        /// <param name="Options">An array of submenu options to display.</param>
        /// <param name="Cases">An array of actions corresponding to each submenu option.</param>
        public static void buildSub(string Title, string[] Options, Action[] Cases)
        {
            int choice = -1;
            do
            {
                Console.Title = $"{ProjectTitle} - {Title}";

                Console.Clear();
                Console.WriteLine("Please select an option: \n");

                int index = 0;
                foreach (string Option in GetPage(Options, Page, 1))
                {
                    index++;
                    Console.WriteLine($"\t{index}. {Option}");
                }

                if (Options.Length > MaxSubOptions)
                {
                    Console.WriteLine($"\n\t{MaxSubOptions + 1}. Next Page");
                }

                if (Page > 1)
                {
                    Console.WriteLine($"\t{MaxSubOptions + 2}. Previous Page");
                }

                Console.WriteLine("\n\t0. Go Back");
                Console.Write("\nChoice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    choice = -1;
                }

                if (choice >= 1 && choice <= MaxSubOptions && choice <= Options.Length)
                {
                    Console.Clear();
                    try
                    {
                        ResetPage();
                        Cases[choice - 1]();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                else if (choice == (MaxSubOptions + 1))
                {
                    if (Options.Length > MaxSubOptions * Page)
                    {
                        Page++;
                    }
                    else if (LoopToFirstPage)
                    {
                        ResetPage();
                    }
                }
                else if (choice == (MaxSubOptions + 2))
                {
                    if (Page > 1)
                    {
                        Page--;
                    }
                }
                else if (choice == 0)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid number!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }

            } while (choice != 0);
        }

        /// <summary>
        /// Retrieves the items to display on the current page for a menu.
        /// </summary>
        /// <typeparam name="T">The type of items in the list.</typeparam>
        /// <param name="list">The full list of items to paginate.</param>
        /// <param name="page">The current page number.</param>
        /// <param name="type">Indicates if it's a main menu (0) or submenu (1).</param>
        /// <returns>An array of items to display on the current page.</returns>
        public static Array GetPage<T>(T[] list, int page, int type)
        {
            if (type == 0)
                return list.Skip((page - 1) * MaxOptions).Take(MaxOptions).ToArray();
            else
                return list.Skip((page - 1) * MaxSubOptions).Take(MaxSubOptions).ToArray();
        }

        /// <summary>
        /// Resets the page number to the first page.
        /// </summary>
        public static void ResetPage()
        {
            Page = 1;
        }
    }
}
