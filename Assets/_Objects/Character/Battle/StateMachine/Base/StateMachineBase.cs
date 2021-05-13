using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Character.Battle.StateMachine.Base
{
    public class StateMachineBase
    {
        public enum E_State
        {
            Idle,
            Walk,
            Run,
            SkillAction,
            Die,
            End,
        }

        protected Animator m_animator;
        protected Battle.Base.CharacterBase m_characterBase;
        protected float m_animationCorrection = 1.5f;
        protected readonly string m_stringIsIdle = "isIdle";
        protected readonly string m_stringIsWalk = "isWalk";
        protected readonly string m_stringIsRun = "isRun";
        protected readonly string m_stringIsAttack = "isAttack";
        protected readonly string m_stringIsDie = "isDie";

        public void Initialize(Animator animator, Battle.Base.CharacterBase characterBase)
        {
            m_animator = animator;
            m_characterBase = characterBase;
        }

        protected virtual void LoadAnimation()
        {
            m_animator.SetBool(m_stringIsIdle, false);
            m_animator.SetBool(m_stringIsWalk, false);
            m_animator.SetBool(m_stringIsRun, false);
            m_animator.SetBool(m_stringIsAttack, false);
            m_animator.SetBool(m_stringIsDie, false);
        }

        public virtual void Action()
        {
            LoadAnimation();
        }

        public virtual void Action(Battle.Base.CharacterBase targetCharacterBase, GameObject skillObject)
        {
            LoadAnimation();
        }
    }
}