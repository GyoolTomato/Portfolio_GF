using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Character.Battle.Base;
using Assets.Skill;

namespace Assets.Character.Battle
{
    public class Healer : CharacterBase
    {
        public Healer()
        {
        }

        protected override void Awake()
        {
            base.Awake();
            Initialize(m_gameManager.GetIndexDBController().TDoll(1));
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

            if (TargetingAlly() != null)
            {
                var temp = Instantiate(SkillObject.Heal(), new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                temp.transform.parent = m_objectParent;
                var tempScript = temp.GetComponent<Skill.Base.SkillBase>();
                tempScript.Initialize(gameObject, TargetingAlly().gameObject, m_stat.FirePower);
            }
            else if (TargetingEnemy() != null)
            {
                var temp = Instantiate(SkillObject.Magic(), new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                temp.transform.parent = m_objectParent;
                var tempScript = temp.GetComponent<Skill.Base.SkillBase>();
                tempScript.Initialize(gameObject, TargetingEnemy().gameObject, m_stat.FirePower);
            }
        }

        private CharacterBase TargetingAlly()
        {
            GameObject target = null;
            var allies = new List<GameObject>();

            if (this.tag.Equals("Player"))
            {
                foreach (var item in GameObject.FindGameObjectsWithTag("Player"))
                {
                    if (item.GetComponent<CharacterBase>() != null)
                    {
                        allies.Add(item);
                    }
                }
            }
            else if (this.tag.Equals("Enemy"))
            {
                foreach (var item in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    if (item.GetComponent<CharacterBase>() != null)
                    {
                        allies.Add(item);
                    }
                }
            }

            if (allies.Count == 0)
                return null;

            var distance_0 = 0.0f;
            var distance_1 = 0.0f;
            for (int i = 0; i < allies.Count; i++)
            {
                if (i == 0)
                    target = allies[0];
                else
                {
                    distance_0 = Vector3.Distance(target.transform.position, transform.position);
                    distance_1 = Vector3.Distance(allies[i].transform.position, transform.position);
                    if (distance_0 < distance_1)
                    {
                        target = allies[i];
                    }
                }
            }

            return target.GetComponent<CharacterBase>();
        }
    }
}