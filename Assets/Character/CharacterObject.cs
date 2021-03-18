using System;
using UnityEngine;

namespace Assets.Character
{
    public static class CharacterObject
    {
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

        public static GameObject DataCodeObject(int dataCode)
        {
            switch (dataCode)
            {
                case 1:
                    return Healer();                    
                case 2:
                    return Sorceress();
                case 3:
                    return Wizzard();
                case 4:
                    return Archer();
                case 5:
                    return GirlArcher();
                case 6:
                    return HoodArcher();
                case 7:
                    return BoyKnight();
                case 8:
                    return ChargeKnight();
                case 9:
                    return ElfKnight();
                default:
                    return null;                    
            }
        }
    }
}