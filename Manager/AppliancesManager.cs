using ModernAppliances.Classes;
using ModernAppliances.Classes.BaseClass;
using ModernAppliances.Helpers;

namespace ModernAppliances.Manager
{
    /// <summary>
    /// Manages the appliances data, including loading, saving, and searching appliances.
    /// </summary>
    public class AppliancesManager
    {
        /// <summary>
        /// The filename where appliances data is stored.
        /// </summary>
        private const string FILENAME = "appliances.txt";
        /// <summary>
        /// List of appliances loaded from the file.
        /// </summary>
        private List<Appliance> appliances;
        /// <summary>
        /// Gets the list of appliances.
        /// </summary>
        public List<Appliance> Appliances => appliances;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppliancesManager"/> class.
        /// </summary>
        public AppliancesManager()
        {
            appliances = this.LoadAppliances();
        }

        /// <summary>
        /// Loads appliances from the specified file.
        /// </summary>
        /// <returns>A list of appliances loaded from the file.</returns>
        private List<Appliance> LoadAppliances()
        {
            List<Appliance> appliances = new List<Appliance>();

            try
            {
                string[] lines = FileHelper.ReadFromFile(FILENAME);

                foreach (string line in lines)
                {

                    string[] parts = line.Split(';');

                    switch (GetApplianceType(parts[0]))
                    {
                        case Appliance.ApplianceType.Dishwasher:
                        case Appliance.ApplianceType.DishwasherAlt:
                            Dishwasher? dishwasher = CreateDishwasher(parts);
                            if (dishwasher != null)
                            {
                                appliances.Add(dishwasher);
                            }
                            break;
                        case Appliance.ApplianceType.Microwave:
                            Microwave? microwave = CreateMicrowave(parts);
                            if (microwave != null)
                            {
                                appliances.Add(microwave);
                            }
                            break;
                        case Appliance.ApplianceType.Refrigerator:
                            Refrigerator? refrigerator = CreateRefrigirator(parts);
                            if (refrigerator != null)
                            {
                                appliances.Add(refrigerator);
                            }
                            break;
                        case Appliance.ApplianceType.Vacum:
                            Vacum? vacum = CreateVacum(parts);
                            if (vacum != null)
                            {
                                appliances.Add(vacum);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading appliances: {ex.Message}");
            }

            return appliances;
        }

        /// <summary>
        /// Determines the type of appliance based on the item number.
        /// </summary>
        /// <param name="itemNumber">The item number of the appliance.</param>
        public static Appliance.ApplianceType GetApplianceType(string itemNumber) =>
            !string.IsNullOrEmpty(itemNumber) &&
            short.TryParse(itemNumber[0].ToString(), out var itemType) ?
            itemType switch
            {
                (short)Appliance.ApplianceType.Microwave => Appliance.ApplianceType.Microwave,
                (short)Appliance.ApplianceType.Refrigerator => Appliance.ApplianceType.Refrigerator,
                (short)Appliance.ApplianceType.Vacum => Appliance.ApplianceType.Vacum,
                (short)Appliance.ApplianceType.Dishwasher => Appliance.ApplianceType.Dishwasher,
                (short)Appliance.ApplianceType.DishwasherAlt => Appliance.ApplianceType.DishwasherAlt,
                _ => Appliance.ApplianceType.Unknown
            } : Appliance.ApplianceType.Unknown;

        /// <summary>
        /// Create Dishwasher from parts array.
        /// </summary>
        /// <param name="parts">Array of string parts representing the dishwasher properties.</param>
        /// <returns>A new instance of <see cref="Dishwasher"/> if the parts are valid, otherwise null.</returns>
        internal Dishwasher? CreateDishwasher(string[] parts) =>
           parts.Length == 8 ?
           new Dishwasher(
               long.Parse(parts[0]),
               parts[1],
               int.Parse(parts[2]),
               decimal.Parse(parts[3]),
               parts[4],
               decimal.Parse(parts[5]),
               parts[6],
               parts[7]
           )
           : null;

        /// <summary>
        /// Create Microwave from parts array.
        /// </summary>
        /// <param name="parts">Array of string parts representing the microwave properties.</param>
        /// <returns>A new instance of <see cref="Microwave"/> if the parts are valid, otherwise null.</returns>
        internal Microwave? CreateMicrowave(string[] parts) =>
            parts.Length == 8 ?
            new Microwave(
                long.Parse(parts[0]),
                parts[1],
                int.Parse(parts[2]),
                decimal.Parse(parts[3]),
                parts[4],
                decimal.Parse(parts[5]),
                float.Parse(parts[6]),
                char.Parse(parts[7])
                )
            : null;

        /// <summary>
        /// Create Refrigerator from parts array.
        /// </summary>
        /// <param name="parts">Array of string parts representing the refrigerator properties.</param>
        /// <returns>A new instance of <see cref="Refrigerator"/> if the parts are valid, otherwise null.</returns>
        internal Refrigerator? CreateRefrigirator(string[] parts) =>
            parts.Length == 9 ?
            new Refrigerator(
                long.Parse(parts[0]),
                parts[1],
                int.Parse(parts[2]),
                decimal.Parse(parts[3]),
                parts[4],
                decimal.Parse(parts[5]),
                short.Parse(parts[6]),
                int.Parse(parts[7]),
                int.Parse(parts[8])
                )
            : null;
        // <summary>
        /// Create Vacum from parts array.
        /// </summary>
        /// <param name="parts">Array of string parts representing the vacum properties.</param>
        /// <returns>A new instance of <see cref="Vacum"/> if the parts are valid, otherwise null.</returns>
        internal Vacum? CreateVacum(string[] parts) =>
            parts.Length == 8 ?
            new Vacum(
                long.Parse(parts[0]),
                parts[1],
                int.Parse(parts[2]),
                decimal.Parse(parts[3]),
                parts[4],
                decimal.Parse(parts[5]),
                parts[6],
                short.Parse(parts[7])
                )
            : null;

        /// <summary>
        /// Searches for dishwashers by sound rating.
        /// </summary>
        /// <param name="soundRating">The sound rating to search for.</param>
        /// <returns>A list of dishwashers that match the specified sound rating.</returns>
        internal List<Dishwasher> GetDishwasherBySoundRating(string soundRating)
        {
            List<Dishwasher> dishwashers = new List<Dishwasher>();
            foreach (var appliance in Appliances)
            {
                if (appliance is Dishwasher dishwasher && dishwasher.SoundRating == soundRating)
                {
                    dishwashers.Add(dishwasher);
                }
            }
            return dishwashers;
        }

        /// <summary>
        /// Searches for appliances by brand.
        /// </summary>
        /// <param name="brand">The brand to search for.</param>
        /// <returns>A list of appliances that match the specified brand.</returns>
        public List<Appliance> SearchAppliancesByBrand(string brand)
        {
            List<Appliance> foundAppliances = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
            {
                if (appliance.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase))
                {
                    foundAppliances.Add(appliance);
                }
            }
            return foundAppliances;
        }

        /// <summary>
        /// Searches for an appliance by its item number.
        /// </summary>
        /// <param name="itemNumber">The item number of the appliance to search for.</param>
        /// <returns>The appliance with the specified item number, or null if not found.</returns>
        public Appliance? SearchApplianceByItemNumber(long itemNumber)
        {
            List<Appliance> appliances = Appliances;

            foreach (Appliance appliance in appliances)
            {
                if (appliance.ItemNumber == itemNumber)
                {
                    return appliance;
                }
            }
            return null;
        }

        /// <summary>
        /// Searches for appliances by their item number.
        /// </summary>
        /// <param name="itemNumbers">A list of item numbers to search for.</param>
        /// <returns>A list of appliances that match the specified item numbers.</returns>
        internal List<Vacum> GetVacumByVoltage(int voltage)
        {
            List<Vacum> vacums = new List<Vacum>();
            foreach (var appliance in Appliances)
            {
                if (appliance is Vacum vacum && vacum.BatteryVoltage == voltage)
                {
                    vacums.Add(vacum);
                }
            }
            return vacums;
        }

        /// <summary>
        /// Searches for microwaves by their room type.
        /// </summary>
        /// <param name="room">The room type to search for.</param>
        /// <returns>A list of microwaves that match the specified room type.</returns>
        internal List<Microwave> GetMicrowaveByRoomType(char room)
        {
            List<Microwave> microwaves = new List<Microwave>();
            foreach (var appliance in Appliances)
            {
                if (appliance is Microwave microwave && microwave.RoomType == room)
                {
                    microwaves.Add(microwave);
                }
            }
            return microwaves;
        }

        /// <summary>
        /// Searches for refrigerators by the number of doors.
        /// </summary>
        /// <param name="doors">The number of doors to search for.</param>
        /// <returns>A list of refrigerators that match the specified number of doors.</returns>
        internal List<Refrigerator> GetRefrigeratorByDoors(int doors)
        {
            List<Refrigerator> refrigerators = new List<Refrigerator>();
            foreach (var appliance in Appliances)
            {
                if (appliance is Refrigerator refrigerator && refrigerator.Doors == doors)
                {
                    refrigerators.Add(refrigerator);
                }
            }
            return refrigerators;
        }

        /// <summary>
        /// Gets a random selection of appliances.
        /// </summary>
        /// <param name="count">The number of random appliances to retrieve.</param>
        /// <returns>A list of randomly selected appliances.</returns>
        internal List<Appliance> GetRandomAppliances(int count)
        {
            List<Appliance> randomAppliances = new List<Appliance>();
            Random random = new Random();
            List<Appliance> availableAppliances = new List<Appliance>(Appliances);
            for (int i = 0; i < count && availableAppliances.Count > 0; i++)
            {
                int index = random.Next(availableAppliances.Count);
                randomAppliances.Add(availableAppliances[index]);
                availableAppliances.RemoveAt(index);
            }
            return randomAppliances;
        }

        /// <summary>
        /// Saves the current list of appliances to the specified file.
        /// </summary>
        public void SaveAppliances()
        {
            try
            {
                FileHelper.SaveToFile(FILENAME, Appliances);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving appliances: {ex.Message}");
            }
        }
    }
}