using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Character.Battle.Base;
using Assets.Skill;

namespace Assets.Character.Battle
{
    public class Wizzard : Base.CharacterBase
    {
        public Wizzard()
        {
        }

        protected override void Awake()
        {
            base.Awake();
            Initialize(m_dbManager.GetIndexDBController().TDoll(3), 1.5f);
        }

        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void AttackAction()
        {
            base.AttackAction();

            if (TargetingEnemy() != null)
            {
                var temp = Instantiate(SkillObject.Magic(), new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);                
                var tempScript = temp.GetComponent<Skill.Base.SkillBase>();
                tempScript.Initialize(gameObject, TargetingEnemy().gameObject, m_stat.FirePower);
            }
        }
    }
}