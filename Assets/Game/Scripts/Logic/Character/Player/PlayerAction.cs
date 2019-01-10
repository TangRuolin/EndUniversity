using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerAction : MonoBehaviour
    {

        Animator anim;
        private void Start()
        {
            anim = this.GetComponent<Animator>();
            EventMgr.Instance.Add((int)EventID.AnimEvent.PlayerMove,SetMove);
            EventMgr.Instance.Add((int)EventID.AnimEvent.PlayerDead, Dead);
            EventMgr.Instance.Add((int)EventID.AnimEvent.PlayerSkill, SetSkill);
            EventMgr.Instance.Add((int)EventID.AnimEvent.PlayerAttack, SetAttack);
        }
        /// <summary>
        /// 角色静止或跑动
        /// </summary>
        /// <param name="num"></param>静止：0，跑动：0.9，加速跑：1
        private void SetMove(object num)
        {
            if (anim == null)
            {
                return;
            }
            anim.SetFloat("MoveOrIdel", (float)num);
        }
        /// <summary>
        /// 角色死亡
        /// </summary>
        private void Dead(object meg)
        {
            if (anim == null)
            {
                return;
            }
            anim.SetBool("Dead", true);
            anim.SetBool("Dead", false);
        }
       
        /// <summary>
        /// 角色释放技能
        /// </summary>
        /// <param name="skill"></param>
        private void SetSkill(object skill)
        {
            if (anim == null)
            {
                return;
            }
            anim.SetInteger("Skill", (int)skill);
            anim.SetInteger("Skill", 0);
        }
        /// <summary>
        /// 角色攻击（普攻的第三次是强力攻击）
        /// </summary>
        /// <param name="attack"></param>普通攻击：1、2，强力攻击：3
        private void SetAttack(object attack)
        {
            if (anim == null)
            {
                return;
            }
            anim.SetInteger("Attack", (int)attack);
            anim.SetInteger("Attack", 0);
        }
    }

}
