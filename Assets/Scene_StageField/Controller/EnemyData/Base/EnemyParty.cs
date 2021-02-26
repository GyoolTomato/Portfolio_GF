using System;
using UnityEngine;
using Assets.Common.DB.Index;
using Assets.Resources.StageField;

namespace Assets.Scene_StageField.Controller.EnemyData.Base
{
    public class EnemyParty
    {
        public EnemyMember Memeber1 { get; set; }
        public EnemyMember Memeber2 { get; set; }
        public EnemyMember Memeber3 { get; set; }
        public EnemyMember Memeber4 { get; set; }
        public EnemyMember Memeber5 { get; set; }
        public EnemyMember Memeber6 { get; set; }

        public OccupationPoint StartPoint { get; set; }
    }
}