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
    }
}