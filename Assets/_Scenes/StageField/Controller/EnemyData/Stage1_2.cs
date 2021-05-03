using System;
using Assets.Scenes.StageField.Object;
using Assets.Scenes.StageField.Controller.EnemyData.Base;

namespace Assets.Scenes.StageField.Controller.EnemyData
{
    public class Stage1_2 : Base.EnemyListBase
    {
        public Stage1_2()
        {
        }

        public override void Initialize()
        {
            base.Initialize();

            var temp = new EnemyParty();

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 7;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 3;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 5;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 2;
            temp.StartPoint = m_board.transform.Find("HeliPortPoint_0").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 7;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 3;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 5;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 2;
            temp.StartPoint = m_board.transform.Find("HeliPortPoint_1").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 3;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 2;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 8;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 2;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 4;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 2;
            temp.StartPoint = m_board.transform.Find("NormalPoint_1").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 3;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 2;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 8;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 2;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 4;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 2;
            temp.StartPoint = m_board.transform.Find("NormalPoint_3").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);
        }
    }
}