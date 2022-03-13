using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Cysharp.Threading.Tasks;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Meduse_client.Scripts.Gateway
{
    public class ConnectionServer : IConnectionServer
    {
        private string _ip = "localhost";
        private int _port = 8080;

        private TcpClient _tcpClient;
        private NetworkStream _stream;

        public ConnectionServer()
        {
            _tcpClient = new TcpClient(_ip, _port);
            _stream = _tcpClient.GetStream();
            Debug.Log("--dd--");
        }


        public async UniTask<byte[]> Read()
        {
            byte[] data = new byte[128];
            var stream = _tcpClient.GetStream();
            Debug.Log("read");
            while (true)
            {
                while (stream.DataAvailable)
                {
                    stream.Read(data, 0, data.Length);
                    this.handleMessage(data);
                }
            }
            return data;
        }

        public async UniTask Write(byte[] data)
        {
            var stream = _tcpClient.GetStream();
            Debug.Log("write: " + BitConverter.ToString(data));
            stream.Write(data, 0, data.Length);
        }

        private void handleMessage(byte[] rawMessage)
        {
            Debug.Log("receiveData: " + BitConverter.ToString(rawMessage));
            switch (rawMessage[0])
            {
                case 1:
                    Debug.Log(rawMessage[0]);
                    Debug.Log(BitConverter.ToString(rawMessage[1..19]));
                    Debug.Log(BitConverter.ToString(BitConverter.GetBytes(1)));
                    this.Write(BitConverter.GetBytes(1));
                    break;
                case 2:
                    Debug.Log(rawMessage[0]);
                    break;
                case 3:
                    Debug.Log(rawMessage[0]);
                    Debug.Log(System.Text.Encoding.UTF8.GetString(rawMessage[1..38]));
                    break;
                case 4:
                    Debug.Log(rawMessage[0]);
                    break;
                default:
                    break;

            }
        }

    }
}
