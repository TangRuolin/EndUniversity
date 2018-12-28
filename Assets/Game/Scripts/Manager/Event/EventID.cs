using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class EventID
    {

        /// <summary>
        /// 场景事件的id，区间为(1,10）
        /// </summary>
        public enum SceneEvent
        {
            
        }
        /// <summary>
        /// 工具事件的id，区间为（10,100）
        /// </summary>
        public enum UtilsEvent
        {
            StartCoroutine = 11,
            StopCoroutine = 12,
            SynLoad = 13,
            AsynLoad = 14,
        }

        /// <summary>
        /// UI事件的id，区间为（100,200）
        /// </summary>
        public enum UIEvent
        {
            LogoPanel = 101,
            LoadPanel = 102,
        }


    }
}

