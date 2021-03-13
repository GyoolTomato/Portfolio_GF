using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.StageField;

namespace Assets.Scene_StageField.Board.Turn
{
    public class Occupation
    {
        private StageFieldManager m_stageFieldManager;
        private BoardManager m_boardManager;

        public Occupation()
        {
        }

        public void Initialize(StageFieldManager stageFieldManager)
        {
            m_stageFieldManager = stageFieldManager;
            m_boardManager = m_stageFieldManager.GetBoardManager();
        }

        public void StartTurn()
        {
            PointOccupation();
        }

        private void PointOccupation()
        {
            var playerScript = new Player();
            var enemyScript = new Enemy();

            foreach (var player in m_boardManager.GetPlayerPlatoonController().GetPlayers())
            {
                playerScript = player.GetComponent<Player>();
                playerScript.GetStayPoint().Owner = OccupationPoint.E_Owner.Player;
            }

            foreach (var enemy in m_boardManager.GetEnemyPlatoonController().GetEnemies())
            {
                enemyScript = enemy.GetComponent<Enemy>();
                enemyScript.GetStayPoint().Owner = OccupationPoint.E_Owner.Enemy;
            }

            m_boardManager.ChangeState(BoardManager.E_State.PlayerTurn);
        }
    }
}