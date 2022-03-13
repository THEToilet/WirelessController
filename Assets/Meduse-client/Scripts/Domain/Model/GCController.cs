namespace Meduse_client.Scripts
{
    public class GcController
    {
        public const string Platform = "GC";
        public const int MaxButtonNum = 12;
        public static readonly string[] ButtonString = { "A", "B", "X", "Y", "Z", "START", "L", "R", "UP", "DOWN", "LEFT", "RIGHT" };
        // stick [-1.0f - 1.0f] => [0 - 32767]
        public enum ButtonBit
        {
            A = 0x01,
            B = 0x02,
            X = 0x04,
            Y = 0x08,
            Z = 0x10,
            Start = 0x20,
            L = 0x40,
            R = 0x80,
            Up = 0x0100,
            Down = 0x0200,
            Left = 0x0400,
            Right = 0x0800
        }

    }
}
