using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Character.Battle.StateMachine
{
    public class Idle : Base.StateMachineBase
    {
        protected override void LoadAnimation()
        {
            if (!m_animator.GetBool(m_stringIsIdle))
            {
                base.LoadAnimation();

                m_animator.speed = 1.0f;
                m_animator.SetBool(m_stringIsIdle, true);
            }
        }
    }
}