using UnityEditor;
using UnityEngine;

namespace Assets.GameManager.DB
{
    public class DataBase_TDoll
    {
        public int UniqueNumber { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Star { get; set; }
        public int Hp { get; set; }
        public int FirePower { get; set; }
        public float AttackSpeed { get; set; }
        public int Focus { get; set; }
        public int Armor { get; set; }
        public int Avoidance { get; set; }
        public float MoveSpeed { get; set; }
        public float ManufacturingTime { get; set; }
    }
}