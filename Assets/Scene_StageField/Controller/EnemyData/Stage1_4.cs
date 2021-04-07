using System;
using Assets.Scene_StageField.Controller.EnemyData.Base;
using Assets.Scene_StageField.Object;

namespace Assets.Scene_StageField.Controller.EnemyData
{
    public class Stage1_4 : Base.EnemyListBase
    {
        public Stage1_4()
        {
        }

        public override void Initialize()
        {
            base.Initialize();

            var temp = new EnemyParty();

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 1;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 1;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 2;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 3;
            temp.Memeber3 = new EnemyMember();
            temp.Memeber3.IndexNumber = 3;
            temp.Memeber3.Level = 10;
            temp.Memeber3.DummyLink = 5;
            temp.StartPoint = m_board.transform.Find("NormalPoint_3").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 7;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 4;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 8;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 1;
            temp.Memeber3 = new EnemyMember();
            temp.Memeber3.IndexNumber = 6;
            temp.Memeber3.Level = 10;
            temp.Memeber3.DummyLink = 2;
            temp.StartPoint = m_board.transform.Find("NormalPoint_0").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 7;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 4;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 8;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 1;
            temp.Memeber3 = new EnemyMember();
            temp.Memeber3.IndexNumber = 2;
            temp.Memeber3.Level = 10;
            temp.Memeber3.DummyLink = 2;
            temp.StartPoint = m_board.transform.Find("NormalPoint_1").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 7;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 4;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 8;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 1;
            temp.Memeber3 = new EnemyMember();
            temp.Memeber3.IndexNumber = 2;
            temp.Memeber3.Level = 10;
            temp.Memeber3.DummyLink = 1;
            temp.Memeber3 = new EnemyMember();
            temp.Memeber3.IndexNumber = 6;
            temp.Memeber3.Level = 10;
            temp.Memeber3.DummyLink = 1;
            temp.StartPoint = m_board.transform.Find("NormalPoint_2").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 9;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 3;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 9;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 3;
            temp.Memeber3 = new EnemyMember();
            temp.Memeber3.IndexNumber = 3;
            temp.Memeber3.Level = 10;
            temp.Memeber3.DummyLink = 2;
            temp.StartPoint = m_board.transform.Find("MainPoint_Enemy").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);
        }
    }
}