using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class LoadCtr
    {

        private static LoadCtr _instance;
        public static LoadCtr Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoadCtr();
                }
                return _instance;
            }
        }
        public float Nload { get; private set; }
        AsyncOperation asy;
        /// <summary>
        /// Load场景数据初始化
        /// </summary>
        public void Init()
        {
            Nload = 0;
            EventMgr.Instance.Add((int)EventID.UIEvent.LogoPanel, Recive);
            EventMgr.Instance.Trigger((int)EventID.UtilsEvent.StartCoroutine,(object)LoadScene());
        }
        /// <summary>
        /// 场景跳转条件
        /// </summary>
        /// <returns></returns>
        IEnumerator LoadScene()
        {
            if (Nload >= 0.9)
            {
                asy.allowSceneActivation = true;
            }
            yield return null;
        }
        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="meg"></param>
        public void Recive(object meg)
        {
            asy = (AsyncOperation)meg;
            Nload = asy.progress;
        }

    }
}

