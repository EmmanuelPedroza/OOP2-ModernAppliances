using System;

namespace ModernAppliances.Classes.BaseClass
{
    /// <summary>
    /// Abstract base class representing a generic appliance.
    /// </summary>
    public abstract class Appliance
    {
        /// <summary>
        /// Enum for appliance types.
        /// </summary>
        public enum ApplianceType
        {
            Unknown,
            Refrigerator = 1,
            Vacum = 2,
            Microwave = 3,
            Dishwasher = 4,
            DishwasherAlt = 5
        }

        private readonly long _itemNumber;
        private readonly string _brand;
        private int _quantity;
        private readonly decimal _wattage;
        private readonly string _color;
        private readonly decimal _price;

        /// <summary>
        /// Initializes a new instance of the <see cref="Appliance"/> class.
        /// </summary>
        /// <param name="itemNumber">The item number.</param>
        /// <param name="brand">The brand name.</param>
        /// <param name="quantity">The quantity available.</param>
        /// <param name="wattage">The wattage of the appliance.</param>
        /// <param name="color">The color of the appliance.</param>
        /// <param name="price">The price of the appliance.</param>
        protected Appliance(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price)
        {
            _itemNumber = itemNumber;
            _brand = brand;
            _quantity = quantity;
            _wattage = wattage;
            _color = color;
            _price = price;
        }

        /// <summary>
        /// Getters for the appliance properties.
        /// </summary>
        public long ItemNumber => _itemNumber;
        public string Brand => _brand;
        public int Quantity => _quantity;
        public decimal Wattage => _wattage;
        public string Color => _color;
        public decimal Price => _price;

        /// <summary>
        /// Formats the appliance data for file storage.
        /// </summary>
        /// <returns>Formatted string for file.</returns>
        public virtual string FormatForFile()
        {
            return $"{_itemNumber};{_brand};{_quantity};{_wattage};{_color};{_price}";
        }

        /// <summary>
        /// Checks if the appliance is available (quantity > 0).
        /// </summary>
        /// <returns>True if available, otherwise false.</returns>
        public bool IsAvailable()
        {
            return Quantity > 0;
        }

        /// <summary>
        /// Decreases the quantity by one if available.
        /// </summary>
        /// <returns>The new quantity.</returns>
        public int CheckOutAppliance()
        {
            if (IsAvailable())
            {
                _quantity--;
            }

            return Quantity;
        }
    }
}