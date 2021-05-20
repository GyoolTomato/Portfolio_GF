using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Common;
using Assets.Scenes.StageField.Object;

namespace Assets.Common.Controller
{
    public class StageBackupController
    {
        private DB.User.Base.UserDataBase_Stage m_stage;
        private List<Player> m_players;
        private List<Enemy> m_enemies;
        private List<OccupationPoint> m_occupationPoints;

        public StageBackupController()
        {
        }

        public void Initialize()
        {

        }

        public void Backup(DB.User.Base.UserDataBase_Stage stage, List<Player> players, List<Enemy> enemies, List<OccupationPoint> occupationPoints)
        {
            m_stage = stage;
            m_players = players;
            m_enemies = enemies;
            m_occupationPoints = occupationPoints;
        }

        public DB.User.Base.UserDataBase_Stage GetStage()
        {
            return m_stage;
        }

        public List<Player> GetPlayers()
        {
            return m_players;
        }

        public List<Enemy> GetEnemies()
        {
            return m_enemies;
        }

        public List<OccupationPoint> GetOccupationPoints()
        {
            return m_occupationPoints;
        }
    }
}