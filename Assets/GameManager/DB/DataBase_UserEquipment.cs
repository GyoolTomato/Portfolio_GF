using System.Collections;
using UnityEngine;

namespace Assets.GameManager.DB
{
    public class DataBase_UserEquipment
    {
        public int OwnerShipNumber { get; set; }
        public int UniqueNumber { get; set; }        
        public int Level { get; set; }
        public float LimitedPower { get; set; }
    }
}