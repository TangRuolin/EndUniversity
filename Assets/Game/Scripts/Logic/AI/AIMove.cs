using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace Game
{
    public class AIMove : MonoBehaviour
    {

        private NavMeshAgent agent;
        private GameObject target;
        private bool isTrackTarget;
        private bool isAttack;
        private Animator anim;
        private IEnumerator move;
        // Use this for initialization
        void Start()
        {
            agent = this.GetComponent<NavMeshAgent>();
            anim = this.GetComponent<Animator>();
            target = GameObject.Find("Player");
            isTrackTarget = false;
            isAttack = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (isTrackTarget)
            {
                if(move == null)
                {
                    move = SetMove();
                    StartCoroutine(move);
                }
                agent.SetDestination(target.transform.position);
            }
            if(Vector3.Distance(transform.position,target.transform.position) < Const.aiViewDis)
            {
                Vector3 dir = target.transform.position - transform.position;
                float angle = Vector3.Angle(dir,transform.forward);
                if(angle <= Const.aiViewAngle / 2){
                    isTrackTarget = true;
                }
            }
            if(isAttack && Vector3.Distance(transform.position,target.transform.position) < Const.aiAttackDis)
            {
                Attack();
                isAttack = false;
            }
        }
        /// <summary>
        /// AI攻击方式
        /// </summary>
        private void Attack()
        {
            if (anim == null)  return;
            anim.SetBool("Attack",true);
        }
        /// <summary>
        /// 改变移动方式
        /// </summary>
        /// <returns></returns>
        IEnumerator SetMove()
        {
            if (anim == null) yield return null;
            for (float i = 0; i <= 1; i += Const.playerMoveChangeTime)
            {
                anim.SetFloat("AIMove", i);
                yield return null;
            }
        }

        public void StopAttack()
        {
            if (anim == null) return;
            anim.SetBool("Attack", false);
        }

        /// <summary>
        /// 攻击是否成功
        /// </summary>
        public void AttackJudge()
        {
            if (Vector3.Distance(transform.position, target.transform.position) < Const.aiAttackDis)
            {
                Vector3 dir = target.transform.position - transform.position;
                float angle = Vector3.Angle(dir, transform.forward);
                if (angle <= Const.aiViewAngle / 2)
                {
                    Debug.Log("主人公掉血");
                }
            }
        }

      

    }
}

