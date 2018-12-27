using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Game
{
    public class LogoPanel : MonoBehaviour
    {

        GameObject text;
        // Use this for initialization
        void Start()
        {
            text = GameObject.Find("Biaoyu");
            Show();
            LogoCtr.Instance.Init();
        }

        /// <summary>
        /// 界面展示
        /// </summary>
        void Show()
        {
            text.transform.GetComponent<Text>().DOFade(1, 3);
            object meg = (object)LoadScene();
           // EventMgr.Instance.Trigger((int)EventID.UtilsEvent.StartCoroutine, meg);
        }
        /// <summary>
        /// 场景切换
        /// </summary>
        /// <returns></returns>
        IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(Const.logoBiaoyuTime);
            string scene = "Main";
            object meg = scene;
            EventMgr.Instance.Trigger((int)EventID.SceneEvent.AsynLoad, meg);
        }

    }
}

