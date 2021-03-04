using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Character.Base
{
    public class CharacterBase : MonoBehaviour
    {
        public enum E_Team
        {
            Player,
            Enemy,
            End,
        }

        public enum E_State
        {
            Idle,
            Walk,
            Run,
            Attack,
            Die,
            End,
        }

        protected Assets.Common.GameManager m_gameManager;
        private bool m_isInit;
        private Assets.Common.DB.Index.IndexDataBase_TDoll m_baseStat;
        private Assets.Common.DB.User.UserDataBase_TDoll m_userStat;
        private Animator m_animator;
        private E_State m_state;
        private string m_stringIsIdle;
        private string m_stringIsWalk;
        private string m_stringIsRun;
        private string m_stringIsAttack;
        private string m_stringIsDie;

        public CharacterBase()
        {

        }

        protected virtual void Awake()
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<Common.GameManager>();
            m_animator = GetComponent<Animator>();
            m_state = E_State.Idle;
            m_stringIsIdle = "isIdle";
            m_stringIsWalk = "isWalk";
            m_stringIsRun = "isRun";
            m_stringIsAttack = "isAttack";
            m_stringIsDie = "isDie";
        }

        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {
            if (!m_isInit)            
                return;

            switch (m_state)
            {
                case E_State.Idle:
                    Idle();
                    break;
                case E_State.Walk:
                    Walk();
                    break;
                case E_State.Run:
                    Run();      
                    break;
                case E_State.Attack:
                    Attack();
                    break;
                case E_State.Die:
                    Die();
                    break;
                default:
                    break;
            }
        }

        public void Initialize(E_Team team, Common.DB.User.UserDataBase_TDoll userStat)
        {
            switch (team)
            {
                case E_Team.Player:
                    transform.tag = "Player";
                    break;
                case E_Team.Enemy:
                    transform.tag = "Enemy";
                    var temp = transform.localScale;
                    temp.x = temp.x * -1;
                    transform.localScale = temp;
                    break;
                default:
                    break;
            }

            m_userStat = userStat;            

            if (m_userStat != null && m_baseStat != null)
            {
                m_isInit = true;
            }           
        }

        protected void Initialize(Common.DB.Index.IndexDataBase_TDoll baseStat)
        {
            m_baseStat = baseStat;
        }

        private void Idle()
        {
            if (TargetingEnemy() == null)
                return;
        }

        private void Walk()
        {
            if (TargetingEnemy() == null)
                SetState(E_State.Idle);
        }

        private void Run()
        {
            if (TargetingEnemy() == null)
                SetState(E_State.Idle);

            if (IsInAttackRange())
            {
                SetState(E_State.Attack);
            }
            else
            {
                transform.Translate(Vector2.right * Time.deltaTime);
            }
        }

        private void Attack()
        {
            if (TargetingEnemy() == null)            
                SetState(E_State.Idle);            

            if (IsInAttackRange())
            {

            }
            else
            {
                SetState(E_State.Idle);
            }
        }

        private void Die()
        {

        }

        private void SetState(E_State state)
        {
            m_state = state;
            SetAnim(m_state);
        }

        protected void SetAnim(E_State state)
        {
            m_animator.SetBool(m_stringIsIdle, false);
            m_animator.SetBool(m_stringIsWalk, false);
            m_animator.SetBool(m_stringIsRun, false);
            m_animator.SetBool(m_stringIsAttack, false);
            m_animator.SetBool(m_stringIsDie, false);

            switch (m_state)
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

        protected CharacterBase TargetingEnemy()
        {
            var target = new CharacterBase();
            var enemies = new List<CharacterBase>();

            if (this.tag.Equals("Player"))
            {
                foreach (var item in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    if (item.GetComponent<CharacterBase>() != null)
                    {
                        enemies.Add(item.GetComponent<CharacterBase>());
                    }
                }
            }
            else if (this.tag.Equals("Enemy"))
            {
                foreach (var item in GameObject.FindGameObjectsWithTag("Player"))
                {
                    if (item.GetComponent<CharacterBase>() != null)
                    {
                        enemies.Add(item.GetComponent<CharacterBase>());
                    }
                }
            }

            if (enemies.Count == 0)
                return null;

            var distance_0 = 0.0f;
            var distance_1 = 0.0f;
            for (int i = 0; i < enemies.Count; i++)
            {
                if (i == 0)
                    target = enemies[0];
                else
                {
                    distance_0 = Vector3.Distance(target.transform.position, transform.position);
                    distance_1 = Vector3.Distance(enemies[i].transform.position, transform.position);
                    if (distance_0 > distance_1)
                    {
                        target = enemies[i];
                    }
                }
            }

            return target;
        }

        private bool IsInAttackRange()
        {
            if (TargetingEnemy() != null)
            {
                if (Vector3.Distance(TargetingEnemy().transform.position, transform.position) <= m_baseStat.AttackRange)
                {
                    return true;
                }
            }

            return false;
        }
    }
}