using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameStart : MonoBehaviour
    {

        // Use this for initialization


        private void Awake()
        {
            DontDestroyOnLoad(this);
            this.gameObject.AddComponent<Utils>().Init();
            SceneMgr.Instance.Init();
        }




    }
}

