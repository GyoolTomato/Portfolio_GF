using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Assets.Character;
using Assets.Character.Base;
using Assets.Common.DB.User;
using Assets.Common.DB.Index;

namespace Assets.Scene_StageField.Controller
{
    public class BattleFieldController
    {
        private StageFieldManager m_stageFieldManager;
        private GameObject m_battleFieldUI;
        private GameObject m_battleField;
        private GameObject m_boardUI;
        private GameObject m_board;
        private List<CharacterBase> m_players;
        private List<CharacterBase> m_enimies;

        public BattleFieldController()
        {
        }

        public void Initialize(StageFieldManager stageFieldManager)
        {
            m_stageFieldManager = stageFieldManager;
            var canvas = GameObject.Find("Canvas");
            m_battleFieldUI = canvas.transform.Find("BattleFieldUI").gameObject;
            m_battleField = GameObject.Find("BattleField");
            m_boardUI = canvas.transform.Find("BoardUI").gameObject;
            m_board = GameObject.Find("Board");
        }

        public void OpenBattleField(UserDataBase_Platoon playerPlatoon, UserDataBase_Platoon enemyPlatoon)
        {
            m_battleFieldUI.SetActive(true);
            m_battleField.SetActive(true);
            m_boardUI.SetActive(false);
            m_board.SetActive(false);

            m_stageFieldManager.StartCoroutine(CreatePlayer(playerPlatoon));
            m_stageFieldManager.StartCoroutine(CreateEnemy(enemyPlatoon));

            m_players = new List<CharacterBase>();
            m_enimies = new List<CharacterBase>();

            var tempPlayer = MonoBehaviour.Instantiate(CharacterObject.Healer(), new Vector3(-10, 0, 0), Quaternion.identity);
            var tempEnemy = MonoBehaviour.Instantiate(CharacterObject.Healer(), new Vector3(10, 0, 0), Quaternion.identity);
            var scriptPlayer = tempPlayer.GetComponent<CharacterBase>();
            var scriptEnemy = tempEnemy.GetComponent<CharacterBase>();

            scriptPlayer.Initialize(CharacterBase.E_Team.Player, new Assets.Common.DB.User.UserDataBase_TDoll());
            scriptEnemy.Initialize(CharacterBase.E_Team.Enemy, new Assets.Common.DB.User.UserDataBase_TDoll());
            tempPlayer.transform.parent = m_battleField.transform;
            tempEnemy.transform.parent = m_battleField.transform;

            m_players.Add(scriptPlayer);
            m_enimies.Add(scriptEnemy);
        }

        private void CloseBattleField()
        {
            m_battleFieldUI.SetActive(false);
            m_battleField.SetActive(false);
            m_boardUI.SetActive(true);
            m_board.SetActive(true);
        }

        private IEnumerator CreatePlayer(UserDataBase_Platoon playerPlatoon)
        {
            yield return null;
        }

        private IEnumerator CreateEnemy(UserDataBase_Platoon enemyPlatoon)
        {
            yield return null;
        }
    }
}