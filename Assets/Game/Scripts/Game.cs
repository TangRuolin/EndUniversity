using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    // Use this for initialization

    
    private void Awake()
    {
        //this.gameObject.AddComponent<Utils>();
        Utils.Instance.Init();
        SceneMgr.Instance.Init();
    }
    
	
   

}
