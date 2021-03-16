using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Character.Board
{
    public class CharacterBase : MonoBehaviour
    {
        public enum E_State
        {
            Idle,
            Walk,
            Run,
            Attack,
            Die,
            End,
        }

        private Animator m_animator;
        private string m_stringIsIdle;
        private string m_stringIsWalk;
        private string m_stringIsRun;
        private string m_stringIsAttack;
        private string m_stringIsDie;

        public CharacterBase()
        {
        }

        private void Awake()
        {
            m_animator = GetComponent<Animator>();
            m_stringIsIdle = "isIdle";
            m_stringIsWalk = "isWalk";
            m_stringIsRun = "isRun";
            m_stringIsAttack = "isAttack";
            m_stringIsDie = "isDie";

            var sortingGroup = GetComponent<SortingGroup>();
            sortingGroup.sortingOrder = 99;
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        public void SetAnim(E_State state)
        {
            m_animator.SetBool(m_stringIsIdle, false);
            m_animator.SetBool(m_stringIsWalk, false);
            m_animator.SetBool(m_stringIsRun, false);
            m_animator.SetBool(m_stringIsAttack, false);
            m_animator.SetBool(m_stringIsDie, false);

            switch (state)
            {
                case E_State.Idle:
                    m_animator.SetBool(m_stringIsIdle, true);
                    break;
                case E_State.Walk:
                    m_animator.SetBool(m_stringIsWalk, true);
                    break;
                case E_State.Run:
                    m_animator.SetBool(m_stringIsRun, true);
                    break;
                case E_State.Attack:
                    m_animator.SetBool(m_stringIsAttack, true);
                    break;
                case E_State.Die:
                    m_animator.SetBool(m_stringIsDie, true);
                    break;
                default:
                    break;
            }
        }
    }
}