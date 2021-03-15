using System;
using System.Collections.Generic;
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
        public List<EnemyMember> Members()
        {
            var temp = new List<EnemyMember>();
            temp.Add(Memeber1);
            temp.Add(Memeber2);
            temp.Add(Memeber3);
            temp.Add(Memeber4);
            temp.Add(Memeber5);
            temp.Add(Memeber6);

            return temp;
        }

        public OccupationPoint StartPoint { get; set; }
    }
}