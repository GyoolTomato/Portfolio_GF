using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.StageField;

namespace Assets.Scene_StageField.Board.Turn
{
    public class Battle
    {
        private StageFieldManager m_stageFieldManager;
        private BoardManager m_boardManager;
        private List<Base.BattleData> m_battleDatas;

        public Battle()
        {
        }

        public void Initialize(StageFieldManager stageFieldManager)
        {
            m_stageFieldManager = stageFieldManager;
            m_boardManager = m_stageFieldManager.GetBoardManager();
        }

        public void StartTurn()
        {
            CheckBattle();
            m_stageFieldManager.StartCoroutine(BattleStart());
        }

        private void CheckBattle()
        {
            m_battleDatas = new List<Base.BattleData>();

            foreach (var player in m_boardManager.GetPlayerPlatoonController().GetPlayers())
            {
                var playerScript = player.GetComponent<Player>();
                foreach (var enemy in m_boardManager.GetEnemyPlatoonController().GetEnemies())
                {
                    var enemyScript = enemy.GetComponent<Enemy>();

                    if (playerScript.GetStayPoint() == enemyScript.GetStayPoint())
                    {
                        var battleData = new Base.BattleData();
                        battleData.Player = playerScript;
                        battleData.Enemy = enemyScript;
                        battleData.BattlePlace = player.GetStayPoint();
                        m_battleDatas.Add(battleData);
                    }
                }
            } 
        }

        private IEnumerator BattleStart()
        {
            var battleFieldManager = m_stageFieldManager.GetBattleFieldManager();

            foreach (var item in m_battleDatas)
            {
                battleFieldManager.OpenBattleField(item);
                while (!battleFieldManager.IsFinishBattle())
                {
                    switch (battleFieldManager.GetWinner())
                    {
                        case BattleField.BattleFieldManager.E_Winner.Player:
                            MonoBehaviour.Destroy(item.Enemy.gameObject);
                            break;
                        case BattleField.BattleFieldManager.E_Winner.Enemy:
                            MonoBehaviour.Destroy(item.Player.gameObject);
                            break;
                        default:
                            break;
                    }

                    yield return null;
                }
            }

            yield return new WaitForSeconds(3);
            m_stageFieldManager.GetBoardManager().ChangeState(BoardManager.E_State.Occupation);
        }
    }
}
