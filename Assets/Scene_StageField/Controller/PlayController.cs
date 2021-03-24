using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scene_StageField.Controller
{
    public class PlayController
    {
        private StageFieldManager m_stageFieldManager;
        private bool m_isPlaying;

        public PlayController()
        {

        }

        public void Initialize(StageFieldManager stageFieldManager)
        {
            m_stageFieldManager = stageFieldManager;
        }

        public void StartPlay()
        {
            m_isPlaying = true;
        }

        public void GameOverCheck()
        {
            if (NotFoundPlayerMainPoints() || PlayerAllDie())
            {
                EnemyWinEvent();
                m_isPlaying = false;
            }

            if (NotFoundEnemyMainPoints())
            {
                PlayerWinEvent();
                m_isPlaying = false;
            }
        }

        public bool NotFoundPlayerMainPoints()
        {
            var pointController = m_stageFieldManager.GetBoardManager().GetPointController();

            foreach (var item in pointController.GetMainPoints())
            {
                if (item.Owner == Object.OccupationPoint.E_Owner.Player)
                {
                    return false;
                }
            }

            return true;
        }

        public bool NotFoundEnemyMainPoints()
        {
            var pointController = m_stageFieldManager.GetBoardManager().GetPointController();

            foreach (var item in pointController.GetMainPoints())
            {
                if (item.Owner == Object.OccupationPoint.E_Owner.Player)
                {
                    return false;
                }
            }

            return true;
        }

        public bool PlayerAllDie()
        {
            var playerPlatoonController = m_stageFieldManager.GetBoardManager().GetPlayerPlatoonController();

            if (playerPlatoonController.GetPlayers().Count == 0)
            {
                return true;
            }

            return false;
        }

        public void PlayerWinEvent()
        {
            Debug.Log("승리");            
        }

        public void EnemyWinEvent()
        {
            Debug.Log("패배");            
        }

        public bool IsPlaying()
        {
            return m_isPlaying;
        }
    }
}