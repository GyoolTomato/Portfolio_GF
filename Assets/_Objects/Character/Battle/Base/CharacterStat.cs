using System;

namespace Assets.Character.Battle.Base
{
    public class CharacterStat
    {
        public int Level { get; set; }
        public int MaxHp { get; set; }
        public int Hp { get; set; }
        public int FirePower { get; set; }
        public float AttackSpeed { get; set; }
        public float AttackRange { get; set; }
        public float Critical { get; set; }
        public int Focus { get; set; }
        public int Armor { get; set; }
        public int Avoidance { get; set; }
        public float MoveSpeed { get; set; }
    }
}