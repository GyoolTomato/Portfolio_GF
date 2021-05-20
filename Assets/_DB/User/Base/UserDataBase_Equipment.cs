using System.Collections;
using UnityEngine;

namespace Assets.DB.User.Base
{
    public class UserDataBase_Equipment
    {
        public int OwnershipCode { get; set; }
        public int DataCode { get; set; }        
        public int Level { get; set; }
        public int LimitedPower { get; set; }
    }
}