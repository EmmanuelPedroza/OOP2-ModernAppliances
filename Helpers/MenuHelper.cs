using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernAppliances.Classes;
using ModernAppliances.Classes.BaseClass;
using ModernAppliances.Manager;

namespace ModernAppliances.Helpers
{
    /// <summary>
    /// Provides helper methods for displaying and handling the main menu and user interactions.
    /// </summary>
    public class MenuHelper
    {
        private AppliancesManager _dataManager;
        public AppliancesManager DataManager => _dataManager;
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuHelper"/> class.
        /// </summary>
        /// <param name="dataManager">The appliances manager instance to use for data operations.</param>
        public MenuHelper(AppliancesManager dataManager) { _dataManager = dataManager; }

        public enum Options
        {
            None,
            Checkout = 1,
            Find = 2,
            DisplayType = 3,
            RandomList = 4,
            SaveExit = 5
        }

        /// <summary>
        /// Displays the main menu options to the user.
        /// </summary>
        public static void DisplayMenu()
        {
            Console.WriteLine("Welcome to the Modern Appliances!");
            Console.WriteLine("How May We Assist You?");
            Console.WriteLine("1 - Check out appliance");
            Console.WriteLine("2 - Find appliances by brand");
            Console.WriteLine("3 - Displlay appliances by type");
            Console.WriteLine("4 - Produce random appliance list");
            Console.WriteLine("5 - Save & Exit");
            Console.WriteLine();
            Console.WriteLine("Enter Option:");

        }

        /// <summary>
        /// Handles the checkout process for an appliance by item number.
        /// </summary>
        public void CheckoutAppliance()
        {
            Console.WriteLine();
            Console.WriteLine("Enter item number of Appliance:");
            string? input = Console.ReadLine();

            if (long.TryParse(input, out long itemNumber))
            {
                Appliance? appliance = DataManager.SearchApplianceByItemNumber(itemNumber);

                if (appliance == null)
                {
                    Console.WriteLine("No appliances found with that item number.");
                    Console.WriteLine();
                    return;
                }

                if (appliance.IsAvailable())
                {
                    int preQty = appliance.Quantity;
                    int postQty = appliance.CheckOutAppliance();
                    if (preQty > postQty)
                    {
                        Console.WriteLine($"Appliance {appliance.ItemNumber} has been checked out.");
                    }
                    else
                    {
                        Console.WriteLine($"There was a error during checkout.");
                    }
                }
                else
                {
                    Console.WriteLine($"The appliance is not available to be checked out.");
                }

            }
            else
            {
                Console.WriteLine("Invalid item number entered. Please try again.");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Finds appliances by brand and displays them to the user.
        /// </summary>
        public void FindAppliancesByBrand()
        {
            Console.WriteLine();
            Console.WriteLine("Enter brand to search for:");
            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                List<Appliance> foundAppliances = DataManager.SearchAppliancesByBrand(input);
                if (foundAppliances.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Matching appliances: ");
                    foreach (var appliance in foundAppliances)
                    {
                        Console.WriteLine(appliance.ToString());
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine($"No appliances found for brand '{input}'.");
                }
            }
            else
            {
                Console.WriteLine("Invalid brand name entered. Please try again.");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Displays appliances by selected type and applies additional filters based on user input.
        /// </summary>
        public void DisplayByType()
        {
            DisplayAppliancesType();
            string? input = Console.ReadLine();

            Appliance.ApplianceType userOption;

            if (Enum.TryParse<Appliance.ApplianceType>(input, out userOption))
            {
                switch (userOption)
                {
                    case Appliance.ApplianceType.Refrigerator:
                        Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
                        string? stringDoors = Console.ReadLine();
                        Console.WriteLine();
                        if (int.TryParse(stringDoors, out int doors))
                        {
                            List<Refrigerator> refrigerators = DataManager.GetRefrigeratorByDoors(doors);
                            foreach (Refrigerator refrigerator in refrigerators)
                            {
                                Console.WriteLine(refrigerator.ToString());
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid number of doors entered. Please try again.");
                        }
                        break;
                    case Appliance.ApplianceType.Vacum:
                        Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high)");
                        string? stringVoltage = Console.ReadLine();
                        Console.WriteLine();
                        if (int.TryParse(stringVoltage, out int voltage))
                        {
                            List<Vacum> vacums = DataManager.GetVacumByVoltage(voltage);
                            foreach (Vacum vacum in vacums)
                            {
                                Console.WriteLine(vacum.ToString());
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid voltage entered. Please try again.");
                        }
                        break;
                    case Appliance.ApplianceType.Microwave:
                        Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site)");
                        string? stringRoomType = Console.ReadLine();
                        Console.WriteLine();
                        if (char.TryParse(stringRoomType, out char roomType))
                        {
                            List<Microwave> microwaves = DataManager.GetMicrowaveByRoomType(roomType);
                            foreach (Microwave microwave in microwaves)
                            {
                                Console.WriteLine(microwave.ToString());
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid room type entered. Please try again.");
                        }
                        break;
                    case Appliance.ApplianceType.Dishwasher:
                        Console.WriteLine($"Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu (Quiet) or M (Moderate):");
                        string? soundRating = Console.ReadLine();
                        Console.WriteLine();
                        if (!string.IsNullOrEmpty(soundRating))
                        {
                            List<Dishwasher> dishwashers = DataManager.GetDishwasherBySoundRating(soundRating);
                            foreach (Dishwasher dishwaser in dishwashers)
                            {
                                Console.WriteLine(dishwaser.ToString());
                                Console.WriteLine();
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid sound rating entered. Please try again.");
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Displays the available appliance types to the user.
        /// </summary>
        private void DisplayAppliancesType()
        {
            Console.WriteLine();
            Console.WriteLine("Appliance Types");
            Console.WriteLine("1 - Refrigerators");
            Console.WriteLine("2 - Vacums");
            Console.WriteLine("3 - Microwaves");
            Console.WriteLine("4 - Dishwashers");
            Console.WriteLine();
            Console.WriteLine("Enter type of appliance:");
        }

        /// <summary>
        /// Displays a random list of appliances based on user-specified count.
        /// </summary>
        public void DisplayRandomAppliances()
        {
            Console.WriteLine();
            Console.WriteLine("Enter number of appliances:");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int count) && count <= DataManager.Appliances.Count)
            {
                List<Appliance> randomAppliances = DataManager.GetRandomAppliances(count);
                if (randomAppliances.Count > 0)
                {
                    foreach (var appliance in randomAppliances)
                    {
                        Console.WriteLine(appliance.ToString());
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No appliances available to display.");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Input must be less than total appliances {DataManager.Appliances.Count}.");
            }

        }

        /// <summary>
        /// Saves appliances to file and displays a confirmation message.
        /// </summary>
        public void SaveAndExit() 
        {
            Console.WriteLine("Saving . . .");
            DataManager.SaveAppliances();
            Console.WriteLine("Appliances saved successfully.");
        }
    }
}