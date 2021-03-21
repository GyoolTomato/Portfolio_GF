using System;
using Assets.Scene_StageField.Object;
using Assets.Scene_StageField.Controller.EnemyData.Base;

namespace Assets.Scene_StageField.Controller.EnemyData
{
    public class Stage1_1 : Base.EnemyListBase
    {
        public Stage1_1()
        {
        }

        public override void Initialize()
        {
            base.Initialize();

            var temp = new EnemyParty();

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 3;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 2;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 4;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 1;
            temp.StartPoint = m_board.transform.Find("NormalPoint_1").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 4;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 2;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 3;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 2;
            temp.Memeber3 = new EnemyMember();
            temp.Memeber3.IndexNumber = 1;
            temp.Memeber3.Level = 10;
            temp.Memeber3.DummyLink = 1;
            temp.StartPoint = m_board.transform.Find("MainPoint_Enemy").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);
        }
    }
}