using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Character.Battle.Base
{
    public class CharacterBase : MonoBehaviour
    {
        protected Assets.Common.ResourceManager m_resourceManager;
        protected DB.DbManager m_dbManager;
        private bool m_isInit;
        protected CharacterStat m_characterStat;
        //private Assets.Common.DB.Index.IndexDataBase_TDoll m_baseStat;
        //private Assets.Common.DB.User.UserDataBase_TDoll m_userStat;        
        private Team m_team;     
        protected Animator m_animator;
                
        private float m_elapsedTimeAttackDelay;
        private float m_animationCorrection;

        protected virtual void Awake()
        {
            m_resourceManager = GameObject.Find("GameManager").GetComponent<Common.ResourceManager>();
            m_dbManager = GameObject.Find("GameManager").GetComponent<DB.DbManager>();
            m_characterStat = new CharacterStat();

            m_animator = GetComponent<Animator>();
        }

        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {
            if (!m_isInit)
                return;

            if (m_elapsedTimeAttackDelay > 0.0f)            
                m_elapsedTimeAttackDelay -= Time.deltaTime;

            StateMachine();
        }

        public void Initialize(Team team, DB.User.UserDataBase_TDoll userStat)
        {
            m_team = team;
            switch (m_team)
            {
                case Team.Player:
                    transform.tag = "Player";
                    break;
                case Team.Enemy:
                    transform.tag = "Enemy";
                    var temp = transform.localScale;
                    temp.x = temp.x * -1;
                    transform.localScale = temp;
                    break;
                default:
                    break;
            }

            var adjustLevel = 1;
            m_characterStat.MaxHp = (int)(m_characterStat.Hp * adjustLevel);
            m_characterStat.Hp = (int)(m_characterStat.Hp * adjustLevel);
            m_characterStat.FirePower = (int)(m_characterStat.FirePower * adjustLevel);
            m_characterStat.Critical = (int)(m_characterStat.Critical * adjustLevel);
            m_characterStat.Focus = (int)(m_characterStat.Focus * adjustLevel);
            m_characterStat.Armor = (int)(m_characterStat.Armor * adjustLevel);
            m_characterStat.Avoidance = (int)(m_characterStat.Avoidance * adjustLevel);

            var equipments = new List<DB.Index.IndexDataBase_Equipment>();
            equipments.Add(m_dbManager.GetIndexDBController().Equipment(userStat.EquipmentOwnershipNumber0));
            equipments.Add(m_dbManager.GetIndexDBController().Equipment(userStat.EquipmentOwnershipNumber1));
            equipments.Add(m_dbManager.GetIndexDBController().Equipment(userStat.EquipmentOwnershipNumber2));
            foreach (var item in equipments)
            {
                if (item != null)
                {
                    m_characterStat.Armor += item.Armor;
                    m_characterStat.Critical += item.Critical;
                    m_characterStat.FirePower += item.FirePower;
                    m_characterStat.Focus += item.Focus;
                }
            }

            var sortingGroup = GetComponent<SortingGroup>();
            sortingGroup.sortingOrder = (int)(Math.Abs(transform.position.y) * 10);

            m_isInit = true; 
        }

        public void Initialize(Team team, Assets.Scenes.StageField.Controller.EnemyData.Base.EnemyMember enemyStat)
        {
            if (team == Team.Enemy)
            {
                var temp = transform.localScale;
                temp.x = temp.x * -1;
                transform.localScale = temp;

                transform.tag = "Enemy";
            }
            else
            {
                transform.tag = "Player";
            }

            var adjustLevel = 1 /*(double)userStat.Level / (double)100*/;
            m_team = team;
            m_characterStat.MaxHp = m_characterStat.Hp * adjustLevel;
            m_characterStat.Hp = m_characterStat.Hp * adjustLevel;
            m_characterStat.FirePower = m_characterStat.FirePower * adjustLevel;
            m_characterStat.Critical = m_characterStat.Critical * adjustLevel;
            m_characterStat.Focus = m_characterStat.Focus * adjustLevel;
            m_characterStat.Armor = m_characterStat.Armor * adjustLevel;
            m_characterStat.Avoidance = m_characterStat.Avoidance * adjustLevel;

            var sortingGroup = GetComponent<SortingGroup>();
            sortingGroup.sortingOrder = (int)(Math.Abs(transform.position.y) * 10);

            m_isInit = true;
        }


        protected void Initialize(DB.Index.IndexDataBase_TDoll baseStat, float animationCorrection)
        {
            m_characterStat.MaxHp = baseStat.Hp;
            m_characterStat.Hp = baseStat.Hp;
            m_characterStat.FirePower = baseStat.FirePower;
            m_characterStat.AttackSpeed = baseStat.AttackSpeed;
            m_characterStat.AttackRange = baseStat.AttackRange;
            m_characterStat.Critical = baseStat.Critical;
            m_characterStat.Focus = baseStat.Focus;
            m_characterStat.Armor = baseStat.Armor;
            m_characterStat.Avoidance = baseStat.Avoidance;
            m_characterStat.MoveSpeed = baseStat.MoveSpeed;

            m_animationCorrection = animationCorrection;
        }

        public void ApplyDamage(int damage)
        {
            m_characterStat.Hp -= damage;
            if (m_characterStat.Hp > m_characterStat.MaxHp)
            {
                m_characterStat.Hp = m_characterStat.MaxHp;
            }
        }

        protected CharacterBase TargetingEnemy()
        {
            GameObject target = null;            

            var unitsObject = GameObject.Find("BattleField").transform.Find("Units");
            var characters = unitsObject.GetComponentsInChildren<CharacterBase>();
            var livedEnemies = new List<GameObject>();

            foreach (var item in characters)
            {
                if (!item.GetTeam().Equals(m_team) && item.GetCharacterStat().Hp > 0)
                {
                    livedEnemies.Add(item.gameObject);
                }                
            }

            if (livedEnemies.Count == 0)
                return null;

            for (int i = 0; i < livedEnemies.Count; i++)
            {
                if (i == 0)
                    target = livedEnemies[0];
                else
                {
                    var distance_0 = Vector3.Distance(target.transform.position, transform.position);
                    var distance_1 = Vector3.Distance(livedEnemies[i].transform.position, transform.position);
                    if (distance_0 > distance_1)
                    {
                        target = livedEnemies[i];
                    }
                }
            }

            return target.GetComponent<CharacterBase>();
        }

        protected bool IsInAttackRange()
        {
            if (TargetingEnemy() != null)
            {
                if (Vector3.Distance(TargetingEnemy().transform.position, transform.position) <= m_characterStat.AttackRange)
                {
                    return true;
                }
            }

            return false;
        }

        public CharacterStat GetCharacterStat() => m_characterStat;
        public Team GetTeam() => m_team;

        protected virtual void StateMachine()
        {

        }
    }
}