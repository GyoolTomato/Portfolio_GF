using System;
using UnityEngine;

namespace Assets.Skill
{
    public class Magic : Base.SkillBase
    {
        public Magic()
        {
        }

        public override void Initialize(GameObject master, GameObject target, int damage)
        {
            base.Initialize(master, target, damage);

            m_isInit = true;
            m_speed = 8;
        }
    }
}
