using OsuNet.Replays.Utils.Enums;

namespace OsuNet.Replays.Utils {
    /// <summary>
    /// Extends the <see cref="BinaryWriter"/> class to provide custom serialization 
    /// logic for osu! replay files, including type-prefixed writing.
    /// </summary>
    internal class SerializationWriter : BinaryWriter {
        /// <summary>
        /// Initializes a new instance of the <see cref="SerializationWriter"/> class 
        /// based on the specified stream.
        /// </summary>
        /// <param name="s">The output stream.</param>
        /// <exception cref="ArgumentException">The stream does not support writing or is closed.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="s"/> is <c>null</c>.</exception>
        public SerializationWriter(Stream s) : base(s) { }

        /// <summary>
        /// Writes a string value to the stream, preceded by its <see cref="ObjType"/> byte.
        /// If the string is <c>null</c>, it writes <see cref="ObjType.Null"/>.
        /// Otherwise, it writes <see cref="ObjType.String"/> followed by the string data.
        /// </summary>
        /// <param name="str">The string value to write.</param>
        public override void Write(string str) {
            if (str == null) {
                Write((byte)ObjType.Null);
            }
            else {
                Write((byte)ObjType.String);
                base.Write(str);
            }
        }

        /// <summary>
        /// Writes a <see cref="DateTime"/> value to the stream as its universal tick count.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> value to write.</param>
        public void Write(DateTime dateTime) {
            Write(dateTime.ToUniversalTime().Ticks);
        }
    }
}