using System;
using System.Collections;
using UnityEngine;
using Assets.Character.Battle.Base;

namespace Assets.Skill
{
    public class Heal : Base.SkillBase
    {
        public Heal()
        {
        }

        public override void Initialize(CharacterBase master, CharacterBase target, int damage, bool isInstanceBoom)
        {
            base.Initialize(master, target, damage, isInstanceBoom);

            var healValue = -(int)(damage / 2);
            m_damage = healValue;

            m_isInit = true;
        }        
    }
}