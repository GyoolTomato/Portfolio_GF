using UnityEditor;
using UnityEngine;

namespace Assets.GameManager.DB
{
    public class DataBase_Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Star { get; set; }
        public int FirePower { get; set; }
        public int Focus { get; set; }
        public int Armor { get; set; }
        public int Avoidance { get; set; }
        public float ManufacturingTime { get; set; }
    }
}