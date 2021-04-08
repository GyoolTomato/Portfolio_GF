using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Character.Battle.Base;
using Assets.Skill;

namespace Assets.Character.Battle
{
    public class Healer : CharacterBase
    {
        private int m_maxHealStack;
        private int m_healStack;

        public Healer()
        {
        }

        protected override void Awake()
        {
            base.Awake();
            Initialize(m_gameManager.GetIndexDBController().TDoll(1), 1.5f);
            m_maxHealStack = 3;
            m_healStack = 0;
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
                var temp = Instantiate(SkillObject.NearAttack(), new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                var tempScript = temp.GetComponent<Skill.Base.SkillBase>();
                tempScript.Initialize(gameObject, TargetingEnemy().gameObject, m_stat.FirePower);

                m_healStack++;
                if (m_healStack >= m_maxHealStack)
                {
                    Healing();
                    m_healStack = 0;
                }
            }
        }

        private void Healing()
        {
            foreach (var item in GameObject.FindGameObjectsWithTag(this.tag))
            {
                var temp = item.GetComponent<CharacterBase>();
                if (temp != null)
                {
                    var healingObject = Instantiate(SkillObject.Heal(), new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                    var tempScript = healingObject.GetComponent<Skill.Base.SkillBase>();
                    tempScript.Initialize(gameObject, temp.gameObject, m_stat.FirePower);
                }
            }
        }

        //protected override void AttackAction()
        //{
        //    base.AttackAction();

        //    if (TargetingAlly() != null)
        //    {
        //        var temp = Instantiate(SkillObject.Heal(), new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);                
        //        var tempScript = temp.GetComponent<Skill.Base.SkillBase>();
        //        tempScript.Initialize(gameObject, TargetingAlly().gameObject, m_stat.FirePower);
        //    }
        //    else if (TargetingEnemy() != null)
        //    {
        //        var temp = Instantiate(SkillObject.Magic(), new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);                
        //        var tempScript = temp.GetComponent<Skill.Base.SkillBase>();
        //        tempScript.Initialize(gameObject, TargetingEnemy().gameObject, m_stat.FirePower);
        //    }
        //}

        //private CharacterBase TargetingAlly()
        //{
        //    GameObject target = null;
        //    var allies = new List<GameObject>();

        //    if (this.tag.Equals("Player"))
        //    {
        //        foreach (var item in GameObject.FindGameObjectsWithTag("Player"))
        //        {
        //            if (item.GetComponent<CharacterBase>() != null)
        //            {
        //                allies.Add(item);
        //            }
        //        }
        //    }
        //    else if (this.tag.Equals("Enemy"))
        //    {
        //        foreach (var item in GameObject.FindGameObjectsWithTag("Enemy"))
        //        {
        //            if (item.GetComponent<CharacterBase>() != null)
        //            {
        //                allies.Add(item);
        //            }
        //        }
        //    }

        //    if (allies.Count == 0)
        //        return null;

        //    var distance_0 = 0.0f;
        //    var distance_1 = 0.0f;
        //    for (int i = 0; i < allies.Count; i++)
        //    {
        //        if (i == 0)
        //            target = allies[0];
        //        else
        //        {
        //            distance_0 = Vector3.Distance(target.transform.position, transform.position);
        //            distance_1 = Vector3.Distance(allies[i].transform.position, transform.position);
        //            if (distance_0 < distance_1)
        //            {
        //                target = allies[i];
        //            }
        //        }
        //    }

        //    return target.GetComponent<CharacterBase>();
        //}
    }
}