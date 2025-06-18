using ModernAppliances.Classes;
using ModernAppliances.Helpers;
using ModernAppliances.Manager;

namespace ModernAppliances
{
    /// <summary>
    /// Entry point for the Modern Appliances application.
    /// </summary>
    /// <remarks>Do not modify this file</remarks>
    /// <remarks>Author: Emmanuel Pedroza (Emmanuel.Pedroza@edu.sait.ca)</remarks>
    /// <remarks>Date: June 18, 2025</remarks>
    class Program
    {

        static void Main()
        {
            AppliancesManager dataManager = new AppliancesManager();
            MenuHelper menu = new MenuHelper(dataManager);
            MenuHelper.Options userOption = MenuHelper.Options.None;

            while (userOption != MenuHelper.Options.SaveExit)
            {
                MenuHelper.DisplayMenu();

                string? input = Console.ReadLine();

                if (Enum.TryParse<MenuHelper.Options>(input, out userOption))
                {
                    switch (userOption)
                    {
                        case MenuHelper.Options.Checkout:
                            {
                                menu.CheckoutAppliance();
                                break;

                            }
                        case MenuHelper.Options.Find:
                            {
                                menu.FindAppliancesByBrand();
                                break;
                            }
                        case MenuHelper.Options.DisplayType:
                            {
                                menu.DisplayByType();
                                break;
                            }
                        case MenuHelper.Options.RandomList:
                            {
                                menu.DisplayRandomAppliances();
                                break;
                            }
                        case MenuHelper.Options.SaveExit:
                            {
                                menu.SaveAndExit();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid option entered. Please try again.");
                                break;
                            }

                    }

                }
                else
                {
                    Console.WriteLine("Invalid option entered. Please try again.");
                }
            }


        }
    }
}