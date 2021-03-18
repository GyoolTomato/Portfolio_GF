using System;
using UnityEngine;

namespace Assets.Skill
{
    public class BasicAttack : Base.SkillBase
    {
        public BasicAttack()
        {
        }

        public override void Initialize(GameObject master, GameObject target, int damage)
        {
            base.Initialize(master, target, damage);

            m_isInit = true;
        }
    }
}
