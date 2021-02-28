using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Common.Controller
{
    public class SpriteController
    {
        public SpriteController()
        {
        }

        public void Initialize()
        {

        }

        public Sprite GetCharacterImage(int dataCode)
        {
            switch (dataCode)
            {
                case 1:
                    return UnityEngine.Resources.Load<Sprite>("Character/Healer");
                case 2:
                    return UnityEngine.Resources.Load<Sprite>("Character/Sorceress");
                case 3:
                    return UnityEngine.Resources.Load<Sprite>("Character/Witch");
                case 4:
                    return UnityEngine.Resources.Load<Sprite>("Character/Archer");
                case 5:
                    return UnityEngine.Resources.Load<Sprite>("Character/GirlArcher");
                case 6:
                    return UnityEngine.Resources.Load<Sprite>("Character/HoodArcher");
                case 7:
                    return UnityEngine.Resources.Load<Sprite>("Character/BoyKnight");
                case 8:
                    return UnityEngine.Resources.Load<Sprite>("Character/ChargeKnight");
                case 9:
                    return UnityEngine.Resources.Load<Sprite>("Character/ElfKnight");
                default:
                    return null;
            }
        }
    }
}