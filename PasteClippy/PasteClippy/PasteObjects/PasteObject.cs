using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteClippy.PasteObjects
{
    /// <summary>
    /// This class represents an item in the clipboard
    /// </summary>
    public class PasteObject
    {
        /// <summary>
        /// Gets or sets the paste value
        /// </summary>
        public string PasteValue { get; set; }

        /// <summary>
        /// Get the string representation of the object
        /// </summary>
        /// <returns>string of up to 20 chars</returns>
        public override string ToString()
        {
            return ToString(20);
        }

        /// <summary>
        /// Get the string representation of the object to a limited size
        /// </summary>
        /// <param name="size">Maximum size of the string</param>
        /// <returns>Returns a string upto a specific size</returns>
        public string ToString(int size)
        {
            string returnValue = PasteValue;

            returnValue = returnValue.Replace("\r\n", "")
                .Replace("\n", "")
                .Replace("\t", "");

            if (returnValue.Length <= (size + 3))
                return returnValue;
            else
                return returnValue.Substring(0, size) + "...";
        }
    }
}
