
#region Apache Notice
/*****************************************************************************
 * $Revision: 408164 $
 * $LastChangedDate: 2008-06-28 09:26:16 -0600 (Sat, 28 Jun 2008) $
 * $LastChangedBy: gbayon $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2008/2005 - The Apache Software Foundation
 *  
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 ********************************************************************************/
#endregion

#region Imports

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

#endregion

namespace Apache.Ibatis.Common.Utilities.TypesResolver
{
	/// <summary> 
	/// Provides access to a central registry of aliased <see cref="System.Type"/>s.
	/// </summary>
	/// <remarks>
	/// <p>
	/// Simplifies configuration by allowing aliases to be used instead of
	/// fully qualified type names.
	/// </p>
	/// <p>
	/// Comes 'pre-loaded' with a number of convenience alias' for the more
	/// common types; an example would be the '<c>int</c>' (or '<c>Integer</c>'
	/// for Visual Basic.NET developers) alias for the <see cref="System.Int32"/>
	/// type.
	/// </p>
	/// </remarks>
	public class TypeRegistry
	{
		#region Constants

		/// <summary>
		/// The alias around the 'list' type.
		/// </summary>
		public const string ArrayListAlias1 = "arraylist";
		/// <summary>
		/// Another alias around the 'list' type.
		/// </summary>
		public const string ArrayListAlias2 = "list";

		/// <summary>
		/// Another alias around the 'bool' type.
		/// </summary>
		public const string BoolAlias = "bool";
		/// <summary>
		/// The alias around the 'bool' type.
		/// </summary>
		public const string BooleanAlias = "boolean";

		/// <summary>
		/// The alias around the 'byte' type.
		/// </summary>
		public const string ByteAlias = "byte";

		/// <summary>
		/// The alias around the 'char' type.
		/// </summary>
		public const string CharAlias = "char";

		/// <summary>
		/// The alias around the 'DateTime' type.
		/// </summary>
		public const string DateAlias1 = "datetime";
		/// <summary>
		/// Another alias around the 'DateTime' type.
		/// </summary>
		public const string DateAlias2 = "date";

		/// <summary>
		/// The alias around the 'decimal' type.
		/// </summary>
		public const string DecimalAlias = "decimal";

		/// <summary>
		/// The alias around the 'double' type.
		/// </summary>
		public const string DoubleAlias = "double";


		/// <summary>
		/// The alias around the 'float' type.
		/// </summary>
		public const string FloatAlias = "float";
		/// <summary>
		/// Another alias around the 'float' type.
		/// </summary>
		public const string SingleAlias = "single";

		/// <summary>
		/// The alias around the 'guid' type.
		/// </summary>
		public const string GuidAlias = "guid";

		/// <summary>
		/// The alias around the 'Hashtable' type.
		/// </summary>
		public const string HashtableAlias1 = "hashtable";
		/// <summary>
		/// Another alias around the 'Hashtable' type.
		/// </summary>
		public const string HashtableAlias2 = "map";
		/// <summary>
		/// Another alias around the 'Hashtable' type.
		/// </summary>
		public const string HashtableAlias3 = "hashmap";

        /// <summary>
        /// The alias around the 'DataRow' type.
        /// </summary>
        public const string DataRowAlias1 = "datarow";
        /// <summary>
        /// Another alias around the 'DataRow' type.
        /// </summary>
        public const string DataRowAlias2 = "data";
        /// <summary>
        /// Another alias around the 'DataRow' type.
        /// </summary>
        public const string DataRowAlias3 = "row";

		/// <summary>
		/// The alias around the 'short' type.
		/// </summary>
		public const string Int16Alias1 = "int16";
		/// <summary>
		/// Another alias around the 'short' type.
		/// </summary>
		public const string Int16Alias2 = "short";


		/// <summary>
		/// The alias around the 'int' type.
		/// </summary>
		public const string Int32Alias1 = "int32";
		/// <summary>
		/// Another alias around the 'int' type.
		/// </summary>
		public const string Int32Alias2 = "int";
		/// <summary>
		/// Another alias around the 'int' type.
		/// </summary>
		public const string Int32Alias3 = "integer";

		/// <summary>
		/// The alias around the 'long' type.
		/// </summary>
		public const string Int64Alias1 = "int64";
		/// <summary>
		/// Another alias around the 'long' type.
		/// </summary>
		public const string Int64Alias2 = "long";

		/// <summary>
		/// The alias around the 'unsigned short' type.
		/// </summary>
		public const string UInt16Alias1 = "uint16";
		/// <summary>
		/// Another alias around the 'unsigned short' type.
		/// </summary>
		public const string UInt16Alias2 = "ushort";

