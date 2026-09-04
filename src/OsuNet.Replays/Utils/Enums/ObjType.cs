namespace OsuNet.Replays.Utils.Enums {
    /// <summary>
    /// Specifies the type of an object during binary serialization.
    /// Used to correctly read and write typed values in the osu! replay format.
    /// </summary>
    internal enum ObjType {
        /// <summary>Represents a <c>null</c> reference.</summary>
        Null,

        /// <summary>Represents a <see cref="bool"/> value.</summary>
        Bool,

        /// <summary>Represents an unsigned 8-bit integer (<see cref="byte"/>).</summary>
        Byte,

        /// <summary>Represents an unsigned 16-bit integer (<see cref="ushort"/>).</summary>
        UShort,

        /// <summary>Represents an unsigned 32-bit integer (<see cref="uint"/>).</summary>
        UInt,

        /// <summary>Represents an unsigned 64-bit integer (<see cref="ulong"/>).</summary>
        ULong,

        /// <summary>Represents a signed 8-bit integer (<see cref="sbyte"/>).</summary>
        SByte,

        /// <summary>Represents a signed 16-bit integer (<see cref="short"/>).</summary>
        Short,

        /// <summary>Represents a signed 32-bit integer (<see cref="int"/>).</summary>
        Int,

        /// <summary>Represents a signed 64-bit integer (<see cref="long"/>).</summary>
        Long,

        /// <summary>Represents a Unicode character (<see cref="char"/>).</summary>
        Char,

        /// <summary>Represents a <see cref="string"/> value.</summary>
        String,

        /// <summary>Represents a single-precision floating-point number (<see cref="float"/>).</summary>
        Float,

        /// <summary>Represents a double-precision floating-point number (<see cref="double"/>).</summary>
        Double,

        /// <summary>Represents a <see cref="decimal"/> value.</summary>
        Decimal,

        /// <summary>Represents a <see cref="System.DateTime"/> value.</summary>
        DateTime,

        /// <summary>Represents an array of bytes.</summary>
        ByteArray,

        /// <summary>Represents an array of characters.</summary>
        CharArray
    }
}