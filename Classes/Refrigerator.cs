using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernAppliances.Classes.BaseClass;

namespace ModernAppliances.Classes
{
    /// <summary>
    /// Represents a refrigerator appliance.
    /// </summary>
    internal class Refrigerator : Appliance
    {
        private readonly short _doors;
        private readonly int _width;
        private readonly int _height;

        /// <summary>
        /// Getters of the properties of the refrigerator.
        /// </summary>
        public short Doors => _doors;
        public int Width => _width;
        public int Height => _height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Refrigerator"/> class.
        /// </summary>
        public Refrigerator(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, short doors, int width, int height)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _doors = doors;
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Formats the refrigerator data for file storage.
        /// </summary>
        public override string FormatForFile()
        {
            return $"{base.FormatForFile()};{Doors};{Width};{Height}";
        }

        /// <summary>
        /// Returns a string representation of the refrigerator.
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
                string.Format("Doors: {0}", Doors) + "\n" +
                string.Format("Width: {0} cm", Width) + "\n" +
                string.Format("Height: {0} cm", Height);
            return display;
        }
    }
}
