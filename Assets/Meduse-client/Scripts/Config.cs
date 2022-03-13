using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ApplicationConfigs : ScriptableObject
{
    //��Ƃ���Photo�ݒ�,�T�[�o�ݒ�ANCMB�̐ݒ������
    public PhotonConfig PhotonConfig;
    public ApiConfig ApiConfig;
    public NcmbConfig NcmbConfig;
}

[Serializable]
public class ApiConfig
{
    public string BaseUrl = "";
}

[Serializable]
public class PhotonConfig
{
    public string gameVersion = "";
}

[Serializable]
public class NcmbConfig
{
    public string ApplicationKey = "";
    public string ClientKey = "";
}
