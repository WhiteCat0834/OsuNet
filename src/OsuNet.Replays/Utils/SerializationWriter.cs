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
    }
}
