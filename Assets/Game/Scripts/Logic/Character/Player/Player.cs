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
                }
                return _instance;
            }
        }

        public int _attackNum { get; private set; }  //攻击次数，用于判断有没有触发强力攻击

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            _attackNum = 0;
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
            object meg = 0.9;
            EventMgr.Instance.Trigger((int)EventID.AnimEvent.PlayerMove, meg);
        }
        /// <summary>
        /// 角色静止
        /// </summary>
        public void Idel()
        {
            object meg = 0;
            EventMgr.Instance.Trigger((int)EventID.AnimEvent.PlayerMove, meg);
        }
        /// <summary>
        /// 角色快速移动
        /// </summary>
        public void MoveQuick()
        {
            object meg = 1;
            EventMgr.Instance.Trigger((int)EventID.AnimEvent.PlayerMove, meg);
        }
        #endregion


    }
}

