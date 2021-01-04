using System.Collections;
using UnityEngine;

namespace Assets.GameManager.DB
{
    public class DataBase_UserEquipment
    {
        public int OwnerShipNumber { get; set; }
        public int Id { get; set; }        
        public int Level { get; set; }
        public float LimitedPower { get; set; }
    }
}