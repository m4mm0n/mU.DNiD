/*
    DNiD 2 - PE Identifier.
    Copyright (C) 2016  mammon

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNiD2.intClasses
{
    static class clsExt
    {
        /// <summary>
        /// Removal of white-spaces in search-arrays such as found with PEiD...
        /// </summary>
        /// <param name="From"></param>
        /// <returns></returns>
        public static string RemoveWhiteSpaces(this string From)
        {
            return From.Replace(" ", "");
        }
        /// <summary>
        /// Retrieves the value from PEiD signatures, and this one's...
        /// </summary>
        /// <param name="From"></param>
        /// <returns></returns>
        public static string GetKeyValue(this string From)
        {
            var a = From.Split(new char[] { '=' });
            return a[1].Trim();
        }
        /// <summary>
        /// Determines wether the search-array is hexadecimals or not...
        /// </summary>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool isHexShortArray(this string toCheck)
        {
            try
            {
                var a = HexToShortArray(toCheck);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Determines wether the string is a boolean or not...
        /// </summary>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool isBoolean(this string toCheck)
        {
            try
            {
                return bool.Parse(toCheck);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Returns the string as a boolean...
        /// </summary>
        /// <param name="toFetch"></param>
        /// <returns></returns>
        public static bool StringToBoolean(this string toFetch)
        {
            return bool.Parse(toFetch);
        }
        /// <summary>
        /// Returns the string as a short-array...
        /// </summary>
        /// <param name="toFix"></param>
        /// <returns></returns>
        public static short[] HexToShortArray(this string toFix)
        {
            if (toFix.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(System.Globalization.CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", toFix));
            }
            var hexAsShort = new short[toFix.Length / 2];
            for (var a = 0; a < hexAsShort.Length; a++)
            {
                var b = toFix.Substring(a * 2, 2);
                if (b == "??")
                    hexAsShort[a] = (short)-1;
                else
                    hexAsShort[a] = (short)byte.Parse(b, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture);
            }
            return hexAsShort;
        }
        /// <summary>
        /// Returns the short-array as a hexadecimal string...
        /// </summary>
        /// <param name="myLst"></param>
        /// <returns></returns>
        public static string ShortToHex(this short[] myLst)
        {
            var a = new StringBuilder();
            foreach (var b in myLst)
            {
                if (b == -1)
                    a.Append("??");
                else
                    a.Append(b.ToString("X2"));
            }
            return a.ToString();
        }
    }
}
