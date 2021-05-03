using System;
using System.Collections;
using UnityEngine;


namespace Assets.Skill
{
    public class Heal : Base.SkillBase
    {
        public Heal()
        {
        }

        public override void Initialize(GameObject master, GameObject target, int damage, bool isInstanceBoom)
        {
            base.Initialize(master, target, damage, isInstanceBoom);

            var healValue = -(int)(damage / 2);
            m_damage = healValue;

            m_isInit = true;
        }        
    }
}