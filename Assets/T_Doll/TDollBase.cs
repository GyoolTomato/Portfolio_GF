using System;
using UnityEngine;

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
protected Assets.GameManager.DB.DataBase_TDoll m_status;

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
}
