using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernAppliances.Classes.BaseClass;

namespace ModernAppliances.Classes
{
    /// <summary>
    /// Represents a dishwasher appliance.
    /// </summary>
    internal class Dishwasher : Appliance
    {
        /// <summary>
        /// Sound rating constants.
        /// </summary>
        public const string SOUND_RATING_QUIETEST = "Qt";
        public const string SOUND_RATING_QUITER = "Qr";
        public const string SOUND_RATING_QUIET = "Qu";
        public const string SOUND_RATING_MODERATE = "M";

        private string _feature;
        private string _soundRating;

        /// <summary>
        /// Getters the property feature of the dishwasher.
        /// </summary>
        public string Feature => _feature;
        public string SoundRating => _soundRating;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dishwasher"/> class.
        /// </summary>
        public Dishwasher(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, string feature, string soundRating)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _feature = feature;
            _soundRating = soundRating;
        }

        /// <summary>
        /// Gets the display string for the sound rating.
        /// </summary>
        public string SoundRatingDisplay =>
            _soundRating switch
            {
                SOUND_RATING_QUIETEST => "Quietest",
                SOUND_RATING_QUITER => "Quieter",
                SOUND_RATING_QUIET => "Quiet",
                SOUND_RATING_MODERATE => "Moderate",
                _ => "Unknown"
            };

        /// <summary>
        /// Formats the dishwasher data for file storage.
        /// </summary>
        public override string FormatForFile()
        {
            return $"{base.FormatForFile()};{_feature};{_soundRating}";
        }

        /// <summary>
        /// Returns a string representation of the dishwasher.
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
                string.Format("Feature: {0}", Feature) + "\n" +
                string.Format("Sound Rating: {0}", SoundRatingDisplay);

            return display;
        }
    }
}
