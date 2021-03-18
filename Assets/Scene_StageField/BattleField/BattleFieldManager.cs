using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Assets.Common;
using Assets.Character;
using Assets.Character.Battle.Base;
using Assets.Common.DB.User;
using Assets.Common.DB.Index;
using Assets.Resources.StageField;
using Assets.Scene_StageField.Controller.EnemyData.Base;

namespace Assets.Scene_StageField.BattleField
{
    public class BattleFieldManager
    {
        public enum E_Winner
        {
            Player,
            Enemy,
            End,
        }

        private GameManager m_gameManager;
        private StageFieldManager m_stageFieldManager;
        private Controller.SpawnController m_spawnController;
        private GameObject m_battleFieldUI;
        private GameObject m_battleField;
        private GameObject m_boardUI;
        private GameObject m_board;
        private bool m_isCreatingPlayer;
        private bool m_isCreatingEnemy;
        private bool m_isFinishBattle;
        private E_Winner m_winner;

        public BattleFieldManager()
        {
        }

        public void Initialize(StageFieldManager stageFieldManager)
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            m_stageFieldManager = stageFieldManager;
            m_spawnController = new Controller.SpawnController();
            var canvas = GameObject.Find("Canvas");
            m_battleFieldUI = canvas.transform.Find("BattleFieldUI").gameObject;
            m_battleField = GameObject.Find("BattleField");
            m_boardUI = canvas.transform.Find("BoardUI").gameObject;
            m_board = GameObject.Find("Board");
        }

        public void OpenBattleField(Base.BattleData battleData)
        {
            m_isCreatingPlayer = false;
            m_isCreatingEnemy = false;
            m_isFinishBattle = false;
            m_battleFieldUI.SetActive(true);
            m_battleField.SetActive(true);
            m_boardUI.SetActive(false);
            m_board.SetActive(false);

            m_stageFieldManager.StartCoroutine(CreatePlayer(battleData.Player));
            m_stageFieldManager.StartCoroutine(CreateEnemy(battleData.Enemy));
            m_stageFieldManager.StartCoroutine(BattleFinishCheck());
        }

        private void CloseBattleField()
        {
            m_battleFieldUI.SetActive(false);
            m_battleField.SetActive(false);
            m_boardUI.SetActive(true);
            m_board.SetActive(true);
            m_isFinishBattle = true;
        }

        public bool IsFinishBattle()
        {
            return m_isFinishBattle;
        }

        public E_Winner GetWinner()
        {
            return E_Winner.End;
        }

        private IEnumerator CreatePlayer(Player player)
        {
            m_isCreatingPlayer = true;

            var platoon = player.GetPlatoonData();
            var member1 = m_gameManager.GetUserDBController().UserTDoll(platoon.Member1);
            var member2 = m_gameManager.GetUserDBController().UserTDoll(platoon.Member2);
            var member3 = m_gameManager.GetUserDBController().UserTDoll(platoon.Member3);
            var member4 = m_gameManager.GetUserDBController().UserTDoll(platoon.Member4);

            GameObject tempObject;
            var yPosition = 0.0f;
            var yPositionMin = -4.5f;
            var yPositionMax = -2.7f;

            for (int i = 1; i <= 5; i++)
            {                
                if (member1 != null && member1.DummyLink >= i)
                {
                    yPosition = UnityEngine.Random.Range(yPositionMin, yPositionMax);
                    tempObject = m_spawnController.SpawnCharacter(member1.DataCode, new Vector3(-10, yPosition, 0));
                    tempObject.transform.parent = m_battleField.transform;
                    var tempScript = tempObject.GetComponent<CharacterBase>();
                    tempScript.Initialize(CharacterBase.E_Team.Player, member1);
                    yield return new WaitForSeconds(1.0f);
                }
                if (member2 != null && member2.DummyLink >= i)
                {
                    yPosition = UnityEngine.Random.Range(yPositionMin, yPositionMax);
                    tempObject = m_spawnController.SpawnCharacter(member2.DataCode, new Vector3(-10, yPosition, 0));
                    tempObject.transform.parent = m_battleField.transform;
                    var tempScript = tempObject.GetComponent<CharacterBase>();
                    tempScript.Initialize(CharacterBase.E_Team.Player, member2);
                    yield return new WaitForSeconds(1.0f);
                }
                if (member3 != null && member3.DummyLink >= i)
                {
                    yPosition = UnityEngine.Random.Range(yPositionMin, yPositionMax);
                    tempObject = m_spawnController.SpawnCharacter(member3.DataCode, new Vector3(-10, yPosition, 0));
                    tempObject.transform.parent = m_battleField.transform;
                    var tempScript = tempObject.GetComponent<CharacterBase>();
                    tempScript.Initialize(CharacterBase.E_Team.Player, member3);
                    yield return new WaitForSeconds(1.0f);
                }
                if (member4 != null && member4.DummyLink >= i)
                {
                    yPosition = UnityEngine.Random.Range(yPositionMin, yPositionMax);
                    tempObject = m_spawnController.SpawnCharacter(member4.DataCode, new Vector3(-10, yPosition, 0));
                    tempObject.transform.parent = m_battleField.transform;
                    var tempScript = tempObject.GetComponent<CharacterBase>();
                    tempScript.Initialize(CharacterBase.E_Team.Player, member4);
                    yield return new WaitForSeconds(1.0f);
                }
                
            }

            m_isCreatingPlayer = false;
            yield return null;
        }

        private IEnumerator CreateEnemy(Enemy enemy)
        {
            m_isCreatingEnemy = true;

            var platoon = enemy.GetEnemyParty();

            GameObject tempObject;
            var yPosition = 0.0f;
            var yPositionMin = -4.5f;
            var yPositionMax = -2.7f;

            for (int i = 1; i <= 5; i++)
            {
                foreach (var item in platoon.Members())
                {
                    if (item != null && item.DummyLink >= i)
                    {
                        yPosition = UnityEngine.Random.Range(yPositionMin, yPositionMax);
                        tempObject = m_spawnController.SpawnCharacter(item.IndexNumber, new Vector3(10, yPosition, 0));
                        tempObject.transform.parent = m_battleField.transform;
                        var tempScript = tempObject.GetComponent<CharacterBase>();
                        tempScript.Initialize(CharacterBase.E_Team.Enemy, item);
                        yield return new WaitForSeconds(1.0f);
                    }                    
                }                
            }

            m_isCreatingEnemy = false;
            yield return null;
        }

        private IEnumerator BattleFinishCheck()
        {
            while (m_isCreatingPlayer && m_isCreatingEnemy)
            {                
                yield return null;
            }

            m_isFinishBattle = true;
        }
    }
}