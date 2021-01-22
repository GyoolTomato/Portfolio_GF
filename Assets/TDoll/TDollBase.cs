using System;
using UnityEngine;

namespace Assets.TDoll
{
    public class TDollBase : MonoBehaviour
    {
        protected enum E_State
        {
            Idle,
            Work,
            Run,
            Attack,
            Die,
            End,
        }

        protected Animator m_animator;
        protected E_State m_nowState;
        protected Assets.Common.DB.Index.IndexDataBase_TDoll m_status;

        protected virtual void Awake()
        {

        }

        protected virtual void Start()
        {
            m_animator = this.GetComponent<Animator>();
            ChangeState(E_State.Idle);
        }

        protected virtual void Update()
        {
            Debug.Log(m_nowState);
        }

        protected virtual void Initialize(Assets.Common.DB.Index.IndexDataBase_TDoll status)
        {
            m_status = status;
        }

        protected virtual void ChangeState(E_State state)
        {
            m_nowState = state;
            switch (m_nowState)
            {
                case E_State.Idle:
                    State_Idle();
                    break;
                case E_State.Work:
                    State_Work();
                    break;
                case E_State.Run:
                    State_Run();
                    break;
                case E_State.Attack:
                    State_Attack();
                    break;
                case E_State.Die:
                    State_Die();
                    break;
                default:
                    break;
            }
        }

        protected virtual void State_Idle()
        {
            if (m_animator.GetBool("isIdle") == false)
            {
                m_animator.SetBool("isHited", false);
                m_animator.SetBool("isIdle", true);
                m_animator.SetBool("isAttack", false);
                m_animator.SetBool("isWalk", false);
                m_animator.SetBool("isDie", false);
                m_animator.SetBool("isRun", false);
            }
        }

        protected virtual void State_Work()
        {
            if (m_animator.GetBool("isWalk") == false)
            {
                m_animator.SetBool("isWalk", true);
                m_animator.SetBool("isIdle", false);
            }
        }

        protected virtual void State_Run()
        {
            if (m_animator.GetBool("isRun") == false)
            {
                m_animator.SetBool("isRun", true);
                m_animator.SetBool("isIdle", false);
            }
        }

        protected virtual void State_Attack()
        {
            if (m_animator.GetBool("isAttack") == false)
            {
                m_animator.SetBool("isAttack", true);
                m_animator.SetBool("isIdle", false);
            }
        }

        protected virtual void State_Die()
        {
            if (m_animator.GetBool("isDie") == false)
            {
                m_animator.SetBool("isDie", true);
                m_animator.SetBool("isIdle", false);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (this.transform.tag.Equals(collision.transform.tag))
            {
                m_status.Hp--;

                if (m_status.Hp <= 0)
                {
                    ChangeState(E_State.Die);
                }
            }
        }
    }
}