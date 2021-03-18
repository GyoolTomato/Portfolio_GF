using System;
using UnityEngine;

namespace Assets.Skill
{
    public static class SkillObject
    {
        public static GameObject NearAttack() => UnityEngine.Resources.Load<GameObject>("Skill/NearAttack");
        public static GameObject Arrow() => UnityEngine.Resources.Load<GameObject>("Skill/Arrow");
        public static GameObject Magic() => UnityEngine.Resources.Load<GameObject>("Skill/Magic");
        public static GameObject Heal() => UnityEngine.Resources.Load<GameObject>("Skill/Heal");
    }
}