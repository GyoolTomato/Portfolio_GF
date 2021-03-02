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

        public Sprite GetEquipmentImage(int dataCode)
        {
            switch (dataCode)
            {
                case 1:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/OldSword");
                case 2:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/NormalSword");
                case 3:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/NormalSword");
                case 4:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/OldBow");
                case 5:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/OldBow");
                case 6:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/OldBow");
                case 7:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/OldWand");
                case 8:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/NormalWand");
                case 9:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/NormalWand");
                case 10:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/OldArmor");
                case 11:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/NormalArmor");
                case 12:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/LegendArmor");
                case 13:
                    return null;
                case 14:
                    return null;
                case 15:
                    return null;
                default:
                    return null;
            }
        }

        public Sprite GetWorkResource(string dBName)
        {
            if (dBName.Equals("Steal"))
            {
                return UnityEngine.Resources.Load<Sprite>("WorkResource/Steal");
            }
            else if (dBName.Equals("Flower"))
            {
                return UnityEngine.Resources.Load<Sprite>("WorkResource/Flower");
            }
            else if (dBName.Equals("Food"))
            {
                return UnityEngine.Resources.Load<Sprite>("WorkResource/Food");
            }
            else if (dBName.Equals("Leather"))
            {
                return UnityEngine.Resources.Load<Sprite>("WorkResource/Leather");
            }
            else
                return null;
        }

        public Sprite GetIconImage(string Type)
        {
            if (Type.Equals("Magician"))
                return UnityEngine.Resources.Load<Sprite>("Icon/MageStaff");
            else if (Type.Equals("Archer"))
                return UnityEngine.Resources.Load<Sprite>("Icon/Bow");
            else if (Type.Equals("Knight"))
                return UnityEngine.Resources.Load<Sprite>("Icon/Sword");
            else
                return null;
        }

    }
}