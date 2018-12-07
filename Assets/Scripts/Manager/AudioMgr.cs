using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr{

    private static AudioMgr _instance;
    public static AudioMgr Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new AudioMgr();
                _instance.Init();
            }
            return _instance;
        }
    }

    private void Init()
    {

    }
}
