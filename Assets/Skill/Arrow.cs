using System;
using UnityEngine;

namespace Assets.Skill
{
    public class Arrow : Base.SkillBase
    {
        public Arrow()
        {
        }

        public override void Initialize(GameObject master, GameObject target, int damage)
        {
            base.Initialize(master, target, damage);

            m_isInit = true;
            m_speed = 10;
        }
    }
}
