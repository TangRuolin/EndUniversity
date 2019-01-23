using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

namespace Game
{
    public class Player
    {
        /// <summary>
        /// 单例
        /// </summary>
        private static Player _instance;
        public static Player Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Player();
                    _instance.Init();
                }
                return _instance;
            }
        }

        public int _attackNum { get; private set; }  //攻击次数，用于判断有没有触发强力攻击
        public float moveSpe { get; private set; }  //玩家移动速度
        private bool _isQuick;    //玩家是否快速移动
        public bool canMove { get; set; }
        private List<GameObject> arrows;
        public GameObject arrowModel;
        public Transform arrowPos;
        private IEnumerator arrowMove;

        
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            _attackNum = 0;
            moveSpe = 0;
            _isQuick = false;
            canMove = true;
            EventMgr.Instance.Add((int)EventID.PlayerEvent.moveSpeChange,SetIsQuick);
            arrows = new List<GameObject>();
        }

        /// <summary>
        /// 玩家移速是否更改
        /// </summary>
        /// <param name="meg"></param>
        private void SetIsQuick(object meg)
        {
            bool isQ = (bool)meg;
            _isQuick = isQ;
        }
        //角色动画控制
        #region
        /// <summary>
        /// 普通攻击
        /// </summary>
        public void Attack()
        {
            //_attackNum++;
            _attackNum = 1;
            object meg = _attackNum;
            EventMgr.Instance.Trigger((int)EventID.AnimEvent.PlayerAttack,meg);
            //if (_attackNum == 3)
            //{
            //    CreateArrow(3);
            //    _attackNum = 0;
            //    return;
            //}
            CreateArrow();
            
        }
        /// <summary>
        /// 创建箭矢
        /// </summary>
        private void CreateArrow()
        {
            GameObject arrow;
            if (arrows.Count == 0)
            {
                arrow = GameObject.Instantiate(arrowModel);
               // arrow.transform.SetParent(arrowPos);
                arrows.Add(arrow);
            }
            else
            {
                arrow = arrows[0];
            } 
            arrow.transform.position = arrowPos.transform.position;
            arrow.transform.rotation = arrowModel.transform.rotation;
            if(arrowMove != null)
            {
                object message = arrowMove;
                EventMgr.Instance.Trigger((int)EventID.UtilsEvent.StopCoroutine, message);
            }
            arrowMove = ArrowMove(arrow);
            object meg = arrowMove;
            EventMgr.Instance.Trigger((int)EventID.UtilsEvent.StartCoroutine, meg);
        }

        IEnumerator ArrowMove(GameObject arrow)
        {
            float distance = 0;
            yield return new WaitForSeconds(Const.arrowMoveYieldTime);
            arrow.SetActive(true);
            while(distance < Const.arrowMoveDis)
            {
                distance += Time.deltaTime * Const.arrowMoveSpe;
                arrow.transform.Translate(Vector3.forward * Time.deltaTime * Const.arrowMoveSpe);
                yield return null;
            }
            
            yield return new WaitForSeconds(Const.arrowContinue);
            arrow.SetActive(false);
        }
        /// <summary>
        /// 技能攻击
        /// </summary>
        /// <param name="skillNum"></param>
        public void Skill(int skillNum)
        {
            object meg = skillNum;
            EventMgr.Instance.Trigger((int)EventID.AnimEvent.PlayerSkill, meg);
        }
        /// <summary>
        /// 角色移动
        /// </summary>
        public void Move()
        {
            float num;
            if (_isQuick)
            {
                moveSpe = Const.playerMoveSpeQ;
                num = 1f;
            }
            else
            {
                moveSpe = Const.playerMoveSpe;
                num = 0.9f;
            }
            
            object meg = num;
            EventMgr.Instance.Trigger((int)EventID.AnimEvent.PlayerMove, meg);
        }


        /// <summary>
        /// 角色静止
        /// </summary>
        public void Idel()
        {
            float num = 0f;
            object meg = num;
            EventMgr.Instance.Trigger((int)EventID.AnimEvent.PlayerMove, meg);
        }
        #endregion


    }
}

