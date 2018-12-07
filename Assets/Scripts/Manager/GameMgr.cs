using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {

    private static GameMgr _instance;
    public static GameMgr Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameMgr();
            }
            return _instance;
        }
    }

}