		/// <summary>
		/// The alias around the 'unsigned int' type.
		/// </summary>
		public const string UInt32Alias1 = "uint32";
		/// <summary>
		/// Another alias around the 'unsigned int' type.
		/// </summary>
		public const string UInt32Alias2 = "uint";

		/// <summary>
		/// The alias around the 'unsigned long' type.
		/// </summary>
		public const string UInt64Alias1 = "uint64";
		/// <summary>
		/// Another alias around the 'unsigned long' type.
		/// </summary>
		public const string UInt64Alias2 = "ulong";

		/// <summary>
		/// The alias around the 'SByte' type.
		/// </summary>
		public const string SByteAlias = "sbyte";

		/// <summary>
		/// The alias around the 'string' type.
		/// </summary>
		public const string StringAlias = "string";

		/// <summary>
		/// The alias around the 'TimeSpan' type.
		/// </summary>
		public const string TimeSpanAlias = "timespan";

        /// <summary>
        /// The alias around the 'int?' type.
        /// </summary>
        public const string NullableInt32Alias = "int?";

        /// <summary>
        /// The alias around the 'int?[]' array type.
        /// </summary>
        public const string NullableInt32ArrayAlias = "int?[]";

        /// <summary>
        /// The alias around the nullable 'DateTime' type.
        /// </summary>
        public const string NullableDateAlias1 = "datetime?";
        /// <summary>
        /// Another alias around nullable the 'DateTime' type.
        /// </summary>
        public const string NullableDateAlias2 = "date?";

        /// <summary>
        /// The alias around the 'decimal?' type.
        /// </summary>
        public const string NullableDecimalAlias = "decimal?";

        /// <summary>
        /// The alias around the 'decimal?[]' array type.
        /// </summary>
        public const string NullableDecimalArrayAlias = "decimal?[]";

        /// <summary>
        /// The alias around the 'char?' type.
        /// </summary>
        public const string NullableCharAlias = "char?";

        /// <summary>
        /// The alias around the 'char?[]' array type.
        /// </summary>
        public const string NullableCharArrayAlias = "char?[]";

        /// <summary>
        /// The alias around the 'long?' type.
        /// </summary>
        public const string NullableInt64Alias = "long?";

        /// <summary>
        /// The alias around the 'long?[]' array type.
        /// </summary>
        public const string NullableInt64ArrayAlias = "long?[]";

        /// <summary>
        /// The alias around the 'short?' type.
        /// </summary>
        public const string NullableInt16Alias = "short?";

        /// <summary>
        /// The alias around the 'short?[]' array type.
        /// </summary>
        public const string NullableInt16ArrayAlias = "short?[]";

        /// <summary>
        /// The alias around the 'unsigned int?' type.
        /// </summary>
        public const string NullableUInt32Alias = "uint?";

        /// <summary>
        /// The alias around the 'unsigned long?' type.
        /// </summary>
        public const string NullableUInt64Alias = "ulong?";

        /// <summary>
        /// The alias around the 'ulong?[]' array type.
        /// </summary>
        public const string NullableUInt64ArrayAlias = "ulong?[]";

        /// <summary>
        /// The alias around the 'uint?[]' array type.
        /// </summary>
        public const string NullableUInt32ArrayAlias = "uint?[]";

        /// <summary>
        /// The alias around the 'unsigned short?' type.
        /// </summary>
        public const string NullableUInt16Alias = "ushort?";

        /// <summary>
        /// The alias around the 'ushort?[]' array type.
        /// </summary>
        public const string NullableUInt16ArrayAlias = "ushort?[]";

        /// <summary>
        /// The alias around the 'double?' type.
        /// </summary>
        public const string NullableDoubleAlias = "double?";

        /// <summary>
        /// The alias around the 'double?[]' array type.
        /// </summary>
        public const string NullableDoubleArrayAlias = "double?[]";

        /// <summary>
        /// The alias around the 'float?' type.
        /// </summary>
        public const string NullableFloatAlias = "float?";

        /// <summary>
        /// The alias around the 'float?[]' array type.
        /// </summary>
        public const string NullableFloatArrayAlias = "float?[]";

        /// <summary>
        /// The alias around the 'bool?' type.
        /// </summary>
        public const string NullableBoolAlias = "bool?";

        /// <summary>
        /// The alias around the 'bool?[]' array type.
        /// </summary>
        public const string NullableBoolArrayAlias = "bool?[]";

		#endregion

		#region Fields
        private static readonly IDictionary<string, Type> types = new Dictionary<string, Type>();
		#endregion

		#region Constructor (s) / Destructor
		/// <summary>
        /// Creates a new instance of the <see cref="TypeRegistry"/> class.
		/// </summary>
		/// <remarks>
		/// <p>
		/// This is a utility class, and as such has no publicly visible
		/// constructors.
		/// </p>
		/// </remarks>
		private TypeRegistry() {}


