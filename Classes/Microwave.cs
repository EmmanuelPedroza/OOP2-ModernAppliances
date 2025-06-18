using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernAppliances.Classes.BaseClass;

namespace ModernAppliances.Classes
{
    /// <summary>
    /// Represents a microwave appliance.
    /// </summary>
    internal class Microwave : Appliance
    {
        /// <summary>
        /// Room type constants.
        /// </summary>
        public const char ROOM_TYPE_KITCHEN = 'K';
        public const char ROOM_TYPE_WORKSITE = 'W';

        private readonly float _capacity;
        private readonly char _roomType;

        /// <summary>
        /// Geterss of the properties of the microwave.
        /// </summary>
        public float Capacity => _capacity;
        public char RoomType => _roomType;

        /// <summary>
        /// Gets the display string for the room type.
        /// </summary>
        public string RoomTypeDisplay =>
            _roomType switch
            {
                ROOM_TYPE_KITCHEN => "Kitchen",
                ROOM_TYPE_WORKSITE => "Worksite",
                _ => "Unknown"
            };

        /// <summary>
        /// Initializes a new instance of the <see cref="Microwave"/> class.
        /// </summary>
        public Microwave(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, float capacity, char roomType)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _capacity = capacity;
            _roomType = roomType;
        }

        /// <summary>
        /// Formats the microwave data for file storage.
        /// </summary>
        public override string FormatForFile()
        {
            return $"{base.FormatForFile()};{Capacity};{RoomType}";
        }

        /// <summary>
        /// Returns a string representation of the microwave.
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
                string.Format("Capacity: {0} L", Capacity) + "\n" +
                string.Format("Room Type: {0}", RoomTypeDisplay);
            return display;

        }
    }
}
