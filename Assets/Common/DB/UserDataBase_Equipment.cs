using System.Collections;
using UnityEngine;

namespace Assets.Common.DB
{
    public class UserDataBase_Equipment
    {
        public int OwnershipCode { get; set; }
        public int DataCode { get; set; }        
        public int Level { get; set; }
        public float LimitedPower { get; set; }
    }
}