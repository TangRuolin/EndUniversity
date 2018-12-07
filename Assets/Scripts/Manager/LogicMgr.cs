using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicMgr  {

    private static LogicMgr _instance;
    public static LogicMgr Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new LogicMgr();
            }
            return _instance;
        }
    }

    public void Init()
    {

    }
}
