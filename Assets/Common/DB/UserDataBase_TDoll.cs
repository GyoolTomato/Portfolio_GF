using System.Collections;
using UnityEngine;

namespace Assets.Common.DB
{
    public class UserDataBase_TDoll
    {
        public int OwnershipCode { get; set; }
        public int DataCode { get; set; }
        public int Level { get; set; }
        public int DummyLink { get; set; }
        public int Platoon { get; set; }
        public int EquipmentOwnershipNumber0 { get; set; }
        public int EquipmentOwnershipNumber1 { get; set; }
        public int EquipmentOwnershipNumber2 { get; set; }
    }
}