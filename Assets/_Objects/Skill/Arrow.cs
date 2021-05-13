using System;
using UnityEngine;
using Assets.Character.Battle.Base;

namespace Assets.Skill
{
    public class Arrow : Base.SkillBase
    {
        public Arrow()
        {
        }

        public override void Initialize(CharacterBase master, CharacterBase target, int damage, bool isInstanceBoom)
        {
            base.Initialize(master, target, damage, isInstanceBoom);

            m_isInit = true;
            m_speed = 10;
        }
    }
}
