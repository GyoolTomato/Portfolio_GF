using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Common
{
    public class ImageController
    {
        public enum E_TDollType
        {
            Magician,
            Archer,
            Knight,
            End,
        }

        public enum E_EquipmentType
        {
            Weapon,
            Armor,
            Tool,
            End,
        }

        public ImageController()
        {
        }

        public Sprite LoadSprite(int dataCode)
        {
            var result = UnityEngine.Resources.Load("aaa") as Sprite;

            return result;
        }

        public Sprite LoadSprite(string type)
        {
            var result = UnityEngine.Resources.Load("aaa") as Sprite;

            return result;
        }
    }
}