using System;
using UnityEngine;

namespace Assets.Graphic
{
    public static class CustomColor
    {
        //new Color(1f, 47f / 51f, 4f / 255f, 1f);
        public static Color Gold => new Color(238f / 255f, 167f / 255f, 42f / 255f, 255f / 255f);
        public static Color Gold_T => new Color(238f / 255f, 167f / 255f, 42f / 255f, 200f / 255f);
        public static Color Silver => new Color(171f / 255f, 171f / 255f, 171f / 255f, 255f / 255f);
        public static Color DarkGray => new Color(111f / 255f, 111f / 255f, 111f / 255f, 255f / 255f);
        public static Color DarkGray_T => new Color(111f / 255f, 111f / 255f, 111f / 255f, 200f / 255f);
        public static Color PlayerPoint => new Color(0f / 255f, 193f / 255f, 248f / 255f, 255f / 255f);
        public static Color EnemyPoint => new Color(255f / 255f, 85f / 255f, 55f / 255f, 255f / 255f);
    }
}
