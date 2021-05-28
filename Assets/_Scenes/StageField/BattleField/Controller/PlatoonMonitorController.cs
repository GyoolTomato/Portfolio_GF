using System;
using UnityEngine;
using Assets.Resources.Album;

namespace Assets.Scenes.StageField.BattleField.Controller
{
    public class PlatoonMonitorController
    {
        private DB.DbManager m_dbManager;

        private SmallAlbum_TDoll m_playerPlatoon1;
        private SmallAlbum_TDoll m_playerPlatoon2;
        private SmallAlbum_TDoll m_playerPlatoon3;
        private SmallAlbum_TDoll m_playerPlatoon4;

        private SmallAlbum_TDoll m_enemyPlatoon1;
        private SmallAlbum_TDoll m_enemyPlatoon2;
        private SmallAlbum_TDoll m_enemyPlatoon3;
        private SmallAlbum_TDoll m_enemyPlatoon4;

        public PlatoonMonitorController()
        {
        }

        public void Initialize()
        {
            m_dbManager = GameObject.Find("GameManager").GetComponent<DB.DbManager>();

            var canvas = GameObject.Find("Canvas");
            var battleFieldUI = canvas.transform.Find("BattleFieldUI");
            var playerTeam = battleFieldUI.Find("PlayerTeam");
            m_playerPlatoon1 = playerTeam.Find("Platoon1").GetComponent<SmallAlbum_TDoll>();
            m_playerPlatoon2 = playerTeam.Find("Platoon2").GetComponent<SmallAlbum_TDoll>();
            m_playerPlatoon3 = playerTeam.Find("Platoon3").GetComponent<SmallAlbum_TDoll>();
            m_playerPlatoon4 = playerTeam.Find("Platoon4").GetComponent<SmallAlbum_TDoll>();

            var enemyTeam = battleFieldUI.Find("EnemyTeam");
            m_enemyPlatoon1 = enemyTeam.Find("Platoon1").GetComponent<SmallAlbum_TDoll>();
            m_enemyPlatoon2 = enemyTeam.Find("Platoon2").GetComponent<SmallAlbum_TDoll>();
            m_enemyPlatoon3 = enemyTeam.Find("Platoon3").GetComponent<SmallAlbum_TDoll>();
            m_enemyPlatoon4 = enemyTeam.Find("Platoon4").GetComponent<SmallAlbum_TDoll>();
        }

        public void ApplyData(Base.BattleData battleData)
        {
            var playerPlatoon = battleData.Player.GetPlatoonData();
            var playerMember1 = m_dbManager.GetUserDBController().UserTDoll(playerPlatoon.Member1);
            var playerMember2 = m_dbManager.GetUserDBController().UserTDoll(playerPlatoon.Member2);
            var playerMember3 = m_dbManager.GetUserDBController().UserTDoll(playerPlatoon.Member3);
            var playerMember4 = m_dbManager.GetUserDBController().UserTDoll(playerPlatoon.Member4);
            m_playerPlatoon1.Initialize(playerMember1);
            m_playerPlatoon2.Initialize(playerMember2);
            m_playerPlatoon3.Initialize(playerMember3);
            m_playerPlatoon4.Initialize(playerMember4);

            var enemyPlatoon = battleData.Enemy.GetEnemyParty();            
            m_enemyPlatoon1.Initialize(enemyPlatoon.Memeber1);
            m_enemyPlatoon2.Initialize(enemyPlatoon.Memeber2);
            m_enemyPlatoon3.Initialize(enemyPlatoon.Memeber3);
            m_enemyPlatoon4.Initialize(enemyPlatoon.Memeber4);
        }
    }
}