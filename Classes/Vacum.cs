using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernAppliances.Classes.BaseClass;

namespace ModernAppliances.Classes
{
    /// <summary>
    /// Represents a vacuum appliance.
    /// </summary>
    internal class Vacum : Appliance
    {
        private readonly string _grade;
        private readonly short _batteryVoltage;

        /// <summary>
        /// Getters of the properties of the vacuum.
        /// </summary>
        public string Grade => _grade;
        public short BatteryVoltage => _batteryVoltage;
        /// <summary>
        /// Gets the display string for battery voltage.
        /// </summary>
        public string DisplayBatteryVoltage => 
            _batteryVoltage <= 18 ? "Low" : "High";

        /// <summary>
        /// Initializes a new instance of the <see cref="Vacum"/> class.
        /// </summary>
        public Vacum(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, string grade, short batteryVoltage)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _grade = grade;
            _batteryVoltage = batteryVoltage;
        }

        /// <summary>
        /// Formats the vacuum data for file storage.
        /// </summary>
        public override string FormatForFile()
        {
            return $"{base.FormatForFile()};{Grade};{BatteryVoltage}";
        }

        /// <summary>
        /// Returns a string representation of the vacuum.
        /// </summary>
        public override string ToString()
        {
            string display =
                string.Format("Item Number: {0}", ItemNumber) + "\n" +
                string.Format("Brand: {0}", Brand) + "\n" +
                string.Format("Quantity: {0}", Quantity) + "\n" +
                string.Format("Wattage: {0}", Wattage) + "\n" +
                string.Format("Color: {0}", Color) + "\n" +
                string.Format("Price: {0}", Price) + "\n" +
                string.Format("Grade: {0}", Grade) + "\n" +
                string.Format("Battery Voltage: {0}", DisplayBatteryVoltage);
            return display;
        }

    }
}
