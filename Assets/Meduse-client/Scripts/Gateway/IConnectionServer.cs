using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Meduse_client.Scripts.Gateway
{
    public interface IConnectionServer
    {
        UniTask<byte[]> Read();
        UniTask Write(byte[] data);
    }
}
