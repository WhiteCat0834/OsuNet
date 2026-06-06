using OsuNet.Replays.Utils.Enums;

namespace OsuNet.Replays.Utils {
    internal class SerializationWriter : BinaryWriter {
        public SerializationWriter(Stream s) : base(s) { }

        public override void Write(string str) {
            if (str == null) {
                Write((byte)ObjType.Null);
            }
            else {
                Write((byte)ObjType.String);
                base.Write(str);
            }
        }

        public void Write(DateTime dateTime) {
            Write(dateTime.ToUniversalTime().Ticks);
        }

        public void Write<T, U>(IDictionary<T, U> d) {
            if (d == null) {
                Write(-1);
            }
            else {
                Write(d.Count);
                foreach (KeyValuePair<T, U> kvp in d) {
                    WriteObject(kvp.Key);
                    WriteObject(kvp.Value);
                }
            }
        }

        public void WriteObject(object obj) {
            if (obj == null) {
                Write((byte)ObjType.Null);
            }
            else {
                switch (obj) {
                    case bool x:
                        Write((byte)ObjType.Bool);
                        Write(x);
                        break;
                    case byte x:
                        Write((byte)ObjType.Byte);
                        Write(x);
                        break;
                    case ushort x:
                        Write((byte)ObjType.UShort);
                        Write(x);
                        break;
                    case uint x:
                        Write((byte)ObjType.UInt);
                        Write(x);
                        break;
                    case ulong x:
                        Write((byte)ObjType.ULong);
                        Write(x);
                        break;
                    case sbyte x:
                        Write((byte)ObjType.SByte);
                        Write(x);
                        break;
                    case short x:
                        Write((byte)ObjType.Short);
                        Write(x);
                        break;
                    case int x:
                        Write((byte)ObjType.Int);
                        Write(x);
                        break;
                    case long x:
                        Write((byte)ObjType.Long);
                        Write(x);
                        break;
                    case char x:
                        Write((byte)ObjType.Char);
                        base.Write(x);
                        break;
                    case string x:
                        Write((byte)ObjType.String);
                        base.Write(x);
                        break;
                    case float x:
                        Write((byte)ObjType.Float);
                        Write(x);
                        break;
                    case double x:
                        Write((byte)ObjType.Double);
                        Write(x);
                        break;
                    case decimal x:
                        Write((byte)ObjType.Decimal);
                        Write(x);
                        break;
                    case DateTime x:
                        Write((byte)ObjType.DateTime);
                        Write(x);
                        break;
                    case byte[] x:
                        Write((byte)ObjType.ByteArray);
                        base.Write(x);
                        break;
                    case char[] x:
                        Write((byte)ObjType.CharArray);
                        base.Write(x);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}
