namespace Meduse_client.Scripts
{
    public class CommonControllerData
    {
        public const int MaxContButton = 16;

        public bool IsFinishKeyBind;
        public int KeyBindStep;

        public ControllerType Type;
        public int ContNum;

        public int Buttons;
        public AnalogStick Stick1;
        public AnalogStick Stick2;

        public int[] KeyRelate = new int[MaxContButton];
        public static string[] ButtonString;

        public CommonControllerData(int num)
        {
            this.Type = null;
            this.IsFinishKeyBind = false;
            this.KeyBindStep = 0;

            this.ContNum = num;
            this.Buttons = 0;

            this.Stick1 = null;
            this.Stick2 = null;

            for (int i = 0; i < MaxContButton; i++) KeyRelate[i] = -1;
        }


        public void SetType(string device, string type)
        {
            this.Type = new ControllerType(device, type);
        }

        public int GetButtonIndex(int value)
        {
            for (int i = 0; i < this.Type.ButtonNum; i++)
            {
                if (this.KeyRelate[i] == value) return i;
            }

            return -1;
        }


    }

    public class AnalogStick
    {
        public const int StickRangeMax = 32767;
        public const int StickRangeMin = 0;

        public uint AxisX, AxisY;
        public string StickName;

        public AnalogStick()
        {
            this.AxisX = 0;
            this.AxisY = 0;
        }

        public AnalogStick(int x, int y, string n)
        {
            this.StickName = n;
            this.SetAxis(x, y);
        }

        public void SetAxis(int x, int y)
        {
            this.AxisX = this.ConvertAxisToUint(x);
            this.AxisY = this.ConvertAxisToUint(y);
        }

        private uint ConvertAxisToUint(float ax)
        {
            const int adjust = StickRangeMax / 2;
            return (uint)((ax + 1.0f) * adjust);
        }
    }

    public class ControllerType
    {
        public string DeviceName;
        public string Platform;

        public int ButtonNum;
        public string[] ButtonString;

        public ControllerType(string d, string t)
        {
            this.DeviceName = d;
            this.Platform = t;

            this.SetPlatform();
        }

        public void SetPlatform()
        {
            switch (this.Platform)
            {
                case WiiController.Platform:
                    this.ButtonNum = WiiController.MaxButtonNum;
                    this.ButtonString = WiiController.ButtonString;
                    break;

                case GcController.Platform:
                    this.ButtonNum = GcController.MaxButtonNum;
                    this.ButtonString = GcController.ButtonString;
                    break;

            }
        }

    }
}