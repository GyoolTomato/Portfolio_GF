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
                    return UnityEngine.Resources.Load<Sprite>("Character/Wizzard");
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
                    return UnityEngine.Resources.Load<Sprite>("Equipment/LegendSword");
                case 4:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/OldBow");
                case 5:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/OldBow");
                case 6:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/LegendBow");
                case 7:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/OldStaff");
                case 8:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/NormalWand");
                case 9:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/SpellBook");
                case 10:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/OldArmor");
                case 11:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/NormalArmor");
                case 12:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/LegendArmor");
                case 13:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/Necklace");
                case 14:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/Ring");
                case 15:
                    return UnityEngine.Resources.Load<Sprite>("Equipment/Amulet");
                default:
                    return null;
            }
        }

        public Sprite GetWorkResource(string dBName)
        {
            if (dBName.Equals("Steel"))
            {
                return UnityEngine.Resources.Load<Sprite>("WorkResource/Steel");
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

        public Sprite GetTypeImage(string Type)
        {
            if (Type.Equals("Magician"))
                return UnityEngine.Resources.Load<Sprite>("Type/MageStaff");
            else if (Type.Equals("Archer"))
                return UnityEngine.Resources.Load<Sprite>("Type/Bow");
            else if (Type.Equals("Knight"))
                return UnityEngine.Resources.Load<Sprite>("Type/Sword");
            else if (Type.Equals("Weapon"))
                return UnityEngine.Resources.Load<Sprite>("Type/Weapon");
            else if (Type.Equals("Armor"))
                return UnityEngine.Resources.Load<Sprite>("Type/Armor");
            else if (Type.Equals("Tool"))
                return UnityEngine.Resources.Load<Sprite>("Type/Tool");
            else
                return null;
        }

    }
}