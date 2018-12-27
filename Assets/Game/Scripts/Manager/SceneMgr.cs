using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class SceneMgr
    {

        private static SceneMgr _instance;
        public static SceneMgr Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SceneMgr();
                }
                return _instance;
            }
        }
        public void Init()
        {
            EventMgr.Instance.Add((int)EventID.SceneEvent.SynLoad, SynLoad);
            EventMgr.Instance.Add((int)EventID.SceneEvent.AsynLoad, AsynLoad);
        }

        /// <summary>
        /// 同步加载场景
        /// </summary>
        /// <param name="meg"></param>
        public void SynLoad(object meg)
        {
            string name = (string)meg;
            UnityEngine.SceneManagement.SceneManager.LoadScene(name);
        }
        /// <summary>
        /// 异步加载场景
        /// </summary>
        AsyncOperation async;
        public void AsynLoad(object meg)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Load");
            string name = (string)meg;
            object asynMeg = AsynLoading(name);
            EventMgr.Instance.Trigger((int)EventID.UtilsEvent.StartCoroutine, asynMeg);
            object loadMeg = async;
            EventMgr.Instance.Trigger((int)EventID.UIEvent.LoadPanel, loadMeg);
        }
        IEnumerator AsynLoading(string name)
        {
            async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(name);
            async.allowSceneActivation = false;
            yield return async;
        }

    }

}
