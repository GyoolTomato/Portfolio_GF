using UnityEditor;
using UnityEngine;

namespace Assets.Project.DB
{
    public class IndexDataBase_Equipment
    {
        public int DataCode { get; set; }
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