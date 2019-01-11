using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public int moveSpe { get; private set; }  //玩家移动速度
        private bool _isQuick;    //玩家是否快速移动

        
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            _attackNum = 0;
            moveSpe = Const.playerMoveSpe;
            _isQuick = false;
            EventMgr.Instance.Add((int)EventID.PlayerEvent.moveSpeChange,SetIsQuick);
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
            _attackNum++;
            object meg = _attackNum;
            EventMgr.Instance.Trigger((int)EventID.AnimEvent.PlayerAttack,meg);
            if(_attackNum == 3)
            {
                _attackNum = 0;
            }
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

