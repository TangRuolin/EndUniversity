using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr {

    private static UIMgr _instance;
    public static UIMgr Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new UIMgr();
            }
            return _instance;
        }
    }
    public void Init()
    {

    }

	
}
