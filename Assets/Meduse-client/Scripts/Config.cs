using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Configs : ScriptableObject
{
    public ServerConfig ServerConfig;
}

[Serializable]
public class ServerConfig
{
    public string Url = "";
    public string Port = "";
}
