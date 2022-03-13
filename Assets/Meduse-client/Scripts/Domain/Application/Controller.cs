using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Meduse_client.Scripts.Gateway;
using UnityEngine;
using TMPro;

// Analog [0,32767]

namespace Meduse_client.Scripts
{

    public class Controller : MonoBehaviour
    {

        const int ButtonMax = 16;

        //GCController cont;
        public GameUI_Button BL;
        public TMP_Text label;

        CommonControllerData mainCont;
        int data = 0;
        private IConnectionServer connectionServer;

        void Start()
        {
            InputManagerGenerator inputManagerGenerator = new InputManagerGenerator();

            for (int bcnt = 0; bcnt < ButtonMax; bcnt++)
            {
                var name = string.Format("test button {0}", bcnt);
                var button = string.Format("joystick button {0}", bcnt);
                inputManagerGenerator.AddAxis(InputAxis.CreateButton(name, button, ""));
            }

            mainCont = new CommonControllerData(0);
            label.text = "push 1:Wii 2:GC";


            // Gateway
            connectionServer = new ConnectionServer();
            Task.Run(() => connectionServer.Read());
            connectionServer.Write((BitConverter.GetBytes(2)));
            connectionServer.Write((BitConverter.GetBytes(3)));
            connectionServer.Write((BitConverter.GetBytes(4)));
            connectionServer.Write((BitConverter.GetBytes(5)));
            Debug.Log(BitConverter.ToString(BitConverter.GetBytes(2)));

        }

        // Update is called once per frame
        void Update()
        {

            if (mainCont.Type == null)
            {
                if (Input.GetKey(KeyCode.Alpha1))
                {
                    mainCont.SetType("def", "Wii");
                }
                else if (Input.GetKey(KeyCode.Alpha2))
                {
                    mainCont.SetType("def", "GC");
                }

                return;
            }

            if (mainCont.IsFinishKeyBind == false)
            {
                this.KeyBind_NEW();
            }
            else
            {
                this.GetInput();
                this.sendContInput();
            }

        }

        public int GetFirstButtonNum()
        {
            for (int bcnt = 0; bcnt < ButtonMax; bcnt++)
            {
                var name = string.Format("test button {0}", bcnt);
                if (Input.GetButton(name))
                {
                    return bcnt;
                }
            }

            return -1;
        }

        private int Convert()
        {
            int res = 0;
            for (int bcnt = 0; bcnt < ButtonMax; bcnt++)
            {
                var name = string.Format("test button {0}", bcnt);
                if (Input.GetButton(name))
                {
                    res |= (1 << mainCont.GetButtonIndex(bcnt));
                }
            }

            this.data = res;
            return res;
        }

        public void GetInput()
        {
            label.text = mainCont.Type.Platform + " Input : 0x" + Convert().ToString("X");
            for (int bcnt = 0; bcnt < ButtonMax; bcnt++)
            {
                var name = string.Format("test button {0}", bcnt);
                if (Input.GetButton(name))
                {

                    var kuso = BL.ButtonList[bcnt].colors;
                    kuso.normalColor = Color.red;
                    BL.ButtonList[bcnt].colors = kuso;

                }
                else
                {
                    var kuso = BL.ButtonList[bcnt].colors;
                    kuso.normalColor = Color.white;
                    BL.ButtonList[bcnt].colors = kuso;
                }
            }
        }

        public void KeyBind_NEW()
        {
            if (mainCont.KeyBindStep == mainCont.Type.ButtonNum)
            {
                mainCont.IsFinishKeyBind = true;
                this.label.text = "KeyBind Done ... !";
            }
            else
            {
                label.text = "Chose " + mainCont.Type.ButtonString[mainCont.KeyBindStep] + " Button !";
                int Bnum = this.GetFirstButtonNum();
                if (Bnum >= 0)
                {
                    for (int i = 0; i < mainCont.Type.ButtonNum; i++)
                    {
                        if (Bnum == mainCont.KeyRelate[i]) return;
                    }

                    mainCont.KeyRelate[mainCont.KeyBindStep] = Bnum;
                    mainCont.KeyBindStep++;
                    //　ここでバインド
                }

            }

        }

        public bool sendContInput()
        {
            //  ここでデータを送ればいい
            //  this.data(ボタン情報)をおくる
            return false; //失敗
        }

    }
}
