using System;
using UnityEngine;

namespace Assets.Character
{
    public class CharacterObject
    {
        public CharacterObject()
        {
        }

        public static GameObject Healer()
        {
            return UnityEngine.Resources.Load<GameObject>("Character/Healer");
        }

        public static GameObject Sorceress()
        {
            return UnityEngine.Resources.Load<GameObject>("Character/Sorceress");
        }

        public static GameObject Wizzard()
        {
            return UnityEngine.Resources.Load<GameObject>("Character/Wizzard");
        }

        public static GameObject Archer()
        {
            return UnityEngine.Resources.Load<GameObject>("Character/Archer");
        }

        public static GameObject GirlArcher()
        {
            return UnityEngine.Resources.Load<GameObject>("Character/GirlArcher");
        }

        public static GameObject HoodArcher()
        {
            return UnityEngine.Resources.Load<GameObject>("Character/HoodArcher");
        }

        public static GameObject BoyKnight()
        {
            return UnityEngine.Resources.Load<GameObject>("Character/BoyKnight");
        }

        public static GameObject ChargeKnight()
        {
            return UnityEngine.Resources.Load<GameObject>("Character/ChargeKnight");
        }

        public static GameObject ElfKnight()
        {
            return UnityEngine.Resources.Load<GameObject>("Character/ElfKnight");
        }
    }
}