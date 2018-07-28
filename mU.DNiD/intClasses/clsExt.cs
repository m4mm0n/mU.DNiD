/*
    DNiD 2 - PE Identifier.
    Copyright (C) 2018  mammon

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
using System.Text;

namespace DNiD2.intClasses
{
    using System.Globalization;

    static class clsExt
    {
        static Logger log = new Logger(LoggerType.Console_File, "DNiD2.frmAbout");

        /// <summary>
        /// Converts any string byte-array into a ASCII-string...
        /// </summary>
        /// <param name="Bytes"></param>
        /// <returns></returns>
        public static string Bytes2String(this byte[] Bytes)
        {
            //Debug.WriteLine("[Bytes2String]");
            log.Log(LogType.Normal, "Bytes2String");
            var builder = new StringBuilder();
            foreach (var a in Bytes)
            {
                builder.Append(Byte2Char(a).ToString());
            }
            return builder.ToString();
        }
        /// <summary>
        /// Converts a single byte to a standard ASCII-char...
        /// </summary>
        /// <param name="Byte"></param>
        /// <returns></returns>
        public static char Byte2Char(this byte Byte)
        {
            //Debug.WriteLine("[Byte2Char]");
            log.Log(LogType.Normal, "Byte2Char");
            return Byte >= 32 && Byte < 127 ? (char)Byte : '.';
        }
        /// <summary>
        /// Removal of white-spaces in search-arrays such as found with PEiD...
        /// </summary>
        /// <param name="From"></param>
        /// <returns></returns>
        public static string RemoveWhiteSpaces(this string From)
        {
            //Debug.WriteLine("[RemoveWhiteSpaces]");
            log.Log(LogType.Normal, "RemoveWhiteSpaces");
            return From.Replace(" ", "");
        }
        /// <summary>
        /// Retrieves the value from PEiD signatures, and this one's...
        /// </summary>
        /// <param name="From"></param>
        /// <returns></returns>
        public static string GetKeyValue(this string From)
        {
            //Debug.WriteLine("[GetKeyValue]");
            log.Log(LogType.Normal, "GetKeyValue");
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
            //Debug.WriteLine("[isHexShortArray]");
            log.Log(LogType.Normal, "isHexShortArray");
            try
            {
                var a = HexToShortArray(toCheck);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Determines wether the input is an unsigned integer or not
        /// </summary>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static uint isUint(this string toCheck)
        {
            //Debug.WriteLine("[isUint]");
            log.Log(LogType.Normal, "isUint");
            var a = (uint)0xFFFFFFFF;
            var b = uint.TryParse(toCheck, isHex(toCheck), CultureInfo.CurrentCulture, out a);
            return a;
        }
        /// <summary>
        /// Determines wether to return NumberStyles.HexNumber or NumberStyles.Any (it excempts Hex on Any!)
        /// </summary>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static NumberStyles isHex(this string toCheck)
        {
            //Debug.WriteLine("[isHex]");
            log.Log(LogType.Normal, "isHex");
            if (System.Text.RegularExpressions.Regex.IsMatch(toCheck, @"\A\b[0-9a-fA-F]+\b\Z"))
                return NumberStyles.HexNumber;

            return NumberStyles.Any;
        }
        /// <summary>
        /// Determines wether the string is a boolean or not...
        /// </summary>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool isBoolean(this string toCheck)
        {
            //Debug.WriteLine("[isBoolean]");
            log.Log(LogType.Normal, "isBoolean");
            var a = false;
            var b = bool.TryParse(toCheck, out a);
            return a;
        }
        /// <summary>
        /// Returns the string as a boolean...
        /// </summary>
        /// <param name="toFetch"></param>
        /// <returns></returns>
        public static bool StringToBoolean(this string toFetch)
        {
            //Debug.WriteLine("[StringToBoolean]");
            log.Log(LogType.Normal, "StringToBoolean");
            return bool.Parse(toFetch);
        }
        /// <summary>
        /// Returns the string as a short-array...
        /// </summary>
        /// <param name="toFix"></param>
        /// <returns></returns>
        public static short[] HexToShortArray(this string toFix)
        {
            //Debug.WriteLine("[HexToShortArray]");
            log.Log(LogType.Normal, "HexToShortArray");
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
            //Debug.WriteLine("[ShortToHex]");
            log.Log(LogType.Normal, "ShortToHex");
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
