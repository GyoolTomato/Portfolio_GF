using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Character.Battle.Base
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
            SkillAction,
            Die,
            End,
        }

        protected Assets.Common.GameManager m_gameManager;
        private bool m_isInit;
        protected CharacterStat m_stat;
        //private Assets.Common.DB.Index.IndexDataBase_TDoll m_baseStat;
        //private Assets.Common.DB.User.UserDataBase_TDoll m_userStat;        
        private E_Team m_team;
        private E_State m_state;
        
        private Animator m_animator;
        private string m_stringIsIdle;
        private string m_stringIsWalk;
        private string m_stringIsRun;
        private string m_stringIsAttack;
        private string m_stringIsDie;
        private float m_elapsedTimeAttackDelay;
        private float m_animationCorrection;

        protected virtual void Awake()
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<Common.GameManager>();
            m_stat = new CharacterStat();
            m_state = E_State.Idle;

            m_animator = GetComponent<Animator>();
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

            if (m_stat.Hp <= 0)
                SetState(E_State.Die);

            if (m_elapsedTimeAttackDelay > 0.0f)            
                m_elapsedTimeAttackDelay -= Time.deltaTime;            

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
                case E_State.SkillAction:
                    SkillAction();
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
            m_team = team;
            switch (m_team)
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

            var adjustLevel =  1 /*(double)userStat.Level / (double)100*/;
            m_stat.MaxHp = (int)(m_stat.Hp * adjustLevel);
            m_stat.Hp = (int)(m_stat.Hp * adjustLevel);
            m_stat.FirePower = (int)(m_stat.FirePower * adjustLevel);
            m_stat.Critical = (int)(m_stat.Critical * adjustLevel);
            m_stat.Focus = (int)(m_stat.Focus * adjustLevel);
            m_stat.Armor = (int)(m_stat.Armor * adjustLevel);
            m_stat.Avoidance = (int)(m_stat.Avoidance * adjustLevel);

            var equipments = new List<Common.DB.Index.IndexDataBase_Equipment>();
            equipments.Add(m_gameManager.GetIndexDBController().Equipment(userStat.EquipmentOwnershipNumber0));
            equipments.Add(m_gameManager.GetIndexDBController().Equipment(userStat.EquipmentOwnershipNumber1));
            equipments.Add(m_gameManager.GetIndexDBController().Equipment(userStat.EquipmentOwnershipNumber2));
            foreach (var item in equipments)
            {
                if (item != null)
                {
                    m_stat.Armor += item.Armor;
                    m_stat.Critical += item.Critical;
                    m_stat.FirePower += item.FirePower;
                    m_stat.Focus += item.Focus;
                }
            }

            var sortingGroup = GetComponent<SortingGroup>();
            sortingGroup.sortingOrder = (int)(Math.Abs(transform.position.y) * 10);

            m_isInit = true; 
        }

        public void Initialize(E_Team team, Assets.Scene_StageField.Controller.EnemyData.Base.EnemyMember enemyStat)
        {
            m_team = team;
            switch (m_team)
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

            var adjustLevel = 1 /*(double)userStat.Level / (double)100*/;
            m_stat.MaxHp = m_stat.Hp * adjustLevel;
            m_stat.Hp = m_stat.Hp * adjustLevel;
            m_stat.FirePower = m_stat.FirePower * adjustLevel;
            m_stat.Critical = m_stat.Critical * adjustLevel;
            m_stat.Focus = m_stat.Focus * adjustLevel;
            m_stat.Armor = m_stat.Armor * adjustLevel;
            m_stat.Avoidance = m_stat.Avoidance * adjustLevel;

            var sortingGroup = GetComponent<SortingGroup>();
            sortingGroup.sortingOrder = (int)(Math.Abs(transform.position.y) * 10);

            m_isInit = true;
        }


        protected void Initialize(Common.DB.Index.IndexDataBase_TDoll baseStat, float animationCorrection)
        {
            m_stat.MaxHp = baseStat.Hp;
            m_stat.Hp = baseStat.Hp;
            m_stat.FirePower = baseStat.FirePower;
            m_stat.AttackSpeed = baseStat.AttackSpeed;
            m_stat.AttackRange = baseStat.AttackRange;
            m_stat.Critical = baseStat.Critical;
            m_stat.Focus = baseStat.Focus;
            m_stat.Armor = baseStat.Armor;
            m_stat.Avoidance = baseStat.Avoidance;
            m_stat.MoveSpeed = baseStat.MoveSpeed;

            m_animationCorrection = animationCorrection;
        }

        private void Idle()
        {
            if (TargetingEnemy() == null)
                return;
            else
            {
                if (IsInAttackRange())
                {
                    SetState(E_State.SkillAction);
                }
                else
                {
                    SetState(E_State.Run);
                }
            }
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
                SetState(E_State.SkillAction);
            }
            else
            {
                switch (m_team)
                {
                    case E_Team.Player:
                        transform.Translate(Vector2.right * Time.deltaTime * m_stat.MoveSpeed);
                        break;
                    case E_Team.Enemy:
                        transform.Translate(Vector2.left * Time.deltaTime * m_stat.MoveSpeed);
                        break;
                    default:
                        break;
                }
            }
        }

        protected virtual void SkillAction()
        {
            if (TargetingEnemy() == null)
                SetState(E_State.Idle);

            if (IsInAttackRange())
            {                
                if (m_elapsedTimeAttackDelay <= 0.0f)
                {                    
                    AttackAction();
                    m_elapsedTimeAttackDelay = m_stat.AttackSpeed;
                }
            }
            else
            {
                SetState(E_State.Idle);
            }
        }

        protected virtual void AttackAction() { }

        private void Die()
        {
            var collider = this.GetComponent<CapsuleCollider2D>();
            Destroy(collider);
            Invoke("DestroyObject", 1.0f);
        }

        private void DestroyObject()
        {
            Destroy(gameObject);
        }

        public void ApplyDamage(int damage)
        {            
            m_stat.Hp -= damage;
            if (m_stat.Hp > m_stat.MaxHp)
            {
                m_stat.Hp = m_stat.MaxHp;
            }
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
                    m_animator.speed = 1.0f;
                    m_animator.SetBool(m_stringIsIdle, true);
                    break;
                case E_State.Walk:
                    m_animator.speed = 1.0f;
                    m_animator.SetBool(m_stringIsWalk, true);
                    break;
                case E_State.Run:
                    m_animator.speed = 1.3f;
                    m_animator.SetBool(m_stringIsRun, true);
                    break;
                case E_State.SkillAction:
                    m_animator.speed = m_stat.AttackSpeed * m_animationCorrection;
                    m_animator.SetBool(m_stringIsAttack, true);
                    break;
                case E_State.Die:
                    m_animator.speed = 2.0f;
                    m_animator.SetBool(m_stringIsDie, true);
                    break;
                default:
                    break;
            }
        }        

        protected CharacterBase TargetingEnemy()
        {
            GameObject target = null;
            var enemies = new List<GameObject>();

            if (this.tag.Equals("Player"))
            {
                foreach (var item in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    if (item.GetComponent<CharacterBase>() != null)
                    {
                        enemies.Add(item);
                    }
                }
            }
            else if (this.tag.Equals("Enemy"))
            {
                foreach (var item in GameObject.FindGameObjectsWithTag("Player"))
                {
                    if (item.GetComponent<CharacterBase>() != null)
                    {
                        enemies.Add(item);
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

            return target.GetComponent<CharacterBase>();
        }

        private bool IsInAttackRange()
        {
            if (TargetingEnemy() != null)
            {
                if (Vector3.Distance(TargetingEnemy().transform.position, transform.position) <= m_stat.AttackRange)
                {
                    return true;
                }
            }

            return false;
        }

        public E_Team GetTeam()
        {
            return m_team;
        }        
    }
}