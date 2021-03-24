using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scene_StageField.Object;

namespace Assets.Scene_StageField.Board.Turn
{
    public class Battle
    {
        private StageFieldManager m_stageFieldManager;
        private BoardManager m_boardManager;
        private List<Base.BattleData> m_battleDatas;
        private bool m_isInCombat;

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
            if (m_stageFieldManager.GetPlayController().IsPlaying())
            {
                CheckBattle();
            }
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

            m_stageFieldManager.StartCoroutine(SelectBattle());
        }

        private IEnumerator SelectBattle()
        {
            foreach (var item in m_battleDatas)
            {
                Focusing(item);
                while (m_isInCombat)
                {
                    yield return null;
                }

                yield return new WaitForSeconds(2);
            }

            m_stageFieldManager.GetBoardManager().ChangeState(BoardManager.E_State.Occupation);
            yield return null;
        }

        private void Focusing(Base.BattleData battleData)
        {
            m_isInCombat = true;
            m_stageFieldManager.StartCoroutine(FocusingAnimation(battleData));
        }

        private IEnumerator FocusingAnimation(Base.BattleData battleData)
        {           
            m_stageFieldManager.StartCoroutine(BattleStart(battleData));
            yield return null;
        }

        private IEnumerator BattleStart(Base.BattleData battleData)
        {
            var battleFieldManager = m_stageFieldManager.GetBattleFieldManager();

            battleFieldManager.OpenBattleField(battleData);
            while (!battleFieldManager.IsFinishBattle())
            {
                switch (battleFieldManager.GetWinner())
                {
                    case BattleField.BattleFieldManager.E_Winner.Player:
                        MonoBehaviour.Destroy(battleData.Enemy.gameObject);
                        break;
                    case BattleField.BattleFieldManager.E_Winner.Enemy:
                        MonoBehaviour.Destroy(battleData.Player.gameObject);
                        break;
                    default:
                        break;
                }

                yield return null;
            }
            battleFieldManager.CloseBattleField();
            m_isInCombat = false;
        }
    }
}
