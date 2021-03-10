using System;
using Assets.Common.DB.User;
using Assets.Resources.StageField;

namespace Assets.Scene_StageField.Base
{
    public class BattleData
    {
        public UserDataBase_Platoon Player { get; set; }
        public UserDataBase_Platoon Enemy { get; set; }
        public OccupationPoint BattlePlace { get; set; }
    }
}