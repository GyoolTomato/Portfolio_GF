using System;
using Assets.DB.User;
using Assets.Scenes.StageField.Object;

namespace Assets.Scenes.StageField.Base
{
    public class BattleData
    {
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }
        public OccupationPoint BattlePlace { get; set; }
    }
}