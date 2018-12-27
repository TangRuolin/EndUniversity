using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Utils : MonoBehaviour
    {
        /// <summary>
        /// 初始化，添加事件
        /// </summary>
        public void Init()
        {
            EventMgr.Instance.Add((int)EventID.UtilsEvent.StartCoroutine, CoroutineStart);
            EventMgr.Instance.Add((int)EventID.UtilsEvent.StopCoroutine, CoroutineStop);
        }
        ////协程工具类(启动和关闭)
        #region
        /// <summary>
        /// 启动协程
        /// </summary>
        /// <param name="meg"></param>
        private void CoroutineStart(object meg)
        {
            if (meg == null)
            {
                return;
            }
            IEnumerator cor = (IEnumerator)meg;
            StartCoroutine(cor);
        }
        /// <summary>
        /// 关闭协程
        /// </summary>
        /// <param name="meg"></param>
        private void CoroutineStop(object meg)
        {
            if(meg == null)
            {
                return;
            }
            IEnumerator cor = (IEnumerator)meg;
            StopCoroutine(cor);
        }
        #endregion


    }
}

