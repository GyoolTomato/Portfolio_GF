using System;
using Assets.Common.DB.User;
using Assets.Resources.StageField;

namespace Assets.Scene_StageField.Base
{
    public class BattleData
    {
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }
        public OccupationPoint BattlePlace { get; set; }
    }
}