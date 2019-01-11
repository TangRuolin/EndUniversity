using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerAction : MonoBehaviour
    {

        Animator anim;
        private float _num;
        IEnumerator ieMove;
        private void Start()
        {
            _num = 0;
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
        private void SetMove(object meg)
        {
            float num = (float)meg;
            if(_num == num)
            {
                return;
            }
            if (ieMove != null)
            {
                StopCoroutine(ieMove);
            }
            if (anim == null)
            {
                return;
            }
            ieMove = SetMoveIE(_num, num);
            _num = num;
            StartCoroutine(ieMove);
        }

        private IEnumerator SetMoveIE(float start,float end)
        {
            if(start <= end)
            {
                for (float i = start; i <= end; i += 0.01f)
                {
                    anim.SetFloat("MoveOrIdle", i);
                    yield return null;
                }
            }
            else
            {
                for (float i = start; i >= end; i -= 0.01f)
                {
                    anim.SetFloat("MoveOrIdle", i);
                    yield return null;
                }
            }
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
