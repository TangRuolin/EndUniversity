using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMgr{

    private static SceneMgr _instance;
    public static SceneMgr Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new SceneMgr();
            }
            return _instance;
        }
    }
    public void Init()
    {
        EventMgr.Instance.Add((int)EventID.SceneEvent.SynLoad,SynLoad);
        EventMgr.Instance.Add((int)EventID.SceneEvent.AsynLoad, AsynLoad);
    }

    public void SynLoad(object meg)
    {
        string name = (string)meg;
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    public void AsynLoad(object meg)
    {

    }


}