        /// <summary>
        /// Initializes the <see cref="TypeRegistry"/> class.
        /// </summary>
        static TypeRegistry()
		{
			// Initialize a dictionary with some fully qualifiaed name 
            types[DataRowAlias1] = typeof(DataRow);
            types[DataRowAlias2] = typeof(DataRow);
            types[DataRowAlias3] = typeof(DataRow);

			types[ArrayListAlias1] = typeof (ArrayList);
			types[ArrayListAlias2] = typeof (ArrayList);

			types[BoolAlias] = typeof (bool);
			types[BooleanAlias] = typeof (bool);

			types[ByteAlias] = typeof (byte);

			types[CharAlias] = typeof (char);

			types[DateAlias1] = typeof (DateTime);
			types[DateAlias2] = typeof (DateTime);

			types[DecimalAlias] = typeof (decimal);

			types[DoubleAlias] = typeof (double);

			types[FloatAlias] = typeof (float);
			types[SingleAlias] = typeof (float);

			types[GuidAlias] = typeof (Guid);

			types[HashtableAlias1] = typeof (Hashtable);
			types[HashtableAlias2] = typeof (Hashtable);
			types[HashtableAlias3] = typeof (Hashtable);

			types[Int16Alias1] = typeof (short);
			types[Int16Alias2] = typeof (short);

			types[Int32Alias1] = typeof (int);
			types[Int32Alias2] = typeof (int);
			types[Int32Alias3] = typeof (int);

			types[Int64Alias1] = typeof (long);
			types[Int64Alias2] = typeof (long);

			types[UInt16Alias1] = typeof (ushort);
			types[UInt16Alias2] = typeof (ushort);

			types[UInt32Alias1] = typeof (uint);
			types[UInt32Alias2] = typeof (uint);

			types[UInt64Alias1] = typeof (ulong);
			types[UInt64Alias2] = typeof (ulong);

			types[SByteAlias] = typeof (sbyte);

			types[StringAlias] = typeof (string);

			types[TimeSpanAlias] = typeof (string);

            types[NullableInt32Alias] = typeof(int?);
            types[NullableInt32ArrayAlias] = typeof(int?[]);

            types[NullableDateAlias1] = typeof(DateTime?);
            types[NullableDateAlias2] = typeof(DateTime?);

            types[NullableDecimalAlias] = typeof(decimal?);
            types[NullableDecimalArrayAlias] = typeof(decimal?[]);

            types[NullableCharAlias] = typeof(char?);
            types[NullableCharArrayAlias] = typeof(char?[]);

            types[NullableInt64Alias] = typeof(long?);
            types[NullableInt64ArrayAlias] = typeof(long?[]);

            types[NullableInt16Alias] = typeof(short?);
            types[NullableInt16ArrayAlias] = typeof(short?[]);

            types[NullableUInt32Alias] = typeof(uint?);
            types[NullableUInt32ArrayAlias] = typeof(uint?[]);

            types[NullableUInt64Alias] = typeof(ulong?);
            types[NullableUInt64ArrayAlias] = typeof(ulong?[]);

            types[NullableUInt16Alias] = typeof(ushort?);
            types[NullableUInt16ArrayAlias] = typeof(ushort?[]);

            types[NullableDoubleAlias] = typeof(double?);
            types[NullableDoubleArrayAlias] = typeof(double?[]);

            types[NullableFloatAlias] = typeof(float?);
            types[NullableFloatArrayAlias] = typeof(float?[]);

            types[NullableBoolAlias] = typeof(bool?);
            types[NullableBoolArrayAlias] = typeof(bool?[]);

        }
		#endregion

		#region Methods

        /// <summary> 
        /// Resolves the supplied <paramref name="alias"/> to a <see cref="System.Type"/>. 
        /// </summary> 
        /// <param name="alias">
        /// The alias to resolve.
        /// </param>
        /// <returns>
        /// The <see cref="System.Type"/> the supplied <paramref name="alias"/> was
        /// associated with, or <see lang="null"/> if no <see cref="System.Type"/> 
        /// was previously registered for the supplied <paramref name="alias"/>.
        /// </returns>
        /// <remarks>The alis name will be convert in lower character before the resolution.</remarks>
        /// <exception cref="System.ArgumentNullException">
        /// If the supplied <paramref name="alias"/> is <see langword="null"/> or
        /// contains only whitespace character(s).
        /// </exception>
        public static Type ResolveType(string alias)
        {
            Type type = null;
            types.TryGetValue(alias.ToLower(), out type);
            return type;
        }

		#endregion

	}
}
