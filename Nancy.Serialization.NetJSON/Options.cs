using System;
using NetJSON;

namespace Nancy.Serialization.NetJSON
{
    [Obsolete("As these Options in here merely forward to the same ones in the NetJSON.* Namespace, those should be set / used directly from now on.")]
    public static class Options
    {
        /// <summary>
        /// This merely forwards the provided value to <see cref="NetJSON.DateFormat" />.
        /// As that property does not expose a getter, no one can reliably be provided here, too.
        /// </summary>
        /// <value>
        /// <c>true</c> if ISO8601 date time format shall be used; otherwise, <c>false</c> (which means ticks will be used).
        /// </value>
        [Obsolete(".DateFormat should be used from now on.")]
        public static bool UseIso8601DateTimeFormat
        {
            set { global::NetJSON.NetJSON.DateFormat = value ? NetJSONDateFormat.ISO : NetJSONDateFormat.Default; }
        }
        
        /// <summary>
        /// This merely forwards the provided value to <see cref="NetJSON.CaseSensitive" />.
        /// As that property does not expose a getter, no one can reliably be provided here, too.
        /// </summary>
        /// <value>
        ///   <c>true</c> if (de-)serialization shall be case sensitive; otherwise, <c>false</c>.
        /// </value>
        public static bool CaseSensitive
        {
            set { global::NetJSON.NetJSON.CaseSensitive = value; }
        }

        /// <summary>
        /// This merely forwards the provided value to <see cref="NetJSON.UseEnumString" />.
        /// As that property does not expose a getter, no one can reliably be provided here, too.
        /// </summary>
        /// <value>
        ///   <c>true</c> if use enums shall be (de-)serialized via their string representation; otherwise, <c>false</c>.
        /// </value>
        public static bool UseEnumString
        {
            set { global::NetJSON.NetJSON.UseEnumString = value; }
        }

        /// <summary>
        /// This merely forwards the provided value to <see cref="NetJSON.SkipDefaultValue" />.
        /// As that property does not expose a getter, no one can reliably be provided here, too.
        /// </summary>
        /// <value>
        ///   <c>true</c> if default values shall be skipped entirely; otherwise, <c>false</c>.
        /// </value>
        public static bool SkipDefaultValue
        {
            set { global::NetJSON.NetJSON.SkipDefaultValue = value; }
        }

        /// <summary>
        /// This merely forwards the provided value to <see cref="NetJSON.GenerateAssembly" />.
        /// As that property does not expose a getter, no one can reliably be provided here, too.
        /// </summary>
        /// <value>
        ///   <c>true</c> if a serialization assembly shall be generated during runtime; otherwise, <c>false</c>.
        /// </value>
        public static bool GenerateAssembly
        {
            set { global::NetJSON.NetJSON.GenerateAssembly = value; }
        }

        /// <summary>
        /// This merely forwards the provided value to <see cref="NetJSON.IncludeFields"/>.
        /// As that property does not expose a getter, no one can reliably be provided here, too.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fields shall be included in serialization, otherwise, <c>false</c>.
        /// </value>
        public static bool IncludeFields
        {
            set { global::NetJSON.NetJSON.IncludeFields = value; }
        }

        /// <summary>
        /// This merely forwards the provided value to <see cref="NetJSON.IncludeTypeInformation"/>.
        /// As that property does not expose a getter, no one can reliably be provided here, too.
        /// </summary>
        /// <value>
        ///   <c>true</c> if type information shall be included in serialization, otherwise, <c>false</c>.
        /// </value>
        public static bool IncludeTypeInformation
        {
            set { global::NetJSON.NetJSON.IncludeTypeInformation = value; }
        }

        /// <summary>
        /// This merely forwards the provided value to <see cref="NetJSON.DateFormat"/>.
        /// As that property does not expose a getter, no one can reliably be provided here, too.
        /// </summary>
        /// <value>
        ///   The <see cref="NetJSONDateFormat"/> to use for (de-)serialization of <see cref="DateTime"/> data.
        /// </value>
        public static NetJSONDateFormat DateFormat
        {
            set { global::NetJSON.NetJSON.DateFormat = value; }
        }

        /// <summary>
        /// This merely forwards the provided value to <see cref="NetJSON.QuoteType"/>.
        /// As that property does not expose a getter, no one can reliably be provided here, too.
        /// </summary>
        /// <value>
        ///   The <see cref="NetJSONQuote"/> to use for (de-)serialization.
        /// </value>
        public static NetJSONQuote QuoteType
        {
            set { global::NetJSON.NetJSON.QuoteType = value; }
        }

        /// <summary>
        /// This merely forwards the provided value to <see cref="NetJSON.TimeZoneFormat"/>.
        /// As that property does not expose a getter, no one can reliably be provided here, too.
        /// </summary>
        /// <value>
        ///   The <see cref="NetJSONTimeZoneFormat"/> to use for (de-)serialization.
        /// </value>
        public static NetJSONTimeZoneFormat TimeZoneFormat
        {
            set { global::NetJSON.NetJSON.TimeZoneFormat = value; }
        }
    }
}