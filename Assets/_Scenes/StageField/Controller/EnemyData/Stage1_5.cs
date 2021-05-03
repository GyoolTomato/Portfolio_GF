using System;
using Assets.Scenes.StageField.Controller.EnemyData.Base;
using Assets.Scenes.StageField.Object;

namespace Assets.Scenes.StageField.Controller.EnemyData
{
    public class Stage1_5 : Base.EnemyListBase
    {
        public Stage1_5()
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
            temp.Memeber1.DummyLink = 3;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 5;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 3;
            temp.Memeber3 = new EnemyMember();
            temp.Memeber3.IndexNumber = 9;
            temp.Memeber3.Level = 10;
            temp.Memeber3.DummyLink = 3;
            temp.StartPoint = m_board.transform.Find("MainPoint_Enemy2").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 2;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 3;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 6;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 3;
            temp.Memeber3 = new EnemyMember();
            temp.Memeber3.IndexNumber = 8;
            temp.Memeber3.Level = 10;
            temp.Memeber3.DummyLink = 3;
            temp.StartPoint = m_board.transform.Find("NormalPoint_11").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 3;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 5;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 2;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 3;
            temp.Memeber3 = new EnemyMember();
            temp.Memeber3.IndexNumber = 1;
            temp.Memeber3.Level = 10;
            temp.Memeber3.DummyLink = 2;
            temp.StartPoint = m_board.transform.Find("MainPoint_Enemy0").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 3;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 5;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 2;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 3;
            temp.StartPoint = m_board.transform.Find("NormalPoint_3").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 4;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 5;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 6;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 3;
            temp.Memeber3 = new EnemyMember();
            temp.Memeber3.IndexNumber = 5;
            temp.Memeber3.Level = 10;
            temp.Memeber3.DummyLink = 2;
            temp.StartPoint = m_board.transform.Find("MainPoint_Enemy1").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 4;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 5;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 6;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 3;
            temp.StartPoint = m_board.transform.Find("NormalPoint_7").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 7;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 5;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 8;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 3;
            temp.Memeber3 = new EnemyMember();
            temp.Memeber3.IndexNumber = 9;
            temp.Memeber3.Level = 10;
            temp.Memeber3.DummyLink = 2;
            temp.StartPoint = m_board.transform.Find("MainPoint_Enemy3").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);

            temp = new EnemyParty();
            temp.Memeber1 = new EnemyMember();
            temp.Memeber1.IndexNumber = 7;
            temp.Memeber1.Level = 10;
            temp.Memeber1.DummyLink = 5;
            temp.Memeber2 = new EnemyMember();
            temp.Memeber2.IndexNumber = 8;
            temp.Memeber2.Level = 10;
            temp.Memeber2.DummyLink = 3;            
            temp.StartPoint = m_board.transform.Find("NormalPoint_15").GetComponent<OccupationPoint>();
            m_enemyParties.Add(temp);
        }
    }
}