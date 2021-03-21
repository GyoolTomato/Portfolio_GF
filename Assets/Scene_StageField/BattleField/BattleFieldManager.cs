using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Assets.Common;
using Assets.Character;
using Assets.Character.Battle.Base;
using Assets.Scene_StageField.Object;
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
        private Base.BattleData m_battleData;
        private GameObject m_battleFieldUI;
        private GameObject m_battleField;
        private Transform m_battleField_Units;
        private GameObject m_boardUI;
        private GameObject m_board;
        private bool m_isFinishCreatingPlayer;
        private bool m_isFinishCreatingEnemy;
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
            m_battleField_Units = m_battleField.transform.Find("Units");
            m_boardUI = canvas.transform.Find("BoardUI").gameObject;
            m_board = GameObject.Find("Board");
        }

        private void ClearBattleField()
        {
            foreach (Transform item in m_battleField_Units)
            {
                MonoBehaviour.Destroy(item.gameObject);
            }
        }

        public void OpenBattleField(Base.BattleData battleData)
        {
            ClearBattleField();

            m_battleData = battleData;
            m_isFinishCreatingPlayer = false;
            m_isFinishCreatingEnemy = false;
            m_isFinishBattle = false;
            m_battleFieldUI.SetActive(true);
            m_battleField.SetActive(true);
            m_boardUI.SetActive(false);
            m_board.SetActive(false);

            m_isFinishCreatingPlayer = false;
            m_isFinishCreatingEnemy = false;
            m_stageFieldManager.StartCoroutine(CreatePlayer(battleData.Player));
            m_stageFieldManager.StartCoroutine(CreateEnemy(battleData.Enemy));
            m_stageFieldManager.StartCoroutine(BattleFinishCheck());
        }

        public void CloseBattleField()
        {
            m_battleFieldUI.SetActive(false);
            m_battleField.SetActive(false);
            m_boardUI.SetActive(true);
            m_board.SetActive(true);
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
                    tempObject.transform.parent = m_battleField_Units;
                    var tempScript = tempObject.GetComponent<CharacterBase>();
                    tempScript.Initialize(CharacterBase.E_Team.Player, member1);
                    yield return new WaitForSeconds(1.0f);
                }
                if (member2 != null && member2.DummyLink >= i)
                {
                    yPosition = UnityEngine.Random.Range(yPositionMin, yPositionMax);
                    tempObject = m_spawnController.SpawnCharacter(member2.DataCode, new Vector3(-10, yPosition, 0));
                    tempObject.transform.parent = m_battleField_Units;
                    var tempScript = tempObject.GetComponent<CharacterBase>();
                    tempScript.Initialize(CharacterBase.E_Team.Player, member2);
                    yield return new WaitForSeconds(1.0f);
                }
                if (member3 != null && member3.DummyLink >= i)
                {
                    yPosition = UnityEngine.Random.Range(yPositionMin, yPositionMax);
                    tempObject = m_spawnController.SpawnCharacter(member3.DataCode, new Vector3(-10, yPosition, 0));
                    tempObject.transform.parent = m_battleField_Units;
                    var tempScript = tempObject.GetComponent<CharacterBase>();
                    tempScript.Initialize(CharacterBase.E_Team.Player, member3);
                    yield return new WaitForSeconds(1.0f);
                }
                if (member4 != null && member4.DummyLink >= i)
                {
                    yPosition = UnityEngine.Random.Range(yPositionMin, yPositionMax);
                    tempObject = m_spawnController.SpawnCharacter(member4.DataCode, new Vector3(-10, yPosition, 0));
                    tempObject.transform.parent = m_battleField_Units;
                    var tempScript = tempObject.GetComponent<CharacterBase>();
                    tempScript.Initialize(CharacterBase.E_Team.Player, member4);
                    yield return new WaitForSeconds(1.0f);
                }
                
            }

            m_isFinishCreatingPlayer = true;
            yield return null;
        }

        private IEnumerator CreateEnemy(Enemy enemy)
        {
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
                        tempObject.transform.parent = m_battleField_Units;
                        var tempScript = tempObject.GetComponent<CharacterBase>();
                        tempScript.Initialize(CharacterBase.E_Team.Enemy, item);
                        yield return new WaitForSeconds(1.0f);
                    }                    
                }                
            }

            m_isFinishCreatingEnemy = true;
            yield return null;
        }

        private IEnumerator BattleFinishCheck()
        {
            var isBattle = true;

            while (isBattle)
            {
                if (m_isFinishCreatingPlayer && m_isFinishCreatingEnemy)
                {
                    var players = GameObject.FindGameObjectsWithTag("Player");
                    var enemies = GameObject.FindGameObjectsWithTag("Enemy");

                    if (players.Length <= 0)
                    {
                        MonoBehaviour.Destroy(m_battleData.Player.gameObject);
                        m_winner = E_Winner.Enemy;
                        m_isFinishBattle = true;
                        isBattle = false;
                        m_stageFieldManager.StartCoroutine(FinishBanner());
                    }
                    else if (enemies.Length <= 0)
                    {
                        MonoBehaviour.Destroy(m_battleData.Enemy.gameObject);
                        m_winner = E_Winner.Player;
                        m_isFinishBattle = true;
                        isBattle = false;
                        m_stageFieldManager.StartCoroutine(FinishBanner());
                    }
                }

                yield return null;
            }

            yield return null;
        }

        private IEnumerator FinishBanner()
        {
            

            yield return null;
        }
    }
}